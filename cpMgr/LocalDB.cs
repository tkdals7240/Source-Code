using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cpMgr
{
    public class StepTbl
    {
        public int _id { get; set; }
        public string gubun1 { get; set; }
        public string gubun2 { get; set; }
        public string device { get; set; }
        public string comment { get; set; }
    }

    public class AlarmTbl
    {
        public int _id { get; set; }
        public string Unit { get; set; }
        public bool Trigger { get; set; }
        public string Message { get; set; }
        public int Level { get; set; }
        public int GroupNo { get; set; }
        public int ScreenNo { get; set; }
        public string Detail { get; set; }
        public string Solution { get; set; }
    }

    public class IoTbl
    {
        public int _id { get; set; }
        public string gubun { get; set; }
        public string device { get; set; }
        public string comment { get; set; }
    }

    public class UserTbl
    {
        public int _id { get; set; }
        public string userid { get; set; }
        public string password { get; set; }
        public int level { get; set; }
    }

    static class LocalDB
    {
        public static LiteDatabase liteDB;
        static LocalDB()
        {
            liteDB = new LiteDatabase(GBL.dbName);
        }

        public static void Dispose()
        {
            liteDB.Dispose();
        }

        public static void Init()
        {
        }

        public static int CheckUser(string userID, string passWord)
        {
            // Master User
            if (userID == "FMStec" && passWord == "fmsTEC") return 2;

            // Select Table
            var userTable = liteDB.GetCollection<UserTbl>("UserTbl");
            var rstQry = userTable.Query()
                .Where(x => x.userid == userID)
                .ToList();

            // Check
            if (rstQry == null) return -1;
            if (rstQry.Count == 0) return -1;
            if (rstQry[0].password == passWord) return rstQry[0].level;

            return -1;
        }

        public static List<IoTbl> GetIoData(string gubun)
        {
            // Select Table
            var ioTable = liteDB.GetCollection<IoTbl>("IoTbl");
            var rstQry = ioTable.Query()
                .Where(x => x.gubun == gubun)
                .ToList();
            return rstQry;
        }
        public static List<StepTbl> GetStepData(string gubun1, string gubun2)
        {
            // Select Table
            var stepTbl = liteDB.GetCollection<StepTbl>("StepTbl");
            var rstQry = stepTbl.Query()
                .Where(x => x.gubun1 == gubun1 && x.gubun2 == gubun2)
                .ToList();
            return rstQry;
        }
        public static AlarmTbl GetAlarmText(int no)
        {
            // Select Table
            var almTbl = liteDB.GetCollection<AlarmTbl>("Alarm");
            var rstQry = almTbl.FindById(no);
            return rstQry;
        }
        public static IEnumerable<AlarmTbl> GetAlarmData()
        {
            // Select Table
            var almTbl = liteDB.GetCollection<AlarmTbl>("Alarm");
            var rstQry = almTbl.FindAll();
            return rstQry;
        }
    }
}
