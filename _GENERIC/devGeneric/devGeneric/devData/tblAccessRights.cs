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
    public class tblAccessRights
    {
        devSE SE;

        public int IDX { get; set; }
        public string AccessRight { get; set; }
        public int Tag { get; set; }

        public BindingList<tblAccessRights> GetData()
        {
            string SQL = "";

            try
            {
                SE = new devSE();

                DataTable dtData;

                SQLiteConnection MyConn = new SQLiteConnection(@"Data Source=" + devGlobals.gDB);
                MyConn.Open();

                BindingList<tblAccessRights> MyData = new BindingList<tblAccessRights>();

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
                    tblAccessRights MyRecord = new tblAccessRights();

                    //Populate fields
                    MyRecord.IDX = Convert.ToInt32(ARec[0].ToString());
                    MyRecord.AccessRight = SE.Decrypt(ARec[1].ToString());
                    MyRecord.Tag = Convert.ToInt32(SE.Decrypt(ARec[2].ToString()));

                    //Add the record
                    MyData.Add(MyRecord);

                    MyIDX++;
                }

                return MyData;
            }
            catch (Exception Ex)
            {
                SE.WriteLog(Ex.Message + Environment.NewLine + "SQL: " + SQL, "tblAccessRights", "GetData");
                return new BindingList<tblAccessRights>();
            }
        }
    }
}
