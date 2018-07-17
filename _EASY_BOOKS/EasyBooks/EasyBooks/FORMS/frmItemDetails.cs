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
using EasyBooks.CLASSES;
using EasyBooks.DATA;

namespace EasyBooks.FORMS
{
    public partial class frmItemDetails : DevExpress.XtraEditors.XtraForm
    {
        int zMyMode;
        int zID;

        public frmItemDetails(int xMode, int xID)
        {
            InitializeComponent();

            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            zMyMode = xMode;
            zID = xID;

            //Add
            if (zMyMode == 0)
            {
                edtItem.Text = "";

                this.Text = "New Item Details";

                edtItem.Focus();
            }

            //Edit
            if (zMyMode == 1)
            {
                this.Text = "Edit Item Details";

                edtItem.Focus();
            }
        }

        private bool ValidationSuccess()
        {
            //CHeck if all required fields are populated
            if (edtItem.Text == "")
            {
                XtraMessageBox.Show("Item field is required.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }

            tblItem xtblItem = new tblItem();

            if (zMyMode == 0)
            {
                //Check if record exist
                var rows = xtblItem.dtItem.AsEnumerable().Where(r => r.Field<string>("Item") == edtItem.Text);

                if (rows.Count() == 1)
                {
                    XtraMessageBox.Show("This record already exist.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return false;
                }
            }
            else
            {
                //Check if record exist
                var rows = xtblItem.dtItem.AsEnumerable().Where(r => (r.Field<string>("Item") == edtItem.Text) && (r.Field<int>("ID") != zID));

                if (rows.Count() == 1)
                {
                    XtraMessageBox.Show("This record already exist.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return false;
                }
            }

            return true;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            edtItem.Text = edtItem.Text.Trim();


            if (ValidationSuccess() == false)
            {
                this.DialogResult = DialogResult.None;

                edtItem.Focus();
                edtItem.SelectAll();
            }
            else
            {
                List<string> fFields = new List<string>();
                List<string> vValues = new List<string>();

                fFields.Add("Item");

                vValues.Add(edtItem.Text);

                if (zMyMode == 0)
                {
                    //Add the record
                    clsHelper.InsertRec("tblItem", fFields, vValues);
                }

                if (zMyMode == 1)
                {
                    //Update the record
                    clsHelper.UpdateRec("tblItem", fFields, vValues, "[ID] = '" + zID + "'");
                }
            }
        }
    }
}