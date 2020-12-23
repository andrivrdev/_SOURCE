using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace SocialRankAndroid.SHARED.CLASSES
{
    public class clsSE
    {
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

        public string Send(string xCommand, Object xObject)
        {
            
            try
            {
                var xData = EncodeMessage(xCommand, xObject);

                //Send
                HttpWebRequest request = CreateWebRequest();
                XmlDocument soapEnvelopeXml = new XmlDocument();


                string myXML = @"<?xml version=""1.0"" encoding=""utf-8""?>
                <soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:tem=""http://tempuri.org/"">
                  <soap:Body>
                    <tem:DoWork>
                        <tem:xData>" + xData + @"</tem:xData>
                    </tem:DoWork>
                  </soap:Body>
                </soap:Envelope>";

                soapEnvelopeXml.LoadXml(myXML);

                using (Stream stream = request.GetRequestStream())
                {
                    soapEnvelopeXml.Save(stream);
                }

                using (WebResponse response = request.GetResponse())
                {
                    using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                    {
                        string soapResult = rd.ReadToEnd();
                        return ParseSoapResponse(soapResult);
                    }
                }












                
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




        public string Execute()
        {
            HttpWebRequest request = CreateWebRequest();
            XmlDocument soapEnvelopeXml = new XmlDocument();
            soapEnvelopeXml.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>
                <soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
                  <soap:Body>
                    <HelloWorld xmlns=""http://tempuri.org/"" />
                  </soap:Body>
                </soap:Envelope>");

            using (Stream stream = request.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }

            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                {
                    string soapResult = rd.ReadToEnd();
                    return ParseSoapResponse(soapResult);
                }
            }
        }

        public HttpWebRequest CreateWebRequest()
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(clsGlobal.gEndpointAddress + "?op=DoWork");
            webRequest.Headers.Add(@"SOAP:Action");
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }

        public string ParseSoapResponse(string response)
        {
            var soap = XDocument.Parse(response);
            XNamespace ns = "http://tempuri.org/";
            var result = soap.Descendants(ns + "DoWorkResponse").First().Element(ns + "DoWorkResult").Value;
            return result;
        }



    }
}
