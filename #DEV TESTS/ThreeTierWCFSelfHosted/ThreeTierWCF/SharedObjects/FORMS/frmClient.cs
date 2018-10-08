using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SharedObjects.CLASSES;
using SharedObjects.DATA;

namespace SharedObjects.FORMS
{
    public partial class frmClient : Form
    {
        tblClient _tblClient = new tblClient();
        tblClientContact _tblClientContact = new tblClientContact();
        tblExport _tblExport = new tblExport();
        

        int RowID = -1;
        string IDX = "";
        int RowID2 = -1;
        string IDX2 = "";

        public frmClient()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void contactTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmContactTypes myForm = new frmContactTypes();
            myForm.Show();
        }

        private void frmClient_Shown(object sender, EventArgs e)
        {
            LoadData();
            DoRefresh();
        }

        private void LoadData()
        {
            dataGridView1.DataSource = null;

            DataTable dummy = new DataTable();
            int retry = 5;
            while (dummy.Rows.Count == 0 && retry > 0)
            {
                dummy = _tblClient.GetData().Copy();
                retry = retry - 1;
            }

            dataGridView1.DataSource = dummy.Copy();
            dataGridView1 = clsHelpers.FixCols(dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmClientDetails myForm;
            myForm = new frmClientDetails();
            myForm.edtGender.SelectedIndex = 0;

            myForm.ShowDialog();

            if (myForm.DialogResult == DialogResult.OK)
            {
                if (myForm.edtGender.Text == "Female")
                {
                    IDX = _tblClient.AddRec(myForm.edtName.Text, myForm.edtSurname.Text, 0, (int)myForm.edtAge.Value);
                }
                else
                {
                    IDX = _tblClient.AddRec(myForm.edtName.Text, myForm.edtSurname.Text, 1, (int)myForm.edtAge.Value);
                }

                LoadData();

                foreach (DataGridViewRow ARec in dataGridView1.Rows)
                {
                    if (ARec.Cells[0].Value.ToString() == IDX)
                    {
                        dataGridView1.CurrentCell = ARec.Cells[1];
                    }

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DoEdit();
        }

        private void DoEdit()
        {
            try
            {
                frmClientDetails myForm;
                myForm = new frmClientDetails();

                IDX = dataGridView1.CurrentRow.Cells["IDX"].Value.ToString();

                if (dataGridView1.CurrentRow.Cells["Gender"].Value.ToString() == "Female")
                {
                    myForm.edtGender.SelectedIndex = 0;
                }
                else
                {
                    myForm.edtGender.SelectedIndex = 1;
                }

                myForm.edtName.Text = dataGridView1.CurrentRow.Cells["Name"].Value.ToString();
                myForm.edtSurname.Text = dataGridView1.CurrentRow.Cells["Surname"].Value.ToString();
                myForm.edtAge.Text = dataGridView1.CurrentRow.Cells["Age"].Value.ToString();

                myForm.ShowDialog();

                if (myForm.DialogResult == DialogResult.OK)
                {
                    if (myForm.edtGender.Text == "Female")
                    {
                        _tblClient.EditRec(IDX, myForm.edtName.Text, myForm.edtSurname.Text, 0, (int)myForm.edtAge.Value);
                    }
                    else
                    {
                        _tblClient.EditRec(IDX, myForm.edtName.Text, myForm.edtSurname.Text, 1, (int)myForm.edtAge.Value);
                    }

                    LoadData();

                    foreach (DataGridViewRow ARec in dataGridView1.Rows)
                    {
                        if (ARec.Cells[0].Value.ToString() == IDX)
                        {
                            dataGridView1.CurrentCell = ARec.Cells[1];
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Select a row first");
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DoEdit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure?", "Remove", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    IDX = dataGridView1.CurrentRow.Cells["IDX"].Value.ToString();

                    _tblClient.DeleteRec(IDX);

                    LoadData();

                }
                catch
                {
                    MessageBox.Show("Select a row first");
                }
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            DoRefresh();
        }

        private void DoRefresh()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView2.DataSource = null;

                DataTable dummy2 = new DataTable();
                int retry2 = 5;
                while (dummy2.Rows.Count == 0 && retry2 > 0)
                {
                    try
                    {
                        dummy2 = _tblClientContact.GetData(dataGridView1.CurrentRow.Cells["IDX"].Value.ToString()).Copy();
                    }
                    catch
                    {
                        dummy2 = _tblClientContact.GetData(dataGridView1.Rows[0].Cells["IDX"].Value.ToString()).Copy();
                    }

                    retry2 = retry2 - 1;
                }

                dataGridView2.DataSource = dummy2.Copy();
                dataGridView2 = FixCols(dataGridView2);
            }
        }

        public static DataGridView FixCols(DataGridView theGrid)
        {
            DataGridView tmpGrid = new DataGridView();
            tmpGrid = theGrid;

            for (int i = 0; i < tmpGrid.ColumnCount; i++)
            {
                if ((tmpGrid.Columns[i].HeaderText == "IDX") ||
                    (tmpGrid.Columns[i].HeaderText == "ClientIDX") ||
                    (tmpGrid.Columns[i].HeaderText == "ContactTypeIDX") ||
                    (tmpGrid.Columns[i].HeaderText == "Type")
                    )
                {
                    tmpGrid.Columns[i].Visible = false;
                }
            }

            return tmpGrid;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                frmContactDetails myForm;
                myForm = new frmContactDetails();

                //Get contact types
                myForm.edtType.Items.Clear();
                myForm.dummyTypes.Clear();

                tblContactType _tblContactType = new tblContactType();
                DataTable dummy = new DataTable();
                int retry = 5;
                while (dummy.Rows.Count == 0 && retry > 0)
                {
                    dummy = _tblContactType.GetData().Copy();
                    retry = retry - 1;
                }

                List<string> tmp = new List<string>();

                foreach (DataRow ARec in dummy.Rows)
                {
                    myForm.edtType.Items.Add(ARec["Description"].ToString());
                    myForm.dummyTypes.Add(ARec["Type"].ToString());
                    tmp.Add(ARec["IDX"].ToString());
                }

                myForm.edtType.SelectedIndex = 0;

                myForm.ShowDialog();

                if (myForm.DialogResult == DialogResult.OK)
                {
                    if (myForm.dummyTypes[myForm.edtType.SelectedIndex] == "Number")
                    {
                        IDX = _tblClientContact.AddRec(dataGridView1.CurrentRow.Cells["IDX"].Value.ToString(), tmp[myForm.edtType.SelectedIndex], myForm.edt1.Text);
                    }
                    else
                    {
                        IDX = _tblClientContact.AddRec(dataGridView1.CurrentRow.Cells["IDX"].Value.ToString(), tmp[myForm.edtType.SelectedIndex], myForm.edt1.Text + "," + myForm.edt2.Text + "," + myForm.edt3.Text + ",");
                    }

                    DoRefresh();

                    foreach (DataGridViewRow ARec in dataGridView2.Rows)
                    {
                        if (ARec.Cells[0].Value.ToString() == IDX)
                        {
                            dataGridView2.CurrentCell = ARec.Cells[4];
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Select a row first");
            }
        }

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            DoRefresh();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DoEdit2();
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            DoEdit2();
        }

        private void DoEdit2()
        {
            try
            {
                frmContactDetails myForm;
                myForm = new frmContactDetails();

                //Get contact types
                myForm.edtType.Items.Clear();
                myForm.dummyTypes.Clear();

                tblContactType _tblContactType = new tblContactType();
                DataTable dummy = new DataTable();
                int retry = 5;
                while (dummy.Rows.Count == 0 && retry > 0)
                {
                    dummy = _tblContactType.GetData().Copy();
                    retry = retry - 1;
                }

                List<string> tmp = new List<string>();

                foreach (DataRow ARec in dummy.Rows)
                {
                    myForm.edtType.Items.Add(ARec["Description"].ToString());
                    myForm.dummyTypes.Add(ARec["Type"].ToString());
                    tmp.Add(ARec["IDX"].ToString());
                }

                IDX = dataGridView2.CurrentRow.Cells["IDX"].Value.ToString();

                int tmpIDX = -1;

                for (int i = 0; i < tmp.Count; i++)
                {
                    if (dataGridView2.CurrentRow.Cells["ContactTypeIDX"].Value.ToString() == tmp[i])
                    {
                        tmpIDX = i;
                        break;
                    }
                }

                myForm.edtType.SelectedIndex = tmpIDX;

                if (myForm.dummyTypes[tmpIDX] == "Number")
                {
                    myForm.edt1.Text = dataGridView2.CurrentRow.Cells["Contact"].Value.ToString();
                }
                else
                {
                    string theData = dataGridView2.CurrentRow.Cells["Contact"].Value.ToString();
                    string A1 = theData.Substring(0, theData.IndexOf(","));
                    theData = theData.Substring(theData.IndexOf(",") + 1);
                    string A2 = theData.Substring(0, theData.IndexOf(","));
                    theData = theData.Substring(theData.IndexOf(",") + 1);
                    string A3 = theData.Substring(0, theData.IndexOf(","));

                    myForm.edt1.Text = A1;
                    myForm.edt2.Text = A2;
                    myForm.edt3.Text = A3;

                }

                myForm.ShowDialog();

                if (myForm.DialogResult == DialogResult.OK)
                {
                    if (myForm.dummyTypes[tmpIDX] == "Number")
                    {
                        IDX = _tblClientContact.EditRec(IDX, dataGridView1.CurrentRow.Cells["IDX"].Value.ToString(), tmp[myForm.edtType.SelectedIndex], myForm.edt1.Text);
                    }
                    else
                    {
                        IDX = _tblClientContact.EditRec(IDX, dataGridView1.CurrentRow.Cells["IDX"].Value.ToString(), tmp[myForm.edtType.SelectedIndex], myForm.edt1.Text + "," + myForm.edt2.Text + "," + myForm.edt3.Text + ",");
                    }

                    DoRefresh();

                    foreach (DataGridViewRow ARec in dataGridView2.Rows)
                    {
                        if (ARec.Cells[0].Value.ToString() == IDX)
                        {
                            dataGridView2.CurrentCell = ARec.Cells[4];
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Select a row first");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure?", "Remove", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    IDX = dataGridView2.CurrentRow.Cells["IDX"].Value.ToString();

                    _tblClientContact.DeleteRec(IDX);

                    DoRefresh();
                }
                catch
                {
                    MessageBox.Show("Select a row first");
                }
            }
        }

        private void exportToCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Prepare data
            DataTable dummy = new DataTable();
            int retry = 5;
            while (dummy.Rows.Count == 0 && retry > 0)
            {
                dummy = _tblExport.GetData().Copy();
                retry = retry - 1;
            }

            clsHelpers.ExportToCSV(dummy);

            MessageBox.Show("Saved as : " + Application.StartupPath + "\\CSVData.csv");
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Made by Andri van Roooyen (072 987 3627");
        }
    }
}
