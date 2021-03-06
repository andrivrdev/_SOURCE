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
using devGeneric.devData;
using System.Data.SqlClient;

namespace devGeneric.devForms
{
    public partial class frmConnectionDetails : DevExpress.XtraEditors.XtraForm
    {
        devSE SE;
        int zMyMode;
        string zOldDesc;


        public frmConnectionDetails(int xMode, string xOldDesc)
        {
           InitializeComponent();

           this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

           zMyMode = xMode;

           SE = new devSE();

           //Add
           if (zMyMode == 0)
           {
               edtDesc.Text = "";
               edtType.SelectedIndex = -1;
               edtUsername.Text = "";
               edtPassword.Text = "";
               edtHost.Text = "";
               edtPort.Value = 0;
               edtDatabase.Text = "";
               edtConnString.Text = "";

               this.Text = "New Connection Details";
               sbMain.SetText("Please complete the connection details");

               edtDesc.Focus();
           }

           //Edit
           if (zMyMode == 1)
           {
               this.Text = "Edit Connection Details";
               sbMain.SetText("Please update the connection details");

               zOldDesc = xOldDesc;

               edtDesc.Focus();
           }
        }

        private void UpdateConnStr()
        {
            if (edtType.Text == "Microsoft SQL Server")
            {
                //
                edtConnString.Text = String.Format("Data Source={0}; Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3};", edtHost.Text.Trim(), edtDatabase.Text.Trim(), edtUsername.Text.Trim(), edtPassword.Text.Trim());
//                edtConnString.Text = @"Data Source=(local)\SQLEXPRESS;Initial Catalog=master;User ID=sa;Password=passDEV790.";

                //edtConnString.Text = String.Format("Data Source={0}; Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3};", edtHost.Text.Trim() + ',' + edtPort.Text.Trim(), edtDatabase.Text.Trim(), edtUsername.Text.Trim(), edtPassword.Text.Trim());
            }
        }

        private void edtType_EditValueChanged(object sender, EventArgs e)
        {
            if (edtType.Text == "Microsoft SQL Server")
            {
                edtPort.Value = 1433;
            }

            UpdateConnStr();
        }

        private void edtHost_EditValueChanged(object sender, EventArgs e)
        {
            UpdateConnStr();
        }

        private void edtPort_EditValueChanged(object sender, EventArgs e)
        {
            UpdateConnStr();
        }

        private void edtUsername_EditValueChanged(object sender, EventArgs e)
        {
            UpdateConnStr();
        }

        private void edtPassword_EditValueChanged(object sender, EventArgs e)
        {
            UpdateConnStr();
        }

        private void edtDatabase_EditValueChanged(object sender, EventArgs e)
        {
            UpdateConnStr();
        }

        private bool DoValidate()
        {
            BindingList<tblDatabaseConnections> MyList = new BindingList<tblDatabaseConnections>();
            tblDatabaseConnections ARec = new tblDatabaseConnections();

            if (zMyMode == 0)
            {
                //Check if connection exist
                MyList = ARec.GetData();

                foreach (tblDatabaseConnections MyItem in MyList)
                {
                    if (edtDesc.Text == MyItem.Description)
                    {
                        XtraMessageBox.Show("The connection with this name already exist.", "No No No !!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return false;
                    }
                }
            }

            return true;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            edtDesc.Text = edtDesc.Text.Trim();
            edtUsername.Text = edtUsername.Text.Trim();
            edtPassword.Text = edtPassword.Text.Trim();
            edtHost.Text = edtHost.Text.Trim();
            edtDatabase.Text = edtDatabase.Text.Trim();

            UpdateConnStr();

            if (DoValidate() == false)
            {
                this.DialogResult = DialogResult.None;

                edtDesc.Focus();
                edtDesc.SelectAll();
            }
            else
            {
                if (zMyMode == 0)
                {
                    //Add the connection
                    SE.AddConnection(edtDesc.Text, edtType.SelectedIndex, edtUsername.Text, edtPassword.Text, edtHost.Text, (int)edtPort.Value, edtDatabase.Text, edtConnString.Text);
                }

                if (zMyMode == 1)
                {
                    //Update the connection
                    SE.UpdateConnection(zOldDesc, edtDesc.Text, edtType.SelectedIndex, edtUsername.Text, edtPassword.Text, edtHost.Text, (int)edtPort.Value, edtDatabase.Text, edtConnString.Text);


                    //*|*|
                    //if ((SE.GetSetting("VISIONCONN") == OldDesc) && (SE.GetSetting("VISIONCONN").Length > 0))
                    //{
                    //    SE.WriteSetting("VISIONCONN", edtDesc.Text);
                    //}

                    //if ((SE.GetSetting("SAPCONN") == OldDesc) && (SE.GetSetting("SAPCONN").Length > 0))
                    //{
                    //    SE.WriteSetting("SAPCONN", edtDesc.Text);
                    //}

                    //if ((SE.GetSetting("RDPCONN") == OldDesc) && (SE.GetSetting("RDPCONN").Length > 0))
                    //{
                    //    SE.WriteSetting("RDPCONN", edtDesc.Text);
                    //}
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SqlConnection TestConn = new SqlConnection(edtConnString.Text);

            try
            {
                TestConn.Open();

                XtraMessageBox.Show("Success", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show("Error:" + Environment.NewLine + Environment.NewLine + Ex.Message, "Result", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}