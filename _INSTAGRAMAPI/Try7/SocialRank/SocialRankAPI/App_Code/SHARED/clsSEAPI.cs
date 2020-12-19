using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for clsSEAPI
/// </summary>
public class clsSEAPI
{
    public string frmRegister_RegisterUser(List<string> xData)
    {
        try
        {

            tblRegisterAPI xtblRegisterAPI = new tblRegisterAPI();

            //Check if exist
            if (xtblRegisterAPI.CheckIfEmailExist(xData[1]) == false)
            {
                //Create new inactive account
                if (xtblRegisterAPI.AddRec(xData[1], xData[0], xData[2]))
                {
                    //Send verification email
                    /*
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
                    */

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
                /*
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
                */
            }

            return "Regstered";
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
            return "Error: " + xEx.Message;
        }
        catch (Exception Ex)
        {
            return "Error: " + xEx.Message;
        }
    }

    public string Decrypt(string encryptedText)
    {
        try
        {
            byte[] cipherTextBytes = Convert.FromBase64String(encryptedText);
            byte[] keyBytes = new Rfc2898DeriveBytes(clsGlobalAPI.gPasswordHash, Encoding.ASCII.GetBytes(clsGlobalAPI.gSaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.None };

            var decryptor = symmetricKey.CreateDecryptor(keyBytes, Encoding.ASCII.GetBytes(clsGlobalAPI.gVIKey));
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

    public string EncodeMessage(string xCommand, Object xObject)
    {
        try
        {
            //Serialize
            var xData = SerializeData(xCommand, xObject);

            //Encrypt
            xData = Encrypt(xData);

            //Compress if large
            if (xData.Length >= clsGlobalAPI.gCompressIfStringLonger)
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

    public string Encrypt(string plainText)
    {
        try
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            byte[] keyBytes = new Rfc2898DeriveBytes(clsGlobalAPI.gPasswordHash, Encoding.ASCII.GetBytes(clsGlobalAPI.gSaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.Zeros };
            var encryptor = symmetricKey.CreateEncryptor(keyBytes, Encoding.ASCII.GetBytes(clsGlobalAPI.gVIKey));

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

    public string SerializeData(string xCommand, Object xDT)
    {
        try
        {
            string JSONresult;
            JSONresult = JsonConvert.SerializeObject(xDT);

            JSONresult = xCommand + clsGlobalAPI.gMessageCommandSeperator + JSONresult;

            return JSONresult;
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


}