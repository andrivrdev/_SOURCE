﻿using devGeneric.devClasses.devDynamic;
using devGeneric.devClasses.devStatic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devGeneric.devData
{
    public class tblDatabaseConnections
    {
        devSE SE;

        public int IDX { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string DBName { get; set; }
        public string ConnString { get; set; }

        public BindingList<tblDatabaseConnections> GetData()
        {
            string SQL = "";

            try
            {
                SE = new devSE();

                DataTable dtData;

                SQLiteConnection MyConn = new SQLiteConnection(@"Data Source=" + devGlobals.gDB);
                MyConn.Open();

                BindingList<tblDatabaseConnections> MyData = new BindingList<tblDatabaseConnections>();

                SQL =
                "SELECT " + Environment.NewLine +
                "  tblDatabaseConnections.IDX," + Environment.NewLine +
                "  tblDatabaseConnections.Description," + Environment.NewLine +
                "  tblDatabaseConnections.Type," + Environment.NewLine +
                "  tblDatabaseConnections.Host," + Environment.NewLine +
                "  tblDatabaseConnections.Port," + Environment.NewLine +
                "  tblDatabaseConnections.Username," + Environment.NewLine +
                "  tblDatabaseConnections.Password," + Environment.NewLine +
                "  tblDatabaseConnections.DBName," + Environment.NewLine +
                "  tblDatabaseConnections.ConnString" + Environment.NewLine +
                "FROM" + Environment.NewLine +
                "  tblDatabaseConnections";

                SQLiteCommand MyCommand = new SQLiteCommand(SQL, MyConn);
                SQLiteDataReader MyReader = MyCommand.ExecuteReader();

                dtData = new DataTable();
                dtData.Load(MyReader);

                MyCommand.Dispose();
                MyReader.Dispose();

                //Populate class
                int MyIDX = 1;
                foreach (DataRow ARec in dtData.Rows)
                {
                    tblDatabaseConnections MyRecord = new tblDatabaseConnections();

                    //Populate fields
                    MyRecord.IDX = Convert.ToInt32(ARec[0].ToString());
                    MyRecord.Description = ARec[1].ToString();
                    MyRecord.Type = Convert.ToInt32(ARec[2].ToString());
                    MyRecord.Host = ARec[3].ToString();
                    MyRecord.Port = Convert.ToInt32(ARec[4].ToString());
                    MyRecord.Username = SE.Decrypt(ARec[5].ToString());
                    MyRecord.Password = SE.Decrypt(ARec[6].ToString());
                    MyRecord.DBName = ARec[7].ToString();
                    MyRecord.ConnString = SE.Decrypt(ARec[8].ToString());

                    //Add the record
                    MyData.Add(MyRecord);

                    MyIDX++;
                }

                return MyData;
            }
            catch (Exception Ex)
            {
                SE.WriteLog(Ex.Message + Environment.NewLine + "SQL: " + SQL, "tblDatabaseConnections", "GetData");
                return new BindingList<tblDatabaseConnections>();
            }
        }

        public tblDatabaseConnections GetConnectionDetails(string xDescription)
        {
            string SQL = "";

            try
            {
                SE = new devSE();

                DataTable dtData;

                SQLiteConnection MyConn = new SQLiteConnection(@"Data Source=" + devGlobals.gDB);
                MyConn.Open();


                SQL =
                "SELECT " + Environment.NewLine +
                "  tblDatabaseConnections.IDX," + Environment.NewLine +
                "  tblDatabaseConnections.Description," + Environment.NewLine +
                "  tblDatabaseConnections.Type," + Environment.NewLine +
                "  tblDatabaseConnections.Host," + Environment.NewLine +
                "  tblDatabaseConnections.Port," + Environment.NewLine +
                "  tblDatabaseConnections.Username," + Environment.NewLine +
                "  tblDatabaseConnections.Password," + Environment.NewLine +
                "  tblDatabaseConnections.DBName," + Environment.NewLine +
                "  tblDatabaseConnections.ConnString" + Environment.NewLine +
                "FROM" + Environment.NewLine +
                "  tblDatabaseConnections" + Environment.NewLine +
                "WHERE" + Environment.NewLine +
                "  tblDatabaseConnections.Description = '" + xDescription + "'";

                SQLiteCommand MyCommand = new SQLiteCommand(SQL, MyConn);
                SQLiteDataReader MyReader = MyCommand.ExecuteReader();

                dtData = new DataTable();
                dtData.Load(MyReader);

                MyCommand.Dispose();
                MyReader.Dispose();

                //Populate class
                int MyIDX = 1;
                foreach (DataRow ARec in dtData.Rows)
                {
                    tblDatabaseConnections MyRecord = new tblDatabaseConnections();

                    //Populate fields
                    MyRecord.IDX = Convert.ToInt32(ARec[0].ToString());
                    MyRecord.Description = ARec[1].ToString();
                    MyRecord.Type = Convert.ToInt32(ARec[2].ToString());
                    MyRecord.Host = ARec[3].ToString();
                    MyRecord.Port = Convert.ToInt32(ARec[4].ToString());
                    MyRecord.Username = SE.Decrypt(ARec[5].ToString());
                    MyRecord.Password = SE.Decrypt(ARec[6].ToString());
                    MyRecord.DBName = ARec[7].ToString();
                    MyRecord.ConnString = SE.Decrypt(ARec[8].ToString());

                    return MyRecord;

                    MyIDX++;
                }

                return new tblDatabaseConnections();
            }
            catch (Exception Ex)
            {
                SE.WriteLog(Ex.Message + Environment.NewLine + "SQL: " + SQL, "tblDatabaseConnections", "GetData");
                return new tblDatabaseConnections();
            }
        }

    }
}
