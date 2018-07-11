using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                if (CheckWall(pnlBlock, "Left"))
                {
                    pnlBlock.Left = pnlBlock.Left - 5;
                }
            }

            if (e.KeyCode == Keys.Right)
            {
                pnlBlock.Left = pnlBlock.Left + 5;
            }

            if (e.KeyCode == Keys.Up)
            {
                pnlBlock.Top = pnlBlock.Top - 5;
            }

            if (e.KeyCode == Keys.Down)
            {
                pnlBlock.Top = pnlBlock.Top + 5;
            }
        }

        private bool CheckWall(DevExpress.XtraEditors.PanelControl xMyPanel, string xDirection)
        {
            if (xDirection == "Left")
            {
                if (xMyPanel.Right >= pnlWall.Right)
                {
                    if ((xMyPanel.Bottom >= pnlWall.Top) && (xMyPanel.Top <= pnlWall.Bottom))
                    {
                        if (xMyPanel.Left - 1 <= pnlWall.Right)
                        {
                            return false;
                        }
                    }
                }
            }

            return true;




        }

    }
}
