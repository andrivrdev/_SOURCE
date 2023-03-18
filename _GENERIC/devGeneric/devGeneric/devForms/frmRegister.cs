﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using devGeneric.devClasses.devDynamic;
using devGeneric.devClasses.devStatic;

namespace devGeneric.devForms
{
    public partial class frmRegister : DevExpress.XtraEditors.XtraForm
    {
        devSE SE;

        string zUser;
        string zPCID;

        public frmRegister(string xUser, string xPCID)
        {
            InitializeComponent();

            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            SE = new devSE();

            string MyID = "";
            string NewID = "";

            zUser = xUser;
            zPCID = xPCID;

            //Make a string of the encrypted username and mac
            MyID = SE.GetEncUsername(xUser) + SE.GetEncUserPCID(SE.GetEncUsername(xUser), xPCID);

            //Now convert it to an encrypted numeric string
            MyID = SE.GetEncryptedNum(MyID);

            //Finally make it shorter by using only every 6th numeric
            while (MyID.Length > 0)
            {
                NewID = NewID + MyID.Substring(5, 1);
                MyID = MyID.Remove(0, 6);
            }

            edtID.Text = NewID;
            memKey.Text = "";

            this.Text = "User Registration";
            sbMain.SetText("Please enter your registration key");

            //If it is me auto register
            if (devGlobals.gRegOverride == 2)
            {
                memKey.Text = SE.GetEncryptedNum(SE.Encrypt(edtID.Text + "admin"));
            }

            if (devGlobals.gRegOverride == 1)
            {
                memKey.Text = SE.GetEncryptedNum(SE.Encrypt(edtID.Text));
            }

            memKey.Focus();
        }

        private bool DoValidate()
        {
            if (memKey.Text.Length == 0)
            {
                XtraMessageBox.Show("Please enter your registration key.", "No No No !!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }

            return true;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            memKey.Text = memKey.Text.Trim();

            int MyResult = 999;

            if (DoValidate() == false)
            {
                this.DialogResult = DialogResult.None;

                memKey.Focus();
                memKey.SelectAll();
            }
            else
            {
                //Validate key
                MyResult = SE.ValidateRegKey(edtID.Text, memKey.Text);

                if (MyResult == 999)
                {
                    XtraMessageBox.Show("Invalid registration key.", "Registration", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.DialogResult = DialogResult.None;

                    memKey.Focus();
                    memKey.SelectAll();
                }
                else
                {
                    if (MyResult == 0)
                    {
                        SE.WriteUserRegistration(SE.GetEncUsername(zUser), SE.GetEncUserPCID(SE.GetEncUsername(zUser), zPCID), false);

                        XtraMessageBox.Show("User registered.", "Registration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        SE.WriteUserRegistration(SE.GetEncUsername(zUser), SE.GetEncUserPCID(SE.GetEncUsername(zUser), zPCID), true);

                        XtraMessageBox.Show("User registered as admin.", "Registration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
    }
}