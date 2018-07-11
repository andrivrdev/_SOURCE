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
using devGeneric.devClasses.devDynamic;

namespace devGeneric.devForms
{
    public partial class frmUserDetail : DevExpress.XtraEditors.XtraForm
    {
        devSE SE;
        int MyMode;
        string OldUser;

        public frmUserDetail(int xMode, string xOldUser)
        {
            InitializeComponent();

            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            MyMode = xMode;

            SE = new devSE();

            if (MyMode == 0)
            {
                edtUsername.Text = "";
                edtPassword.Text = "";

                this.Text = "Initial Setup";
                sbMain.SetText("Please choose your user details");

                edtUsername.Focus();
            }

            if (MyMode == 1)
            {
                edtUsername.Text = "";
                edtPassword.Text = "";

                this.Text = "Please Log In";
                sbMain.SetText("Please enter your user details");

                edtUsername.Focus();
            }

            //Add User
            if (MyMode == 2)
            {
                edtUsername.Text = "";
                edtPassword.Text = "";

                this.Text = "New User";
                sbMain.SetText("Please choose your user details");

                edtUsername.Focus();
            }

            //Edit User
            if (MyMode == 3)
            {
                this.Text = "Edit User";
                sbMain.SetText("Please update your user details");

                OldUser = xOldUser;

                edtUsername.Focus();
            }
        }

        private bool DoValidate()
        {
            List<string> MyList = new List<string>();

            if ((edtUsername.Text.Length == 0) || (edtPassword.Text.Length == 0))
            {
                XtraMessageBox.Show("Please enter a Username and Password.", "No No No !!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }

            if ((SE.IsAllLettersOrDigits(edtUsername.Text) == false) || (SE.IsAllLettersOrDigits(edtPassword.Text) == false))
            {
                XtraMessageBox.Show("Special characters are not allowed.", "No No No !!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }

            if (MyMode == 2)
            {
                //Check if user exist
                MyList = SE.GetEncryptedUserList();

                foreach (string MyUser in MyList)
                {
                    if (edtUsername.Text == SE.Decrypt(MyUser))
                    {
                        XtraMessageBox.Show("The username selected already exist.", "No No No !!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return false;
                    }
                }
            }

            return true;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            edtUsername.Text = edtUsername.Text.Trim();
            edtPassword.Text = edtPassword.Text.Trim();

            if (DoValidate() == false)
            {
                this.DialogResult = DialogResult.None;

                edtPassword.Text = "";
                edtUsername.Focus();
                edtUsername.SelectAll();
            }
            else
            {
                if (MyMode == 1)
                {
                    //Validate username and password
                    if (SE.ValidateUsernameAndPassword(edtUsername.Text, edtPassword.Text) == false)
                    {
                        XtraMessageBox.Show("Invalid Username or Password.", "Authentication", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;

                        edtPassword.Text = "";
                        edtUsername.Focus();
                        edtUsername.SelectAll();
                    }
                }

                if (MyMode == 2)
                {
                    //Add the user
                    SE.AddUser(edtUsername.Text, edtPassword.Text);
                }

                if (MyMode == 3)
                {
                    //Update the user
                    SE.UpdateUser(OldUser, edtUsername.Text, edtPassword.Text);
                }
            }
        }
    }
}