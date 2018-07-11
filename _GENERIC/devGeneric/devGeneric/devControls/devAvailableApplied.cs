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
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using devGeneric.devClasses.devStatic;
using devGeneric.devClasses.devDynamic;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;

namespace devGeneric.devControls
{
    public partial class devAvailableApplied : DevExpress.XtraEditors.XtraUserControl
    {
        DataTable dsA;
        DataTable dsB;

        string APriKey;
        string BPriKey;

        int[] GridSelRows;

        DataTable TempTable = new DataTable();

        string FromGrid;

        GridHitInfo downHitInfo = null;


        public devAvailableApplied()
        {
            InitializeComponent();

            ((DevExpress.XtraGrid.Views.Grid.GridView)grdA.MainView).Appearance.Row.BackColor = devGlobals.gRowCol1;
            ((DevExpress.XtraGrid.Views.Grid.GridView)grdA.MainView).Appearance.Row.BackColor2 = devGlobals.gRowCol2;
            ((DevExpress.XtraGrid.Views.Grid.GridView)grdA.MainView).Appearance.SelectedRow.BackColor = devGlobals.gSelRowCol1;
            ((DevExpress.XtraGrid.Views.Grid.GridView)grdA.MainView).Appearance.SelectedRow.BackColor2 = devGlobals.gSelRowCol2;
            ((DevExpress.XtraGrid.Views.Grid.GridView)grdA.MainView).Appearance.FocusedRow.BackColor = devGlobals.gCurRowCol1;
            ((DevExpress.XtraGrid.Views.Grid.GridView)grdA.MainView).Appearance.FocusedRow.BackColor2 = devGlobals.gCurRowCol2;

            ((DevExpress.XtraGrid.Views.Grid.GridView)grdB.MainView).Appearance.Row.BackColor = devGlobals.gRowCol1;
            ((DevExpress.XtraGrid.Views.Grid.GridView)grdB.MainView).Appearance.Row.BackColor2 = devGlobals.gRowCol2;
            ((DevExpress.XtraGrid.Views.Grid.GridView)grdB.MainView).Appearance.SelectedRow.BackColor = devGlobals.gSelRowCol1;
            ((DevExpress.XtraGrid.Views.Grid.GridView)grdB.MainView).Appearance.SelectedRow.BackColor2 = devGlobals.gSelRowCol2;
            ((DevExpress.XtraGrid.Views.Grid.GridView)grdB.MainView).Appearance.FocusedRow.BackColor = devGlobals.gCurRowCol1;
            ((DevExpress.XtraGrid.Views.Grid.GridView)grdB.MainView).Appearance.FocusedRow.BackColor2 = devGlobals.gCurRowCol2;
        }

