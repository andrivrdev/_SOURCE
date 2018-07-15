using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QBook.Data
{
    public class tblPropertyAccountTransaction
    {
        public DataTable dtPropertyAccountTransaction { get; set; }
        public DataTable dtPropertyAccountTransactionMoneyIn { get; set; }
        public DataTable dtPropertyAccountTransactionMoneyOut { get; set; }

        public tblPropertyAccountTransaction()
        {
            string SQL = "";

            try
            {
                SQL =
                @"
                SELECT 
                  dbo.tblPropertyAccountTransaction.ID,
                  dbo.tblPropertyAccountTransaction.tblPropertyAccountID,
                  dbo.tblPropertyAccountTransaction.DT,
                  dbo.tblPropertyAccountTransaction.Reference,
                  dbo.tblPropertyAccountTransaction.Description,
                  dbo.tblPropertyAccountTransaction.Amount,
                  dbo.tblPropertyAccount.tblPropertyID,
                  dbo.tblPropertyAccount.tblAccountID,
                  dbo.tblProperty.Property,
                  dbo.tblAccount.Name,
                  dbo.tblAccount.IO
                FROM
                  dbo.tblPropertyAccountTransaction
                  LEFT OUTER JOIN dbo.tblPropertyAccount ON (dbo.tblPropertyAccountTransaction.tblPropertyAccountID = dbo.tblPropertyAccount.ID)
                  LEFT OUTER JOIN dbo.tblAccount ON (dbo.tblPropertyAccount.tblAccountID = dbo.tblAccount.ID)
                  LEFT OUTER JOIN dbo.tblProperty ON (dbo.tblPropertyAccount.tblPropertyID = dbo.tblProperty.ID)
                ";

                SqlCommand MyCommand = new SqlCommand(SQL, clsHelper.zConn);
                SqlDataReader MyReader = MyCommand.ExecuteReader();

                dtPropertyAccountTransaction = new DataTable();
                dtPropertyAccountTransaction.Load(MyReader);

                SQL =
                @"
                SELECT 
                  dbo.tblPropertyAccountTransaction.ID,
                  dbo.tblPropertyAccountTransaction.tblPropertyAccountID,
                  dbo.tblPropertyAccountTransaction.DT,
                  dbo.tblPropertyAccountTransaction.Reference,
                  dbo.tblPropertyAccountTransaction.Description,
                  dbo.tblPropertyAccountTransaction.Amount,
                  dbo.tblPropertyAccount.tblPropertyID,
                  dbo.tblPropertyAccount.tblAccountID,
                  dbo.tblProperty.Property,
                  dbo.tblAccount.Name,
                  dbo.tblAccount.IO
                FROM
                  dbo.tblPropertyAccountTransaction
                  LEFT OUTER JOIN dbo.tblPropertyAccount ON (dbo.tblPropertyAccountTransaction.tblPropertyAccountID = dbo.tblPropertyAccount.ID)
                  LEFT OUTER JOIN dbo.tblAccount ON (dbo.tblPropertyAccount.tblAccountID = dbo.tblAccount.ID)
                  LEFT OUTER JOIN dbo.tblProperty ON (dbo.tblPropertyAccount.tblPropertyID = dbo.tblProperty.ID)
                WHERE
                  dbo.tblAccount.IO = 'I'
                ";

                MyCommand = new SqlCommand(SQL, clsHelper.zConn);
                MyReader = MyCommand.ExecuteReader();

                dtPropertyAccountTransactionMoneyIn = new DataTable();
                dtPropertyAccountTransactionMoneyIn.Load(MyReader);

                SQL =
                @"
                SELECT 
                  dbo.tblPropertyAccountTransaction.ID,
                  dbo.tblPropertyAccountTransaction.tblPropertyAccountID,
                  dbo.tblPropertyAccountTransaction.DT,
                  dbo.tblPropertyAccountTransaction.Reference,
                  dbo.tblPropertyAccountTransaction.Description,
                  dbo.tblPropertyAccountTransaction.Amount,
                  dbo.tblPropertyAccount.tblPropertyID,
                  dbo.tblPropertyAccount.tblAccountID,
                  dbo.tblProperty.Property,
                  dbo.tblAccount.Name,
                  dbo.tblAccount.IO
                FROM
                  dbo.tblPropertyAccountTransaction
                  LEFT OUTER JOIN dbo.tblPropertyAccount ON (dbo.tblPropertyAccountTransaction.tblPropertyAccountID = dbo.tblPropertyAccount.ID)
                  LEFT OUTER JOIN dbo.tblAccount ON (dbo.tblPropertyAccount.tblAccountID = dbo.tblAccount.ID)
                  LEFT OUTER JOIN dbo.tblProperty ON (dbo.tblPropertyAccount.tblPropertyID = dbo.tblProperty.ID)
                WHERE
                  dbo.tblAccount.IO = 'O'
                ";

                MyCommand = new SqlCommand(SQL, clsHelper.zConn);
                MyReader = MyCommand.ExecuteReader();

                dtPropertyAccountTransactionMoneyOut = new DataTable();
                dtPropertyAccountTransactionMoneyOut.Load(MyReader);

                MyCommand.Dispose();
                MyReader.Dispose();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show("tblPropertyAccountTransaction: " + Ex.Message);
            }
        }
    }
}
