using ACTMULTILib;
using ActProgTypeLib;
using FmsTec.Util;
using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace cpMgr
{
    public interface MELSEC_INTERFACE
    {
        bool Connected { get; set; }
        int Open();
        int ReadDeviceBlock(string srtDev, int devLen, out int datBuf);
        int WriteDeviceBlock(string devID, int datLen, ref int datBuf);
        int ReadDeviceRandom(string devList, int devLen, out int datBuf);
        int GetDevice(string devID, out int data);
        int SetDevice(string devID, int data);
        int Close();
    }

    public static class MELSEC
    {
        public static bool Connected = false;
        public static MELSEC_INTERFACE plcIF;
        public static bool Simulation;
        public static string HostAddress;

        // Private
        public static bool thread_run { get; set; } = true;
        private static Thread connectThread = null;
        private static readonly ILog _Log = LogManager.GetLogger("MELSEC");
        private static BlockReadClass blockRead = new BlockReadClass("M12000", 500);

        static MELSEC()
        {
            // Read config
            ReadConfig();

            // Data Read Thread Start
            thread_run = true;
            connectThread = new Thread(ConnectThread);
            connectThread.Name = "Data Read Thread";
            connectThread.Start();
            _Log.Info("Thread Run(Data Read Thread)");
        }

        static void ReadConfig()
        {
            try
            {
                // Config Read
                IniFile inifile = new IniFile();
                string tempStr = inifile.ReadStr("PLC", "Simulation", "False");
                Simulation = tempStr.ToLower() == "true";
                HostAddress = inifile.ReadStr("PLC", "IP_Address", "192.168.3.39");
                GBL.cstID[0] = inifile.ReadStr("M-DMS", "CSTID1", "");
                GBL.cstID[1] = inifile.ReadStr("M-DMS", "CSTID2", "");
                GBL.cstID[2] = inifile.ReadStr("M-DMS", "CSTID3", "");
                GBL.cstID[3] = inifile.ReadStr("M-DMS", "CSTID4", "");
                GBL.cstID[4] = inifile.ReadStr("M-DMS", "CSTID5", "");
            }
            catch
            {
                Console.WriteLine("Post Config Read Exception.");
            }
        }

        private static void ConnectThread()
        {
            // Delay
            Thread.Sleep(10);

            // PLC Connect Loop
            while (thread_run)
            {
                // Create Network
                if (Simulation)
                    plcIF = new MELSEC1("0");
                else
                    plcIF = new MELSEC2(HostAddress);

                // Network Open
                if (plcIF.Open() != 0)
                {
                    Thread.Sleep(5000);
                    _Log.Error("PLC Connect Error.");
                    continue;
                }
                Connected = true;
                _Log.Info("PLC Connected.");

                int chkCount1 = 0;
                while(Connected)
                {
                    chkCount1++;
                    if (chkCount1 >= 10)
                    {
                        chkCount1 = 0;
                        if (AlarmCheck() == false)
                        {
                            _Log.Error("Function Error ->DataRead()");
                            Connected = false;
                            break;
                        }
                    }

                    // Check Connect
                    Thread.Sleep(100);
                }
                _Log.Info("PLC Disconnected.");
                Thread.Sleep(5000);
            }
            plcIF.Close();
        }

        static bool AlarmCheck()
        {
            if (!blockRead.DataRead())
            {
                _Log.Error("Function Error ->DataRead()");
                return false;
            }

            bool changeAlarm = false;
            int alarmCount = 0;
            for(int i=0; i< GBL.AlarmList.Count; i++)
            {
                var item = GBL.AlarmList[i];
                int almOn = blockRead.GetData(item.unit);
                if (almOn == 0)
                {
                    if (item.dt != DateTime.MinValue)
                    {
                        item.dt = DateTime.MinValue;
                        changeAlarm = true;
                    }
                }
                else
                {
                    if (item.dt == DateTime.MinValue)
                    {
                        item.dt = DateTime.Now;
                        changeAlarm = true;
                        AlarmHistroy(i);
                    }
                    alarmCount++;
                }
            }
            GBL.AlarmCount = alarmCount;
            if (changeAlarm) GBL.AlarmUpdate++;
            return true;
        }
        
        public static void AlarmHistroy(int n)
        {
            var item1 = GBL.AlarmList[n];
            var item2 = new AlarmInfo2();
            item2.no = n;
            item2.dt = item1.dt;
            GBL.AlarmHistory.Add(item2);
            AlarmLog(n);
        }
        static StreamWriter _fw = null;
        static string _saveTime = "";
        private static void AlarmLog(int n)
        {
            var item = GBL.AlarmList[n];

            // Get File Name
            string postTime = item.dt.ToString("yyyyMMdd");
            if (postTime != _saveTime)
            {
                _saveTime = postTime;
                if (_fw != null)
                {
                    _fw.Close();
                    _fw = null;
                }
            }
            string fn = ".\\Log\\Alarm_" + postTime + ".Log";

            // File Open
            if (_fw == null)
            {
                try
                {
                    FileStream fs = File.Open(fn, FileMode.Append, FileAccess.Write, FileShare.Read);
                    _fw = new StreamWriter(fs);
                    if (_fw == null)
                    {
                        Console.WriteLine("Data Log File Open Errror. :" + fn);
                        return;
                    }

                    // Head Write
                    if (fs.Length == 0)
                    {
                        string s = "AlarmTime,AlarmNo,AlarmType,AlarmMessage";
                        _fw.WriteLine(s);
                    }
                }
                catch (Exception e)
                {
                    _fw = null;
                    Console.WriteLine("Data Log File Open Errror. :" + e.Message);
                    return;
                }
            }

            // Write Data
            try
            {
                string s = "";
                s = item.dt.ToString("yyyy-MM-dd HH:mm:ss");
                s += "," + item.trigger.ToString();
                s += "," + item.message;
                _fw.WriteLine(s);
                _fw.Flush();
            }
            catch (Exception e)
            {
                Console.WriteLine("Data Log File Wrtie Errror. :" + e.Message);
            }
        }

        public static void SetPulse(string devAddr, int delayCount = 500)
        {
            if (!Connected) return;
            SetDevice(devAddr, 1);
            //delayOffTbl.Add(new DelayOffInfo(devAddr, delayCount));
            new System.Threading.Timer(Pulse_Timer, devAddr, delayCount, Timeout.Infinite);
        }
        public static void Pulse_Timer(Object devAddr)
        {
            SetDevice((string)devAddr, 0);
        }

        public static void SetInvert(string devAddr)
        {
            if (!Connected) return;
            int data;
            plcIF.GetDevice(devAddr, out data);
            data = data == 1 ? 0 : 1;
            SetDevice(devAddr, data);
        }

        public static int ReadDeviceBlock(string srtDev, int devLen, out int datBuf)
        {
            return plcIF.ReadDeviceBlock(srtDev, devLen, out datBuf);
        }
        public static int ReadDeviceRandom(string devList, int devLen, out int datBuf)
        {
            return plcIF.ReadDeviceRandom(devList, devLen, out datBuf);
        }
        public static int GetDevice(string devID, out int datBuf)
        {
            return plcIF.GetDevice(devID, out datBuf);
        }
        public static Func<string, int, int> SetDevice = delegate (string devID, int datBuf)
        {
            return plcIF.SetDevice(devID, datBuf);
        };

        public static int SetText(string devAddr, string datBuf, int datLen)
        {
            int putLen = (datLen + 1) / 2; 
            int[] putbuf = new int[putLen];
            Array.Clear(putbuf, 0, putLen);
            byte[] tmpbuf = Encoding.Default.GetBytes(datBuf);
            for (int i = 0; i < tmpbuf.Length; i++)
            {
                int n = i / 2;
                if ((i % 2) == 0)
                {
                    int tmpInt = tmpbuf[i + 1];
                    putbuf[n] = (tmpInt << 8) & 0xff00;
                }
                else
                {
                    int tmpInt = tmpbuf[i - 1];
                    putbuf[n] = putbuf[n] | tmpInt;
                }
            }
            return plcIF.WriteDeviceBlock(devAddr, putLen, ref putbuf[0]);
        }


        public static void Close()
        {
            plcIF.Close();
            thread_run = false;
            connectThread.Abort();
        }
    }

    // Simulator
    public class MELSEC1 : MELSEC_INTERFACE
    {
        public bool Connected { get; set; } = false;
        public ActEasyIF plcIF { get; } = new ActEasyIF();
        private static readonly ILog _Log = LogManager.GetLogger("MELSEC");
        int stationNumber = 0;

        public MELSEC1(string host)
        {
            stationNumber = int.Parse(host);
        }

        public int Open()
        {
            plcIF.ActLogicalStationNumber = stationNumber;
            return plcIF.Open();
        }
        public int ReadDeviceBlock(string srtDev, int devLen, out int datBuf)
        {
            return plcIF.ReadDeviceBlock(srtDev, devLen, out datBuf);
        }
        public int ReadDeviceRandom(string devList, int devLen, out int datBuf)
        {
            return plcIF.ReadDeviceRandom(devList, devLen, out datBuf);
        }
        public int GetDevice(string devID, out int datBuf)
        {
            return plcIF.GetDevice(devID, out datBuf);
        }
        public int SetDevice(string devID, int datBuf)
        {
            return plcIF.SetDevice(devID, datBuf);
        }
        public int WriteDeviceBlock(string devID, int datLen, ref int datBuf)
        {
            return plcIF.WriteDeviceBlock(devID, datLen, ref datBuf);
        }
        public int Close()
        {
            return plcIF.Close();
        }
    }

    // Ethernet
    public class MELSEC2 : MELSEC_INTERFACE
    {
        public bool Connected { get; set; } = false;

        private ActProgType plcIF { get; } = new ActProgType();
        private static readonly ILog _Log = LogManager.GetLogger("MELSEC");
        string hostAddress;

        public MELSEC2(string host)
        {
            hostAddress = host;
        }

        public int Open()
        {
            plcIF.ActCpuType = 211;                     // Cpu type : Q06UDVCPU
            plcIF.ActHostAddress = hostAddress;         // Host (IP Address)
            plcIF.ActDestinationPortNumber = 5007;      // DestinationPortNumber
            plcIF.ActProtocolType = 0x05;               // PROTOCOL_TCPIP(0x05)
            plcIF.ActUnitType = 0x2C;                   // UNIT_QNETHER(0x2C)
            return plcIF.Open();
        }
        public int ReadDeviceBlock(string srtDev, int devLen, out int datBuf)
        {
            return plcIF.ReadDeviceBlock(srtDev, devLen, out datBuf);
        }
        public int ReadDeviceRandom(string devList, int devLen, out int datBuf)
        {
            return plcIF.ReadDeviceRandom(devList, devLen, out datBuf);
        }
        public int GetDevice(string devID, out int datBuf)
        {
            return plcIF.GetDevice(devID, out datBuf);
        }
        public int SetDevice(string devID, int datBuf)
        {
            return plcIF.SetDevice(devID, datBuf);
        }
        public int WriteDeviceBlock(string devID, int datLen, ref int datBuf)
        {
            return plcIF.WriteDeviceBlock(devID, datLen, ref datBuf);
        }
        public int Close()
        {
            return plcIF.Close();
        }
    }

    public class RandomReadClass
    {
        int _datpnt = 0;
        int[] _data = new int[1000];
        private static readonly ILog _Log = LogManager.GetLogger("MELSEC");

        class randomReadInfo
        {
            public string _device;
            public int _valpnt;
            public randomReadInfo(string device)
            {
                _device = device;
                _valpnt = 0;
            }
        }
        Dictionary<string, int> randomReadList = new Dictionary<string, int>();

        public RandomReadClass()
        {
            // Reset PLC Memory
            Array.Clear(_data, 0, _data.Length);
        }

        public int GetData(string devAddr)
        {
            if (randomReadList.ContainsKey(devAddr))
                return _data[randomReadList[devAddr]];
            else
                lock (randomReadList)
                    randomReadList.Add(devAddr, _datpnt++);
            return 0;
        }
        public void AddDev(string devAddr)
        {
            if (!randomReadList.ContainsKey(devAddr))
            {
                lock (randomReadList)
                {
                    randomReadList.Add(devAddr, _datpnt++);
                }
            }
        }

        public bool DataRead()
        {
            if (!MELSEC.Connected) return false;
            if (randomReadList.Count == 0) return false;
            StringBuilder szDevices = new StringBuilder();
            lock (randomReadList)
            {
                //int[] data = new int[randomReadList.Count];
                int n = 0;
                foreach (string szDevice in randomReadList.Keys)
                {
                    szDevices.Append(szDevice);
                    if (++n < randomReadList.Count)
                        szDevices.Append("\n");
                }
                //szDevices.Remove(szDevices.Length - 2, 1);
                int retCode = MELSEC.plcIF.ReadDeviceRandom(szDevices.ToString(), randomReadList.Count, out _data[0]);
                if (retCode != 0)
                {
                    Console.WriteLine("Error ReadDeviceRandom({0}) ->0x{1:X8}", szDevices, retCode);
                    return false;
                }
            }
            return true;
        }
    }

    public class BlockReadClass
    {
        // Log
        private static readonly ILog _Log = LogManager.GetLogger("MELSEC");

        // Data
        int[] _data;
        string _srtAddr;
        int _offset = 0;
        string _devType;

        public BlockReadClass(string srtAddr, int regCount)
        {
            ChangeAddr(srtAddr, regCount);
        }

        public void ChangeAddr(string srtAddr, int regCount)
        {
            _srtAddr = srtAddr;
            _devType = srtAddr.Substring(0, 1);
            if (_devType == "B" || _devType == "X" || _devType == "Y")
                _offset = int.Parse(srtAddr.Substring(1, srtAddr.Length - 1), System.Globalization.NumberStyles.HexNumber);
            else
                _offset = int.Parse(srtAddr.Substring(1, srtAddr.Length - 1));
            _data = new int[regCount];

            // Reset PLC Memory
            Array.Clear(_data, 0, _data.Length);
        }

        public bool DataRead()
        {
            if (!MELSEC.Connected) return false;
            int retCode = MELSEC.plcIF.ReadDeviceBlock(_srtAddr, _data.Length, out _data[0]);
            if (retCode != 0)
            {
                Console.WriteLine("Error ReadDeviceBlock({0})->0x{1:X8}", _srtAddr, retCode);
                return false;
            }
            return true;
        }

        public int GetData(string devAddr)
        {
            string devID = devAddr.Substring(0, 1);
            string devNO = devAddr.Substring(1, devAddr.Length - 1);
            if (devID != _devType) return -1;

            try
            {
                    switch (devID)
                {
                    case "D":
                    case "R":
                        {
                            int addr0 = int.Parse(devNO) - _offset;
                            if (addr0 >= _data.Length)
                            {
                                Console.WriteLine("[{0}]Out of range.", devAddr);
                                return -1;
                            }
                            return _data[addr0];
                        }
                    case "M":
                    case "L":
                        {
                            int addr0 = int.Parse(devNO) - _offset;
                            int addr1 = addr0 / 16;
                            int addr2 = addr0 % 16;
                            if (addr1 >= _data.Length)
                            {
                                Console.WriteLine("[{0}]Out of range.", devAddr);
                                return -1;
                            }
                            return ((_data[addr1] >> addr2) & 0x01);
                        }
                    case "B":
                    case "X":
                    case "Y":
                        {
                            int addr0 = int.Parse(devNO, System.Globalization.NumberStyles.HexNumber) - _offset;
                            int addr1 = addr0 / 16;
                            int addr2 = addr0 % 16;
                            if (addr1 >= _data.Length)
                            {
                                Console.WriteLine("[{0}]Out of range.", devAddr);
                                return -1;
                            }
                            return ((_data[addr1] >> addr2) & 0x01);
                        }
                }
            }
            catch
            {
                Console.WriteLine("GetData:Address Error->{0}", devAddr);
            }
            return 0;
        }
        public int GetData2(string devAddr)
        {
            string devID = devAddr.Substring(0, 1);
            if (devID != "D") return -1;
            string devNO = devAddr.Substring(1, devAddr.Length - 1);
            int n = devNO.IndexOf('.');
            if (n == -1) return -1;
            string devNO1 = devNO.Substring(0, n);
            string devNO2 = devNO.Substring(n+2, 1);

            try
            {
                int addr0 = int.Parse(devNO1) - _offset;
                int addr1 = int.Parse(devNO2, System.Globalization.NumberStyles.HexNumber);

                if (addr0 >= _data.Length)
                {
                    Console.WriteLine("[{0}]Out of range.", devAddr);
                    return -1;
                }
                return ((_data[addr0] >> addr1) & 0x01);
            }
            catch
            {
                Console.WriteLine("GetData:Address Error->{0}", devAddr);
            }
            return 0;
        }

        public string GetText(string devAddr, int len)
        {
            string devID = devAddr.Substring(0, 1);
            string devNO = devAddr.Substring(1, devAddr.Length - 1);
            string retStr = "";
            len /= 2;
            switch (devID)
            {
                case "D":
                    {
                        int addr0 = int.Parse(devNO) - _offset;
                        for (int i = addr0; i < addr0 + len; i++)
                        {
                            retStr += Convert.ToChar(_data[i] & 0xFF);
                            retStr += Convert.ToChar(_data[i] >> 8 & 0xFF);
                        }
                        break;
                    }
            }
            return retStr;
        }
    }
}