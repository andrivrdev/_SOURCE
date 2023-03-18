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
    public class tblUserAccessRights
    {
        devSE SE;

        public int IDX { get; set; }
        public string AccessRight { get; set; }
        public int Tag { get; set; }

        public BindingList<tblUserAccessRights> GetData(string xUsername)
        {
            string SQL = "";

            try
            {
                SE = new devSE();

                //If one of the regs is admin then give full access
                DataTable dtData;

                SQLiteConnection MyConn = new SQLiteConnection(@"Data Source=" + devGlobals.gDB);
                MyConn.Open();

                BindingList<tblUserAccessRights> MyData = new BindingList<tblUserAccessRights>();

                bool IsAdmin = false;
                List<string> MyIDList = new List<string>();
                MyIDList = SE.GetUserPCIDList(SE.Encrypt(xUsername));

                foreach (string MyItem in MyIDList)
                {
                    if (SE.CheckUserRegistration(SE.Encrypt(xUsername), SE.Encrypt(MyItem)) == 2)
                    {
                        IsAdmin = true;
                        break;
                    }
                }

                if (IsAdmin)
                {
                    SQL =
                    "SELECT " + Environment.NewLine +
                    "  tblAccessRights.IDX," + Environment.NewLine +
                    "  tblAccessRights.Description," + Environment.NewLine +
                    "  tblAccessRights.Tag" + Environment.NewLine +
                    "FROM" + Environment.NewLine +
                    "  tblAccessRights";

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
                        tblUserAccessRights MyRecord = new tblUserAccessRights();

                        //Populate fields
                        MyRecord.IDX = Convert.ToInt32(ARec[0].ToString());
                        MyRecord.AccessRight = SE.Decrypt(ARec[1].ToString());
                        MyRecord.Tag = Convert.ToInt32(SE.Decrypt(ARec[2].ToString()));

                        //Add the record
                        MyData.Add(MyRecord);

                        MyIDX++;
                    }
                }
                else
                {
                    SQL =
                    "SELECT " + Environment.NewLine +
                    "  tblAccessRights.IDX," + Environment.NewLine +
                    "  tblAccessRights.Description," + Environment.NewLine +
                    "  tblAccessRights.Tag" + Environment.NewLine +
                    "FROM" + Environment.NewLine +
                    "  tblUserAccess" + Environment.NewLine +
                    "  INNER JOIN tblAccessRights ON (tblUserAccess.AccessRightsIDX = tblAccessRights.IDX)" + Environment.NewLine +
                    "  INNER JOIN tblUsers ON (tblUserAccess.UsersIDX = tblUsers.IDX)" + Environment.NewLine +
                    "WHERE" + Environment.NewLine +
                    "  tblUsers.Username = '" + SE.Encrypt(xUsername) + "'";

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
                        tblUserAccessRights MyRecord = new tblUserAccessRights();

                        //Populate fields
                        MyRecord.IDX = Convert.ToInt32(ARec[0].ToString());
                        MyRecord.AccessRight = SE.Decrypt(ARec[1].ToString());
                        MyRecord.Tag = Convert.ToInt32(SE.Decrypt(ARec[2].ToString()));

                        //Add the record
                        MyData.Add(MyRecord);

                        MyIDX++;
                    }
                }

                return MyData;
            }
            catch (Exception Ex)
            {
                SE.WriteLog(Ex.Message + Environment.NewLine + "SQL: " + SQL, "tblUserAccessRights", "GetData");
                return new BindingList<tblUserAccessRights>();
            }
        }
    }
}
