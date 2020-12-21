using Newtonsoft.Json;
using Shared.DATA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Shared.CLASSES
{
    public class clsSE
    {
        public bool sqlCheckIfDBExist(string xServer, string xDatabase, string xUserID, string xPassword)
        {
            try
            {
                string SQL = "SELECT * FROM master.dbo.sysdatabases where name = '" + xDatabase + "'";
                string xConnStr = "Server=" + xServer + ";User ID=" + xUserID + ";Password=" + xPassword + ";Trusted_Connection=False;Connection Timeout=30";


                using (SqlConnection con = new SqlConnection(xConnStr))
                {
                    SqlCommand MyCommand = new SqlCommand(SQL, con);

                    con.Open();
                    SqlDataReader MyReader = MyCommand.ExecuteReader();

                    if (MyReader.HasRows)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception Ex)
            {
                //WriteLog(1, Ex.Message, "clsSE", "sqliteInsertRec");
                return false;
            }
        }

        public void sqlCreateDatabase(string xServer, string xDatabase, string xUserID, string xPassword)
        {
            try
            {
                string SQL = "CREATE DATABASE " + xDatabase;
                string xConnStr = "Server=" + xServer + ";User ID=" + xUserID + ";Password=" + xPassword + ";Trusted_Connection=False;Connection Timeout=30";

                using (SqlConnection con = new SqlConnection(xConnStr))
                {
                    SqlCommand MyCommand = new SqlCommand(SQL, con);

                    con.Open();

                    MyCommand.ExecuteNonQuery();
                }

                //Create Tables
                
                SQL =
                    @"
                    CREATE TABLE [dbo].[tblUser] (
                      [Id] int IDENTITY(1, 1) NOT NULL,
                      [Email] varchar(500) COLLATE Latin1_General_CI_AS NULL,
                      [Alias] varchar(50) COLLATE Latin1_General_CI_AS NULL,
                      [Password] varchar(50) COLLATE Latin1_General_CI_AS NULL,
                      [EmailVerified] int CONSTRAINT [DF__tblUser__EmailVe__37A5467C] DEFAULT 0 NULL,
                      [CreatedDT] datetime CONSTRAINT [DF__tblUser__Created__38996AB5] DEFAULT getdate() NOT NULL,
                      CONSTRAINT [PK__tblUser__3214EC077B5EAF05] PRIMARY KEY CLUSTERED ([Id])
                    )
                    ON [PRIMARY];

                    CREATE TABLE [dbo].[tblInstagramUser] (
                      [Id] int IDENTITY(1, 1) NOT NULL,
                      [tblUserId] int NOT NULL,
                      [01_BasicDisplayAPI] varchar(2000) COLLATE Latin1_General_CI_AS NULL,
                      [01_Client_id] varchar(2000) COLLATE Latin1_General_CI_AS NULL,
                      [01_Redirect_uri] varchar(2000) COLLATE Latin1_General_CI_AS NULL,
                      [01_URI_GetCode] varchar(2000) COLLATE Latin1_General_CI_AS NULL,
                      [01_URI_ResponseAfterGetCode] varchar(2000) COLLATE Latin1_General_CI_AS NULL,
                      [02_URI_access_token] varchar(2000) COLLATE Latin1_General_CI_AS NULL,
                      [02_Client_secret] varchar(2000) COLLATE Latin1_General_CI_AS NULL,
                      [02_Code] varchar(2000) COLLATE Latin1_General_CI_AS NULL,
                      [02_S_access_token] varchar(2000) COLLATE Latin1_General_CI_AS NULL,
                      [02_S_user_id] varchar(2000) COLLATE Latin1_General_CI_AS NULL,
                      [03_URI_long_access_token] varchar(2000) COLLATE Latin1_General_CI_AS NULL,
                      [03_L_access_token] varchar(2000) COLLATE Latin1_General_CI_AS NULL,
                      [03_L_token_type] varchar(2000) COLLATE Latin1_General_CI_AS NULL,
                      [03_L_expires_in] varchar(2000) COLLATE Latin1_General_CI_AS NULL,
                      [04_username] varchar(2000) COLLATE Latin1_General_CI_AS NULL,
                      [04_media_count] int NULL,
                      [CreatedDT] datetime CONSTRAINT [DF__tblInstag__Creat__3F466844] DEFAULT getdate() NOT NULL,
                      CONSTRAINT [PK__tblInsta__3214EC074BC58D9B] PRIMARY KEY CLUSTERED ([Id]),
                      CONSTRAINT [tblInstagramUser_fk] FOREIGN KEY ([tblUserId]) 
                      REFERENCES [dbo].[tblUser] ([Id]) 
                      ON UPDATE CASCADE
                      ON DELETE CASCADE
                    )
                    ON [PRIMARY];

                    CREATE TABLE [dbo].[tblInstagramUserMediaID] (
                      [Id] int IDENTITY(1, 1) NOT NULL,
                      [tblInstagramUserId] int NOT NULL,
                      [MediaID] int NULL,
                      [CreatedDT] datetime CONSTRAINT [DF__tblInstag__Creat__4316F928] DEFAULT getdate() NOT NULL,
                      CONSTRAINT [PK__tblInsta__3214EC07D2380E3E] PRIMARY KEY CLUSTERED ([Id]),
                      CONSTRAINT [tblInstagramUserMediaID_fk] FOREIGN KEY ([tblInstagramUserId]) 
                      REFERENCES [dbo].[tblInstagramUser] ([Id]) 
                      ON UPDATE CASCADE
                      ON DELETE CASCADE
                    )
                    ON [PRIMARY];

                    









                    ";

                using (SqlConnection con = new SqlConnection(clsGlobal.gConnectionString))
                {
                    SqlCommand MyCommand = new SqlCommand(SQL, con);

                    con.Open();

                    MyCommand.ExecuteNonQuery();
                }
            }
            catch (Exception Ex)
            {
                var x = 1;
                //WriteLog(1, Ex.Message, "clsSE", "sqliteInsertRec");
            }
        }


        public bool sqlInsertRec(string xTableName, List<string> xFields, List<string> xValues)
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

                using (SqlConnection con = new SqlConnection(clsGlobal.gConnectionString))
                {
                    SqlCommand MyCommand = new SqlCommand(SQL, con);

                    con.Open();

                    MyCommand.ExecuteNonQuery();

                    return true;
                }
            }
            catch (Exception Ex)
            {
                //WriteLog(1, Ex.Message, "clsSE", "sqliteInsertRec");
                return false;
            }
        }

        public bool sqlUpdateRec(string xTableName, List<string> xFields, List<string> xValues, string xWhere)
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

                using (SqlConnection con = new SqlConnection(clsGlobal.gConnectionString))
                {
                    SqlCommand MyCommand = new SqlCommand(SQL, con);

                    con.Open();

                    MyCommand.ExecuteNonQuery();

                    return true;
                }
            }
            catch (Exception Ex)
            {
                //WriteLog(1, Ex.Message, "clsSE", "sqliteUpdateRec");
                return false;
            }
        }

        public bool sqlDeleteRec(string xTableName, string xWhere)
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

                using (SqlConnection con = new SqlConnection(clsGlobal.gConnectionString))
                {
                    SqlCommand MyCommand = new SqlCommand(SQL, con);

                    con.Open();

                    MyCommand.ExecuteNonQuery();

                    return true;
                }
            }
            catch (Exception Ex)
            {
                //WriteLog(1, Ex.Message, "clsSE", "sqliteDeleteRec");

                return false;
            }
        }

        public string EncodeMessage(string xCommand, Object xObject)
        {
            try
            {
                //Serialize
                var xData = SerializeData(xCommand, xObject);

                //Encrypt
                xData = Encrypt(xData);

                //Compress if large
                if (xData.Length >= clsGlobal.gCompressIfStringLonger)
                {
                    xData = "1" + CompressString(xData);
                }
                else
                {
                    xData = "0" + xData;
                }

                return xData;
            }
            catch (Exception Ex)
            {
                return DoError(Ex);
            }
        }

        public string DecodeMessage(string xData)
        {
            try
            {
                var toDecode = xData;
                toDecode = toDecode.Remove(0, 1);

                //Check if compressed
                if (xData[0] == '1')
                {
                    //Decompress
                    toDecode = DecompressString(toDecode);
                }

                //Decrypt
                toDecode = Decrypt(toDecode);

                return toDecode;
            }
            catch (Exception Ex)
            {
                return DecodeMessage(DoError(Ex));
            }
        }

        public string Send(string xCommand, Object xObject)
        {
            try
            {
                var xData = EncodeMessage(xCommand, xObject);
                
                //Send
                var remoteAddress = new System.ServiceModel.EndpointAddress(clsGlobal.gEndpointAddress);

                using (var xwsServerSoapClient = new wsGrowmeAPI.GrowmeWSSoapClient(new System.ServiceModel.BasicHttpBinding(), remoteAddress))
                {
                    //set timeout
                    xwsServerSoapClient.Endpoint.Binding.SendTimeout = new TimeSpan(0, 0, 0, 0, clsGlobal.gSoapCallTimeout);

                    //call web service method
                    var xResponse = xwsServerSoapClient.DoWork(xData);

                    return xResponse;
                }
            }
            catch (Exception Ex)
            {
                return DoError(Ex);
            }
        }

        public string SerializeData(string xCommand, Object xDT)
        {
            try
            {
                string JSONresult;
                JSONresult = JsonConvert.SerializeObject(xDT);

                JSONresult = xCommand + clsGlobal.gMessageCommandSeperator + JSONresult;

                return JSONresult;
            }
            catch (Exception Ex)
            {
                return DoError(Ex);
            }
        }

        public string Encrypt(string plainText)
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
                return DoError(Ex);
            }
        }

        public string Decrypt(string encryptedText)
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
                return DoError(Ex);
            }
        }

        public string CompressString(string text)
        {
            try
            {
                byte[] buffer = Encoding.UTF8.GetBytes(text);
                var memoryStream = new MemoryStream();
                using (var gZipStream = new GZipStream(memoryStream, CompressionMode.Compress, true))
                {
                    gZipStream.Write(buffer, 0, buffer.Length);
                }

                memoryStream.Position = 0;

                var compressedData = new byte[memoryStream.Length];
                memoryStream.Read(compressedData, 0, compressedData.Length);

                var gZipBuffer = new byte[compressedData.Length + 4];
                Buffer.BlockCopy(compressedData, 0, gZipBuffer, 4, compressedData.Length);
                Buffer.BlockCopy(BitConverter.GetBytes(buffer.Length), 0, gZipBuffer, 0, 4);
                return Convert.ToBase64String(gZipBuffer);
            }
            catch (Exception Ex)
            {
                return DoError(Ex);
            }
        }

        public string DecompressString(string compressedText)
        {
            try
            {
                byte[] gZipBuffer = Convert.FromBase64String(compressedText);
                using (var memoryStream = new MemoryStream())
                {
                    int dataLength = BitConverter.ToInt32(gZipBuffer, 0);
                    memoryStream.Write(gZipBuffer, 4, gZipBuffer.Length - 4);

                    var buffer = new byte[dataLength];

                    memoryStream.Position = 0;
                    using (var gZipStream = new GZipStream(memoryStream, CompressionMode.Decompress))
                    {
                        gZipStream.Read(buffer, 0, buffer.Length);
                    }

                    return Encoding.UTF8.GetString(buffer);
                }
            }
            catch (Exception Ex)
            {
                return DoError(Ex);
            }
        }

        public string DoError(Exception xEx)
        {
            try
            {
                return EncodeMessage("Error", xEx.Message);
            }
            catch (Exception Ex)
            {
                return EncodeMessage("Error", Ex.Message);
            }
        }

        public bool IsValidEmailAddress(string xEmail)
        {
            try
            {
                MailAddress m = new MailAddress(xEmail);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public bool SendEmail(string xEmailToAddress, string xSubject, string xBody)
        {
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(clsGlobal.gEmailFromAddress);
                    mail.To.Add(xEmailToAddress);
                    mail.Subject = xSubject;
                    mail.Body = xBody;
                    mail.IsBodyHtml = true;
                    //mail.Attachments.Add(new Attachment("D:\\TestFile.txt"));//--Uncomment this to send any attachment  
                    using (SmtpClient smtp = new SmtpClient(clsGlobal.gSmtpAddress, clsGlobal.gSmtpPort))
                    {
                        smtp.Timeout = clsGlobal.gSmtpTimeout;
                        smtp.Credentials = new NetworkCredential(clsGlobal.gEmailFromAddress, clsGlobal.gSmtpPassword);
                        smtp.EnableSsl = clsGlobal.gSmtpUseSSL;
                        smtp.Send(mail);
                    }
                }

                return true;
            }
            catch (Exception Ex)
            {
                DoError(Ex);
                return false;
            }
        }

        public string frmRegister_RegisterUser(List<string> xData)
        {
            try
            {
                tblUser xtblUser = new tblUser();

                //Check if exist
                if (xtblUser.CheckIfEmailExist(xData[1]) == false)
                {
                    //Create new inactive account
                    if (xtblUser.AddRec(xData[1], xData[0], xData[2]))
                    {
                        //Send verification email
                        if (SendEmail(xData[1], "Growme Account Verification", clsGlobal.gEmailVerificationAddress + EncodeMessage("ValidateUserEmail", xData[1])))
                        {
                            List<string> xMessage = new List<string>();
                            xMessage.Add("Account created successfully.");
                            xMessage.Add("");
                            xMessage.Add("Please activate your account by clicking on the link");
                            xMessage.Add("we have sent to your email address.");

                            return EncodeMessage("Success", xMessage);
                        }
                        else
                        {
                            return EncodeMessage("Error", "");
                        }
                    }
                    else
                    {
                        return EncodeMessage("Error", "");
                    }
                }
                else
                {
                    //Check if email is verified
                    if (xtblUser.CheckIfEmailVerified(xData[1]) == false)
                    {
                        List<string> xMessage = new List<string>();
                        xMessage.Add("The email address is not verified.");
                        xMessage.Add("");
                        xMessage.Add("Please activate your account by clicking on the link");
                        xMessage.Add("we have sent to your email address when you created");
                        xMessage.Add("your account.");
                        xMessage.Add("");
                        xMessage.Add("If you have not received an email containing the link,");
                        xMessage.Add("please click on the 'Resend Activation Email' button");
                        xMessage.Add("on the logon screen.");

                        return EncodeMessage("ErrorNotVerified", xMessage);
                    }
                    else
                    {
                        List<string> xMessage = new List<string>();
                        xMessage.Add("The email address is already in use.");
                        xMessage.Add("");
                        xMessage.Add("If you have forgotten your password, you can reset");
                        xMessage.Add("your password by clicking on the 'I Forgot My Password'");
                        xMessage.Add("button on the Logon screen.");

                        return EncodeMessage("ErrorExist", xMessage);
                    }
                }
            }
            catch (Exception Ex)
            {
                return DoError(Ex);
            }
        }

        public string ValidateUserEmail(string xEmail)
        {
            try
            {
                tblUser xtblUser = new tblUser();

                //Check if exist
                if (xtblUser.CheckIfEmailExist(xEmail))
                {
                    //Check if already verified
                    if (xtblUser.CheckIfEmailVerified(xEmail) == false)
                    {
                        //Verify the account
                        if (xtblUser.VerifyEmail(xEmail))
                        {
                            return "Account verified. You may now log in.";
                        }
                        else
                        {
                            return "Failed to verify your account. Please try again.";
                        }
                    }
                    else
                    {
                        return "This account has already been verified.";
                    }
                }
                else
                {
                    return "This account does not exist.";
                }
            }
            catch (Exception Ex)
            {
                DoError(Ex);
                return "Failed to verify your account. An unknown error has occurred.";
            }
        }

        public string frmForgotPassword_ResetPassword(List<string> xData)
        {
            try
            {
                tblUser xtblUser = new tblUser();

                //Check if exist
                if (xtblUser.CheckIfEmailExist(xData[0]))
                {
                    //Check if email is verified
                    if (xtblUser.CheckIfEmailVerified(xData[0]))
                    {
                        //Send reset password verification email
                        if (SendEmail(xData[0], "Growme Password Reset Verification", clsGlobal.gEmailVerificationAddress + EncodeMessage("ValidateResetPassword", xData[0])))
                        {
                            List<string> xMessage = new List<string>();
                            xMessage.Add("Verification email sent.");
                            xMessage.Add("");
                            xMessage.Add("You can now reset your password by clicking");
                            xMessage.Add("on the link we have sent to your email address.");

                            return EncodeMessage("Success", xMessage);
                        }
                        else
                        {
                            return EncodeMessage("Error", "");
                        }
                    }
                    else
                    {
                        List<string> xMessage = new List<string>();
                        xMessage.Add("The email address is not verified.");
                        xMessage.Add("");
                        xMessage.Add("Please activate your account by clicking on the link");
                        xMessage.Add("we have sent to your email address when you created");
                        xMessage.Add("your account.");
                        xMessage.Add("");
                        xMessage.Add("If you have not received an email containing the link,");
                        xMessage.Add("please click on the 'Resend Activation Email' button");
                        xMessage.Add("on the logon screen.");

                        return EncodeMessage("ErrorNotVerified", xMessage);
                    }
                }
                else
                {
                    List<string> xMessage = new List<string>();
                    xMessage.Add("The email address is not registered.");
                    xMessage.Add("");
                    xMessage.Add("You are welcome to create a new account");
                    xMessage.Add("by clicking on the 'Register a New Account'");
                    xMessage.Add("button on the Logon screen.");

                    return EncodeMessage("ErrorExist", xMessage);
                }
            }
            catch (Exception Ex)
            {
                return DoError(Ex);
            }
        }
    }
}
