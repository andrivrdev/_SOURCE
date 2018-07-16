using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace QBook.Forms
{
    public partial class frmAbout : DevExpress.XtraEditors.XtraForm
    {
        public frmAbout()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            while (this.Controls.Count > 1)
            {
                foreach (Control c in this.Controls)
                {
                    if (c.GetType() == typeof(Label))
                    {
                        var pos = this.PointToScreen(c.Location);
                        pos = imgLogo.PointToClient(pos);
                        c.Parent = imgLogo;
                        c.Location = pos;
                        c.BackColor = Color.Transparent;
                    }
                }
            }
        }
    }
}