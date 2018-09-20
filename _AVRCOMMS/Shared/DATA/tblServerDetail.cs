using Shared.CLASSES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DATA
{
    public class tblServerDetail
    {
        public DataTable dtServerDetail { get; set; }

        public tblServerDetail()
        {
            string SQL = "";

            try
            {
                SQL =
                "SELECT " + Environment.NewLine +
                "  tblServerDetail.ID," + Environment.NewLine +
                "  tblServerDetail.Name" + Environment.NewLine +
                "FROM" + Environment.NewLine +
                "  tblServerDetail";

                SQLiteCommand MyCommand = new SQLiteCommand(SQL, Shared.CLASSES.clsSQLiteDB.zConn);
                SQLiteDataReader MyReader = MyCommand.ExecuteReader();

                dtServerDetail = new DataTable();
                dtServerDetail.Load(MyReader);

                MyCommand.Dispose();
                MyReader.Dispose();
            }
            catch (Exception Ex)
            {
                clsSE.WriteLog(1, Ex.Message, "tblServerDetail", "tblServerDetail");
            }
        }

    }
}
