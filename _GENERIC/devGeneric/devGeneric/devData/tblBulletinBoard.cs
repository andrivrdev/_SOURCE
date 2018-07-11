using devGeneric.devClasses.devDynamic;
using devGeneric.devClasses.devStatic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devGeneric.devData
{
    public class tblBulletinBoard
    {
        devSE SE;

        public int IDX { get; set; }
        public string DisplayText { get; set; }

        public string GetData()
        {
            string SQL = "";

            try
            {
                SE = new devSE();

                DataTable dtData;

                SQLiteConnection MyConn = new SQLiteConnection(@"Data Source=" + devGlobals.gDB);
                MyConn.Open();

                SQL =
                "SELECT" + Environment.NewLine +
                "  tblBulletinBoard.DisplayText" + Environment.NewLine +
                "FROM" + Environment.NewLine +
                "  tblBulletinBoard" + Environment.NewLine +
                "WHERE" + Environment.NewLine +
                "  tblBulletinBoard.IDX = " + Environment.NewLine +
                "  (    " + Environment.NewLine +
                "  SELECT " + Environment.NewLine +
                "    MAX(tblBulletinBoard.IDX)" + Environment.NewLine +
                "  FROM" + Environment.NewLine +
                "    tblBulletinBoard" + Environment.NewLine +
                "  )";

                SQLiteCommand MyCommand = new SQLiteCommand(SQL, MyConn);
                SQLiteDataReader MyReader = MyCommand.ExecuteReader();

                dtData = new DataTable();
                dtData.Load(MyReader);

                MyCommand.Dispose();
                MyReader.Dispose();

                //Populate class
                foreach (DataRow ARec in dtData.Rows)
                {
                    return ARec["DisplayText"].ToString();
                }

                return "";

            }
            catch (Exception Ex)
            {
                SE.WriteLog(Ex.Message + Environment.NewLine + "SQL: " + SQL, "tblBulletinBoard", "GetData");
                return "";
            }
        }
    }
}
