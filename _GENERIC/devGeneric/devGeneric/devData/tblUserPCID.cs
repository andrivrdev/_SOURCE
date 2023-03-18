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
    public class tblUserPCID
    {
        devSE SE;

        public int IDX { get; set; }
        public string PCID { get; set; }
        public int Registered { get; set; }

        public BindingList<tblUserPCID> GetData(string xUser)
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
                "  tblUserReg.IDX," + Environment.NewLine +
                "  tblUserReg.PCID," + Environment.NewLine +
                "  tblUserReg.Register" + Environment.NewLine +
                "FROM" + Environment.NewLine +
                "  tblUserReg" + Environment.NewLine +
                "WHERE" + Environment.NewLine +
                "  tblUserReg.Username = '" + SE.Encrypt(xUser) + "'";

                SQLiteCommand MyCommand = new SQLiteCommand(SQL, MyConn);
                SQLiteDataReader MyReader = MyCommand.ExecuteReader();

                dtData = new DataTable();
                dtData.Load(MyReader);

                MyCommand.Dispose();
                MyReader.Dispose();

                //Populate class
                BindingList<tblUserPCID> MyData = new BindingList<tblUserPCID>();
                foreach (DataRow ARec in dtData.Rows)
                {
                    tblUserPCID MyRecord = new tblUserPCID();

                    //Populate fields
                    MyRecord.IDX = Convert.ToInt32(ARec[0].ToString());
                    MyRecord.PCID = SE.Decrypt(ARec[1].ToString());
                    MyRecord.Registered = SE.CheckUserRegistration(SE.Encrypt(xUser), ARec[1].ToString());

                    //Add the record
                    MyData.Add(MyRecord);
                }

                return MyData;
            }
            catch (Exception Ex)
            {
                SE.WriteLog(Ex.Message + Environment.NewLine + "SQL: " + SQL, "tblUserPCID", "GetData");
                return new BindingList<tblUserPCID>();
            }
        }
    }
}
