using DevExpress.XtraEditors;
using QBook.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QBook.Forms
{
    public partial class frmPropertyDetails : DevExpress.XtraEditors.XtraForm
    {
        int zMyMode;
        int zID;

        public frmPropertyDetails(int xMode, int xID)
        {
            InitializeComponent();

            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            zMyMode = xMode;
            zID = xID;

            //Add
            if (zMyMode == 0)
            {
                edtProperty.Text = "";

                this.Text = "New Property Details";

                edtProperty.Focus();
            }

            //Edit
            if (zMyMode == 1)
            {
                this.Text = "Edit Proprty Details";

                edtProperty.Focus();
            }
        }

        private bool ValidationSuccess()
        {
            tblProperty xtblProperty = new tblProperty();

            if (zMyMode == 0)
            {
                //Check if record exist
                var rows = xtblProperty.dtProperty.AsEnumerable().Where(r => r.Field<string>("Property") == edtProperty.Text);

                if (rows.Count() == 1)
                {
                    XtraMessageBox.Show("This record already exist.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return false;
                }
            }
            else
            {
                //Check if record exist
                var rows = xtblProperty.dtProperty.AsEnumerable().Where(r => (r.Field<string>("Property") == edtProperty.Text) && (r.Field<int>("ID") != zID));

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
            edtProperty.Text = edtProperty.Text.Trim();


            if (ValidationSuccess() == false)
            {
                this.DialogResult = DialogResult.None;

                edtProperty.Focus();
                edtProperty.SelectAll();
            }
            else
            {
                List<string> fFields = new List<string>();
                List<string> vValues = new List<string>();

                fFields.Add("Property");

                vValues.Add(edtProperty.Text);

                if (zMyMode == 0)
                {
                    //Add the record
                    clsHelper.InsertRec("tblProperty", fFields, vValues);
                }

                if (zMyMode == 1)
                {
                    //Update the record
                    clsHelper.UpdateRec("tblProperty", fFields, vValues, "[ID] = '" + zID + "'");
                }
            }
        }
    }
}
