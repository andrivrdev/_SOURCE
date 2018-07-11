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
    public partial class devGroupBoxTop : DevExpress.XtraEditors.XtraUserControl
    {
        public string devCaption
        {
            get
            {
                return lblCaption.Text;
            }
            set
            {
                lblCaption.Text = value;
            }
        }

        public Color devCaptionGradientColor
        {
            get
            {
                return lblCaption.Appearance.BackColor2;
            }
            set
            {
                lblCaption.Appearance.BackColor2 = value;
            }
        }

        public Color devLineColor1
        {
            get
            {
                return pnlColor.Appearance.BackColor;
            }
            set
            {
                pnlColor.Appearance.BackColor = value;
            }
        }

        public Color devLineColor2
        {
            get
            {
                return pnlColor.Appearance.BackColor2;
            }
            set
            {
                pnlColor.Appearance.BackColor2 = value;
            }
        }

        public devGroupBoxTop()
        {
            InitializeComponent();
        }
    }
}
