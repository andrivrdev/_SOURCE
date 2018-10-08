using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace SharedObjects.CLASSES
{
    public static class clsHelpers
    {
        public const string DB_DIRECTORY = "Database";

        public static System.Data.SqlClient.SqlConnection con;

        public static string GetRecsForExport()
        {
            try
            {
                DataTable table = new DataTable();

                SqlCommand cmd = new SqlCommand(
                    @"SELECT DISTINCT *
                    FROM
                    (
                    SELECT
                        (SELECT [dbo].[Client].IDX FROM [dbo].[Client] WHERE [dbo].[Client].IDX = [dbo].[ClientContact].[ClientIDX]) AS Client_IDX,
                        (SELECT [dbo].[Client].Name FROM [dbo].[Client] WHERE [dbo].[Client].IDX = [dbo].[ClientContact].[ClientIDX]) AS Client_Name,
                        (SELECT [dbo].[Client].Surname FROM [dbo].[Client] WHERE [dbo].[Client].IDX = [dbo].[ClientContact].[ClientIDX]) AS Client_Surname,
                        (SELECT IIF([dbo].[Client].Gender = '0', 'Female', 'Male') FROM [dbo].[Client] WHERE [dbo].[Client].IDX = [dbo].[ClientContact].[ClientIDX]) AS Client_Gender,
                        (SELECT [dbo].[Client].Age FROM [dbo].[Client] WHERE [dbo].[Client].IDX = [dbo].[ClientContact].[ClientIDX]) AS Client_Age,

                        [dbo].[ClientContact].IDX AS Contact_IDX,
                        (SELECT IIF([dbo].[ContactType].Type = '0', 'Number', 'Address') FROM [dbo].[ContactType] WHERE [dbo].[ContactType].IDX = [dbo].[ClientContact].[ContactTypeIDX]) AS Contact_Type,
                        (SELECT [dbo].[ContactType].Description FROM [dbo].[ContactType] WHERE [dbo].[ContactType].IDX = [dbo].[ClientContact].[ContactTypeIDX]) AS Contact_Description,
                        [dbo].[ClientContact].Contact AS Contact_Contact
                    FROM
                        [dbo].[ClientContact]

                    UNION
  
                    SELECT
                        [dbo].[Client].IDX AS Client_IDX,
                        [dbo].[Client].Name AS Client_Name,
                        [dbo].[Client].Surname AS Client_Surname,
                        IIF([dbo].[Client].Gender = '0', 'Female', 'Male') AS Client_Gender,
                        [dbo].[Client].Age AS Client_Age,
  
                        '' AS Contact_IDX,
                        '' AS Contact_Type,
                        '' AS Contact_Description,
                        '' AS Contact_Contact
                    FROM
                        [dbo].[Client]
                    WHERE
                        [dbo].[Client].IDX NOT IN (SELECT DISTINCT [dbo].[ClientContact].ClientIDX FROM [dbo].[ClientContact])
                    ) Z
                    WHERE
                        Z.Contact_Type <> 'Address' ORDER BY Client_IDX", con);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(table);

                return SerializeDT(table);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static string GetClientContactRecs(string myData)
        {
            try
            {
                string theData = myData;
                theData = theData.Substring(theData.IndexOf("|") + 1);
                string IDX = theData.Substring(0, theData.IndexOf("|"));

                DataTable table = new DataTable();

                SqlCommand cmd = new SqlCommand(
                @"SELECT 
                      dbo.ClientContact.IDX,
                      dbo.ClientContact.ClientIDX,
                      dbo.ClientContact.ContactTypeIDX,
                      (SELECT dbo.ContactType.Type FROM dbo.ContactType WHERE dbo.ClientContact.ContactTypeIDX = dbo.ContactType.IDX) AS Type,
                      (SELECT dbo.ContactType.Description FROM dbo.ContactType WHERE dbo.ClientContact.ContactTypeIDX = dbo.ContactType.IDX) AS Description,
                      dbo.ClientContact.Contact
                    FROM
                      dbo.ClientContact
                    WHERE
                       dbo.ClientContact.ClientIDX = '" + IDX + "'", con);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(table);

                return SerializeDT(table);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static string ClientContactRecsAdd(string myData)
        {
            try
            {
                string theData = myData;
                theData = theData.Substring(theData.IndexOf("|") + 1);
                string ClientIDX = theData.Substring(0, theData.IndexOf("|"));
                theData = theData.Substring(theData.IndexOf("|") + 1);
                string ContactTypeIDX = theData.Substring(0, theData.IndexOf("|"));
                theData = theData.Substring(theData.IndexOf("|") + 1);
                string Contact = theData.Substring(0, theData.IndexOf("|"));

                SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[ClientContact] ([ClientIDX], [ContactTypeIDX], [Contact]) VALUES ('" + ClientIDX + "', '" + ContactTypeIDX + "', '" + Contact + "')", con);
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("SELECT MAX(IDX) AS IDX FROM [ClientContact] ", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    return reader[0].ToString();
                }

                return "";
            }
            catch (Exception Ex)
            {
                throw;
            }
        }

        public static string ClientContactRecsEdit(string myData)
        {
            try
            {
                string theData = myData;
                theData = theData.Substring(theData.IndexOf("|") + 1);
                string IDX = theData.Substring(0, theData.IndexOf("|"));
                theData = theData.Substring(theData.IndexOf("|") + 1);
                string ClientIDX = theData.Substring(0, theData.IndexOf("|"));
                theData = theData.Substring(theData.IndexOf("|") + 1);
                string ContactTypeIDX = theData.Substring(0, theData.IndexOf("|"));
                theData = theData.Substring(theData.IndexOf("|") + 1);
                string Contact = theData.Substring(0, theData.IndexOf("|"));

                SqlCommand cmd = new SqlCommand("UPDATE [dbo].[ClientContact] SET [ClientIDX] = '" + ClientIDX + "', [ContactTypeIDX] = '" + ContactTypeIDX +
                    "', [Contact] = '" + Contact + "' WHERE [IDX] = '" + IDX + "'", con);
                cmd.ExecuteNonQuery();

                return "";
            }
            catch
            {
                throw;
            }
        }

        public static string ClientContactRecsRemove(string myData)
        {
            try
            {
                string theData = myData;
                theData = theData.Substring(theData.IndexOf("|") + 1);
                string IDX = theData.Substring(0, theData.IndexOf("|"));

                SqlCommand cmd = new SqlCommand("DELETE FROM [dbo].[ClientContact] WHERE [IDX] = '" + IDX + "'", con);
                cmd.ExecuteNonQuery();

                return "";
            }
            catch
            {
                throw;
            }
        }

        public static string GetAllClientRecs()
        {
            try
            {
                DataTable table = new DataTable();

                SqlCommand cmd = new SqlCommand("SELECT IDX, Name, Surname, IIF(Gender = '0', 'Female', 'Male') as Gender, Age FROM [Client]", con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(table);

                return SerializeDT(table);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static string ClientRecsAdd(string myData)
        {
            try
            {
                string theData = myData;
                theData = theData.Substring(theData.IndexOf("|") + 1);
                string Name = theData.Substring(0, theData.IndexOf("|"));
                theData = theData.Substring(theData.IndexOf("|") + 1);
                string Surname = theData.Substring(0, theData.IndexOf("|"));
                theData = theData.Substring(theData.IndexOf("|") + 1);
                string Gender = theData.Substring(0, theData.IndexOf("|"));
                theData = theData.Substring(theData.IndexOf("|") + 1);
                string Age = theData.Substring(0, theData.IndexOf("|"));

                SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[Client] ([Name], [Surname], [Gender], [Age]) VALUES ('" + Name + "', '" + Surname + "', '"  + Gender + "', '" + Age + "')", con);
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("SELECT MAX(IDX) AS IDX FROM [Client] ", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    return reader[0].ToString();
                }

                return "";
            }
            catch
            {
                throw;
            }
        }

        public static string ClientRecsEdit(string myData)
        {
            try
            {
                string theData = myData;
                theData = theData.Substring(theData.IndexOf("|") + 1);
                string IDX = theData.Substring(0, theData.IndexOf("|"));
                theData = theData.Substring(theData.IndexOf("|") + 1);
                string Name = theData.Substring(0, theData.IndexOf("|"));
                theData = theData.Substring(theData.IndexOf("|") + 1);
                string Surname = theData.Substring(0, theData.IndexOf("|"));
                theData = theData.Substring(theData.IndexOf("|") + 1);
                string Gender = theData.Substring(0, theData.IndexOf("|"));
                theData = theData.Substring(theData.IndexOf("|") + 1);
                string Age = theData.Substring(0, theData.IndexOf("|"));

                SqlCommand cmd = new SqlCommand("UPDATE [dbo].[Client] SET [Name] = '" + Name + "', [Surname] = '" + Surname +
                    "', [Gender] = '" + Gender + "', [Age] = '" + Age + "' WHERE [IDX] = '" + IDX + "'", con);
                cmd.ExecuteNonQuery();

                return "";
            }
            catch
            {
                throw;
            }
        }

        public static string ClientRecsRemove(string myData)
        {
            try
            {
                string theData = myData;
                theData = theData.Substring(theData.IndexOf("|") + 1);
                string IDX = theData.Substring(0, theData.IndexOf("|"));

                SqlCommand cmd = new SqlCommand("DELETE FROM [dbo].[Client] WHERE [IDX] = '" + IDX + "'", con);
                cmd.ExecuteNonQuery();

                return "";
            }
            catch
            {
                throw;
            }
        }

        public static string GetAllContactTypeRecs()
        {
            try
            {
                DataTable table = new DataTable();

                SqlCommand cmd = new SqlCommand("SELECT IDX, IIF(Type = '0', 'Number', 'Address') as Type, Description FROM [ContactType]", con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(table);

                return SerializeDT(table);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static string ContactTypeRecsAdd(string myData)
        {
            try
            {
                string theData = myData;
                theData = theData.Substring(theData.IndexOf("|") + 1);
                string Type = theData.Substring(0, theData.IndexOf("|"));
                theData = theData.Substring(theData.IndexOf("|") + 1);
                string Description = theData.Substring(0, theData.IndexOf("|"));

                SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[ContactType] ([Type], [Description]) VALUES ('" + Type + "', '" + Description + "')", con);
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("SELECT MAX(IDX) AS IDX FROM [ContactType] ", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    return reader[0].ToString();
                }

                return "";
            }
            catch
            {
                throw;
            }
        }

        public static string ContactTypeRecsEdit(string myData)
        {
            try
            {
                string theData = myData;
                theData = theData.Substring(theData.IndexOf("|") + 1);
                string IDX = theData.Substring(0, theData.IndexOf("|"));
                theData = theData.Substring(theData.IndexOf("|") + 1);
                string Type = theData.Substring(0, theData.IndexOf("|"));
                theData = theData.Substring(theData.IndexOf("|") + 1);
                string Description = theData.Substring(0, theData.IndexOf("|"));

                SqlCommand cmd = new SqlCommand("UPDATE [dbo].[ContactType] SET [Type] = '" + Type + "', [Description] = '" + Description + "' WHERE [IDX] = '" + IDX + "'", con);
                cmd.ExecuteNonQuery();

                return "";
            }
            catch
            {
                throw;
            }
        }

        public static string ContactTypeRecsRemove(string myData)
        {
            try
            {
                string theData = myData;
                theData = theData.Substring(theData.IndexOf("|") + 1);
                string IDX = theData.Substring(0, theData.IndexOf("|"));

                SqlCommand cmd = new SqlCommand("DELETE FROM [dbo].[ContactType] WHERE [IDX] = '" + IDX + "'", con);
                cmd.ExecuteNonQuery();

                return "";
            }
            catch
            {
                throw;
            }
        }

        public static string SerializeDT(DataTable table)
        {
            try
            {
                DataSet ds = new DataSet();
                ds.Tables.Add(table);

                string xml = "";

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (TextWriter streamWriter = new StreamWriter(memoryStream))
                    {
                        XmlSerializer xmlSerializer = new XmlSerializer(typeof(DataSet));
                        xmlSerializer.Serialize(streamWriter, ds);
                        xml = Encoding.UTF8.GetString(memoryStream.ToArray());
                    }
                }

                return xml;
            }
            catch
            {
                throw;
            }
        }

        public static DataTable DeSerializeToDT(string theData)
        {
            var dataSet = new DataSet();
            byte[] byteArray = Encoding.UTF8.GetBytes(theData);
            MemoryStream stream = new MemoryStream(byteArray);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(DataSet));
            dataSet = (DataSet)xmlSerializer.Deserialize(stream);

            try
            {
                return (DataTable)(dataSet.Tables[0].Copy());
            }
            catch
            {
                return null;
            }
        }

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
                            CREATE TABLE [dbo].[Client]
                            (
	                            [IDX] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
                                [Name] VARCHAR(50) NOT NULL, 
                                [Surname] VARCHAR(50) NOT NULL, 
                                [Gender] TINYINT NOT NULL, 
                                [Age] INT NOT NULL
                            );

                            CREATE TABLE [dbo].[ContactType]
                            (
	                            [IDX] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
                                [Type] TINYINT NOT NULL, 
                                [Description] VARCHAR(50) NOT NULL
                            );

                            CREATE UNIQUE INDEX [IX_ContactType_Type_Description] ON [dbo].[ContactType] ([Type], [Description]);

                            CREATE TABLE [dbo].[ClientContact]
                            (
	                            [IDX] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
                                [ClientIDX] INT NOT NULL, 
                                [ContactTypeIDX] INT NOT NULL, 
                                [Contact] VARCHAR(200) NULL, 
                                CONSTRAINT [FK_ClientContact_ClientIDX] FOREIGN KEY ([ClientIDX]) REFERENCES [Client]([IDX]),
                                CONSTRAINT [FK_ClientContact_ContactTypeIDX] FOREIGN KEY ([ContactTypeIDX]) REFERENCES [ContactType]([IDX])
                            );

                            CREATE UNIQUE INDEX [IX_Table_ClientIDX_ContactTypeIDX] ON [dbo].[ClientContact] ([ClientIDX], [ContactTypeIDX]);

                            INSERT INTO [dbo].[ContactType] ([Type], [Description]) VALUES ('0', 'Home Phone');
                            INSERT INTO [dbo].[ContactType] ([Type], [Description]) VALUES ('0', 'Work Phone');
                            INSERT INTO [dbo].[ContactType] ([Type], [Description]) VALUES ('0', 'Cell Number');
                            INSERT INTO [dbo].[ContactType] ([Type], [Description]) VALUES ('1', 'Home Address');
                            INSERT INTO [dbo].[ContactType] ([Type], [Description]) VALUES ('1', 'Work Address');
                            ";

                        cmd.CommandText = sql;
                        cmd.ExecuteNonQuery();

                        /*
                        for (int i = 0; i < 100000; i++)
                        {
                            sql = "INSERT INTO [dbo].[Client] ([Name], [Surname], [Gender], [Age]) VALUES ('" + i.ToString() + "', '" + i.ToString() + "', '0', '" + i.ToString() + "');";
                            cmd.CommandText = sql;
                            cmd.ExecuteNonQuery();
                        }
                        */

                    }

                    ReInitDB(dbName, deleteIfExists);
                }
                else
                {
                    con = connection;
                }

                return mustCreateTables;
            }
            catch
            {
                throw;
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

                con = connection;
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

        public static DataGridView FixCols(DataGridView theGrid)
        {
            DataGridView tmpGrid = new DataGridView();
            tmpGrid = theGrid;

            for (int i = 0; i < tmpGrid.ColumnCount; i++)
            {
                if ((tmpGrid.Columns[i].HeaderText == "IDX"))
                {
                    tmpGrid.Columns[i].Visible = false;
                }
            }

            return tmpGrid;
        }

        public static void ExportToCSV(DataTable xDTData)
        {
            //Build the file from data using DataMap
            List<string> xLines = new List<string>();
            string xALine = "";
            int C1 = 0;

            //Add columns line
            foreach (DataColumn AField in xDTData.Columns)
            {
                if (C1 < xDTData.Columns.Count - 1)
                {
                        xALine = xALine + xDTData.Columns[C1].ColumnName.ToString() + ",";
                }
                else
                {
                        xALine = xALine + xDTData.Columns[C1].ColumnName.ToString();
                }
                C1++;
            }
            xLines.Add(xALine);

            //Add record lines
            foreach (DataRow xARec in xDTData.Rows)
            {
                xALine = "";
                C1 = 0;
                foreach (DataColumn AField in xDTData.Columns)
                {
                        if (C1 < xDTData.Columns.Count - 1)
                        {
                            xALine = xALine + xARec[C1].ToString() + ",";
                        }
                        else
                        {
                            xALine = xALine + xARec[C1].ToString();
                        }
                    C1++;
                }
                xLines.Add(xALine);
            }

            //Write the file
            StreamWriter xCSV = new StreamWriter(Application.StartupPath + "\\CSVData.csv", false, Encoding.Unicode);
            for (int i = 0; i < xLines.Count; i++)
            {
                xCSV.WriteLine(xLines[i]);
            }
            xCSV.Close();
        }
    }
}
