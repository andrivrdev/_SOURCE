using DevExpress.XtraEditors;
using DevExpress.XtraMap;
using Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapViewer
{
    public partial class frmMain : DevExpress.XtraEditors.XtraForm
    {
        public frmMain()
        {
            InitializeComponent();

            clsSQLiteDB.CustomConn(@"C:\_SOURCE\_SOURCE\_REST_SQLITE_MAPS\RestMaps\RestAPI\bin\Debug\net5.0\Database\Database.dat");
            clsSQLiteDB.Connect();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var xData = clsSQLiteDB.sqlGetTableRecs("tblLocation", "");
            gridControl1.DataSource = xData;
            //gridView1.Columns.A

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            mapItemStorage1.Items.Clear();

            var xData = new DataTable();
            xData = clsSQLiteDB.sqlGetTableRecs("tblLocation", "");

            foreach (DataRow dr in xData.Rows)
            {
                mapItemStorage1.Items.Add(new MapPushpin() { Location = new GeoPoint(Convert.ToDouble(dr["Latitude"].ToString()), Convert.ToDouble(dr["Longitude"].ToString())) });
            }

            gridControl1.DataSource = clsSQLiteDB.sqlGetTableRecs("tblLocation", "");

        }
    }
}