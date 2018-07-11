using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using devGeneric.devClasses.devStatic;

namespace devGeneric.devControls
{
    public partial class devStatusBar : DevExpress.XtraEditors.XtraUserControl
    {
        public string MyLBLMain = "";
        public string MyLBLSub = "";

        public devStatusBar()
        {
            InitializeComponent();
        }

        public void SetText(string MyText)
        {
            lblStatus.Text = MyText;
            lblStatus.Visible = true;
        }

        public void SetPBText(int MyProgressBar, string MyText)
        {
            switch (MyProgressBar)
            {
                case 1:
                    {
                        MyLBLSub = MyText;

                        Application.DoEvents();
                        break;
                    }

                default:
                    {
                        MyLBLMain = MyText;

                        Application.DoEvents();
                        break;
                    }
            }
        }

        public void pbDoInit(int MyProgressBar, int MyMax)
        {
            switch (MyProgressBar)
            {
                case 1:
                    {
                        pbSub.Properties.Minimum = 0;
                        pbSub.Properties.Maximum = MyMax;

                        if (MyLBLSub == "")
                        {
                            lblSub.Text = "Processing...";
                        }
                        else
                        {
                            lblSub.Text = MyLBLSub;
                        }

                        lblSub.ForeColor = Color.Red;
                        lblSub.Visible = true;

                        pbSub.Position = 0;
                        pbSub.Visible = true;

                        Application.DoEvents();
                        break;
                    }

                default:
                    {
                        pbMain.Properties.Minimum = 0;
                        pbMain.Properties.Maximum = MyMax;

                        if (MyLBLMain == "")
                        {
                            lblMain.Text = "Processing...";
                        }
                        else
                        {
                            lblMain.Text = MyLBLMain;
                        }

                        lblMain.ForeColor = Color.Red;
                        lblMain.Visible = true;

                        pbMain.Position = 0;
                        pbMain.Visible = true;

                        Application.DoEvents();
                        break;
                    }
            }

            Application.DoEvents();
        }

        public void pbDoFinal(int MyProgressBar)
        {
            switch (MyProgressBar)
            {
                case 1:
                    {
                        pbSub.Properties.Minimum = 0;
                        pbSub.Properties.Maximum = 1;

                        if (MyLBLSub == "")
                        {
                            lblSub.Text = "Ready";
                        }
                        else
                        {
                            lblSub.Text = MyLBLSub;
                        }

                        lblSub.Text = "Ready";

                        lblSub.ForeColor = Color.Chartreuse;
                        lblSub.Visible = true;

                        pbSub.Position = 1;
                        pbSub.Visible = true;

                        Application.DoEvents();
                        break;
                    }

                default:
                    {
                        pbMain.Properties.Minimum = 0;
                        pbMain.Properties.Maximum = 1;

                        if (MyLBLMain == "")
                        {
                            lblMain.Text = "Ready";
                        }
                        else
                        {
                            lblMain.Text = MyLBLMain;
                        }

                        lblMain.Text = "Ready";

                        lblMain.ForeColor = Color.Chartreuse;
                        lblMain.Visible = true;

                        pbMain.Position = 1;
                        pbMain.Visible = true;

                        Application.DoEvents();
                        break;
                    }
            }

            Application.DoEvents();
        }

        public void pbDoMove(int MyProgressBar)
        {
            switch (MyProgressBar)
            {
                case 1:
                    {
                        if (MyLBLSub != "")
                        {
                            lblSub.Text = MyLBLSub;
                        }

                        lblSub.ForeColor = Color.Red;
                        lblSub.Visible = true;

                        pbSub.Position = pbSub.Position + 1;
                        pbSub.Visible = true;

                        Application.DoEvents();
                        break;
                    }

                default:
                    {
                        if (MyLBLMain != "")
                        {
                            lblMain.Text = MyLBLMain;
                        }

                        lblMain.ForeColor = Color.Red;
                        lblMain.Visible = true;

                        pbMain.Position = pbMain.Position + 1;
                        pbMain.Visible = true;

                        Application.DoEvents();
                        break;
                    }
            }

            Application.DoEvents();
        }

        public void pbDoProgress(int MyProgressBar, int MyMax, int MyProgress)
        {
            if (MyMax == MyProgress)
            {
                pbDoFinal(MyProgressBar);
            }
            else
            {

                switch (MyProgressBar)
                {
                    case 1:
                        {
                            pbSub.Properties.Minimum = 0;
                            pbSub.Properties.Maximum = MyMax;

                            if (MyLBLSub != "")
                            {
                                lblSub.Text = MyLBLSub;
                            }

                            lblSub.ForeColor = Color.Red;
                            lblSub.Visible = true;

                            pbSub.Position = MyProgress;
                            pbSub.Visible = true;

                            Application.DoEvents();
                            break;
                        }

                    default:
                        {
                            pbMain.Properties.Minimum = 0;
                            pbMain.Properties.Maximum = MyMax;

                            if (MyLBLMain != "")
                            {
                                lblMain.Text = MyLBLMain;
                            }

                            lblMain.ForeColor = Color.Red;
                            lblMain.Visible = true;

                            pbMain.Position = MyProgress;
                            pbMain.Visible = true;

                            Application.DoEvents();
                            break;
                        }
                }
            }

            Application.DoEvents();
        }

        public void pbDoHide(int MyProgressBar, int xZeroIsBarOneIsText)
        {
            if (MyProgressBar == 1)
            {
                if (xZeroIsBarOneIsText == 1)
                {
                    lblSub.Visible = false;
                }
                else
                {
                    pbSub.Visible = false;
                }
            }
            else
            {
                if (xZeroIsBarOneIsText == 1)
                {
                    lblMain.Visible = false;
                }
                else
                {
                    pbMain.Visible = false;
                }
            }

            Application.DoEvents();
        }

        public void pbDoShowVer()
        {
            lblSub.Left = lblSub.Left - 90;
            lblMain.Left = lblMain.Left - 90;
            lblThread.Left = lblThread.Left - 90;
            lblSplit1.Left = lblSplit1.Left - 90;
            lblSplit2.Left = lblSplit2.Left - 90;

            pbSub.Left = pbSub.Left - 90;
            pbMain.Left = pbMain.Left - 90;

            lblVer.Text = devGlobals.gVersion;
            lblVer.Visible = true;
            Application.DoEvents();
        }

        public void pbDoThread(int xSec)
        {
            if (xSec > 0)
            {
                lblThread.Text = xSec.ToString();
                lblThread.ForeColor = Color.Chartreuse;
            }
            else
            {
                lblThread.Text = "Busy";
                lblThread.ForeColor = Color.Red;
            }

            lblThread.Visible = true;
            lblSplit1.Visible = true;
            lblSplit2.Visible = true;

            Application.DoEvents();
        }




        private void lblStatus_Click(object sender, EventArgs e)
        {

        }
    }
}
