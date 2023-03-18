using Newtonsoft.Json;
using Shared.MODELS;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;

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
                    CREATE TABLE [dbo].[tblCompany] (
                      [ID] bigint IDENTITY(1, 1) NOT NULL,
                      [Name] varchar(50) COLLATE Latin1_General_CI_AS NOT NULL,
                      [Password] varchar(50) COLLATE Latin1_General_CI_AS NOT NULL,
                      [CreatedDateTime] datetime CONSTRAINT [DF__tblCompan__Creat__38996AB5] DEFAULT getdate() NOT NULL,
                      CONSTRAINT [PK__tblCompa__3214EC27B92D6FB9] PRIMARY KEY CLUSTERED ([ID]),
                      CONSTRAINT [UQ__tblCompa__737584F686184EDA] UNIQUE ([Name])
                    )
                    ON [PRIMARY];

                    CREATE TABLE [dbo].[tblGroup] (
                      [ID] bigint IDENTITY(1, 1) NOT NULL,
                      [CompanyID] bigint NOT NULL,
                      [Code] varchar(20) COLLATE Latin1_General_CI_AS NOT NULL,
                      [Description] varchar(1000) COLLATE Latin1_General_CI_AS NULL,
                      [CreatedDateTime] datetime CONSTRAINT [DF__tblGroup__Create__3B75D760] DEFAULT getdate() NOT NULL,
                      [Deleted] int CONSTRAINT [DF__tblGroup__Delete__3C69FB99] DEFAULT 0 NOT NULL,
                      CONSTRAINT [PK__tblGroup__3214EC2756898800] PRIMARY KEY CLUSTERED ([ID]),
                      CONSTRAINT [tblGroup_fk] FOREIGN KEY ([CompanyID]) 
                      REFERENCES [dbo].[tblCompany] ([ID]) 
                      ON UPDATE NO ACTION
                      ON DELETE NO ACTION
                    )
                    ON [PRIMARY];


                    CREATE NONCLUSTERED INDEX [tblGroup_idx] ON [dbo].[tblGroup]
                      ([CompanyID], [Code])
                    WITH (
                      PAD_INDEX = OFF,
                      DROP_EXISTING = OFF,
                      STATISTICS_NORECOMPUTE = OFF,
                      SORT_IN_TEMPDB = OFF,
                      ONLINE = OFF,
                      ALLOW_ROW_LOCKS = ON,
                      ALLOW_PAGE_LOCKS = ON)
                    ON [PRIMARY];

                    CREATE TABLE [dbo].[tblPlant] (
                      [ID] bigint IDENTITY(1, 1) NOT NULL,
                      [GroupID] bigint NOT NULL,
                      [Name] varchar(20) COLLATE Latin1_General_CI_AS NOT NULL,
                      [CreatedDateTime] datetime CONSTRAINT [DF__tblPlant__Create__3F466844] DEFAULT getdate() NOT NULL,
                      [Deleted] int CONSTRAINT [DF__tblPlant__Delete__403A8C7D] DEFAULT 0 NOT NULL,
                      CONSTRAINT [PK__tblPlant__3214EC277B4686F3] PRIMARY KEY CLUSTERED ([ID]),
                      CONSTRAINT [tblPlant_fk] FOREIGN KEY ([GroupID]) 
                      REFERENCES [dbo].[tblGroup] ([ID]) 
                      ON UPDATE NO ACTION
                      ON DELETE NO ACTION
                    )
                    ON [PRIMARY];

                    CREATE TABLE [dbo].[tblEventCategory] (
                      [ID] bigint IDENTITY(1, 1) NOT NULL,
                      [Name] varchar(20) COLLATE Latin1_General_CI_AS NOT NULL,
                      [CreatedDateTime] datetime CONSTRAINT [DF__tblEventC__Creat__4AB81AF0] DEFAULT getdate() NOT NULL,
                      CONSTRAINT [PK__tblEvent__3214EC2742022F94] PRIMARY KEY CLUSTERED ([ID]),
                      CONSTRAINT [UQ__tblEvent__737584F64A0B5310] UNIQUE ([Name])
                    )
                    ON [PRIMARY];

                    CREATE TABLE [dbo].[tblEvent] (
                      [ID] bigint IDENTITY(1, 1) NOT NULL,
                      [EventCategoryID] bigint NOT NULL,
                      [Name] varchar(20) COLLATE Latin1_General_CI_AS NOT NULL,
                      [CreatedDateTime] datetime CONSTRAINT [DF__tblEvent__Create__4E88ABD4] DEFAULT getdate() NOT NULL,
                      CONSTRAINT [PK__tblEvent__3214EC27D8DB0C78] PRIMARY KEY CLUSTERED ([ID]),
                      CONSTRAINT [UQ__tblEvent__737584F6700DD539] UNIQUE ([Name]),
                      CONSTRAINT [tblEvent_fk] FOREIGN KEY ([EventCategoryID]) 
                      REFERENCES [dbo].[tblEventCategory] ([ID]) 
                      ON UPDATE NO ACTION
                      ON DELETE NO ACTION
                    )
                    ON [PRIMARY];

                    CREATE TABLE [dbo].[tblPlantHistory] (
                      [ID] bigint IDENTITY(1, 1) NOT NULL,
                      [PlantID] bigint NOT NULL,
                      [EventID] bigint NOT NULL,
                      [Data] varbinary(max) NULL,
                      [CreatedDateTime] datetime CONSTRAINT [DF__tblPlantH__Creat__44FF419A] DEFAULT getdate() NOT NULL,
                      [Deleted] int CONSTRAINT [DF__tblPlantH__Delet__45F365D3] DEFAULT 0 NOT NULL,
                      CONSTRAINT [PK__tblPlant__3214EC2739B8AABD] PRIMARY KEY CLUSTERED ([ID]),
                      CONSTRAINT [tblPlantHistory_fk] FOREIGN KEY ([PlantID]) 
                      REFERENCES [dbo].[tblPlant] ([ID]) 
                      ON UPDATE NO ACTION
                      ON DELETE NO ACTION,
                      CONSTRAINT [tblPlantHistory_fk2] FOREIGN KEY ([EventID]) 
                      REFERENCES [dbo].[tblEvent] ([ID]) 
                      ON UPDATE NO ACTION
                      ON DELETE NO ACTION
                    )
                    ON [PRIMARY];





                    INSERT INTO [dbo].[tblEventCategory] ([Name])
                    VALUES (N'Phases');
                    

                    INSERT INTO [dbo].[tblEventCategory] ([Name])
                    VALUES (N'Mediums');
                    

                    INSERT INTO [dbo].[tblEventCategory] ([Name])
                    VALUES (N'Daily');
                    

                    INSERT INTO [dbo].[tblEventCategory] ([Name])
                    VALUES (N'Environmental');
                    

                    INSERT INTO [dbo].[tblEventCategory] ([Name])
                    VALUES (N'Chemicals');
                    

                    INSERT INTO [dbo].[tblEventCategory] ([Name])
                    VALUES (N'Problems');
                    

                    INSERT INTO [dbo].[tblEventCategory] ([Name])
                    VALUES (N'Images');
                    

                    INSERT INTO [dbo].[tblEventCategory] ([Name])
                    VALUES (N'Nutrients');
                    

                    INSERT INTO [dbo].[tblEventCategory] ([Name])
                    VALUES (N'Origin');
                    

                    INSERT INTO [dbo].[tblEventCategory] ([Name])
                    VALUES (N'Varieties');
                    

                    INSERT INTO [dbo].[tblEventCategory] ([Name])
                    VALUES (N'Notes');
                    

                    INSERT INTO [dbo].[tblEventCategory] ([Name])
                    VALUES (N'Cuttings');
                    
                    INSERT INTO [dbo].[tblEventCategory] ([Name])
                    VALUES (N'X1 Placeholder');


                    INSERT INTO [dbo].[tblEvent] ([EventCategoryID], [Name])
                    VALUES (1, N'Germination');


                    INSERT INTO [dbo].[tblEvent] ([EventCategoryID], [Name])
                    VALUES (1, N'Vegitative');


                    INSERT INTO [dbo].[tblEvent] ([EventCategoryID], [Name])
                    VALUES (1, N'Flower');


                    INSERT INTO [dbo].[tblEvent] ([EventCategoryID], [Name])
                    VALUES (1, N'Cutting');


                    INSERT INTO [dbo].[tblEvent] ([EventCategoryID], [Name])
                    VALUES (1, N'Trimming');


                    INSERT INTO [dbo].[tblEvent] ([EventCategoryID], [Name])
                    VALUES (1, N'Curing');


                    INSERT INTO [dbo].[tblEvent] ([EventCategoryID], [Name])
                    VALUES (1, N'End of Life');


                    INSERT INTO [dbo].[tblEvent] ([EventCategoryID], [Name])
                    VALUES (2, N'Medium Change');


                    INSERT INTO [dbo].[tblEvent] ([EventCategoryID], [Name])
                    VALUES (3, N'Inspected');


                    INSERT INTO [dbo].[tblEvent] ([EventCategoryID], [Name])
                    VALUES (3, N'Watered');


                    INSERT INTO [dbo].[tblEvent] ([EventCategoryID], [Name])
                    VALUES (8, N'Nutrient');


                    INSERT INTO [dbo].[tblEvent] ([EventCategoryID], [Name])
                    VALUES (5, N'Chemical');


                    INSERT INTO [dbo].[tblEvent] ([EventCategoryID], [Name])
                    VALUES (6, N'Rotten');


                    INSERT INTO [dbo].[tblEvent] ([EventCategoryID], [Name])
                    VALUES (6, N'Bugs');


                    INSERT INTO [dbo].[tblEvent] ([EventCategoryID], [Name])
                    VALUES (7, N'Image');


                    INSERT INTO [dbo].[tblEvent] ([EventCategoryID], [Name])
                    VALUES (4, N'Temperature');


                    INSERT INTO [dbo].[tblEvent] ([EventCategoryID], [Name])
                    VALUES (4, N'Humidity');


                    INSERT INTO [dbo].[tblEvent] ([EventCategoryID], [Name])
                    VALUES (1, N'Domes Off');


                    INSERT INTO [dbo].[tblEvent] ([EventCategoryID], [Name])
                    VALUES (13, N'X2 Placeholder');


                    INSERT INTO [dbo].[tblEvent] ([EventCategoryID], [Name])
                    VALUES (13, N'X3 Placeholder');


                    INSERT INTO [dbo].[tblEvent] ([EventCategoryID], [Name])
                    VALUES (13, N'X4 Placeholder');


                    INSERT INTO [dbo].[tblEvent] ([EventCategoryID], [Name])
                    VALUES (9, N'Other Origin');


                    INSERT INTO [dbo].[tblEvent] ([EventCategoryID], [Name])
                    VALUES (13, N'X5 Placeholder');


                    INSERT INTO [dbo].[tblEvent] ([EventCategoryID], [Name])
                    VALUES (9, N'Mother');


                    INSERT INTO [dbo].[tblEvent] ([EventCategoryID], [Name])
                    VALUES (10, N'Variety');


                    INSERT INTO [dbo].[tblEvent] ([EventCategoryID], [Name])
                    VALUES (13, N'X6 Placeholder');


                    INSERT INTO [dbo].[tblEvent] ([EventCategoryID], [Name])
                    VALUES (11, N'Note');


                    INSERT INTO [dbo].[tblEvent] ([EventCategoryID], [Name])
                    VALUES (13, N'X7 Placeholder');


                    INSERT INTO [dbo].[tblEvent] ([EventCategoryID], [Name])
                    VALUES (13, N'X8 Placeholder');


                    INSERT INTO [dbo].[tblEvent] ([EventCategoryID], [Name])
                    VALUES (12, N'Took a Cutting');

                    ALTER TABLE [dbo].[tblCompany]
                    ADD [AddCuttingsTo] bigint DEFAULT 0 NOT NULL;





















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

                /*
                var remoteAddress = new System.ServiceModel.EndpointAddress(clsGlobal.gEndpointAddress);

                using (var xwsServerSoapClient = new wsGrowmeAPI.GrowmeWSSoapClient(new System.ServiceModel.BasicHttpBinding(), remoteAddress))
                {
                    //set timeout
                    xwsServerSoapClient.Endpoint.Binding.SendTimeout = new TimeSpan(0, 0, 0, 0, clsGlobal.gSoapCallTimeout);

                    //call web service method
                    var xResponse = xwsServerSoapClient.DoWork(xData);

                    return xResponse;
                }
                */
                return xData;
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
