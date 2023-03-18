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
    public class tblUsers
    {
        devSE SE;

        public int IDX { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool LoggedIn { get; set; }
        public string EncUsername { get; set; }
        public string EncPassword { get; set; }
        public bool ShowBulletin { get; set; }
        public bool KickUser { get; set; }

        public BindingList<tblUsers> GetData()
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
                "  tblUsers.IDX," + Environment.NewLine +
                "  tblUsers.Username," + Environment.NewLine +
                "  tblUsers.Password," + Environment.NewLine +
                "  tblUsers.LoggedIn," + Environment.NewLine +
                "  tblUsers.ShowBulletin," + Environment.NewLine +
                "  tblUsers.KickUser" + Environment.NewLine +
                "FROM" + Environment.NewLine +
                "  tblUsers";

                SQLiteCommand MyCommand = new SQLiteCommand(SQL, MyConn);
                SQLiteDataReader MyReader = MyCommand.ExecuteReader();

                dtData = new DataTable();
                dtData.Load(MyReader);

                MyCommand.Dispose();
                MyReader.Dispose();

                //Populate class
                BindingList<tblUsers> MyData = new BindingList<tblUsers>();
                foreach (DataRow ARec in dtData.Rows)
                {
                    tblUsers MyRecord = new tblUsers();

                    //Populate fields
                    MyRecord.IDX = Convert.ToInt32(ARec[0].ToString());
                    MyRecord.Username = SE.Decrypt(ARec[1].ToString());
                    MyRecord.Password = SE.Decrypt(ARec[2].ToString());

                    MyRecord.LoggedIn = false;
                    if (SE.Decrypt(ARec[3].ToString()) == "1")
                    {
                        MyRecord.LoggedIn = true;
                    }

                    MyRecord.ShowBulletin = false;
                    if ((ARec[4].ToString()) == "1")
                    {
                        MyRecord.ShowBulletin = true;
                    }

                    MyRecord.KickUser = false;
                    if ((ARec[5].ToString()) == "1")
                    {
                        MyRecord.KickUser = true;
                    }

                    MyRecord.EncUsername = ARec[1].ToString();
                    MyRecord.EncPassword = ARec[2].ToString();

                    //Add the record
                    MyData.Add(MyRecord);
                }

                return MyData;
            }
            catch (Exception Ex)
            {
                SE.WriteLog(Ex.Message + Environment.NewLine + "SQL: " + SQL, "tblUsers", "GetData");
                return new BindingList<tblUsers>();
            }
        }
    }
}
