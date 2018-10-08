using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClientDataTest.DATA;
using ClientDataTest.CLASSES;


namespace ClientDataTest
{
    public partial class frmMain : Form
    {
        tblClient ztblClient = new tblClient();
        DataTable zData = new DataTable();

        public frmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int xRecCount;
            if (int.TryParse(edtRecCount.Text, out xRecCount))
            {
                zData = new DataTable();
                zData = devGeneral.BindingListToDataTable(ztblClient.GenerateData(xRecCount));

                dataGridView1.DataSource = zData;
                FixCols1();
            }
        }

        private void FixCols1()
        {
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                if ((dataGridView1.Columns[i].HeaderText == "IDX") || (dataGridView1.Columns[i].HeaderText == "IsValid"))
                {
                    dataGridView1.Columns[i].ReadOnly = true;
                    dataGridView1.Columns[i].DefaultCellStyle.ForeColor = Color.Red;
                }
            }
        }

        private void FixCols2()
        {
            for (int i = 0; i < dataGridView2.ColumnCount; i++)
            {
                if ((dataGridView2.Columns[i].HeaderText == "IDX"))
                {
                    dataGridView2.Columns[i].Visible = false;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            devCSV xCSV = new devCSV();
            xCSV.SaveData(zData);

            devJSON xJSON = new devJSON();
            xJSON.SaveData(zData);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            devJSON xJSON = new devJSON();

            zData = xJSON.LoadData();
            dataGridView1.DataSource = zData;
            FixCols1();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            devCSV xCSV = new devCSV();

            zData = xCSV.LoadData();
            dataGridView1.DataSource = zData;
            FixCols1();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            tblDataMap.PopulateDataMap();
            dataGridView2.DataSource = tblDataMap.zDataMap;
            FixCols2();
        }
    }
}
