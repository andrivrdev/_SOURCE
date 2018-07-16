using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
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
    public partial class frmProperty : DevExpress.XtraEditors.XtraForm
    {
        double zpnlLeft = 0;
        double zpnlRight = 0;
        double zpnlBottom = 0;

        public frmProperty()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            grdPATMoneyInView.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "Amount", colInAmount, "{0:c2}");
            grdPATMoneyInView.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "Variance", colInVariance, "{0:c2}");
            grdPATMoneyOutView.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "Amount", colOutAmount, "{0:c2}");
        }

        private void LoadProperty()
        {
            tblProperty xtblProperty = new tblProperty();
            grdProperty.DataSource = xtblProperty.dtProperty;

            grdPropertyView.BestFitColumns();
        }

        private void frmProperty_Shown(object sender, EventArgs e)
        {
            pnlLeft.SplitterPosition = Convert.ToInt32(Math.Round(Screen.PrimaryScreen.WorkingArea.Height * (1.0 / 4.0 * 2.5), 0));

            double xHeight = Screen.PrimaryScreen.WorkingArea.Height;
            double xPosition = pnlLeft.SplitterPosition;
            double x = xPosition / xHeight;
            zpnlLeft = x;

            pnlRight.SplitterPosition = Convert.ToInt32(Math.Round(pnlRight.Width / 2.0));
            double xWidth = pnlRight.Width;
            xPosition = pnlRight.SplitterPosition;
            x = xPosition / xWidth;
            zpnlRight = x;

            pnlBottom.SplitterPosition = Convert.ToInt32(Math.Round(groupControl2.Width / 2.0));
            xWidth = pnlBottom.Width;
            xPosition = pnlBottom.SplitterPosition;
            x = xPosition / xWidth;
            zpnlBottom = x;

            timLoad.Start();
        }

        private void timLoad_Tick(object sender, EventArgs e)
        {
            timLoad.Stop();

            //Load data
            LoadProperty();
            LoadPropertyAccount();
            LoadPropertyAccountTransaction();
        }

        private void grdPropertyView_DoubleClick(object sender, EventArgs e)
        {
            DoEditProperty();
        }

        private void DoEditProperty()
        {
            if (grdPropertyView.RowCount > 0)
            {
                frmPropertyDetails MyForm;

                MyForm = new frmPropertyDetails(1, Convert.ToInt32(grdPropertyView.GetFocusedRowCellValue("ID").ToString()));

                MyForm.edtProperty.Text = grdPropertyView.GetFocusedRowCellValue("Property").ToString();

                if (MyForm.ShowDialog() == DialogResult.OK)
                {
                    int xID = Convert.ToInt32(grdPropertyView.GetFocusedRowCellValue("ID").ToString());

                    LoadProperty();

                    int rowHandle = grdPropertyView.LocateByValue("ID", xID);
                    if (rowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                    {
                        grdPropertyView.FocusedRowHandle = rowHandle;
                    }

                    LoadPropertyAccount();
                    LoadPropertyAccountTransaction();
                }
            }
            else
            {
                XtraMessageBox.Show("Please select a valid record first.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnAddProperty_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmPropertyDetails MyForm;

            MyForm = new frmPropertyDetails(0, 0);

            if (MyForm.ShowDialog() == DialogResult.OK)
            {
                LoadProperty();

                int rowHandle = grdPropertyView.LocateByValue("ID", clsHelper.GetLastRecID("tblProperty"));
                if (rowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                {
                    grdPropertyView.FocusedRowHandle = rowHandle;
                }

                LoadPropertyAccount();
                LoadPropertyAccountTransaction();
            }
        }

        private void btnEditProperty_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            DoEditProperty();
        }

        private void btnRemoveProperty_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (grdPropertyView.RowCount > 0)
            {
                if (XtraMessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    clsHelper.DeleteRecByID("tblProperty", Convert.ToInt32(grdPropertyView.GetFocusedRowCellValue("ID").ToString()));

                    LoadProperty();
                }

                LoadPropertyAccount();
                LoadPropertyAccountTransaction();
            }
            else
            {
                XtraMessageBox.Show("Please select a valid record first.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void LoadPropertyAccount()
        {
            tblPropertyAccount xtblPropertyAccount = new tblPropertyAccount();

            DataTable xdtPropertyAccountMoneyIn = xtblPropertyAccount.dtPropertyAccountMoneyIn.Clone();
            DataTable xdtPropertyAccountMoneyOut = xtblPropertyAccount.dtPropertyAccountMoneyOut.Clone();

            foreach(DataRow ARec in xtblPropertyAccount.dtPropertyAccountMoneyIn.Rows)
            {
                if (ARec["tblPropertyID"].ToString() == grdPropertyView.GetFocusedRowCellValue("ID").ToString())
                {
                    xdtPropertyAccountMoneyIn.ImportRow(ARec);
                }
            }

            foreach (DataRow ARec in xtblPropertyAccount.dtPropertyAccountMoneyOut.Rows)
            {
                if (ARec["tblPropertyID"].ToString() == grdPropertyView.GetFocusedRowCellValue("ID").ToString())
                {
                    xdtPropertyAccountMoneyOut.ImportRow(ARec);
                }
            }

            grdPropertyAccountMoneyIn.DataSource = xdtPropertyAccountMoneyIn;
            grdPropertyAccountMoneyOut.DataSource = xdtPropertyAccountMoneyOut;

            grdPropertyAccountMoneyInView.BestFitColumns();
            grdPropertyAccountMoneyOutView.BestFitColumns();
        }

        private void btnAddMoneyInAccount_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (grdPropertyView.RowCount > 0)
            {
                tblAccount xtblAccount = new tblAccount();
                var rows = xtblAccount.dtAccount.AsEnumerable().Where(r => (r.Field<string>("IO") == "I"));

                if (rows.Count() == 0)
                {
                    XtraMessageBox.Show("Please create some Money In Accounts first.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                frmPropertyAccountDetails MyForm;

                MyForm = new frmPropertyAccountDetails(0, 0, Convert.ToInt32(grdPropertyView.GetFocusedRowCellValue("ID").ToString()));
                MyForm.edtProperty.Text = grdPropertyView.GetFocusedRowCellValue("Property").ToString();
                MyForm.edtAccountType.Text = "Money In";

                foreach (DataRow ARec in xtblAccount.dtAccount.Rows)
                {
                    if (ARec["IO"].ToString() == "I")
                    {
                        MyForm.edtAccount.Properties.Items.Add(ARec["Name"]);
                    }
                }

                if (MyForm.ShowDialog() == DialogResult.OK)
                {
                    LoadPropertyAccount();

                    int rowHandle = grdPropertyAccountMoneyInView.LocateByValue("ID", clsHelper.GetLastRecID("tblPropertyAccount"));
                    if (rowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                    {
                        grdPropertyAccountMoneyInView.FocusedRowHandle = rowHandle;
                    }

                    LoadPropertyAccountTransaction();
                }
            }
            else
            {
                XtraMessageBox.Show("Please create a Property first.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void grdPropertyView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                DoEditProperty();
            }
        }

        private void btnAddMoneyOutAccount_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (grdPropertyView.RowCount > 0)
            {
                tblAccount xtblAccount = new tblAccount();
                var rows = xtblAccount.dtAccount.AsEnumerable().Where(r => (r.Field<string>("IO") == "O"));

                if (rows.Count() == 0)
                {
                    XtraMessageBox.Show("Please create some Money Out Accounts first.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                frmPropertyAccountDetails MyForm;

                MyForm = new frmPropertyAccountDetails(0, 0, Convert.ToInt32(grdPropertyView.GetFocusedRowCellValue("ID").ToString()));
                MyForm.edtProperty.Text = grdPropertyView.GetFocusedRowCellValue("Property").ToString();
                MyForm.edtAccountType.Text = "Money Out";

                foreach (DataRow ARec in xtblAccount.dtAccount.Rows)
                {
                    if (ARec["IO"].ToString() == "O")
                    {
                        MyForm.edtAccount.Properties.Items.Add(ARec["Name"]);
                    }
                }

                if (MyForm.ShowDialog() == DialogResult.OK)
                {
                    LoadPropertyAccount();

                    int rowHandle = grdPropertyAccountMoneyOutView.LocateByValue("ID", clsHelper.GetLastRecID("tblPropertyAccount"));
                    if (rowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                    {
                        grdPropertyAccountMoneyOutView.FocusedRowHandle = rowHandle;
                    }

                    LoadPropertyAccountTransaction();
                }
            }
            else
            {
                XtraMessageBox.Show("Please create a Property first.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnEditMoneyInAccount_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            DoEditPropertyMoneyInAccount();
        }

        private void DoEditPropertyMoneyInAccount()
        {
            if (grdPropertyAccountMoneyInView.RowCount > 0)
            {
                frmPropertyAccountDetails MyForm;

                MyForm = new frmPropertyAccountDetails(1, Convert.ToInt32(grdPropertyAccountMoneyInView.GetFocusedRowCellValue("ID").ToString()), Convert.ToInt32(grdPropertyView.GetFocusedRowCellValue("ID").ToString()));
                MyForm.edtProperty.Text = grdPropertyView.GetFocusedRowCellValue("Property").ToString();
                MyForm.edtAccountType.Text = "Money In";

                tblAccount xtblAccount = new tblAccount();
                foreach (DataRow ARec in xtblAccount.dtAccount.Rows)
                {
                    if (ARec["IO"].ToString() == "I")
                    {
                        MyForm.edtAccount.Properties.Items.Add(ARec["Name"]);
                    }
                }

                MyForm.edtAccount.Text = grdPropertyAccountMoneyInView.GetFocusedRowCellValue("Name").ToString();

                if (MyForm.ShowDialog() == DialogResult.OK)
                {
                    int xIDIn = Convert.ToInt32(grdPropertyAccountMoneyInView.GetFocusedRowCellValue("ID").ToString());
                    int xIDOut = Convert.ToInt32(grdPropertyAccountMoneyOutView.GetFocusedRowCellValue("ID").ToString());
                    int xIDInPAT = Convert.ToInt32(grdPATMoneyInView.GetFocusedRowCellValue("ID").ToString());
                    int xIDOutPAT = Convert.ToInt32(grdPATMoneyOutView.GetFocusedRowCellValue("ID").ToString());

                    LoadPropertyAccount();

                    int rowHandleIn = grdPropertyAccountMoneyInView.LocateByValue("ID", xIDIn);
                    int rowHandleOut = grdPropertyAccountMoneyOutView.LocateByValue("ID", xIDOut);

                    if (rowHandleIn != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                    {
                        grdPropertyAccountMoneyInView.FocusedRowHandle = rowHandleIn;
                    }

                    if (rowHandleOut != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                    {
                        grdPropertyAccountMoneyOutView.FocusedRowHandle = rowHandleOut;
                    }

                    LoadPropertyAccountTransaction();

                    int rowHandleInPAT = grdPATMoneyInView.LocateByValue("ID", xIDInPAT);
                    int rowHandleOutPAT = grdPATMoneyOutView.LocateByValue("ID", xIDOutPAT);

                    if (rowHandleInPAT != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                    {
                        grdPATMoneyInView.FocusedRowHandle = rowHandleInPAT;
                    }

                    if (rowHandleOutPAT != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                    {
                        grdPATMoneyOutView.FocusedRowHandle = rowHandleOutPAT;
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("Please select a valid record first.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void grdPropertyAccountMoneyInView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                DoEditPropertyMoneyInAccount();
            }
        }

        private void btnEditMoneyOutAccount_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            DoEditPropertyMoneyOutAccount();
        }

        private void grdPropertyAccountMoneyInView_DoubleClick(object sender, EventArgs e)
        {
            DoEditPropertyMoneyInAccount();
        }

        private void DoEditPropertyMoneyOutAccount()
        {
            if (grdPropertyAccountMoneyOutView.RowCount > 0)
            {
                frmPropertyAccountDetails MyForm;

                MyForm = new frmPropertyAccountDetails(1, Convert.ToInt32(grdPropertyAccountMoneyOutView.GetFocusedRowCellValue("ID").ToString()), Convert.ToInt32(grdPropertyView.GetFocusedRowCellValue("ID").ToString()));
                MyForm.edtProperty.Text = grdPropertyView.GetFocusedRowCellValue("Property").ToString();
                MyForm.edtAccountType.Text = "Money Out";

                tblAccount xtblAccount = new tblAccount();
                foreach (DataRow ARec in xtblAccount.dtAccount.Rows)
                {
                    if (ARec["IO"].ToString() == "O")
                    {
                        MyForm.edtAccount.Properties.Items.Add(ARec["Name"]);
                    }
                }

                MyForm.edtAccount.Text = grdPropertyAccountMoneyOutView.GetFocusedRowCellValue("Name").ToString();

                if (MyForm.ShowDialog() == DialogResult.OK)
                {
                    int xIDIn = Convert.ToInt32(grdPropertyAccountMoneyInView.GetFocusedRowCellValue("ID").ToString());
                    int xIDOut = Convert.ToInt32(grdPropertyAccountMoneyOutView.GetFocusedRowCellValue("ID").ToString());
                    int xIDInPAT = Convert.ToInt32(grdPATMoneyInView.GetFocusedRowCellValue("ID").ToString());
                    int xIDOutPAT = Convert.ToInt32(grdPATMoneyOutView.GetFocusedRowCellValue("ID").ToString());

                    LoadPropertyAccount();

                    int rowHandleIn = grdPropertyAccountMoneyInView.LocateByValue("ID", xIDIn);
                    int rowHandleOut = grdPropertyAccountMoneyOutView.LocateByValue("ID", xIDOut);

                    if (rowHandleIn != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                    {
                        grdPropertyAccountMoneyInView.FocusedRowHandle = rowHandleIn;
                    }

                    if (rowHandleOut != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                    {
                        grdPropertyAccountMoneyOutView.FocusedRowHandle = rowHandleOut;
                    }

                    LoadPropertyAccountTransaction();

                    int rowHandleInPAT = grdPATMoneyInView.LocateByValue("ID", xIDInPAT);
                    int rowHandleOutPAT = grdPATMoneyOutView.LocateByValue("ID", xIDOutPAT);

                    if (rowHandleInPAT != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                    {
                        grdPATMoneyInView.FocusedRowHandle = rowHandleInPAT;
                    }

                    if (rowHandleOutPAT != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                    {
                        grdPATMoneyOutView.FocusedRowHandle = rowHandleOutPAT;
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("Please select a valid record first.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void grdPropertyAccountMoneyOutView_DoubleClick(object sender, EventArgs e)
        {
            DoEditPropertyMoneyOutAccount();
        }

        private void grdPropertyView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            LoadPropertyAccount();
            LoadPropertyAccountTransaction();
        }

        private void grdPropertyAccountMoneyOutView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                DoEditPropertyMoneyOutAccount();
            }
        }

        private void btnRemoveMoneyInAccount_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (grdPropertyAccountMoneyInView.RowCount > 0)
            {
                if (XtraMessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    clsHelper.DeleteRecByID("tblPropertyAccount", Convert.ToInt32(grdPropertyAccountMoneyInView.GetFocusedRowCellValue("ID").ToString()));

                    LoadPropertyAccount();
                    LoadPropertyAccountTransaction();
                }
            }
            else
            {
                XtraMessageBox.Show("Please select a valid record first.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnRemoveMoneyOutAccount_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (grdPropertyAccountMoneyOutView.RowCount > 0)
            {
                if (XtraMessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    clsHelper.DeleteRecByID("tblPropertyAccount", Convert.ToInt32(grdPropertyAccountMoneyOutView.GetFocusedRowCellValue("ID").ToString()));

                    LoadPropertyAccount();
                    LoadPropertyAccountTransaction();
                }
            }
            else
            {
                XtraMessageBox.Show("Please select a valid record first.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void AfterSize()
        {
            pnlLeft.SplitterPosition = Convert.ToInt32(Math.Round(this.Height * zpnlLeft, 0));
            pnlRight.SplitterPosition = Convert.ToInt32(Math.Round(pnlRight.Width * zpnlRight, 0));
            pnlBottom.SplitterPosition = Convert.ToInt32(Math.Round(groupControl2.Width * zpnlBottom, 0));

            grdPropertyView.BestFitColumns();
            grdPropertyAccountMoneyInView.BestFitColumns();
            grdPropertyAccountMoneyOutView.BestFitColumns();
            grdPATMoneyInView.BestFitColumns();
            grdPATMoneyOutView.BestFitColumns();
        }

        private void frmProperty_SizeChanged(object sender, EventArgs e)
        {
            AfterSize();
        }

        private void pnlLeft_SplitterPositionChanged(object sender, EventArgs e)
        {
            double xHeight = this.Height;
            double xPosition = pnlLeft.SplitterPosition;
            double x = xPosition / xHeight;
            zpnlLeft = x;
        }

        private void pnlRight_SplitterPositionChanged(object sender, EventArgs e)
        {
            double xWidth = pnlRight.Width;
            double xPosition = pnlRight.SplitterPosition;
            double x = xPosition / xWidth;
            zpnlRight = x;
        }

        private void btnAddTransactionIn_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if ((grdPropertyView.RowCount > 0) && (grdPropertyAccountMoneyInView.RowCount > 0))
            {
                frmPropertyAccountTransactionDetails MyForm;

                MyForm = new frmPropertyAccountTransactionDetails(0, 0);

                MyForm.edtProperty.Text = grdPropertyView.GetFocusedRowCellValue("Property").ToString();
                MyForm.edtAccountType.Text = "Money In";
                MyForm.edtDate.EditValue = DateTime.Now;

                tblPropertyAccount xtblPropertyAccount = new tblPropertyAccount();
                foreach (DataRow ARec in xtblPropertyAccount.dtPropertyAccountMoneyIn.Rows)
                {
                    if (ARec["tblPropertyID"].ToString() == grdPropertyView.GetFocusedRowCellValue("ID").ToString())
                    {
                        MyForm.edtAccount.Properties.Items.Add(ARec["Name"]);
                    }
                }

                MyForm.edtReference.Text = "N/A Until Saved";
                MyForm.edtReference.Visible = true;
                MyForm.edtReferenceCombo.Visible = false;

                if (MyForm.ShowDialog() == DialogResult.OK)
                {
                    LoadPropertyAccountTransaction();

                    int rowHandle = grdPATMoneyInView.LocateByValue("ID", clsHelper.GetLastRecID("tblPropertyAccountTransaction"));
                    if (rowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                    {
                        grdPATMoneyInView.FocusedRowHandle = rowHandle;
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("Please create a Property, and link a Money In Account to it first.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void LoadPropertyAccountTransaction()
        {
            tblPropertyAccountTransaction xtblPropertyAccountTransaction = new tblPropertyAccountTransaction();

            DataTable xdtPropertyAccountTransactionMoneyIn = xtblPropertyAccountTransaction.dtPropertyAccountTransactionMoneyIn.Clone();
            DataTable xdtPropertyAccountTransactionMoneyOut = xtblPropertyAccountTransaction.dtPropertyAccountTransactionMoneyOut.Clone();

            foreach (DataRow ARec in xtblPropertyAccountTransaction.dtPropertyAccountTransactionMoneyIn.Rows)
            {
                if (ARec["tblPropertyID"].ToString() == grdPropertyView.GetFocusedRowCellValue("ID").ToString())
                {
                    xdtPropertyAccountTransactionMoneyIn.ImportRow(ARec);
                }
            }

            foreach (DataRow ARec in xtblPropertyAccountTransaction.dtPropertyAccountTransactionMoneyOut.Rows)
            {
                if (ARec["tblPropertyID"].ToString() == grdPropertyView.GetFocusedRowCellValue("ID").ToString())
                {
                    xdtPropertyAccountTransactionMoneyOut.ImportRow(ARec);
                }
            }

            xdtPropertyAccountTransactionMoneyIn.Columns.Add("Variance", typeof(Double));
            foreach (DataRow ARec in xdtPropertyAccountTransactionMoneyIn.Rows)
            {
                double xTot = 0;
                foreach (DataRow BRec in xdtPropertyAccountTransactionMoneyOut.Rows)
                {
                    if (BRec["Reference"].ToString() == ARec["Reference"].ToString())
                    {
                        xTot = xTot + Convert.ToDouble(BRec["Amount"].ToString());
                    }
                }

                ARec["Variance"] = Convert.ToDouble(ARec["Amount"].ToString()) - xTot;
            }

            grdPATMoneyIn.DataSource = xdtPropertyAccountTransactionMoneyIn;
            grdPATMoneyOut.DataSource = xdtPropertyAccountTransactionMoneyOut;

            grdPATMoneyInView.BestFitColumns();
            grdPATMoneyOutView.BestFitColumns();

            grdPATMoneyInView.ExpandAllGroups();
            grdPATMoneyOutView.ExpandAllGroups();
        }

        private void groupControl3_SizeChanged(object sender, EventArgs e)
        {
            AfterSize();
        }

        private void btnAddTransactionOut_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if ((grdPropertyView.RowCount > 0) && (grdPropertyAccountMoneyOutView.RowCount > 0))
            {
                frmPropertyAccountTransactionDetails MyForm;

                MyForm = new frmPropertyAccountTransactionDetails(0, 0);
                MyForm.edtProperty.Text = grdPropertyView.GetFocusedRowCellValue("Property").ToString();
                MyForm.edtAccountType.Text = "Money Out";
                MyForm.edtDate.EditValue = DateTime.Now;

                tblPropertyAccount xtblPropertyAccount = new tblPropertyAccount();
                foreach (DataRow ARec in xtblPropertyAccount.dtPropertyAccountMoneyOut.Rows)
                {
                    if (ARec["tblPropertyID"].ToString() == grdPropertyView.GetFocusedRowCellValue("ID").ToString())
                    {
                        MyForm.edtAccount.Properties.Items.Add(ARec["Name"]);
                    }
                }

                MyForm.edtReference.Visible = false;
                MyForm.edtReferenceCombo.Visible = true;

                foreach (DataRow ARec in clsHelper.GetReferencesForMoneyOutTransaction(grdPropertyView.GetFocusedRowCellValue("ID").ToString()).Rows)
                {
                    MyForm.edtReferenceCombo.Properties.Items.Add(ARec["Reference"]);
                }

                if (MyForm.ShowDialog() == DialogResult.OK)
                {
                    LoadPropertyAccountTransaction();

                    int rowHandle = grdPATMoneyOutView.LocateByValue("ID", clsHelper.GetLastRecID("tblPropertyAccountTransaction"));
                    if (rowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                    {
                        grdPATMoneyOutView.FocusedRowHandle = rowHandle;
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("Please create a Property, and link a Money Out Account to it first.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void DoEditTransactionMoneyInAccount()
        {
            
            if ((grdPATMoneyInView.RowCount > 0) && (grdPATMoneyInView.IsDataRow(grdPATMoneyInView.FocusedRowHandle)))
            {
                frmPropertyAccountTransactionDetails MyForm;

                MyForm = new frmPropertyAccountTransactionDetails(1, Convert.ToInt32(grdPATMoneyInView.GetFocusedRowCellValue("ID").ToString()));

                MyForm.edtProperty.Text = grdPropertyView.GetFocusedRowCellValue("Property").ToString();
                MyForm.edtAccountType.Text = "Money In";
                MyForm.edtDate.EditValue = grdPATMoneyInView.GetFocusedRowCellValue("DT");

                tblPropertyAccount xtblPropertyAccount = new tblPropertyAccount();
                foreach (DataRow ARec in xtblPropertyAccount.dtPropertyAccountMoneyIn.Rows)
                {
                    if (ARec["tblPropertyID"].ToString() == grdPropertyView.GetFocusedRowCellValue("ID").ToString())
                    {
                        MyForm.edtAccount.Properties.Items.Add(ARec["Name"]);
                    }
                }
                MyForm.edtAccount.Text = grdPATMoneyInView.GetFocusedRowCellValue("Name").ToString();

                MyForm.edtReference.Text = grdPATMoneyInView.GetFocusedRowCellValue("Reference").ToString();
                MyForm.edtReference.Visible = true;
                MyForm.edtReferenceCombo.Visible = false;
                MyForm.edtDescription.Text = grdPATMoneyInView.GetFocusedRowCellValue("Description").ToString();
                MyForm.edtAmount.Value = (decimal)(grdPATMoneyInView.GetFocusedRowCellValue("Amount"));

                if (MyForm.ShowDialog() == DialogResult.OK)
                {
                    int xIDIn = Convert.ToInt32(grdPATMoneyInView.GetFocusedRowCellValue("ID").ToString());
                    int xIDOut = Convert.ToInt32(grdPATMoneyOutView.GetFocusedRowCellValue("ID").ToString());

                    LoadPropertyAccountTransaction();

                    int rowHandleIn = grdPATMoneyInView.LocateByValue("ID", xIDIn);
                    int rowHandleOut = grdPATMoneyOutView.LocateByValue("ID", xIDOut);

                    if (rowHandleIn != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                    {
                        grdPATMoneyInView.FocusedRowHandle = rowHandleIn;
                    }

                    if (rowHandleOut != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                    {
                        grdPATMoneyOutView.FocusedRowHandle = rowHandleOut;
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("Please select a valid record first.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void EditTransactionIn_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            DoEditTransactionMoneyInAccount();
        }

        private void grdPATMoneyInView_DoubleClick(object sender, EventArgs e)
        {
            DoEditTransactionMoneyInAccount();
        }

        private void grdPATMoneyInView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                DoEditTransactionMoneyInAccount();
            }
        }

        private void DoEditTransactionMoneyOutAccount()
        {
            if ((grdPATMoneyOutView.RowCount > 0) && (grdPATMoneyOutView.IsDataRow(grdPATMoneyOutView.FocusedRowHandle)))
            {
                frmPropertyAccountTransactionDetails MyForm;

                MyForm = new frmPropertyAccountTransactionDetails(1, Convert.ToInt32(grdPATMoneyOutView.GetFocusedRowCellValue("ID").ToString()));

                MyForm.edtProperty.Text = grdPropertyView.GetFocusedRowCellValue("Property").ToString();
                MyForm.edtAccountType.Text = "Money Out";
                MyForm.edtDate.EditValue = grdPATMoneyOutView.GetFocusedRowCellValue("DT");

                tblPropertyAccount xtblPropertyAccount = new tblPropertyAccount();
                foreach (DataRow ARec in xtblPropertyAccount.dtPropertyAccountMoneyOut.Rows)
                {
                    if (ARec["tblPropertyID"].ToString() == grdPropertyView.GetFocusedRowCellValue("ID").ToString())
                    {
                        MyForm.edtAccount.Properties.Items.Add(ARec["Name"]);
                    }
                }
                MyForm.edtAccount.Text = grdPATMoneyOutView.GetFocusedRowCellValue("Name").ToString();

                MyForm.edtReference.Visible = false;
                MyForm.edtReferenceCombo.Visible = true;

                foreach (DataRow ARec in clsHelper.GetReferencesForMoneyOutTransaction(grdPropertyView.GetFocusedRowCellValue("ID").ToString()).Rows)
                {
                    MyForm.edtReferenceCombo.Properties.Items.Add(ARec["Reference"]);
                }
                MyForm.edtReferenceCombo.Text = grdPATMoneyOutView.GetFocusedRowCellValue("Reference").ToString();

                MyForm.edtDescription.Text = grdPATMoneyOutView.GetFocusedRowCellValue("Description").ToString();
                MyForm.edtAmount.Value = (decimal)(grdPATMoneyOutView.GetFocusedRowCellValue("Amount"));

                if (MyForm.ShowDialog() == DialogResult.OK)
                {
                    int xIDIn = Convert.ToInt32(grdPATMoneyInView.GetFocusedRowCellValue("ID").ToString());
                    int xIDOut = Convert.ToInt32(grdPATMoneyOutView.GetFocusedRowCellValue("ID").ToString());

                    LoadPropertyAccountTransaction();

                    int rowHandleIn = grdPATMoneyInView.LocateByValue("ID", xIDIn);
                    int rowHandleOut = grdPATMoneyOutView.LocateByValue("ID", xIDOut);

                    if (rowHandleIn != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                    {
                        grdPATMoneyInView.FocusedRowHandle = rowHandleIn;
                    }

                    if (rowHandleOut != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                    {
                        grdPATMoneyOutView.FocusedRowHandle = rowHandleOut;
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("Please select a valid record first.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnEditTransactionOut_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            DoEditTransactionMoneyOutAccount();
        }

        private void grdPATMoneyOutView_DoubleClick(object sender, EventArgs e)
        {
            DoEditTransactionMoneyOutAccount();
        }

        private void grdPATMoneyOutView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                DoEditTransactionMoneyOutAccount();
            }
        }

        private void btnRemoveTransactionIn_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if ((grdPATMoneyInView.RowCount > 0) && (grdPATMoneyInView.IsDataRow(grdPATMoneyInView.FocusedRowHandle)))
            {
                //Check if record has linked Money Out transactions
                tblPropertyAccountTransaction xtblPropertyAccountTransaction = new tblPropertyAccountTransaction();
                DataTable xdtPropertyAccountTransactionMoneyOut = xtblPropertyAccountTransaction.dtPropertyAccountTransactionMoneyOut.Clone();

                foreach (DataRow ARec in xtblPropertyAccountTransaction.dtPropertyAccountTransactionMoneyOut.Rows)
                {
                    if (ARec["tblPropertyID"].ToString() == grdPropertyView.GetFocusedRowCellValue("ID").ToString())
                    {
                        xdtPropertyAccountTransactionMoneyOut.ImportRow(ARec);
                    }
                }

                var rows = xdtPropertyAccountTransactionMoneyOut.AsEnumerable().Where(r => (r.Field<string>("Reference") == grdPATMoneyInView.GetFocusedRowCellValue("Reference").ToString()));

                if (rows.Count() > 0)
                {
                    XtraMessageBox.Show("This record has Money Out records linked to it," + Environment.NewLine +
                                        "and can not be removed until the linked records are" + Environment.NewLine +
                                        "removed first.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    if (XtraMessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        clsHelper.DeleteRecByID("tblPropertyAccountTransaction", Convert.ToInt32(grdPATMoneyInView.GetFocusedRowCellValue("ID").ToString()));

                        LoadPropertyAccountTransaction();
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("Please select a valid record first.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnRemoveTransactionOut_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if ((grdPATMoneyOutView.RowCount > 0) && (grdPATMoneyOutView.IsDataRow(grdPATMoneyOutView.FocusedRowHandle)))
            {
                if (XtraMessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    clsHelper.DeleteRecByID("tblPropertyAccountTransaction", Convert.ToInt32(grdPATMoneyOutView.GetFocusedRowCellValue("ID").ToString()));

                    LoadPropertyAccountTransaction();
                }
            }
            else
            {
                XtraMessageBox.Show("Please select a valid record first.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void pnlBottom_SplitterPositionChanged(object sender, EventArgs e)
        {
            double xWidth = groupControl2.Width;
            double xPosition = pnlBottom.SplitterPosition;
            double x = xPosition / xWidth;
            zpnlBottom = x;
        }

        private void navBarControl1_SizeChanged(object sender, EventArgs e)
        {
            AfterSize();
        }

        private void btnExpandAll_Click(object sender, EventArgs e)
        {
            grdPATMoneyInView.ExpandAllGroups();
            grdPATMoneyOutView.ExpandAllGroups();
        }

        private void btnCollapseAll_Click(object sender, EventArgs e)
        {
            grdPATMoneyInView.CollapseAllGroups();
            grdPATMoneyOutView.CollapseAllGroups();
        }

        private void grdPATMoneyInView_EndGrouping(object sender, EventArgs e)
        {
            grdPATMoneyInView.ExpandAllGroups();
        }

        private void splitContainerControl2_SplitterPositionChanged(object sender, EventArgs e)
        {
            AfterSize();
        }

        private void grdPATMoneyOutView_EndGrouping(object sender, EventArgs e)
        {
            grdPATMoneyOutView.ExpandAllGroups();
        }

        private void grdPATMoneyOutView_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if ((grdPATMoneyInView.RowCount > 0) && (grdPATMoneyInView.IsDataRow(grdPATMoneyInView.FocusedRowHandle)))
            {
                ColumnView view = (ColumnView)sender;
                if ((view.IsValidRowHandle(e.RowHandle)) && (grdPATMoneyOutView.IsDataRow(e.RowHandle)))
                {
                    if (view.GetRowCellValue(e.RowHandle, "Reference").ToString() == grdPATMoneyInView.GetFocusedRowCellValue("Reference").ToString())
                    {
                        e.Appearance.BackColor = ColorTranslator.FromHtml("#FFD6D6");
                    }
                }
            }
        }

        private void grdPATMoneyInView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            grdPATMoneyOutView.RefreshData();
        }
    }
}
