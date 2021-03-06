﻿using Newtonsoft.Json;
using Shared.CLASSES;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TESTING_WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            try
            {
                clsSE xclsSE = new clsSE();
                var xresult = xclsSE.Send("frmRegister_RegisterUser", edtData.Text);
                edtResult.Text = xresult;
                xresult = xclsSE.DecodeMessage(xresult);

                if (xresult.Contains("Success" + clsGlobal.gMessageCommandSeperator))
                {
                    var xMessage = xresult.Replace("Success" + clsGlobal.gMessageCommandSeperator, "");
                    var dData = JsonConvert.DeserializeObject<List<string>>(xMessage);

                    string xLines = "";
                    foreach (var xLine in dData)
                    {
                        xLines += xLine + Environment.NewLine;
                    }

                    //XtraMessageBox.Show(xLines, "Account Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception Ex)
            {
                edtResult.Text = Ex.Message;
            }
        }

   

        private void btnEnc01_Click(object sender, EventArgs e)
        {
            try
            {
                clsSE xclsSE = new clsSE();
                edtEncDec02.Text = xclsSE.EncodeMessage(edtEncodingCommand.Text, edtEncDec01.Text);

            }
            catch (Exception Ex)
            {
                edtEncDec02.Text = Ex.Message;
            }
        }

        private void btnEnc02_Click(object sender, EventArgs e)
        {
            try
            {
                clsSE xclsSE = new clsSE();
                edtEncDec01.Text = xclsSE.EncodeMessage(edtEncodingCommand.Text, edtEncDec02.Text);

            }
            catch (Exception Ex)
            {
                edtEncDec01.Text = Ex.Message;
            }

        }

        private void btnDec01_Click(object sender, EventArgs e)
        {
            try
            {
                clsSE xclsSE = new clsSE();
                edtEncDec02.Text = xclsSE.DecodeMessage(edtEncDec01.Text);

            }
            catch (Exception Ex)
            {
                edtEncDec02.Text = Ex.Message;
            }
        }

        private void btnDec02_Click(object sender, EventArgs e)
        {

            try
            {
                clsSE xclsSE = new clsSE();
                edtEncDec01.Text = xclsSE.DecodeMessage(edtEncDec02.Text);

            }
            catch (Exception Ex)
            {
                edtEncDec01.Text = Ex.Message;
            }


        }
    }
}
