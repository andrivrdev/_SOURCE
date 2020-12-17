using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoWorkController : ControllerBase
    {
        // GET: api/<DoWorkController>
        
       
        [HttpGet]
        public string Get(string xData)
        {
            try
            {
                /*
                FileInfo MyFile = new FileInfo(zDBPathAndFileName);

                if (!(Directory.Exists(MyFile.DirectoryName)))
                {
                    Directory.CreateDirectory(MyFile.DirectoryName);
                }

                if (!File.Exists(zDBPathAndFileName))
                {
                    SQLiteConnection.CreateFile(zDBPathAndFileName);
                }
                */
//                zConn = new SQLiteConnection(@"Data Source=" + zDBPathAndFileName);
                var zConn = new SqliteConnection(@"Data Source=C:\DB.dat");
                SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_winsqlite3());
                zConn.Open();
                string SQL = "PRAGMA foreign_keys = ON;";
                SqliteCommand MyCommand = new SqliteCommand(SQL, zConn);
                MyCommand.ExecuteNonQuery();

                SQL =
                @"
                CREATE TABLE tblUser (
                ID INTEGER        PRIMARY KEY AUTOINCREMENT
                                  NOT NULL,
                [01_BasicDisplayAPI]          VARCHAR(2000),
                [01_Client_id]                VARCHAR(2000),
                [01_Redirect_uri]             VARCHAR(2000),
                [01_URI_GetCode]              VARCHAR(2000),
                [01_URI_ResponseAfterGetCode] VARCHAR(2000),
                [02_URI_access_token]         VARCHAR(2000),
                [02_Client_secret]            VARCHAR(2000),
                [02_Code]                     VARCHAR(2000),
                [02_S_access_token]           VARCHAR(2000),
                [02_S_user_id]                VARCHAR(2000),
                [03_URI_long_access_token]    VARCHAR(2000),
                [03_L_access_token]           VARCHAR(2000),
                [03_L_token_type]             VARCHAR(2000),
                [03_L_expires_in]             VARCHAR(2000),
                [04_username]                 VARCHAR(2000),
                [04_media_count]              INTEGER,
                CreatedDT TIMESTAMP      DEFAULT CURRENT_TIMESTAMP
                                                             NOT NULL
                );";

                MyCommand = new SqliteCommand(SQL, zConn);
                MyCommand.ExecuteNonQuery();

                SQL =
                @"
                CREATE TABLE tblUserMediaID (
                    ID        INTEGER   PRIMARY KEY AUTOINCREMENT
                                        NOT NULL,
                    tblUserID INTEGER   REFERENCES tblUser (ID) ON DELETE CASCADE
                                                                ON UPDATE RESTRICT,
                    MediaID   INTEGER,
                    CreatedDT TIMESTAMP DEFAULT CURRENT_TIMESTAMP
                                        NOT NULL
                );";

                MyCommand = new SqliteCommand(SQL, zConn);
                MyCommand.ExecuteNonQuery();

                return "Success";
            }
            catch (Exception Ex)
            {
                return "Failed: " + Ex.Message;
            }
            
        }
        // POST api/<DoWorkController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DoWorkController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DoWorkController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
