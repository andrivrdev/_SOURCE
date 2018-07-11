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

namespace devGeneric.devControls
{
    public partial class devLoading : DevExpress.XtraEditors.XtraUserControl
    {
        public string devCaption1
        {
            get
            {
                UpdateControl();
                return progressPanel1.Caption;
            }
            set
            {
                progressPanel1.Caption = value;
                UpdateControl();
            }
        }

        public string devCaption2
        {
            get
            {
                UpdateControl();
                return progressPanel1.Description;
            }
            set
            {
                progressPanel1.Description = value;
                UpdateControl();
            }
        }

        public devLoading()
        {
            InitializeComponent();
        }

        private void devLoading_ClientSizeChanged(object sender, EventArgs e)
        {
            UpdateControl();
        }



        private void UpdateControl()
        {
            labelControl1.Text = progressPanel1.Caption;
            labelControl2.Text = progressPanel1.Description;

            int MyMax = 0;
            if (labelControl1.Width > MyMax)
            {
                MyMax = labelControl1.Width;
            }

            if (labelControl2.Width > MyMax)
            {
                MyMax = labelControl2.Width;
            }

            progressPanel1.Width = MyMax + 71;

            double A = this.Width / 2;
            double B = progressPanel1.Width / 2;

            progressPanel1.Left = Convert.ToInt32(Math.Round(A) - (Math.Round(B)));

            A = this.Height / 2;
            B = progressPanel1.Height / 2;

            progressPanel1.Top = Convert.ToInt32(Math.Round(A) - (Math.Round(B)));
        }

    }
}
