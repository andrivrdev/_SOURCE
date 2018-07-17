using DevExpress.XtraEditors;
using EasyBooks.CLASSES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
                  dbo.tblItemAccountTransaction.ID,
                  dbo.tblItemAccountTransaction.tblItemAccountID,
                  dbo.tblItemAccountTransaction.DT,
                  dbo.tblItemAccountTransaction.Reference,
                  dbo.tblItemAccountTransaction.Description,
                  dbo.tblItemAccountTransaction.Amount,
                  dbo.tblItemAccount.tblItemID,
                  dbo.tblItemAccount.tblAccountID,
                  dbo.tblItem.Item,
                  dbo.tblAccount.Name,
                  dbo.tblAccount.IO
                FROM
                  dbo.tblItemAccountTransaction
                  LEFT OUTER JOIN dbo.tblItemAccount ON (dbo.tblItemAccountTransaction.tblItemAccountID = dbo.tblItemAccount.ID)
                  LEFT OUTER JOIN dbo.tblAccount ON (dbo.tblItemAccount.tblAccountID = dbo.tblAccount.ID)
                  LEFT OUTER JOIN dbo.tblItem ON (dbo.tblItemAccount.tblItemID = dbo.tblItem.ID)
                ";

                SqlCommand MyCommand = new SqlCommand(SQL, clsHelper.zConn);
                SqlDataReader MyReader = MyCommand.ExecuteReader();

                dtItemAccountTransaction = new DataTable();
                dtItemAccountTransaction.Load(MyReader);

                SQL =
                @"
                SELECT 
                  dbo.tblItemAccountTransaction.ID,
                  dbo.tblItemAccountTransaction.tblItemAccountID,
                  dbo.tblItemAccountTransaction.DT,
                  dbo.tblItemAccountTransaction.Reference,
                  dbo.tblItemAccountTransaction.Description,
                  dbo.tblItemAccountTransaction.Amount,
                  dbo.tblItemAccount.tblItemID,
                  dbo.tblItemAccount.tblAccountID,
                  dbo.tblItem.Item,
                  dbo.tblAccount.Name,
                  dbo.tblAccount.IO
                FROM
                  dbo.tblItemAccountTransaction
                  LEFT OUTER JOIN dbo.tblItemAccount ON (dbo.tblItemAccountTransaction.tblItemAccountID = dbo.tblItemAccount.ID)
                  LEFT OUTER JOIN dbo.tblAccount ON (dbo.tblItemAccount.tblAccountID = dbo.tblAccount.ID)
                  LEFT OUTER JOIN dbo.tblItem ON (dbo.tblItemAccount.tblItemID = dbo.tblItem.ID)
                WHERE
                  dbo.tblAccount.IO = 'I'
                ";

                MyCommand = new SqlCommand(SQL, clsHelper.zConn);
                MyReader = MyCommand.ExecuteReader();

                dtItemAccountTransactionMoneyIn = new DataTable();
                dtItemAccountTransactionMoneyIn.Load(MyReader);

                SQL =
                @"
                SELECT 
                  dbo.tblItemAccountTransaction.ID,
                  dbo.tblItemAccountTransaction.tblItemAccountID,
                  dbo.tblItemAccountTransaction.DT,
                  dbo.tblItemAccountTransaction.Reference,
                  dbo.tblItemAccountTransaction.Description,
                  dbo.tblItemAccountTransaction.Amount,
                  dbo.tblItemAccount.tblItemID,
                  dbo.tblItemAccount.tblAccountID,
                  dbo.tblItem.Item,
                  dbo.tblAccount.Name,
                  dbo.tblAccount.IO
                FROM
                  dbo.tblItemAccountTransaction
                  LEFT OUTER JOIN dbo.tblItemAccount ON (dbo.tblItemAccountTransaction.tblItemAccountID = dbo.tblItemAccount.ID)
                  LEFT OUTER JOIN dbo.tblAccount ON (dbo.tblItemAccount.tblAccountID = dbo.tblAccount.ID)
                  LEFT OUTER JOIN dbo.tblItem ON (dbo.tblItemAccount.tblItemID = dbo.tblItem.ID)
                WHERE
                  dbo.tblAccount.IO = 'O'
                ";

                MyCommand = new SqlCommand(SQL, clsHelper.zConn);
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