        public void SetData(DataTable AData, DataTable BData, List<string> AFields, List<string> ACols, List<string> BFields, List<string> BCols, string AKey, string BKey, string ASort, string BSort, int RemoveFrom)
        {
            try
            {
                //Clear
                grdA.DataSource = null;
                grdB.DataSource = null;

                grdAView.Columns.Clear();
                grdBView.Columns.Clear();

                dsA = AData;
                dsB = BData;

                APriKey = AKey;
                BPriKey = BKey;

                //Create grid A
                for (int C1 = 0; C1 < AFields.Count; C1++)
                {
                    grdAView.Columns.Add();

                    grdAView.Columns[C1].Caption = ACols[C1];

                    if (AFields[C1].IndexOf("|1") > -1)
                    {
                        grdAView.Columns[C1].FieldName = AFields[C1].Substring(0, AFields[C1].IndexOf("|"));
                        grdAView.Columns[C1].VisibleIndex = C1;
                    }
                    else
                    {
                        if (AFields[C1].IndexOf("|0") > -1)
                        {
                            grdAView.Columns[C1].FieldName = AFields[C1].Substring(0, AFields[C1].IndexOf("|"));
                        }
                        else
                        {
                            grdAView.Columns[C1].FieldName = AFields[C1];
                            grdAView.Columns[C1].VisibleIndex = C1;
                        }
                    }
                }

                //Create grid B
                for (int C1 = 0; C1 < BFields.Count; C1++)
                {
                    grdBView.Columns.Add();

                    grdBView.Columns[C1].Caption = BCols[C1];

                    if (BFields[C1].IndexOf("|1") > -1)
                    {
                        grdBView.Columns[C1].FieldName = BFields[C1].Substring(0, BFields[C1].IndexOf("|"));
                        grdBView.Columns[C1].VisibleIndex = C1;
                    }
                    else
                    {
                        if (BFields[C1].IndexOf("|0") > -1)
                        {
                            grdBView.Columns[C1].FieldName = BFields[C1].Substring(0, BFields[C1].IndexOf("|"));
                        }
                        else
                        {
                            grdBView.Columns[C1].FieldName = BFields[C1];
                            grdBView.Columns[C1].VisibleIndex = C1;
                        }
                    }
                }

                if (RemoveFrom == 0)
                {
                    for (int C1 = 0; C1 < dsB.Rows.Count; C1++)
                    {
                        DataRow[] foundRows;

                        foundRows = dsA.Select(APriKey + " = " + dsB.Rows[C1][BPriKey]);

                        while (foundRows.Length != 0)
                        {
                            dsA.Rows.Remove(foundRows[0]);

                            foundRows = dsA.Select(APriKey + " = " + dsB.Rows[C1][BPriKey]);
                        }
                    }
                }

                if (RemoveFrom == 1)
                {
                    for (int C1 = 0; C1 < dsA.Rows.Count; C1++)
                    {
                        DataRow[] foundRows;

                        foundRows = dsB.Select(BPriKey + " = " + dsA.Rows[C1][APriKey]);

                        while (foundRows.Length != 0)
                        {
                            dsB.Rows.Remove(foundRows[0]);

                            foundRows = dsB.Select(BPriKey + " = " + dsA.Rows[C1][APriKey]);
                        }
                    }
                }

                grdA.DataSource = dsA;
                grdB.DataSource = dsB;

                //Format the headers
                for (int C1 = 0; C1 < grdAView.Columns.Count; C1++)
                {
                    grdAView.Columns[C1].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    grdAView.Columns[C1].AppearanceHeader.Font = new Font("Arial Narrow", 8, FontStyle.Bold, GraphicsUnit.Point);
                    grdAView.Columns[C1].AppearanceCell.Font = new Font("Arial Narrow", 8, FontStyle.Regular, GraphicsUnit.Point);

                    //Check sorting
                    if (grdAView.Columns[C1].FieldName == ASort)
                    {
                        grdAView.Columns[C1].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                    }

                    //Fit Data
                    grdAView.Columns[C1].BestFit();
                }

                for (int C1 = 0; C1 < grdBView.Columns.Count; C1++)
                {
                    grdBView.Columns[C1].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    grdBView.Columns[C1].AppearanceHeader.Font = new Font("Arial Narrow", 8, FontStyle.Bold, GraphicsUnit.Point);
                    grdBView.Columns[C1].AppearanceCell.Font = new Font("Arial Narrow", 8, FontStyle.Regular, GraphicsUnit.Point);

                    //Check sorting
                    if (grdBView.Columns[C1].FieldName == BSort)
                    {
                        grdBView.Columns[C1].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                    }

                    //Fit Data
                    grdBView.Columns[C1].BestFit();
                }
            }
            catch (Exception Ex)
            {
                devSE SE = new devSE();
                SE.WriteLog(Ex.Message, "avrAvailableApplied", "SetData");

                //Clear
                grdA.DataSource = null;
                grdB.DataSource = null;

                grdAView.Columns.Clear();
                grdBView.Columns.Clear();
            }
        }

        private void GenericGridiew_MouseDown(object sender, MouseEventArgs e)
        {
            downHitInfo = null;

            TempTable.Rows.Clear();

            GridView view = sender as GridView;

            FromGrid = view.GridControl.Name;

            GridSelRows = null;

            if (view.SelectedRowsCount > 1)
            {
                GridSelRows = view.GetSelectedRows();

                TempTable = (view.GridControl.DataSource as DataTable).Copy();
                TempTable.Rows.Clear();

                for (int C1 = 0; C1 < GridSelRows.Length; C1++)
                {
                    TempTable.ImportRow(view.GetDataRow(GridSelRows[C1]));
                }
            }
            else
            {
                GridHitInfo hitInfo = view.CalcHitInfo(new Point(e.X, e.Y));

                if (e.Button == MouseButtons.Left && hitInfo.RowHandle >= 0)
                {
                    TempTable = (view.GridControl.DataSource as DataTable).Copy();
                    TempTable.Rows.Clear();

                    downHitInfo = hitInfo;
                }
            }
        }

