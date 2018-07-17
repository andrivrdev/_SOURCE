using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using EasyBooks.CLASSES;
using EasyBooks.DATA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyBooks.FORMS
{
    public partial class frmItem : DevExpress.XtraEditors.XtraForm
    {
        double zpnlLeft = 0;
        double zpnlRight = 0;
        double zpnlBottom = 0;
        Int64 zI = -1;
        Int64 zAI = -1;
        Int64 zAO = -1;
        Int64 zTI = -1;
        Int64 zTO = -1;
        bool zSkipFocusLoad = false;

        public frmItem()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            grdPATMoneyInView.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "Amount", colInAmount, "{0:c2}");
            grdPATMoneyInView.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "Variance", colInVariance, "{0:c2}");
            grdPATMoneyOutView.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "Amount", colOutAmount, "{0:c2}");
        }

        public void ClearFocusedRows()
        {
            zI = -1;
            zAI = -1;
            zAO = -1;
            zTI = -1;
            zTO = -1;
        }

        public void SaveFocusedRows()
        {
            zI = -1;
            if (grdItemView.RowCount > 0)
            {
                zI = Convert.ToInt64(grdItemView.GetFocusedRowCellValue("ID").ToString());
            }

            zAI = -1;
            if (grdItemAccountMoneyInView.RowCount > 0)
            {
                zAI = Convert.ToInt64(grdItemAccountMoneyInView.GetFocusedRowCellValue("ID").ToString());
            }

            zAO = -1;
            if (grdItemAccountMoneyOutView.RowCount > 0)
            {
                zAO = Convert.ToInt64(grdItemAccountMoneyOutView.GetFocusedRowCellValue("ID").ToString());
            }

            zTI = -1;
            if (grdPATMoneyInView.RowCount > 0)
            {
                zTI = Convert.ToInt64(grdPATMoneyInView.GetFocusedRowCellValue("ID").ToString());
            }

            zTO = -1;
            if (grdPATMoneyOutView.RowCount > 0)
            {
                zTO = Convert.ToInt64(grdPATMoneyOutView.GetFocusedRowCellValue("ID").ToString());
            }
        }

        public void LoadFocusedRows()
        {
            if (!zSkipFocusLoad)
            {
                int rowH = -1;

                rowH = grdItemView.LocateByValue("ID", zI);
                if (rowH != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                {
                    grdItemView.FocusedRowHandle = rowH;
                }

                rowH = grdItemAccountMoneyInView.LocateByValue("ID", zAI);
                if (rowH != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                {
                    grdItemAccountMoneyInView.FocusedRowHandle = rowH;
                }

                rowH = grdItemAccountMoneyOutView.LocateByValue("ID", zAO);
                if (rowH != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                {
                    grdItemAccountMoneyOutView.FocusedRowHandle = rowH;
                }

                rowH = grdPATMoneyInView.LocateByValue("ID", zTI);
                if (rowH != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                {
                    grdPATMoneyInView.FocusedRowHandle = rowH;
                }

                rowH = grdPATMoneyOutView.LocateByValue("ID", zTO);
                if (rowH != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                {
                    grdPATMoneyOutView.FocusedRowHandle = rowH;
                }
            }
        }

        private void LoadItem()
        {
            tblItem xtblItem = new tblItem();
            grdItem.DataSource = xtblItem.dtItem;

            grdItemView.BestFitColumns();

            LoadFocusedRows();
        }

        private void LoadItemAccount()
        {
            if (grdItemView.RowCount > 0)
            {
                tblItemAccount xtblItemAccount = new tblItemAccount();

                DataTable xdtItemAccountMoneyIn = xtblItemAccount.dtItemAccountMoneyIn.Clone();
                DataTable xdtItemAccountMoneyOut = xtblItemAccount.dtItemAccountMoneyOut.Clone();

                foreach (DataRow ARec in xtblItemAccount.dtItemAccountMoneyIn.Rows)
                {
                    if (ARec["tblItemID"].ToString() == grdItemView.GetFocusedRowCellValue("ID").ToString())
                    {
                        xdtItemAccountMoneyIn.ImportRow(ARec);
                    }
                }

                foreach (DataRow ARec in xtblItemAccount.dtItemAccountMoneyOut.Rows)
                {
                    if (ARec["tblItemID"].ToString() == grdItemView.GetFocusedRowCellValue("ID").ToString())
                    {
                        xdtItemAccountMoneyOut.ImportRow(ARec);
                    }
                }

                grdItemAccountMoneyIn.DataSource = xdtItemAccountMoneyIn;
                grdItemAccountMoneyOut.DataSource = xdtItemAccountMoneyOut;

                grdItemAccountMoneyInView.BestFitColumns();
                grdItemAccountMoneyOutView.BestFitColumns();
            }

            LoadFocusedRows();
        }

        private void LoadItemAccountTransaction()
        {
            if (grdItemView.RowCount > 0)
            {
                tblItemAccountTransaction xtblItemAccountTransaction = new tblItemAccountTransaction();

                DataTable xdtItemAccountTransactionMoneyIn = xtblItemAccountTransaction.dtItemAccountTransactionMoneyIn.Clone();
                DataTable xdtItemAccountTransactionMoneyOut = xtblItemAccountTransaction.dtItemAccountTransactionMoneyOut.Clone();

                foreach (DataRow ARec in xtblItemAccountTransaction.dtItemAccountTransactionMoneyIn.Rows)
                {
                    if (ARec["tblItemID"].ToString() == grdItemView.GetFocusedRowCellValue("ID").ToString())
                    {
                        xdtItemAccountTransactionMoneyIn.ImportRow(ARec);
                    }
                }

                foreach (DataRow ARec in xtblItemAccountTransaction.dtItemAccountTransactionMoneyOut.Rows)
                {
                    if (ARec["tblItemID"].ToString() == grdItemView.GetFocusedRowCellValue("ID").ToString())
                    {
                        xdtItemAccountTransactionMoneyOut.ImportRow(ARec);
                    }
                }

                xdtItemAccountTransactionMoneyIn.Columns.Add("Variance", typeof(Double));
                foreach (DataRow ARec in xdtItemAccountTransactionMoneyIn.Rows)
                {
                    double xTot = 0;
                    foreach (DataRow BRec in xdtItemAccountTransactionMoneyOut.Rows)
                    {
                        if (BRec["Reference"].ToString() == ARec["Reference"].ToString())
                        {
                            xTot = xTot + Convert.ToDouble(BRec["Amount"].ToString());
                        }
                    }

                    ARec["Variance"] = Convert.ToDouble(ARec["Amount"].ToString()) - xTot;
                }

                grdPATMoneyIn.DataSource = xdtItemAccountTransactionMoneyIn;
                grdPATMoneyOut.DataSource = xdtItemAccountTransactionMoneyOut;

                grdPATMoneyInView.BestFitColumns();
                grdPATMoneyOutView.BestFitColumns();

                grdPATMoneyInView.ExpandAllGroups();
                grdPATMoneyOutView.ExpandAllGroups();
            }

            LoadFocusedRows();
        }

        private void frmItem_Shown(object sender, EventArgs e)
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
            LoadItem();
            LoadItemAccount();
            LoadItemAccountTransaction();
        }

        private void grdItemView_DoubleClick(object sender, EventArgs e)
        {
            DoEditItem();
        }

        private void DoEditItem()
        {
            if (grdItemView.RowCount > 0)
            {
                frmItemDetails MyForm;

                MyForm = new frmItemDetails(1, Convert.ToInt64(grdItemView.GetFocusedRowCellValue("ID").ToString()));

                MyForm.edtItem.Text = grdItemView.GetFocusedRowCellValue("Item").ToString();

                if (MyForm.ShowDialog() == DialogResult.OK)
                {
                    SaveFocusedRows();
                    LoadItem();
                    LoadItemAccount();
                    LoadItemAccountTransaction();
                }
            }
            else
            {
                XtraMessageBox.Show("Please select a valid record first.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnAddItem_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmItemDetails MyForm;

            MyForm = new frmItemDetails(0, 0);

            if (MyForm.ShowDialog() == DialogResult.OK)
            {
                ClearFocusedRows();
                zI = clsHelper.GetLastRecID("tblItem");
                LoadItem();
                LoadItemAccount();
                LoadItemAccountTransaction();
            }
        }

        private void btnEditItem_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            DoEditItem();
        }

        private void btnRemoveItem_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (grdItemView.RowCount > 0)
            {
                if (XtraMessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    clsHelper.DeleteRecByID("tblItem", Convert.ToInt64(grdItemView.GetFocusedRowCellValue("ID").ToString()));

                    ClearFocusedRows();
                    LoadItem();
                    LoadItemAccount();
                    LoadItemAccountTransaction();
                }
            }
            else
            {
                XtraMessageBox.Show("Please select a valid record first.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnAddMoneyInAccount_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (grdItemView.RowCount > 0)
            {
                tblAccount xtblAccount = new tblAccount();
                var rows = xtblAccount.dtAccount.AsEnumerable().Where(r => (r.Field<string>("IO") == "I"));

                if (rows.Count() == 0)
                {
                    XtraMessageBox.Show("Please create some Money In Accounts first.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                frmItemAccountDetails MyForm;

                MyForm = new frmItemAccountDetails(0, 0, Convert.ToInt64(grdItemView.GetFocusedRowCellValue("ID").ToString()));
                MyForm.edtItem.Text = grdItemView.GetFocusedRowCellValue("Item").ToString();
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
                    SaveFocusedRows();
                    zAI = clsHelper.GetLastRecID("tblItemAccount");
                    LoadItemAccount();
                    LoadItemAccountTransaction();
                }
            }
            else
            {
                XtraMessageBox.Show("Please create a Item first.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void grdItemView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                DoEditItem();
            }
        }

        private void btnAddMoneyOutAccount_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (grdItemView.RowCount > 0)
            {
                tblAccount xtblAccount = new tblAccount();
                var rows = xtblAccount.dtAccount.AsEnumerable().Where(r => (r.Field<string>("IO") == "O"));

                if (rows.Count() == 0)
                {
                    XtraMessageBox.Show("Please create some Money Out Accounts first.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                frmItemAccountDetails MyForm;

                MyForm = new frmItemAccountDetails(0, 0, Convert.ToInt64(grdItemView.GetFocusedRowCellValue("ID").ToString()));
                MyForm.edtItem.Text = grdItemView.GetFocusedRowCellValue("Item").ToString();
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
                    SaveFocusedRows();
                    zAO = clsHelper.GetLastRecID("tblItemAccount");
                    LoadItemAccount();
                    LoadItemAccountTransaction();
                }
            }
            else
            {
                XtraMessageBox.Show("Please create a Item first.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnEditMoneyInAccount_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            DoEditItemMoneyInAccount();
        }

        private void DoEditItemMoneyInAccount()
        {
            if (grdItemAccountMoneyInView.RowCount > 0)
            {
                frmItemAccountDetails MyForm;

                MyForm = new frmItemAccountDetails(1, Convert.ToInt64(grdItemAccountMoneyInView.GetFocusedRowCellValue("ID").ToString()), Convert.ToInt64(grdItemView.GetFocusedRowCellValue("ID").ToString()));
                MyForm.edtItem.Text = grdItemView.GetFocusedRowCellValue("Item").ToString();
                MyForm.edtAccountType.Text = "Money In";

                tblAccount xtblAccount = new tblAccount();
                foreach (DataRow ARec in xtblAccount.dtAccount.Rows)
                {
                    if (ARec["IO"].ToString() == "I")
                    {
                        MyForm.edtAccount.Properties.Items.Add(ARec["Name"]);
                    }
                }

                MyForm.edtAccount.Text = grdItemAccountMoneyInView.GetFocusedRowCellValue("Name").ToString();

                if (MyForm.ShowDialog() == DialogResult.OK)
                {
                    SaveFocusedRows();
                    LoadItemAccount();
                    LoadItemAccountTransaction();
                }
            }
            else
            {
                XtraMessageBox.Show("Please select a valid record first.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void grdItemAccountMoneyInView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                DoEditItemMoneyInAccount();
            }
        }

        private void btnEditMoneyOutAccount_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            DoEditItemMoneyOutAccount();
        }

        private void grdItemAccountMoneyInView_DoubleClick(object sender, EventArgs e)
        {
            DoEditItemMoneyInAccount();
        }

        private void DoEditItemMoneyOutAccount()
        {
            if (grdItemAccountMoneyOutView.RowCount > 0)
            {
                frmItemAccountDetails MyForm;

                MyForm = new frmItemAccountDetails(1, Convert.ToInt64(grdItemAccountMoneyOutView.GetFocusedRowCellValue("ID").ToString()), Convert.ToInt64(grdItemView.GetFocusedRowCellValue("ID").ToString()));
                MyForm.edtItem.Text = grdItemView.GetFocusedRowCellValue("Item").ToString();
                MyForm.edtAccountType.Text = "Money Out";

                tblAccount xtblAccount = new tblAccount();
                foreach (DataRow ARec in xtblAccount.dtAccount.Rows)
                {
                    if (ARec["IO"].ToString() == "O")
                    {
                        MyForm.edtAccount.Properties.Items.Add(ARec["Name"]);
                    }
                }

                MyForm.edtAccount.Text = grdItemAccountMoneyOutView.GetFocusedRowCellValue("Name").ToString();

                if (MyForm.ShowDialog() == DialogResult.OK)
                {
                    SaveFocusedRows();
                    LoadItemAccount();
                    LoadItemAccountTransaction();
                }
            }
            else
            {
                XtraMessageBox.Show("Please select a valid record first.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void grdItemAccountMoneyOutView_DoubleClick(object sender, EventArgs e)
        {
            DoEditItemMoneyOutAccount();
        }

        private void grdItemView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            zSkipFocusLoad = true;
            zAI = -1;
            zAO = -1;
            zTI = -1;
            zTO = -1;
            LoadItemAccount();
            LoadItemAccountTransaction();
            zSkipFocusLoad = false;
        }

        private void grdItemAccountMoneyOutView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                DoEditItemMoneyOutAccount();
            }
        }

        private void btnRemoveMoneyInAccount_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (grdItemAccountMoneyInView.RowCount > 0)
            {
                if (XtraMessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    clsHelper.DeleteRecByID("tblItemAccount", Convert.ToInt64(grdItemAccountMoneyInView.GetFocusedRowCellValue("ID").ToString()));

                    SaveFocusedRows();
                    zAI = -1;
                    LoadItemAccount();
                    LoadItemAccountTransaction();
                }
            }
            else
            {
                XtraMessageBox.Show("Please select a valid record first.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnRemoveMoneyOutAccount_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (grdItemAccountMoneyOutView.RowCount > 0)
            {
                if (XtraMessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    clsHelper.DeleteRecByID("tblItemAccount", Convert.ToInt64(grdItemAccountMoneyOutView.GetFocusedRowCellValue("ID").ToString()));

                    SaveFocusedRows();
                    zAO = -1;
                    LoadItemAccount();
                    LoadItemAccountTransaction();
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

            grdItemView.BestFitColumns();
            grdItemAccountMoneyInView.BestFitColumns();
            grdItemAccountMoneyOutView.BestFitColumns();
            grdPATMoneyInView.BestFitColumns();
            grdPATMoneyOutView.BestFitColumns();
        }

        private void frmItem_SizeChanged(object sender, EventArgs e)
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
            if ((grdItemView.RowCount > 0) && (grdItemAccountMoneyInView.RowCount > 0))
            {
                frmItemAccountTransactionDetails MyForm;

                MyForm = new frmItemAccountTransactionDetails(0, 0);

                MyForm.edtItem.Text = grdItemView.GetFocusedRowCellValue("Item").ToString();
                MyForm.edtAccountType.Text = "Money In";
                MyForm.edtDate.EditValue = DateTime.Now;

                tblItemAccount xtblItemAccount = new tblItemAccount();
                foreach (DataRow ARec in xtblItemAccount.dtItemAccountMoneyIn.Rows)
                {
                    if (ARec["tblItemID"].ToString() == grdItemView.GetFocusedRowCellValue("ID").ToString())
                    {
                        MyForm.edtAccount.Properties.Items.Add(ARec["Name"]);
                    }
                }

                MyForm.edtReference.Text = "N/A Until Saved";
                MyForm.edtReference.Visible = true;
                MyForm.edtReferenceCombo.Visible = false;

                if (MyForm.ShowDialog() == DialogResult.OK)
                {
                    SaveFocusedRows();
                    zTI = clsHelper.GetLastRecID("tblItemAccountTransaction");
                    LoadItemAccountTransaction();
                }
            }
            else
            {
                XtraMessageBox.Show("Please create a Item, and link a Money In Account to it first.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void groupControl3_SizeChanged(object sender, EventArgs e)
        {
            AfterSize();
        }

        private void btnAddTransactionOut_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if ((grdItemView.RowCount > 0) && (grdItemAccountMoneyOutView.RowCount > 0))
            {
                frmItemAccountTransactionDetails MyForm;

                MyForm = new frmItemAccountTransactionDetails(0, 0);
                MyForm.edtItem.Text = grdItemView.GetFocusedRowCellValue("Item").ToString();
                MyForm.edtAccountType.Text = "Money Out";
                MyForm.edtDate.EditValue = DateTime.Now;

                tblItemAccount xtblItemAccount = new tblItemAccount();
                foreach (DataRow ARec in xtblItemAccount.dtItemAccountMoneyOut.Rows)
                {
                    if (ARec["tblItemID"].ToString() == grdItemView.GetFocusedRowCellValue("ID").ToString())
                    {
                        MyForm.edtAccount.Properties.Items.Add(ARec["Name"]);
                    }
                }

                MyForm.edtReference.Visible = false;
                MyForm.edtReferenceCombo.Visible = true;

                foreach (DataRow ARec in clsHelper.GetReferencesForMoneyOutTransaction(grdItemView.GetFocusedRowCellValue("ID").ToString()).Rows)
                {
                    MyForm.edtReferenceCombo.Properties.Items.Add(ARec["Reference"]);
                }

                if (MyForm.ShowDialog() == DialogResult.OK)
                {
                    SaveFocusedRows();
                    zTO = clsHelper.GetLastRecID("tblItemAccountTransaction");
                    LoadItemAccountTransaction();
                }
            }
            else
            {
                XtraMessageBox.Show("Please create a Item, and link a Money Out Account to it first.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void DoEditTransactionMoneyInAccount()
        {
            
            if ((grdPATMoneyInView.RowCount > 0) && (grdPATMoneyInView.IsDataRow(grdPATMoneyInView.FocusedRowHandle)))
            {
                frmItemAccountTransactionDetails MyForm;

                MyForm = new frmItemAccountTransactionDetails(1, Convert.ToInt64(grdPATMoneyInView.GetFocusedRowCellValue("ID").ToString()));

                MyForm.edtItem.Text = grdItemView.GetFocusedRowCellValue("Item").ToString();
                MyForm.edtAccountType.Text = "Money In";
                MyForm.edtDate.EditValue = grdPATMoneyInView.GetFocusedRowCellValue("DT");

                tblItemAccount xtblItemAccount = new tblItemAccount();
                foreach (DataRow ARec in xtblItemAccount.dtItemAccountMoneyIn.Rows)
                {
                    if (ARec["tblItemID"].ToString() == grdItemView.GetFocusedRowCellValue("ID").ToString())
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
                    SaveFocusedRows();
                    LoadItemAccountTransaction();
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
                frmItemAccountTransactionDetails MyForm;

                MyForm = new frmItemAccountTransactionDetails(1, Convert.ToInt64(grdPATMoneyOutView.GetFocusedRowCellValue("ID").ToString()));

                MyForm.edtItem.Text = grdItemView.GetFocusedRowCellValue("Item").ToString();
                MyForm.edtAccountType.Text = "Money Out";
                MyForm.edtDate.EditValue = grdPATMoneyOutView.GetFocusedRowCellValue("DT");

                tblItemAccount xtblItemAccount = new tblItemAccount();
                foreach (DataRow ARec in xtblItemAccount.dtItemAccountMoneyOut.Rows)
                {
                    if (ARec["tblItemID"].ToString() == grdItemView.GetFocusedRowCellValue("ID").ToString())
                    {
                        MyForm.edtAccount.Properties.Items.Add(ARec["Name"]);
                    }
                }
                MyForm.edtAccount.Text = grdPATMoneyOutView.GetFocusedRowCellValue("Name").ToString();

                MyForm.edtReference.Visible = false;
                MyForm.edtReferenceCombo.Visible = true;

                foreach (DataRow ARec in clsHelper.GetReferencesForMoneyOutTransaction(grdItemView.GetFocusedRowCellValue("ID").ToString()).Rows)
                {
                    MyForm.edtReferenceCombo.Properties.Items.Add(ARec["Reference"]);
                }
                MyForm.edtReferenceCombo.Text = grdPATMoneyOutView.GetFocusedRowCellValue("Reference").ToString();

                MyForm.edtDescription.Text = grdPATMoneyOutView.GetFocusedRowCellValue("Description").ToString();
                MyForm.edtAmount.Value = (decimal)(grdPATMoneyOutView.GetFocusedRowCellValue("Amount"));

                if (MyForm.ShowDialog() == DialogResult.OK)
                {
                    SaveFocusedRows();
                    LoadItemAccountTransaction();
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
                tblItemAccountTransaction xtblItemAccountTransaction = new tblItemAccountTransaction();
                DataTable xdtItemAccountTransactionMoneyOut = xtblItemAccountTransaction.dtItemAccountTransactionMoneyOut.Clone();

                foreach (DataRow ARec in xtblItemAccountTransaction.dtItemAccountTransactionMoneyOut.Rows)
                {
                    if (ARec["tblItemID"].ToString() == grdItemView.GetFocusedRowCellValue("ID").ToString())
                    {
                        xdtItemAccountTransactionMoneyOut.ImportRow(ARec);
                    }
                }

                var rows = xdtItemAccountTransactionMoneyOut.AsEnumerable().Where(r => (r.Field<string>("Reference") == grdPATMoneyInView.GetFocusedRowCellValue("Reference").ToString()));

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
                        clsHelper.DeleteRecByID("tblItemAccountTransaction", Convert.ToInt64(grdPATMoneyInView.GetFocusedRowCellValue("ID").ToString()));
                        SaveFocusedRows();
                        zTI = -1;
                        LoadItemAccountTransaction();
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
                    clsHelper.DeleteRecByID("tblItemAccountTransaction", Convert.ToInt64(grdPATMoneyOutView.GetFocusedRowCellValue("ID").ToString()));
                    SaveFocusedRows();
                    zTO = -1;
                    LoadItemAccountTransaction();
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