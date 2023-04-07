using SharedObjects.CLASSES;
using SharedObjects.DATA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SharedObjects.FORMS
{
    public partial class frmContactTypes : Form
    {
        tblContactType _tblContactType = new tblContactType();

        int RowID = -1;
        string IDX = "";

        public frmContactTypes()
        {
            InitializeComponent();
        }

        private void frmContactTypes_Shown(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            dataGridView1.DataSource = null;

            DataTable dummy = new DataTable();
            int retry = 5;
            while (dummy.Rows.Count == 0 && retry > 0)
            {
                dummy = _tblContactType.GetData().Copy();
                retry = retry - 1;
            }

            dataGridView1.DataSource = dummy.Copy();
            dataGridView1 = clsHelpers.FixCols(dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmClientDetail myForm;
            myForm = new frmClientDetail();
            myForm.edtType.SelectedIndex = 0;

            myForm.ShowDialog();

            if (myForm.DialogResult == DialogResult.OK)
            {
                if (myForm.edtType.Text == "Number")
                {
                    IDX = _tblContactType.AddRec(0, myForm.edtDescription.Text);
                }
                else
                {
                    IDX = _tblContactType.AddRec(1, myForm.edtDescription.Text);
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

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure?", "Remove", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    IDX = dataGridView1.CurrentRow.Cells["IDX"].Value.ToString();

                    _tblContactType.DeleteRec(IDX);

                    LoadData();

                }
                catch
                {
                    MessageBox.Show("Select a row first");
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
                frmClientDetail myForm;
                myForm = new frmClientDetail();

                IDX = dataGridView1.CurrentRow.Cells["IDX"].Value.ToString();

                if (dataGridView1.CurrentRow.Cells["Type"].Value.ToString() == "Number")
                {
                    myForm.edtType.SelectedIndex = 1;
                }
                else
                {
                    myForm.edtType.SelectedIndex = 0;
                }


                myForm.edtDescription.Text = dataGridView1.CurrentRow.Cells["Description"].Value.ToString();

                myForm.ShowDialog();

                if (myForm.DialogResult == DialogResult.OK)
                {
                    if (myForm.edtType.Text == "Number")
                    {
                        _tblContactType.EditRec(IDX, 0, myForm.edtDescription.Text);
                    }
                    else
                    {
                        _tblContactType.EditRec(IDX, 1, myForm.edtDescription.Text);
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
    }
}