        private void GenericGridView_MouseMove(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;

            if (e.Button == MouseButtons.Left && (TempTable.Rows.Count > 0))
            {
                view.GridControl.DoDragDrop(TempTable, DragDropEffects.Move);

                DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = true;
            }
            else
            {
                if (e.Button == MouseButtons.Left && (downHitInfo != null))
                {
                    Size dragSize = SystemInformation.DragSize;

                    Rectangle dragRect = new Rectangle(new Point(downHitInfo.HitPoint.X - dragSize.Width / 2,

                    downHitInfo.HitPoint.Y - dragSize.Height / 2), dragSize);

                    if (!dragRect.Contains(new Point(e.X, e.Y)))
                    {
                        DataRow row = view.GetDataRow(downHitInfo.RowHandle);

                        TempTable.ImportRow(row);

                        view.GridControl.DoDragDrop(TempTable, DragDropEffects.Move);

                        downHitInfo = null;

                        DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = true;

                    }
                }
            }
        }

        private void GenericGrid_DragOver(object sender, DragEventArgs e)
        {
            GridControl grid = sender as GridControl;

            if (e.Data.GetDataPresent(typeof(DataTable)) && (grid.Name != FromGrid))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void GenericGrid_DragDrop(object sender, DragEventArgs e)
        {
            string MyKeyX;
            string MyKeyZ;

            GridControl grid = sender as GridControl;
            GridControl Othergrid;

            if (grid.Name == "grdB")
            {
                MyKeyX = BPriKey;
                MyKeyZ = APriKey;

                Othergrid = grdA as GridControl;
            }
            else
            {
                MyKeyX = APriKey;
                MyKeyZ = BPriKey;

                Othergrid = grdB as GridControl;
            }

            DataTable ReceivedData = new DataTable();

            ReceivedData = e.Data.GetData(typeof(DataTable)) as DataTable;

            for (int C1 = 0; C1 < ReceivedData.Rows.Count; C1++)
            {
                DataRow[] foundRows;

                foundRows = (grid.DataSource as DataTable).Select(MyKeyX + " = " + ReceivedData.Rows[C1][MyKeyZ]);

                if (foundRows.Length == 0)
                {
                    (grid.DataSource as DataTable).ImportRow(ReceivedData.Rows[C1]);

                    //Delete row from other grid
                    foundRows = (Othergrid.DataSource as DataTable).Select(MyKeyZ + " = " + ReceivedData.Rows[C1][MyKeyZ]);

                    if (foundRows.Length != 0)
                    {
                        (Othergrid.DataSource as DataTable).Rows.Remove(foundRows[0]);
                    }
                }
            }
        }

        public DataTable GetData(int WhichGrid)
        {
            if (WhichGrid == 0)
            {
                return dsA;
            }
            else
            {
                return dsB;
            }
        }

        public void ShowLoading()
        {
            try
            {
                devLoading1.Dock = DockStyle.Fill;
                devLoading1.Visible = true;
                devLoading1.BringToFront();

                devLoading2.Dock = DockStyle.Fill;
                devLoading2.Visible = true;
                devLoading2.BringToFront();

                Application.DoEvents();
            }
            catch (Exception Ex)
            {
            }
        }

        public void HideLoading()
        {
            try
            {
                devLoading1.Visible = false;
                devLoading2.Visible = false;
            }
            catch (Exception Ex)
            {
            }
        }

        private void devAvailableApplied_ClientSizeChanged(object sender, EventArgs e)
        {
            try
            {
                gbAvail.Width = (this.Width / 2) - 1;
                gbAvail.Left = 0;

                gbApplied.Width = gbAvail.Width + 1;
                gbApplied.Left = (this.Width) - gbApplied.Width;
            }
            catch
            {

            }
        }
    }
}
