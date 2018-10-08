using DevExpress.XtraEditors;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Shared.CLASSES
{
    public static class clsSE
    {
        // ----- SQL LITE DB -----
        public static bool sqliteInsertRec(string xTableName, List<string> xFields, List<string> xValues)
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

                SQLiteCommand MyCommand = new SQLiteCommand(SQL, clsSQLiteDB.zConn);
                MyCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception Ex)
            {
                WriteLog(1, Ex.Message, "clsSE", "sqliteInsertRec");
                return false;
            }
        }

        public static bool sqliteUpdateRec(string xTableName, List<string> xFields, List<string> xValues, string xWhere)
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

                SQLiteCommand MyCommand = new SQLiteCommand(SQL, clsSQLiteDB.zConn);
                MyCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception Ex)
            {
                WriteLog(1, Ex.Message, "clsSE", "sqliteUpdateRec");
                return false;
            }
        }

        public static bool sqliteDeleteRec(string xTableName, string xWhere)
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

                SQLiteCommand MyCommand = new SQLiteCommand(SQL, clsSQLiteDB.zConn);
                MyCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception Ex)
            {
                WriteLog(1, Ex.Message, "clsSE", "sqliteDeleteRec");

                return false;
            }
        }

        public static void sqliteDeleteRecByID(string xTableName, Int64 xID)
        {
            try
            {
                sqliteDeleteRec(xTableName, "[ID] = '" + xID + "'");
            }
            catch (Exception Ex)
            {
                WriteLog(1, Ex.Message, "clsSE", "sqliteDeleteRecByID");
            }
        }

        public static Int64 sqliteGetLastRecID(string xTableName)
        {
            string SQL = "";

            try
            {
                SQL =
                "SELECT " + Environment.NewLine +
                "  MAX(" + xTableName + ".ID) AS LastRecID" + Environment.NewLine +
                "FROM" + Environment.NewLine +
                "  " + xTableName + "";

                SQLiteCommand MyCommand = new SQLiteCommand(SQL, clsSQLiteDB.zConn);
                SQLiteDataReader MyReader = MyCommand.ExecuteReader();

                DataTable dtLastRec = new DataTable();
                dtLastRec.Load(MyReader);

                MyCommand.Dispose();
                MyReader.Dispose();

                return Convert.ToInt64(dtLastRec.Rows[0]["LastRecID"].ToString());
            }
            catch (Exception Ex)
            {
                WriteLog(1, Ex.Message, "clsSE", "sqliteGetLastRecID");
                return -1;
            }
        }

        public static string Pack(string xCommand, DataTable xDT)
        {
            try
            {
                string JSONresult;
                JSONresult = JsonConvert.SerializeObject(xDT);

                JSONresult = xCommand + "||||/|" + JSONresult;

                return Encrypt(JSONresult);
            }
            catch (Exception Ex)
            {
                WriteLog(1, Ex.Message, "clsSE", "Pack");
                return "";
            }
        }



        public static string Encrypt(string plainText)
        {
            try
            {
                byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

                byte[] keyBytes = new Rfc2898DeriveBytes(clsGlobal.gPasswordHash, Encoding.ASCII.GetBytes(clsGlobal.gSaltKey)).GetBytes(256 / 8);
                var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.Zeros };
                var encryptor = symmetricKey.CreateEncryptor(keyBytes, Encoding.ASCII.GetBytes(clsGlobal.gVIKey));

                byte[] cipherTextBytes;

                using (var memoryStream = new MemoryStream())
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                        cryptoStream.FlushFinalBlock();
                        cipherTextBytes = memoryStream.ToArray();
                        cryptoStream.Close();
                    }
                    memoryStream.Close();
                }
                return Convert.ToBase64String(cipherTextBytes);
            }
            catch (Exception Ex)
            {
                WriteLog(1, Ex.Message, "clsSE", "Encrypt");
                return "";
            }
        }

        public static string Decrypt(string encryptedText)
        {
            try
            {
                byte[] cipherTextBytes = Convert.FromBase64String(encryptedText);
                byte[] keyBytes = new Rfc2898DeriveBytes(clsGlobal.gPasswordHash, Encoding.ASCII.GetBytes(clsGlobal.gSaltKey)).GetBytes(256 / 8);
                var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.None };

                var decryptor = symmetricKey.CreateDecryptor(keyBytes, Encoding.ASCII.GetBytes(clsGlobal.gVIKey));
                var memoryStream = new MemoryStream(cipherTextBytes);
                var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
                byte[] plainTextBytes = new byte[cipherTextBytes.Length];

                int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                memoryStream.Close();
                cryptoStream.Close();
                return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount).TrimEnd("\0".ToCharArray());
            }
            catch (Exception Ex)
            {
                WriteLog(1, Ex.Message, "clsSE", "Decrypt");
                return "";
            }
        }

        public static void WriteLog(int xType /* 0: Normal 1:Error 2:Warning 3:Verbose*/ , string xMessage, string xForm, string xMethod)
        {
            try
            {
                if (clsGlobal.gDebugLog)
                {
                    List<string> fFields = new List<string>();
                    List<string> vValues = new List<string>();

                    fFields.Add("DT");
                    fFields.Add("Type");
                    fFields.Add("Form");
                    fFields.Add("Method");
                    fFields.Add("Message");

                    vValues.Add(DateTime.Now.Year.ToString() + "/" +
                                                              DateTime.Now.Month.ToString() + "/" +
                                                              DateTime.Now.Day.ToString() + " " +
                                                              DateTime.Now.Hour.ToString() + ":" +
                                                              DateTime.Now.Minute.ToString() + ":" +
                                                              DateTime.Now.Second.ToString() + ":" +
                                                              DateTime.Now.Millisecond.ToString());
                    vValues.Add(xType.ToString());
                    vValues.Add(xForm);
                    vValues.Add(xMethod);
                    vValues.Add(xMessage);

                    clsSE.sqliteInsertRec("tblLog", fFields, vValues);
                }
            }
            catch 
            {
            }
        }

    }
}
