using FmsTec.Util;
using LiteDB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace cpMgr
{
    public class AlarmInfo
    {
        public DateTime dt;
        public int no;
        public string unit;
        public int trigger;
        public string message;
        public int level;
        public int group;
        public int screen;
    }
    public class AlarmInfo2
    {
        public DateTime dt;
        public int no;
    }
    public static class GBL
    {
        public static int userLevel = 0;
        public static string userID = "";
        public static string passWord = "";
        public static int logoutTime = 30;
        public static bool wndMax = false;              //window창 최대화안함
        public static string activeScreen = "";
        public static int operatorScreenActive = 0;
        public static int AlarmCount = 0;
        public static int AlarmUpdate = 0;
        public static List<AlarmInfo> AlarmList = new List<AlarmInfo>();
        public static List<AlarmInfo2> AlarmHistory = new List<AlarmInfo2>();
        public static string dbName = @"cpMgr.db";
        public static string[] cstID = new string[5];

        static GBL()
        {
            ReadConfig();
            LocalDB.Init();
            Alarm_Load();
        }
        public static void Init()
        {
        }

        public static void Close()
        {
            LocalDB.Dispose();
            MELSEC.Close();
        }

        static void ReadConfig()
        {
            try
            {
                // Config Read
                IniFile inifile = new IniFile();
                userID = inifile.ReadStr("Common", "UserID", "BOE12");
                passWord = inifile.ReadStr("Common", "Password", "");
                logoutTime = inifile.ReadInt("Common", "LogoutTime", 30);
                string tempStr = inifile.ReadStr("Window", "Maximize", "False");
                wndMax = tempStr.ToLower() == "true";
            }
            catch
            {
                Console.WriteLine("Post Config Read Exception.");
            }
        }

        static bool Alarm_Load()
        {
            try
            {
                var rstQry = LocalDB.GetAlarmData();            //LiteDB안에 AlarmData가져오는 쿼리문
                foreach (var item in rstQry)
                {
                    AlarmInfo ad = new AlarmInfo();
                    {
                        ad.no = item._id;
                        ad.unit = item.Unit;
                        ad.trigger = item.Trigger ? 1 : 0;
                        ad.message = item.Message;
                        ad.level = item.Level;
                        ad.group = item.GroupNo;
                        ad.screen = item.ScreenNo;
                    }
                    AlarmList.Add(ad);
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
