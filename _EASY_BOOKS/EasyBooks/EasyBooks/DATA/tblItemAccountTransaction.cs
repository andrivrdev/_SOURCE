using DevExpress.XtraEditors;
using EasyBooks.CLASSES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBooks.DATA
{
    public class tblItemAccountTransaction
    {
        public DataTable dtItemAccountTransaction { get; set; }
        public DataTable dtItemAccountTransactionMoneyIn { get; set; }
        public DataTable dtItemAccountTransactionMoneyOut { get; set; }

        public tblItemAccountTransaction()
        {
            string SQL = "";

            try
            {
                SQL =
                @"
                SELECT 
                  tblItemAccountTransaction.ID,
                  tblItemAccountTransaction.tblItemAccountID,
                  tblItemAccountTransaction.DT,
                  tblItemAccountTransaction.Reference,
                  tblItemAccountTransaction.Description,
                  tblItemAccountTransaction.Amount,
                  tblItemAccount.tblItemID,
                  tblItemAccount.tblAccountID,
                  tblItem.Item,
                  tblAccount.Name,
                  tblAccount.IO
                FROM
                  tblItemAccountTransaction
                  LEFT OUTER JOIN tblItemAccount ON (tblItemAccountTransaction.tblItemAccountID = tblItemAccount.ID)
                  LEFT OUTER JOIN tblAccount ON (tblItemAccount.tblAccountID = tblAccount.ID)
                  LEFT OUTER JOIN tblItem ON (tblItemAccount.tblItemID = tblItem.ID)
                ";

                SQLiteCommand MyCommand = new SQLiteCommand(SQL, clsSQLiteDB.zConn);
                SQLiteDataReader MyReader = MyCommand.ExecuteReader();

                dtItemAccountTransaction = new DataTable();
                dtItemAccountTransaction.Load(MyReader);

                SQL =
                @"
                SELECT 
                  tblItemAccountTransaction.ID,
                  tblItemAccountTransaction.tblItemAccountID,
                  tblItemAccountTransaction.DT,
                  tblItemAccountTransaction.Reference,
                  tblItemAccountTransaction.Description,
                  tblItemAccountTransaction.Amount,
                  tblItemAccount.tblItemID,
                  tblItemAccount.tblAccountID,
                  tblItem.Item,
                  tblAccount.Name,
                  tblAccount.IO
                FROM
                  tblItemAccountTransaction
                  LEFT OUTER JOIN tblItemAccount ON (tblItemAccountTransaction.tblItemAccountID = tblItemAccount.ID)
                  LEFT OUTER JOIN tblAccount ON (tblItemAccount.tblAccountID = tblAccount.ID)
                  LEFT OUTER JOIN tblItem ON (tblItemAccount.tblItemID = tblItem.ID)
                WHERE
                  tblAccount.IO = 'I'
                ";

                MyCommand = new SQLiteCommand(SQL, clsSQLiteDB.zConn);
                MyReader = MyCommand.ExecuteReader();

                dtItemAccountTransactionMoneyIn = new DataTable();
                dtItemAccountTransactionMoneyIn.Load(MyReader);

                SQL =
                @"
                SELECT 
                  tblItemAccountTransaction.ID,
                  tblItemAccountTransaction.tblItemAccountID,
                  tblItemAccountTransaction.DT,
                  tblItemAccountTransaction.Reference,
                  tblItemAccountTransaction.Description,
                  tblItemAccountTransaction.Amount,
                  tblItemAccount.tblItemID,
                  tblItemAccount.tblAccountID,
                  tblItem.Item,
                  tblAccount.Name,
                  tblAccount.IO
                FROM
                  tblItemAccountTransaction
                  LEFT OUTER JOIN tblItemAccount ON (tblItemAccountTransaction.tblItemAccountID = tblItemAccount.ID)
                  LEFT OUTER JOIN tblAccount ON (tblItemAccount.tblAccountID = tblAccount.ID)
                  LEFT OUTER JOIN tblItem ON (tblItemAccount.tblItemID = tblItem.ID)
                WHERE
                  tblAccount.IO = 'O'
                ";

                MyCommand = new SQLiteCommand(SQL, clsSQLiteDB.zConn);
                MyReader = MyCommand.ExecuteReader();

                dtItemAccountTransactionMoneyOut = new DataTable();
                dtItemAccountTransactionMoneyOut.Load(MyReader);

                MyCommand.Dispose();
                MyReader.Dispose();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show("tblItemAccountTransaction: " + Ex.Message);
            }
        }
    }
}
