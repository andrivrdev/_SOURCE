using DevExpress.XtraEditors;
using QBook.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QBook
{
    public static class clsHelper
    {
        public const string DB_DIRECTORY = "Database";
        public static System.Data.SqlClient.SqlConnection zConn;

        public static bool CheckDB(string dbName, bool deleteIfExists = false)
        {
            try
            {
                string outputFolder = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), DB_DIRECTORY);
                string mdfFilename = dbName + ".mdf";
                string dbFileName = Path.Combine(outputFolder, mdfFilename);
                string logFileName = Path.Combine(outputFolder, String.Format("{0}_log.ldf", dbName));

                if (!Directory.Exists(outputFolder))
                {
                    Directory.CreateDirectory(outputFolder);
                }

                bool mustCreateTables = false;

                if (File.Exists(dbFileName) && deleteIfExists)
                {
                    mustCreateTables = true;
                }
                else if (!File.Exists(dbFileName))
                {
                    mustCreateTables = true;
                }

                return mustCreateTables;
            }
            catch
            {
                throw;
            }
        }

        public static bool GetLocalDB(string dbName, bool deleteIfExists = false)
        {
            try
            {
                string outputFolder = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), DB_DIRECTORY);
                string mdfFilename = dbName + ".mdf";
                string dbFileName = Path.Combine(outputFolder, mdfFilename);
                string logFileName = Path.Combine(outputFolder, String.Format("{0}_log.ldf", dbName));

                if (!Directory.Exists(outputFolder))
                {
                    Directory.CreateDirectory(outputFolder);
                }

                bool mustCreateTables = false;

                if (File.Exists(dbFileName) && deleteIfExists)
                {
                    if (File.Exists(logFileName)) File.Delete(logFileName);
                    File.Delete(dbFileName);
                    CreateDatabase(dbName, dbFileName);
                    mustCreateTables = true;
                }
                else if (!File.Exists(dbFileName))
                {
                    CreateDatabase(dbName, dbFileName);
                    mustCreateTables = true;
                }

                string connectionString = String.Format(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDBFileName={1};Initial Catalog={0};Integrated Security=True;", dbName, dbFileName);
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                if (mustCreateTables)
                {
                    using (connection)
                    {
                        SqlCommand cmd = connection.CreateCommand();

                        string sql =
                            @"
                            CREATE TABLE [dbo].[tblAccount] (
                              [ID] int IDENTITY(1, 1) NOT NULL,
                              [Name] varchar(50) COLLATE Latin1_General_CI_AS NOT NULL,
                              [IO] varchar(1) COLLATE Latin1_General_CI_AS NOT NULL,
                              CONSTRAINT [tblAccount_pk] PRIMARY KEY CLUSTERED ([ID]),
                              CONSTRAINT [tblAccount_uq] UNIQUE ([Name], [IO])
                            );

                            CREATE TABLE [dbo].[tblProperty] (
                              [ID] int IDENTITY(1, 1) NOT NULL,
                              [Property] varchar(200) COLLATE Latin1_General_CI_AS NOT NULL,
                              CONSTRAINT [PK_tblProperty] PRIMARY KEY CLUSTERED ([ID]),
                              CONSTRAINT [tblProperty_uq] UNIQUE ([Property])
                            );

                            CREATE TABLE [dbo].[tblPropertyAccount] (
                              [ID] int IDENTITY(1, 1) NOT NULL,
                              [tblPropertyID] int NOT NULL,
                              [tblAccountID] int NOT NULL,
                              CONSTRAINT [PK__tblPrope__3214EC27B0984859] PRIMARY KEY CLUSTERED ([ID]),
                              CONSTRAINT [tblPropertyAccount_fk] FOREIGN KEY ([tblPropertyID]) 
                              REFERENCES [dbo].[tblProperty] ([ID]) 
                              ON UPDATE NO ACTION
                              ON DELETE NO ACTION,
                              CONSTRAINT [tblPropertyAccount_fk2] FOREIGN KEY ([tblAccountID]) 
                              REFERENCES [dbo].[tblAccount] ([ID]) 
                              ON UPDATE NO ACTION
                              ON DELETE NO ACTION
                            );

                            CREATE UNIQUE NONCLUSTERED INDEX [tblPropertyAccount_uq] ON [dbo].[tblPropertyAccount]
                              ([tblPropertyID], [tblAccountID])
                            WITH (
                              PAD_INDEX = OFF,
                              IGNORE_DUP_KEY = OFF,
                              DROP_EXISTING = OFF,
                              STATISTICS_NORECOMPUTE = OFF,
                              SORT_IN_TEMPDB = OFF,
                              ONLINE = OFF,
                              ALLOW_ROW_LOCKS = ON,
                              ALLOW_PAGE_LOCKS = ON);

                            CREATE TABLE [dbo].[tblPropertyAccountTransaction] (
                              [ID] int IDENTITY(1, 1) NOT NULL,
                              [tblPropertyAccountID] int NOT NULL,
                              [DT] date NOT NULL,
                              [Reference] varchar(10) COLLATE Latin1_General_CI_AS NULL,
                              [Description] varchar(200) COLLATE Latin1_General_CI_AS NOT NULL,
                              [Amount] money NOT NULL,
                              CONSTRAINT [PK__tblPrope__3214EC27B39C3160] PRIMARY KEY CLUSTERED ([ID]),
                              CONSTRAINT [tblPropertyAccountTransaction_fk] FOREIGN KEY ([tblPropertyAccountID]) 
                              REFERENCES [dbo].[tblPropertyAccount] ([ID]) 
                              ON UPDATE NO ACTION
                              ON DELETE NO ACTION
                            );
                            ";

                        cmd.CommandText = sql;
                        cmd.ExecuteNonQuery();
                    }

                    ReInitDB(dbName, deleteIfExists);
                }
                else
                {
                    zConn = connection;
                }

                return mustCreateTables;
            }
            catch
            {
                throw;
            }
        }

        public static bool CreateDatabase(string dbName, string dbFileName)
        {
            try
            {
                string connectionString = String.Format(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;");
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = connection.CreateCommand();

                    DetachDatabase(dbName);

                    cmd.CommandText = String.Format("CREATE DATABASE {0} ON (NAME = N'{0}', FILENAME = '{1}')", dbName, dbFileName);
                    cmd.ExecuteNonQuery();
                }

                if (File.Exists(dbFileName)) return true;
                else return false;
            }
            catch
            {
                throw;
            }
        }

        public static bool DetachDatabase(string dbName)
        {
            try
            {
                string connectionString = String.Format(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True");
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = String.Format("exec sp_detach_db '{0}'", dbName);
                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public static void ReInitDB(string dbName, bool deleteIfExists = false)
        {
            try
            {
                string outputFolder = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), DB_DIRECTORY);
                string mdfFilename = dbName + ".mdf";
                string dbFileName = Path.Combine(outputFolder, mdfFilename);
                string logFileName = Path.Combine(outputFolder, String.Format("{0}_log.ldf", dbName));

                string connectionString = String.Format(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDBFileName={1};Initial Catalog={0};Integrated Security=True;", dbName, dbFileName);
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                zConn = connection;
            }
            catch
            {
                throw;
            }
        }

        public static bool InsertRec(string xTableName, List<string> xFields, List<string> xValues)
        {
            string SQL = "";

            try
            {
                //Build SQL
                SQL =
                "INSERT INTO [" + xTableName + "]" + Environment.NewLine +
                "(" + Environment.NewLine;

                //Fields
                for (int i = 0; i < xFields.Count; i++)
                {
                    SQL += "[" + xFields[i] + "]";

                    if (i + 1 != xFields.Count)
                    {
                        SQL += ",";
                    }

                    SQL += Environment.NewLine;
                }

                SQL +=
                    ")" + Environment.NewLine +
                    "values" + Environment.NewLine +
                    "(" + Environment.NewLine;

                //Values
                for (int i = 0; i < xValues.Count; i++)
                {
                    //If the value start with || then dont put the value in quotes

                    string tmpSQL = "";
                    if (xValues[i].Contains("'"))
                    {
                        tmpSQL = "'" + xValues[i].Replace("'", "''") + "'";
                    }
                    else
                    {
                        tmpSQL = "'" + xValues[i] + "'";
                    }

                    if (xValues[i].Length > 2)
                    {
                        if (xValues[i].Substring(0, 2) == "||")
                        {
                            xValues[i] = xValues[i].Substring(2);
                            tmpSQL = xValues[i];
                        }
                    }

                    SQL += tmpSQL;

                    if (i + 1 != xFields.Count)
                    {
                        SQL += ",";
                    }

                    SQL += Environment.NewLine;
                }

                SQL += ")";

                SqlCommand MyCommand = new SqlCommand(SQL, zConn);
                MyCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show("clsHelper: " + Ex.Message);
                return false;
            }
        }

        public static bool UpdateRec(string xTableName, List<string> xFields, List<string> xValues, string xWhere)
        {
            try
            {
                string SQL = "";

                //Build SQL
                SQL =
                "UPDATE [" + xTableName + "]" + Environment.NewLine +
                "SET" + Environment.NewLine;

                for (int i = 0; i < xFields.Count; i++)
                {
                    //Fix '
                    if (xValues[i].Contains("'"))
                    {
                        xValues[i] = xValues[i].Replace("'", "''");
                    }

                    //If the value start with || then dont put the value in quotes
                    string tmpSQL = "[" + xFields[i] + "] = '" + xValues[i] + "'";
                    if (xValues[i].Length > 2)
                    {
                        if (xValues[i].Substring(0, 2) == "||")
                        {
                            xValues[i] = xValues[i].Substring(2);

                            tmpSQL = "[" + xFields[i] + "] = " + xValues[i];
                        }
                    }

                    SQL += tmpSQL;
                    if (i + 1 != xFields.Count)
                    {
                        SQL += ",";
                    }

                    SQL += Environment.NewLine;
                }

                if (xWhere.Length > 0)
                {
                    SQL +=
                        "WHERE" + Environment.NewLine + xWhere;
                }

                SqlCommand MyCommand = new SqlCommand(SQL, zConn);
                MyCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show("clsHelper: " + Ex.Message);
                return false;
            }
        }

        public static bool DeleteRec(string xTableName, string xWhere)
        {
            try
            {
                string SQL = "";

                //Build SQL
                SQL =
                "DELETE FROM [" + xTableName + "]" + Environment.NewLine;

                if (xWhere.Length > 0)
                {
                    SQL += "WHERE" + Environment.NewLine + xWhere;
                }

                SqlCommand MyCommand = new SqlCommand(SQL, zConn);
                MyCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show("This record has other records linked to it," + Environment.NewLine +
                                    "and can not be removed until the linked records are" + Environment.NewLine +
                                    "removed first.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
        }

        public static void DeleteRecByID(string xTableName, int xID)
        {
            try
            {
                DeleteRec(xTableName, "[ID] = '" + xID + "'");
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show("clsHelper: " + Ex.Message);
            }
        }

        public static int GetLastRecID(string xTableName)
        {
            string SQL = "";

            try
            {
                SQL =
                "SELECT " + Environment.NewLine +
                "  MAX(" + xTableName + ".ID) AS LastRecID" + Environment.NewLine +
                "FROM" + Environment.NewLine +
                "  " + xTableName + "";

                SqlCommand MyCommand = new SqlCommand(SQL, clsHelper.zConn);
                SqlDataReader MyReader = MyCommand.ExecuteReader();

                DataTable dtLastRec = new DataTable();
                dtLastRec.Load(MyReader);

                MyCommand.Dispose();
                MyReader.Dispose();

                return Convert.ToInt32(dtLastRec.Rows[0]["LastRecID"].ToString());
            }
            catch (Exception Ex)
            {
                return -1;
            }
        }

        public static int FindAccountID(string xIO, string xAccountName)
        {
            //Find Account ID
            tblAccount xtblAccount = new tblAccount();
            int xAccountID = -1;
            var rows = xtblAccount.dtAccount.AsEnumerable().Where(r => (r.Field<string>("Name") == xAccountName) && (r.Field<string>("IO") == xIO));
            foreach (DataRow ARec in rows)
            {
                xAccountID = Convert.ToInt32(ARec["ID"]);
            }

            return xAccountID;
        }

        public static int FindPropertyID(string xProperty)
        {
            //Find Account ID
            tblProperty xtblProperty = new tblProperty();
            int xID = -1;
            var rows = xtblProperty.dtProperty.AsEnumerable().Where(r => (r.Field<string>("Property") == xProperty));
            foreach (DataRow ARec in rows)
            {
                xID = Convert.ToInt32(ARec["ID"]);
            }

            return xID;
        }

        public static int FindPropertyAccountID(string xIO, int xPropertyID, string xAccountName)
        {
            //Find Account ID
            int xAccountID = FindAccountID(xIO, xAccountName);

            //Find Property Account ID
            tblPropertyAccount xtblPropertyAccount = new tblPropertyAccount();
            int xPropertyAccountID = -1;
            var rows = xtblPropertyAccount.dtPropertyAccount.AsEnumerable().Where(r => (r.Field<int>("tblPropertyID") == xPropertyID) && (r.Field<int>("tblAccountID") == xAccountID));
            foreach (DataRow ARec in rows)
            {
                xPropertyAccountID = Convert.ToInt32(ARec["ID"]);
            }

            return xPropertyAccountID;
        }

        public static DataTable GetReferencesForMoneyOutTransaction(string xPropertyID)
        {
            string SQL = "";

            try
            {
                SQL =
                @"
                SELECT DISTINCT
                  dbo.tblPropertyAccountTransaction.Reference
                FROM
                  dbo.tblPropertyAccountTransaction
                  LEFT OUTER JOIN dbo.tblPropertyAccount ON (dbo.tblPropertyAccountTransaction.tblPropertyAccountID = dbo.tblPropertyAccount.ID)
                  LEFT OUTER JOIN dbo.tblAccount ON (dbo.tblPropertyAccount.tblAccountID = dbo.tblAccount.ID)
                WHERE
                  dbo.tblPropertyAccount.tblPropertyID = '" + xPropertyID + @"' AND
                  dbo.tblAccount.IO = 'I'
                ";

                SqlCommand MyCommand = new SqlCommand(SQL, clsHelper.zConn);
                SqlDataReader MyReader = MyCommand.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(MyReader);

                MyCommand.Dispose();
                MyReader.Dispose();

                return dt;
            }
            catch (Exception Ex)
            {
                return new DataTable();
            }
        }

    }
}
