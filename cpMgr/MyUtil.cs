using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace FmsTec.Util
{
    static class MyUtil
    {
        [DllImport("user32")]
        public static extern IntPtr FindWindow(String lpClassName, String lpWindowName);
        [DllImport("user32")]
        public static extern Boolean ShowWindow(IntPtr hWnd, Int32 nCmdShow);
        [DllImport("User32")]
        private static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

        [StructLayout(LayoutKind.Sequential)]
        internal struct LASTINPUTINFO
        {
            public uint cbSize;
            public uint dwTime;
        }

        public static void ShowTouchKeyboard()
        {
            //Kill all on screen keyboards
            Process[] oskProcessArray = Process.GetProcessesByName("TabTip");
            foreach (Process onscreenProcess in oskProcessArray)
            {
                onscreenProcess.Kill();
            }

            // Run screen keyboard
            string progFiles = @"C:\Program Files\Common Files\Microsoft Shared\ink";
            string keyboardPath = Path.Combine(progFiles, "TabTip.exe");
            Process keyboardProc = Process.Start(keyboardPath);
        }

        public static int GetIdleTime()
        {
            var lastInputInfo = new LASTINPUTINFO();
            lastInputInfo.cbSize = (uint)Marshal.SizeOf(lastInputInfo);

            GetLastInputInfo(ref lastInputInfo);

            int lastInput = (int)((Environment.TickCount - lastInputInfo.dwTime) / 1000);
            return lastInput;
        }
    }

    class IniFile   // revision 11
    {
        string Path;
        string EXE = Assembly.GetExecutingAssembly().GetName().Name;

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern long WritePrivateProfileInt(string Section, string Key, int Value, string FilePath);

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern int GetPrivateProfileInt(string Section, string Key, int Default, string FilePath);

        public IniFile(string IniPath = null)
        {
            Path = new FileInfo(IniPath ?? EXE + ".ini").FullName;
        }

        public string Read(string Key, string Section = null)
        {
            var RetVal = new StringBuilder(255);
            GetPrivateProfileString(Section ?? EXE, Key, "", RetVal, 255, Path);
            return RetVal.ToString();
        }

        public string ReadStr(string Section, string Key, string Default = "")
        {
            var RetVal = new StringBuilder(255);
            GetPrivateProfileString(Section, Key, Default, RetVal, 255, Path);
            return RetVal.ToString();
        }

        public int ReadInt(string Section, string Key, int Default = 0)
        {
            int RetVal = GetPrivateProfileInt(Section, Key, Default, Path);
            return RetVal;
        }
        public double ReadDouble(string Section, string Key, double Default = 0)
        {
            var readBuf = new StringBuilder(255);
            var defStr = Default.ToString();
            GetPrivateProfileString(Section, Key, defStr, readBuf, 255, Path);
            double RetVal = double.Parse(readBuf.ToString());
            return RetVal;
        }

        public void Write(string Key, string Value, string Section = null)
        {
            WritePrivateProfileString(Section ?? EXE, Key, Value, Path);
        }

        public void WriteStr(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, Path);
        }

        public void DeleteKey(string Key, string Section = null)
        {
            Write(Key, null, Section ?? EXE);
        }

        public void DeleteSection(string Section = null)
        {
            Write(null, null, Section ?? EXE);
        }

        public bool KeyExists(string Key, string Section = null)
        {
            return ReadStr(Key, Section).Length > 0;
        }
    }

    class BinFile
    {
        FileStream _fileStream;
        byte[] _buff;

        public BinFile(string fileName, int recordSize)
        {
            _fileStream = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            _buff = new byte[recordSize];
        }
        ~BinFile()
        {
            _fileStream.Close();
        }

        public object Get(int recordNo)
        {
            try
            {
                int offset = recordNo * _buff.Length;
                _fileStream.Seek(offset, SeekOrigin.Begin);
                _fileStream.Read(_buff, 0, _buff.Length);
                return ByteArrayToObject(_buff);
            }
            catch
            {
                return null;
            }
        }

        public bool Put(int recordNo, Object obj)
        {
            try
            {
                // Make data
                byte[] tempBuff = ObjectToByteArray(obj);
                Array.Clear(_buff, 0, _buff.Length);
                tempBuff.CopyTo(_buff, 0);

                // Write
                int offset = recordNo * _buff.Length;
                _fileStream.Seek(offset, SeekOrigin.Begin);
                _fileStream.Write(_buff, 0, _buff.Length);

                return true;
            }
            catch
            {
                return false;
            }
        }

        // Convert an object to a byte array
        private byte[] ObjectToByteArray(Object obj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        // Convert a byte array to an Object
        private Object ByteArrayToObject(byte[] arrBytes)
        {
            using (var memStream = new MemoryStream())
            {
                var binForm = new BinaryFormatter();
                memStream.Write(arrBytes, 0, arrBytes.Length);
                memStream.Seek(0, SeekOrigin.Begin);
                var obj = binForm.Deserialize(memStream);
                return obj;
            }
        }
    }
}
