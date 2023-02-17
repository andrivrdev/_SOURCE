using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grid
{
    public partial class frmMain : DevExpress.XtraEditors.XtraForm
    {
        public frmMain()
        {
            InitializeComponent();

            this.AllowDrop = true;
            this.DragEnter += new DragEventHandler(Form1_DragEnter);
            this.DragDrop += new DragEventHandler(Form1_DragDrop);
        }

        void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                string[] str = File.ReadAllLines(file);
                string[] strnew = new string[str.Length];

                int c = 0;
                foreach (string str2 in str)
                {
                    strnew[c] = str2.Replace(",", "");
                        c = c + 1;
                }


                // create new datatable
                DataTable dt = new DataTable();

                // get the column header means first line
                string[] temp = str[0].Split(',');

                // creates columns of gridview as per the header name
                foreach (string t in temp)
                {
                    dt.Columns.Add(t, typeof(string));
                }

                // now retrive the record from second line and add it to datatable
                for (int i = 1; i < str.Length; i++)
                {
                    string[] t = str[i].Split(',');
                    dt.Rows.Add(t);

                }

                // assign gridview datasource property by datatable
                gridControl1.DataSource = dt;

                gridView1.BestFitColumns();
                // bind the gridview

            }

        }





    }
}