﻿using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SocialRankMobile.SHARED
{
    public class clsSEMobile
    {
        public string Send(string xCommand, Object xObject)
        {
            try
            {
                var xData = EncodeMessage(xCommand, xObject);

                //Send

                //var remoteAddress = new System.ServiceModel.EndpointAddress(clsGlobalAPI.gEndpointAddress);
                var xwsServerSoapClient = new wsSocialRankAPI.SocialRankAPISoapClient(wsSocialRankAPI.SocialRankAPISoapClient.EndpointConfiguration.SocialRankAPISoap12);
               
                    //set timeout
                    //xwsServerSoapClient.Endpoint.Binding.SendTimeout = new TimeSpan(0, 0, 0, 0, clsGlobal.gSoapCallTimeout);

                    //call web service method
                    var response = xwsServerSoapClient.DoworkAsync(xData);

                return response;
                    //clsGlobalMobile.gError = response;
                



/*
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://andrivr.hopto.org:6001");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("/api/Dowork?xData=" + xData);*/


                /*
                string URI = "https://andrivr.hopto.org:6001/api/Dowork?xData=" + xData;
                var client = new RestClient(URI);
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.C
                //request.AddParameter("xData", xData);
                IRestResponse response = client.Execute(request);*/

              //  var details = response.Content;
                /*var remoteAddress = new System.ServiceModel.EndpointAddress(clsGlobal.gEndpointAddress);

                using (var xwsServerSoapClient = new wsGrowmeAPI.GrowmeWSSoapClient(new System.ServiceModel.BasicHttpBinding(), remoteAddress))
                {
                    //set timeout
                    xwsServerSoapClient.Endpoint.Binding.SendTimeout = new TimeSpan(0, 0, 0, 0, clsGlobal.gSoapCallTimeout);

                    //call web service method
                    var xResponse = xwsServerSoapClient.DoWork(xData);

                    return xResponse;
                }
                */

               // return details.ToString();
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

        public string EncodeMessage(string xCommand, Object xObject)
        {
            try
            {
                //Serialize
                var xData = SerializeData(xCommand, xObject);

                //Encrypt
                xData = Encrypt(xData);

                //Compress if large
                if (xData.Length >= clsGlobalMobile.gCompressIfStringLonger)
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
        public string SerializeData(string xCommand, Object xDT)
        {
            try
            {
                string JSONresult;
                JSONresult = JsonConvert.SerializeObject(xDT);

                JSONresult = xCommand + clsGlobalMobile.gMessageCommandSeperator + JSONresult;

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

        public string Encrypt(string plainText)
        {
            try
            {
                byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

                byte[] keyBytes = new Rfc2898DeriveBytes(clsGlobalMobile.gPasswordHash, Encoding.ASCII.GetBytes(clsGlobalMobile.gSaltKey)).GetBytes(256 / 8);
                var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.Zeros };
                var encryptor = symmetricKey.CreateEncryptor(keyBytes, Encoding.ASCII.GetBytes(clsGlobalMobile.gVIKey));

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

    }
}
