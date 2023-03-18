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
    public class tblClientDetail
    {
        public DataTable dtClientDetail { get; set; }

        public tblClientDetail()
        {
            string SQL = "";

            try
            {
                SQL =
                "SELECT " + Environment.NewLine +
                "  tblClientDetail.ID," + Environment.NewLine +
                "  tblClientDetail.Name" + Environment.NewLine +
                "FROM" + Environment.NewLine +
                "  tblClientDetail";

                SQLiteCommand MyCommand = new SQLiteCommand(SQL, Shared.CLASSES.clsSQLiteDB.zConn);
                SQLiteDataReader MyReader = MyCommand.ExecuteReader();

                dtClientDetail = new DataTable();
                dtClientDetail.Load(MyReader);

                MyCommand.Dispose();
                MyReader.Dispose();
            }
            catch (Exception Ex)
            {
                clsSE.WriteLog(1, Ex.Message, "tblClientDetail", "tblClientDetail");
            }
        }
    }
}
