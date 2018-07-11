using DevExpress.Skins;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using devGeneric.devClasses.devStatic;
using devGeneric.devControls;
using devGeneric.devForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace devGeneric.devClasses.devDynamic
{
    public delegate void devSE_Progress1(int Max, int Progress);
    public delegate void devSE_ProgressText1(string MyMessage);
    public delegate void devSE_Progress2(int Max, int Progress);
    public delegate void devSE_ProgressText2(string MyMessage);
    public delegate void devSE_LabelHide();

    public delegate void devSE_ProgressHide(int xProgressBar, int xZeroIsBarOneIsText);

    public class devSE
    {
        public event devSE_Progress1 onDoProgress1;
        public event devSE_ProgressText1 onDoProgressText1;
        public event devSE_Progress2 onDoProgress2;
        public event devSE_ProgressText2 onDoProgressText2;

        public event devSE_ProgressHide onDoProgressHide;
        public event devSE_LabelHide onDoLabelHide;

        List<Control> zControlList = new List<Control>();
        
        public void LoadSkin()
        {
            DevExpress.UserSkins.BonusSkins.Register();
            SkinManager.EnableFormSkins();
            SkinManager.EnableMdiFormSkins();
            DevExpress.LookAndFeel.DefaultLookAndFeel defLookAndFeel = new DevExpress.LookAndFeel.DefaultLookAndFeel();
            defLookAndFeel.LookAndFeel.SetSkinStyle("Dark Side");
        }

        public bool MustKickUser()
        {
            try
            {
                //Find record
                string SQL = "";
                DataTable dtData;

                SQLiteConnection MyConn = new SQLiteConnection(@"Data Source=" + devGlobals.gDB);
                MyConn.Open();

                SQL =
                "SELECT " + Environment.NewLine +
                "  tblUsers.KickUser" + Environment.NewLine +
                "FROM" + Environment.NewLine +
                "  tblUsers" + Environment.NewLine +
                "WHERE" + Environment.NewLine +
                "  tblUsers.Username = '" + devGlobals.gEncUsername + "'";

                SQLiteCommand MyCommand = new SQLiteCommand(SQL, MyConn);
                SQLiteDataReader MyReader = MyCommand.ExecuteReader();

                dtData = new DataTable();
                dtData.Load(MyReader);

                MyCommand.Dispose();
                MyReader.Dispose();

                for (int i = 0; i < dtData.Rows.Count; i++)
                {
                    if ((dtData.Rows[i][0].ToString()) == "1" && devGlobals.gSkipKickUser == false)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                return false;
            }
            catch (Exception Ex)
            {
                WriteLog(Ex.Message, "devSE", "MustKickUser");
                return false;
            }
        }

        public List<string> GetUserAccessTagList(string xEncUsername)
        {
            try
            {
                List<string> TempList = new List<string>();

                //Get from DB
                string SQL = "";
                DataTable dtData;

                SQLiteConnection MyConn = new SQLiteConnection(@"Data Source=" + devGlobals.gDB);
                MyConn.Open();

                SQL =
                "SELECT " + Environment.NewLine +
                "  tblAccessRights.Tag, tblAccessRights.Description" + Environment.NewLine +
                "FROM" + Environment.NewLine +
                "  tblUserAccess" + Environment.NewLine +
                "  INNER JOIN tblAccessRights ON (tblUserAccess.AccessRightsIDX = tblAccessRights.IDX)" + Environment.NewLine +
                "  INNER JOIN tblUsers ON (tblUserAccess.UsersIDX = tblUsers.IDX)" + Environment.NewLine +
                "WHERE" + Environment.NewLine +
                "  tblUsers.Username = '" + xEncUsername + "'";

                SQLiteCommand MyCommand = new SQLiteCommand(SQL, MyConn);
                SQLiteDataReader MyReader = MyCommand.ExecuteReader();

                dtData = new DataTable();
                dtData.Load(MyReader);

                MyCommand.Dispose();
                MyReader.Dispose();

                //Loop data
                foreach (DataRow ARow in dtData.Rows)
                {
                    string Tag = Decrypt(ARow[0].ToString());
                    string Desc = Decrypt(ARow[1].ToString());

                    if (Desc == "Modify System Defaults")
                    {
                        Tag = Tag;
                    }

                    TempList.Add(Decrypt(ARow[0].ToString()));
                }

                return TempList;
            }
            catch (Exception Ex)
            {
                WriteLog(Ex.Message, "devSE", "GetUserAccessTagList");
                return new List<string>();
            }
        }

        public bool HideControl(int xTag)
        {
            try
            {
                bool found = true;
                for (int i = 0; i < devGlobals.gMainMenuButtonList.Count; i++)
                {
                    if (xTag.ToString() == devGlobals.gMainMenuButtonList[i])
                    {
                        found = false;
                        break;
                    }
                }

                return found;
            }
            catch (Exception Ex)
            {
                WriteLog(Ex.Message, "devSE", "HideControl");
                return true;
            }
        }

        public void PrepareRightsData(string xUser)
        {
            //Prepare data for fast processing
            bool tmpIsAdmin = false;
            if (CheckUserRegistration(Encrypt(xUser), GetEncUserPCID(Encrypt(xUser), GetPCID())) == 2)
            {
                tmpIsAdmin = true;
            }

            devGlobals.gFastIsAdmin = tmpIsAdmin;

            List<string> MyAccessList = new List<string>();
            MyAccessList = GetUserAccessTagList(GetEncUsername(xUser));

            devGlobals.gFastAccessList = MyAccessList;
        }

        public void ApplyRights(string xUser, Control xMyControl)
        {
            //Apply rights to any container
            try
            {
                int TheTag = 0;

                //Prepare data for fast processing
                bool tmpIsAdmin = devGlobals.gFastIsAdmin;
                List<string> MyAccessList = new List<string>();
                MyAccessList = devGlobals.gFastAccessList;

                foreach (Control c in xMyControl.Controls)
                {
                    ColorMyGrids(c);
                    ApplyRights(xUser, c);

                    bool AlreadyApplied = false;

                    ////FOR NAVBARS
                    try
                    {
                        if (!AlreadyApplied)
                        {
                            if (c.GetType() == typeof(DevExpress.XtraNavBar.NavBarControl))
                            {
                                AlreadyApplied = true;

                                //Loop navbar items
                                DevExpress.XtraNavBar.NavBarControl TheNavBar = c as DevExpress.XtraNavBar.NavBarControl;

                                for (int i = 0; i < TheNavBar.Items.Count; i++)
                                {
                                    try
                                    {
                                        TheTag = Convert.ToInt32(TheNavBar.Items[i].Tag);
                                    }
                                    catch
                                    {
                                        TheTag = 0;
                                    }

                                    if (TheTag >= 1000)
                                    {
                                        if (TheTag == 1024)
                                        {
                                            TheTag = TheTag;
                                        }

                                        bool tmpSecure = false;

                                        //Check if the user is an admin user
                                        if (tmpIsAdmin)
                                        {
                                            tmpSecure = true;
                                        }


                                        foreach (string MyTag in MyAccessList)
                                        {
                                            if (Convert.ToInt32(MyTag) == TheTag)
                                            {
                                                tmpSecure = true;
                                            }
                                        }

                                        //Apply righs
                                        if (tmpSecure)
                                        {
                                            TheNavBar.Items[i].Enabled = true;

                                        }
                                        else
                                        {
                                            TheNavBar.Items[i].Enabled = false;

                                        }

                                        //Show or Hide items not belonging to program
                                        if (!HideControl(TheTag))
                                        {
                                            TheNavBar.Items[i].Visible = true;
                                        }
                                        else
                                        {
                                            TheNavBar.Items[i].Visible = false;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch
                    {

                    }


                    ///


                }
            }
            catch (Exception Ex)
            {
            }
        }

        public void ColorMyGrids(Control xContainer)
        {
            foreach (Control c in xContainer.Controls)
            {
                ColorMyGrids(c);
                if (c is DevExpress.XtraGrid.GridControl)
                {
                    DevExpress.XtraGrid.GridControl TheGrid = new DevExpress.XtraGrid.GridControl();
                    TheGrid = c as DevExpress.XtraGrid.GridControl;

                    ((DevExpress.XtraGrid.Views.Grid.GridView)TheGrid.MainView).Appearance.Row.BackColor = devGlobals.gRowCol1;
                    ((DevExpress.XtraGrid.Views.Grid.GridView)TheGrid.MainView).Appearance.Row.BackColor2 = devGlobals.gRowCol2;
                    ((DevExpress.XtraGrid.Views.Grid.GridView)TheGrid.MainView).Appearance.SelectedRow.BackColor = devGlobals.gSelRowCol1;
                    ((DevExpress.XtraGrid.Views.Grid.GridView)TheGrid.MainView).Appearance.SelectedRow.BackColor2 = devGlobals.gSelRowCol2;
                    ((DevExpress.XtraGrid.Views.Grid.GridView)TheGrid.MainView).Appearance.FocusedRow.BackColor = devGlobals.gCurRowCol1;
                    ((DevExpress.XtraGrid.Views.Grid.GridView)TheGrid.MainView).Appearance.FocusedRow.BackColor2 = devGlobals.gCurRowCol2;
                    ((DevExpress.XtraGrid.Views.Grid.GridView)TheGrid.MainView).Appearance.HideSelectionRow.BackColor = devGlobals.gCurRowCol1;
                    ((DevExpress.XtraGrid.Views.Grid.GridView)TheGrid.MainView).Appearance.HideSelectionRow.BackColor2 = devGlobals.gCurRowCol2;



                    //Do narrow font
                    foreach (GridColumn ACol in ((DevExpress.XtraGrid.Views.Grid.GridView)TheGrid.MainView).Columns)
                    {
                        ACol.AppearanceHeader.Font = devGlobals.gHeaderFont;
                        ACol.AppearanceCell.Font = devGlobals.gCellFont;
                    }
                }
            }
        }

        private List<Control> GetAllControls(Control container)
        {
            foreach (Control c in container.Controls)
            {
                GetAllControls(c);
                if (c.GetType() == typeof(devLoading))
                {
                    zControlList.Add(c);
                }
            }

            return zControlList;
        }

        public void ShowHideLoading(Control xMyControl, int xOffOn, List<Control> xIncludedNames)
        {
            zControlList = new List<Control>();

            foreach (Control devLoading in GetAllControls(xMyControl))
            {
                bool MustDo = false;
                if (xIncludedNames.Count > 0)
                {
                    foreach (Control ARec in xIncludedNames)
                    {
                        if (ARec.Name == devLoading.Name)
                        {
                            MustDo = true;
                            break;
                        }
                    }
                }
                else
                {
                    MustDo = true;
                }

                if (MustDo)
                {
                    if (xOffOn == 0)
                    {
                        //MessageBox.Show(c.Name);

                        devLoading.Visible = false;
                        devLoading.SendToBack();
                    }
                    else
                    {
                        devLoading.Dock = DockStyle.Fill;
                        devLoading.Visible = true;
                        devLoading.BringToFront();
                    }

                    Application.DoEvents();
                }
            }





            //foreach (Control c in xMyControl.Controls)
            //{
            //    if ((c.Name == "devGroupBox3"))
            //    {
            //        int a = 0;
            //    }

            //    ShowHideLoading(c, xOffOn, xIncludedNames);


            //    if (c.GetType() == typeof(devLoading))
            //    {
            //        MessageBox.Show("A:" + c.Name);


            //        bool MustDo = false;
            //        if (xIncludedNames.Count > 0)
            //        {
            //            foreach (Control ARec in xIncludedNames)
            //            {
            //                if (ARec.Name == c.Name)
            //                {
            //                    MustDo = true;
            //                    break;
            //                }
            //            }
            //        }
            //        else
            //        {
            //            MustDo = true;
            //        }

            //        if ((MustDo == false) && (c.Name == "devLoadingData"))
            //        {
            //            int a = 0;
            //        }

            //        if (MustDo)
            //        {
            //            if (xOffOn == 0)
            //            {
            //                MessageBox.Show(c.Name);

            //                c.Visible = false;
            //                c.SendToBack();
            //            }
            //            else
            //            {
            //                c.Dock = DockStyle.Fill;
            //                c.Visible = true;
            //                c.BringToFront();
            //            }

            //            Application.DoEvents();
            //        }
            //    }
            //}
        }

        public void WriteLog(string xMessage, string xForm, string xMethod)
        {
            try
            {
                if (devGlobals.gDebugLog)
                {
                    FileInfo MyFile = new FileInfo(devGlobals.gLocalSettingFile);
                    StreamWriter MyLogWrite = new StreamWriter(MyFile.DirectoryName + "\\Log.txt", true, Encoding.Unicode);

                    MyLogWrite.WriteLine("[" + DateTime.Now.Year.ToString() + "/" +
                                                              DateTime.Now.Month.ToString() + "/" +
                                                              DateTime.Now.Day.ToString() + " " +
                                                              DateTime.Now.Hour.ToString() + ":" +
                                                              DateTime.Now.Minute.ToString() + ":" +
                                                              DateTime.Now.Second.ToString() + ":" +
                                                              DateTime.Now.Millisecond.ToString() + "] [" + xForm + "] [" + xMethod + "] " + xMessage);

                    MyLogWrite.Close();
                }
            }
            catch (Exception Ex)
            {
            }
        }

        public int DoSettingsIni()
        {
            //Set progress text
            if (onDoProgressText1 != null)
            {
                onDoProgressText1("Loading INI...");
            }

            if (onDoProgress1 != null)
            {
                onDoProgress1(1, 0);
            }

            //Check if we can get the id, else exit
            if (GetPCID().Length == 0)
            {
                //Unable
                if (onDoLabelHide != null)
                {
                    onDoLabelHide();
                }

                XtraMessageBox.Show("Your computer is unable to run this software." + Environment.NewLine + Environment.NewLine +
                                    "Click [OK] to close the application.", "PC ID Check", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                //return 999;
            }

            try
            {
                //Check local ini
                if (File.Exists(devGlobals.gLocalSettingFile))
                {
                    if (onDoProgress1 != null)
                    {
                        onDoProgress1(3, 0);
                    }

                    //Confirm the ini file has not been tampered with
                    if (CheckINIFileTamper(devGlobals.gLocalSettingFile))
                    {
                        if (onDoProgress1 != null)
                        {
                            onDoProgress1(3, 1);
                        }

                        //Make a backup
                        FileInfo MyFile = new FileInfo(devGlobals.gLocalSettingFile);
                        File.Copy(devGlobals.gLocalSettingFile, MyFile.DirectoryName + "\\LocalSettings.bu", true);

                        if (onDoProgress1 != null)
                        {
                            onDoProgress1(3, 2);
                        }

                        //Read path to DB from local settings file
                        devINIFile MyINI = new devINIFile(devGlobals.gLocalSettingFile);

                        devGlobals.gDB = Decrypt(MyINI.ReadString("DEFAULTS", "DBPATH")) + "\\" + devGlobals.gDBName + ".dat";

                        devGlobals.gDB = devGlobals.gDB.Replace("\\\\", "\\");

                        List<string> MySections = new List<string>();
                        MySections = MyINI.GetSections();

                        bool found = false;
                        foreach (string ASection in MySections)
                        {
                            if (ASection == "DEBUG")
                            {
                                found = true;
                                break;
                            }
                        }

                        if (!found)
                        {
                            MyINI.WriteString("DEBUG", "DOLOG", "0");
                        }

                        if (MyINI.ReadString("DEBUG", "DOLOG") == "1")
                        {
                            devGlobals.gDebugLog = true;
                        }
                        else
                        {
                            devGlobals.gDebugLog = false;
                        }

                        if (onDoProgress1 != null)
                        {
                            onDoProgress1(3, 3);
                        }
                    }
                    else
                    {
                        //File has been tampered
                        if (onDoLabelHide != null)
                        {
                            onDoLabelHide();
                        }

                        XtraMessageBox.Show("Your naughty fingers has tampered with the Settings file." + Environment.NewLine + Environment.NewLine +
                                            "DO NOT HACK MY SOFTWARE!!!" + Environment.NewLine + Environment.NewLine +
                                            "Click [OK] to close the application.", "ANTI HACKING", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                        return 999;
                    }
                }
                else
                {
                    if (onDoProgressText1 != null)
                    {
                        onDoProgressText1("Setup INI...");
                    }

                    if (onDoProgress1 != null)
                    {
                        onDoProgress1(3, 0);
                    }

                    //Create default file
                    devINIFile MyINI = new devINIFile(devGlobals.gLocalSettingFile);

                    MyINI.WriteString("DEBUG", "DOLOG", "0");

                    if (XtraMessageBox.Show("This is the first time running the application. Please take a second to configure your settings." + Environment.NewLine + Environment.NewLine +
                                            "Are you running the application over the network and sharing your data with other users?", "Initial Setup", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        frmInternalDBPathDetails MyForm;

                        MyForm = new frmInternalDBPathDetails(0, "");

                        if (MyForm.ShowDialog() == DialogResult.OK)
                        {
                            return 1;
                        }
                        else
                        {
                            if (onDoLabelHide != null)
                            {
                                onDoLabelHide();
                            }

                            XtraMessageBox.Show("You have failed to configure the initial setup." + Environment.NewLine + Environment.NewLine +
                                                "Click [OK] to close the application.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            return 999;
                        }
                    }
                    else
                    {
                        FileInfo MyFile = new FileInfo(devGlobals.gDB);

                        SetDBPath(MyFile.DirectoryName);

                        CreateINIFileAntiTamper(devGlobals.gLocalSettingFile);
                    }
                }

                //Connect to database
                string encUser;
                string encPassword;

                FileInfo MyDB = new FileInfo(devGlobals.gDB);

                if ((File.Exists(devGlobals.gDB)) && (MyDB.Length > 0))
                {
                    //Set progress text
                    if (onDoProgressText1 != null)
                    {
                        onDoProgressText1("Connecting DB...");
                    }

                    if (onDoProgress1 != null)
                    {
                        onDoProgress1(2, 0);
                    }

                    devGlobals.gBusySettingUp = false;

                    //Confirm the database has not been tampered with
                    if (CheckDBTamper(devGlobals.gDB, devGlobals.gTamperTableList))
                    {
                        if (onDoProgress1 != null)
                        {
                            onDoProgress1(2, 0);
                        }

                        //Add missing tables if needed
                        CreateAppTables();

                        //Add missing rights if new ones were added
                        CreateAccessRights();

                        //Add new items to the bulletin board
                        CreateBullets();

                        //Add extra database recs
                        DoExtraDBStuff();

                        if (onDoProgress1 != null)
                        {
                            onDoProgress1(2, 2);
                        }

                        //User Login
                        if (onDoLabelHide != null)
                        {
                            onDoLabelHide();
                        }

                        if (DoLogin())
                        {
                            return 0;
                        }
                        else
                        {
                            return 999;
                        }
                    }
                    else
                    {
                        //File has been tampered
                        if (onDoLabelHide != null)
                        {
                            onDoLabelHide();
                        }

                        XtraMessageBox.Show("Your naughty fingers has tampered with the Database security." + Environment.NewLine + Environment.NewLine +
                                            "DO NOT HACK MY SOFTWARE!!!" + Environment.NewLine + Environment.NewLine +
                                            "Click [OK] to close the application.", "ANTI HACKING", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                        return 999;
                    }

                    return 0;
                }
                else
                {
                    if (onDoProgressText1 != null)
                    {
                        onDoProgressText1("Creating DB...");
                    }

                    if (onDoProgress1 != null)
                    {
                        onDoProgress1(7, 0);
                    }

                    devGlobals.gBusySettingUp = true;

                    //Create new DB
                    if (CreateDB(devGlobals.gDB))
                    {
                        CreateAppTables();
                        //xx
                        if (onDoProgressText1 != null)
                        {
                            onDoProgressText1("Select...");
                        }

                        if (onDoProgress1 != null)
                        {
                            onDoProgress1(7, 0);
                        }

                       

                            if (onDoProgressText1 != null)
                            {
                                onDoProgressText1("User setup...");
                            }

                            if (onDoProgress1 != null)
                            {
                                onDoProgress1(7, 0);
                            }

                            frmUserDetail MyForm;

                            MyForm = new frmUserDetail(0, "");

                            if (MyForm.ShowDialog() == DialogResult.OK)
                            {
                                if (onDoProgressText1 != null)
                                {
                                    onDoProgressText1("Configuring...");
                                }

                                if (onDoProgress1 != null)
                                {
                                    onDoProgress1(7, 0);
                                }

                                //User entered correct details
                                AddUser(MyForm.edtUsername.Text, MyForm.edtPassword.Text);
                                if (onDoProgress1 != null)
                                {
                                    onDoProgress1(7, 1);
                                }


                                string EncUser = GetEncUsername(MyForm.edtUsername.Text);
                                if (onDoProgress1 != null)
                                {
                                    onDoProgress1(7, 2);
                                }

                                string MyPCID = GetPCID();
                                if (onDoProgress1 != null)
                                {
                                    onDoProgress1(7, 3);
                                }

                                //Reg
                                List<string> fFields = new List<string>();
                                List<string> vValues = new List<string>();

                                fFields.Add("Username");
                                fFields.Add("PCID");

                                vValues.Add(EncUser);
                                vValues.Add(Encrypt(MyPCID));

                                InsertRec("tblUserReg", fFields, vValues);
                                if (onDoProgress1 != null)
                                {
                                    onDoProgress1(7, 4);
                                }

                                //Access
                                CreateAccessRights();
                                if (onDoProgress1 != null)
                                {
                                    onDoProgress1(7, 5);
                                }

                                //Give the user access
                                ApplyDefaultUserAccess(EncUser);
                                if (onDoProgress1 != null)
                                {
                                    onDoProgress1(7, 6);
                                }

                                CreateDBAntiTamper(devGlobals.gDB, devGlobals.gTamperTableList);
                                if (onDoProgress1 != null)
                                {
                                    onDoProgress1(7, 7);
                                }

                                return 1;
                            }
                            else
                            {
                                if (onDoLabelHide != null)
                                {
                                    onDoLabelHide();
                                }

                                XtraMessageBox.Show("You have failed to enter your user details." + Environment.NewLine + Environment.NewLine +
                                                    "Click [OK] to close the application.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                CreateDBAntiTamper(devGlobals.gDB, devGlobals.gTamperTableList);

                                return 999;
                            }
                        
                    }
                    else
                    {
                        if (onDoLabelHide != null)
                        {
                            onDoLabelHide();
                        }

                        XtraMessageBox.Show("Database connection failed." + Environment.NewLine + Environment.NewLine +
                                            "Click [OK] to close the application.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        return 999;
                    }
                }
            }
            catch (Exception Ex)
            {
                if (onDoLabelHide != null)
                {
                    onDoLabelHide();
                }

                WriteLog(Ex.Message, "devSE", "DoSettingsIni");

                return 999;
            }
        }

        public void ApplyDefaultUserAccess(string xEncUsername)
        {
            try
            {
                //Specify defaults
                List<string> TagList = new List<string>();
                TagList.Add("1001");
                TagList.Add("1006");

                //Find user IDX
                int UserIDX = GetUserIDX(xEncUsername);

                //Find access right IDX'es
                List<string> AccessIDX = new List<string>();

                foreach (string MyTag in TagList)
                {
                    AccessIDX.Add(GetAccessIDXFromTag(Convert.ToInt32(MyTag)).ToString());
                }

                //Now add the recs
                foreach (string MyIDX in AccessIDX)
                {
                    List<string> fFields = new List<string>();
                    List<string> vValues = new List<string>();

                    fFields.Add("UsersIDX");
                    fFields.Add("AccessRightsIDX");

                    vValues.Add(UserIDX.ToString());
                    vValues.Add(MyIDX);

                    InsertRec("tblUserAccess", fFields, vValues);
                }
            }
            catch (Exception Ex)
            {
                WriteLog(Ex.Message, "devSE", "ApplyDefaultUserAccess");
            }
        }

        public int GetAccessIDXFromTag(int xTag)
        {
            try
            {
                //Find user IDX
                string SQL = "";
                DataTable dtData;

                SQLiteConnection MyConn = new SQLiteConnection(@"Data Source=" + devGlobals.gDB);
                MyConn.Open();

                SQL =
                "SELECT " + Environment.NewLine +
                "  tblAccessRights.IDX," + Environment.NewLine +
                "  tblAccessRights.Tag" + Environment.NewLine +
                "FROM" + Environment.NewLine +
                "  tblAccessRights";

                SQLiteCommand MyCommand = new SQLiteCommand(SQL, MyConn);
                SQLiteDataReader MyReader = MyCommand.ExecuteReader();

                dtData = new DataTable();
                dtData.Load(MyReader);

                MyCommand.Dispose();
                MyReader.Dispose();

                for (int i = 0; i < dtData.Rows.Count; i++)
                {
                    if (Convert.ToInt32(Decrypt(dtData.Rows[i][1].ToString())) == xTag)
                    {
                        return Convert.ToInt32(dtData.Rows[i][0].ToString());
                    }
                }

                return 0;
            }
            catch (Exception Ex)
            {
                WriteLog(Ex.Message, "devSE", "GetAccessIDXFromTag");
                return 0;
            }
        }

        public int GetUserIDX(string xEncUsername)
        {
            try
            {
                //Find user IDX
                string SQL = "";
                DataTable dtData;

                SQLiteConnection MyConn = new SQLiteConnection(@"Data Source=" + devGlobals.gDB);
                MyConn.Open();

                SQL =
                "SELECT " + Environment.NewLine +
                "  tblUsers.IDX" + Environment.NewLine +
                "FROM" + Environment.NewLine +
                "  tblUsers" + Environment.NewLine +
                "WHERE" + Environment.NewLine +
                "  tblUsers.Username = '" + xEncUsername + "'";

                SQLiteCommand MyCommand = new SQLiteCommand(SQL, MyConn);
                SQLiteDataReader MyReader = MyCommand.ExecuteReader();

                dtData = new DataTable();
                dtData.Load(MyReader);

                MyCommand.Dispose();
                MyReader.Dispose();

                for (int i = 0; i < dtData.Rows.Count; i++)
                {
                    return Convert.ToInt32(dtData.Rows[i][0].ToString());
                }

                return 0;
            }
            catch (Exception Ex)
            {
                WriteLog(Ex.Message, "devSE", "GetUserIDX");
                return 0;
            }
        }

        public string GetEncUsername(string xUsername)
        {
            try
            {
                //Find record
                string SQL = "";
                DataTable dtData;

                SQLiteConnection MyConn = new SQLiteConnection(@"Data Source=" + devGlobals.gDB);
                MyConn.Open();

                SQL =
                "SELECT DISTINCT " + Environment.NewLine +
                "  tblUsers.Username" + Environment.NewLine +
                "FROM" + Environment.NewLine +
                "  tblUsers";

                SQLiteCommand MyCommand = new SQLiteCommand(SQL, MyConn);
                SQLiteDataReader MyReader = MyCommand.ExecuteReader();

                dtData = new DataTable();
                dtData.Load(MyReader);

                MyCommand.Dispose();
                MyReader.Dispose();

                for (int i = 0; i < dtData.Rows.Count; i++)
                {
                    if (Decrypt(dtData.Rows[i][0].ToString()) == xUsername)
                    {
                        return dtData.Rows[i][0].ToString();
                    }
                }

                return "";
            }
            catch (Exception Ex)
            {
                WriteLog(Ex.Message, "devSE", "GetEncUsername");
                return "";
            }
        }


        public bool CreateDB(string xDB)
        {
            try
            {
                FileInfo MyFile = new FileInfo(xDB);

                if (!(Directory.Exists(MyFile.DirectoryName)))
                {
                    Directory.CreateDirectory(MyFile.DirectoryName);
                }

                if (!File.Exists(xDB))
                {
                    SQLiteConnection.CreateFile(xDB);
                }

                return true;
            }
            catch (Exception Ex)
            {
                WriteLog(Ex.Message, "devSE", "CreateDB");
                return false;
            }
        }

        public bool DoLogin()
        {
            if (onDoProgressText1 != null)
            {
                onDoProgressText1("Log in...");
            }

            if (onDoProgress1 != null)
            {
                onDoProgress1(1, 0);
            }

            frmUserDetail MyForm;

            MyForm = new frmUserDetail(1, "");

            if (MyForm.ShowDialog() == DialogResult.OK)
            {
                //Check for new PCID
                string MyPCID = GetPCID();

                //Compare against known list and add if missing
                if (MyPCID.Length > 0)
                {
                    List<string> MyUserPCIDList = new List<string>();

                    MyUserPCIDList = GetUserPCIDList(devGlobals.gEncUsername);

                    bool Found = false;

                    foreach (string UserPCID in MyUserPCIDList)
                    {
                        if (MyPCID == UserPCID)
                        {
                            Found = true;
                            break;
                        }
                    }

                    if (!(Found))
                    {
                        //Add PCID
                        List<string> fFields = new List<string>();
                        List<string> vValues = new List<string>();

                        fFields.Add("Username");
                        fFields.Add("PCID");

                        vValues.Add(devGlobals.gEncUsername);
                        vValues.Add(Encrypt(MyPCID));

                        InsertRec("tblUserReg", fFields, vValues);
                    }

                    //Check if current MAC is registered
                    MyUserPCIDList = GetUserPCIDList(devGlobals.gEncUsername);

                    foreach (string UserPCID in MyUserPCIDList)
                    {
                        if (UserPCID == MyPCID)
                        {
                            if (CheckUserRegistration(devGlobals.gEncUsername, Encrypt(UserPCID)) == 0)
                            {
                                if (onDoProgressText1 != null)
                                {
                                    onDoProgressText1("Register...");
                                }

                                if (onDoProgress1 != null)
                                {
                                    onDoProgress1(1, 0);
                                }

                                if (XtraMessageBox.Show("This is the first time you are running the application for your user from this PC." + Environment.NewLine + Environment.NewLine +
                                                        "Whould you like to register now?", "Registration", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    frmRegister MyRegForm;

                                    MyRegForm = new frmRegister(devGlobals.gUsername, UserPCID);

                                    if (MyRegForm.ShowDialog() == DialogResult.OK)
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                return true;
                            }
                        }
                    }

                    //Should never get here
                    return false;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public string GetEncryptedNum(string MyValue)
        {
            try
            {
                int IntP1;
                int IntP2;

                string StrP1;
                string StrP2;
                string TempValue = "";
                string Swop = "";

                for (int C1 = 0; C1 < MyValue.Length; C1 += 2)
                {
                    IntP1 = (int)MyValue[C1];
                    IntP2 = (int)MyValue[C1 + 1];

                    StrP1 = IntP1.ToString();

                    while (StrP1.Length < 3)
                    {
                        StrP1 = "0" + StrP1;
                    }

                    StrP2 = IntP2.ToString();

                    while (StrP2.Length < 3)
                    {
                        StrP2 = "0" + StrP2;
                    }

                    //Swop first and last characters
                    Swop = StrP1.Substring(0, 1);
                    StrP1 = StrP1.Remove(0, 1);
                    StrP1 = StrP2.Substring(2, 1) + StrP1;

                    StrP2 = StrP2.Remove(2, 1);
                    StrP2 = StrP2 + Swop;

                    TempValue = TempValue + (StrP1 + StrP2);
                }

                return TempValue;
            }
            catch (Exception Ex)
            {
                WriteLog(Ex.Message, "devSE", "GetEncryptedNum");
                return "";
            }
        }

        public int ValidateRegKey(string xID, string xKey)
        {
            try
            {
                if (Decrypt(GetDecryptedNum(xKey)) == xID)
                {
                    return 0;
                }
                else
                {
                    if (Decrypt(GetDecryptedNum(xKey)) == xID + "admin")
                    {
                        return 1;
                    }
                    else
                    {
                        return 999;
                    }
                }
            }
            catch (Exception Ex)
            {
                WriteLog(Ex.Message, "devSE", "ValidateRegKey");
                return 999;
            }
        }

        public string GetDecryptedNum(string MyValue)
        {
            try
            {
                int IntP1;
                int IntP2;

                string StrP1;
                string StrP2;

                char CharP1;
                char CharP2;

                string TempValue = "";
                string Swop = "";

                string TheString = MyValue;

                //Build string
                while (TheString.Length > 0)
                {
                    StrP1 = TheString.Substring(0, 3);
                    StrP2 = TheString.Substring(3, 3);

                    //Swop first and last characters
                    Swop = StrP1.Substring(0, 1);
                    StrP1 = StrP1.Remove(0, 1);
                    StrP1 = StrP2.Substring(2, 1) + StrP1;

                    StrP2 = StrP2.Remove(2, 1);
                    StrP2 = StrP2 + Swop;

                    //Make them ints
                    IntP1 = Convert.ToInt32(StrP1);
                    IntP2 = Convert.ToInt32(StrP2);

                    CharP1 = (char)IntP1;
                    CharP2 = (char)IntP2;

                    TempValue = TempValue + CharP1.ToString() + CharP2.ToString();

                    TheString = TheString.Remove(0, 6);
                }

                return TempValue;
            }
            catch (Exception Ex)
            {
                WriteLog(Ex.Message, "devSE", "GetDecryptedNum");
                return "";
            }
        }


        public void WriteUserRegistration(string xEncUsername, string xEncPCID, bool xAdmin)
        {
            try
            {
                List<string> MyUserPCIDList = new List<string>();

                MyUserPCIDList = GetUserPCIDList(xEncUsername);

                bool Found = false;

                foreach (string UserPCID in MyUserPCIDList)
                {
                    if (Decrypt(xEncPCID) == UserPCID)
                    {
                        Found = true;
                        break;
                    }
                }

                if (!(Found))
                {
                    //Add PCID
                    List<string> fFields = new List<string>();
                    List<string> vValues = new List<string>();

                    fFields.Add("Username");
                    fFields.Add("PCID");

                    vValues.Add(xEncUsername);
                    vValues.Add(xEncPCID);

                    InsertRec("tblUserReg", fFields, vValues);
                }

                //Now we know the record exist so create reg
                if (xAdmin)
                {
                    //Register as admin
                    List<string> fFields = new List<string>();
                    List<string> vValues = new List<string>();

                    fFields.Add("Register");

                    vValues.Add(Encrypt(xEncUsername + xEncPCID + "admin"));

                    UpdateRec("tblUserReg", fFields, vValues, "[Username] = '" + xEncUsername + "' AND [PCID] = '" + xEncPCID + "'");
                }
                else
                {
                    //Register as normal
                    List<string> fFields = new List<string>();
                    List<string> vValues = new List<string>();

                    fFields.Add("Register");

                    vValues.Add(Encrypt(xEncUsername + xEncPCID));

                    UpdateRec("tblUserReg", fFields, vValues, "[Username] = '" + xEncUsername + "' AND [PCID] = '" + xEncPCID + "'");
                }
            }
            catch (Exception Ex)
            {
                WriteLog(Ex.Message, "devSE", "WriteUserRegistration");
            }
        }


        public string GetEncUserPCID(string xEncUsername, string xPCID)
        {
            try
            {
                //Get from DB
                string SQL = "";
                DataTable dtData;

                SQLiteConnection MyConn = new SQLiteConnection(@"Data Source=" + devGlobals.gDB);
                MyConn.Open();

                SQL =
                "SELECT " + Environment.NewLine +
                "  tblUserReg.PCID" + Environment.NewLine +
                "FROM" + Environment.NewLine +
                "  tblUserReg" + Environment.NewLine +
                "WHERE" + Environment.NewLine +
                "  tblUserReg.Username = '" + xEncUsername + "'";

                SQLiteCommand MyCommand = new SQLiteCommand(SQL, MyConn);
                SQLiteDataReader MyReader = MyCommand.ExecuteReader();

                dtData = new DataTable();
                dtData.Load(MyReader);

                MyCommand.Dispose();
                MyReader.Dispose();

                //Loop data
                foreach (DataRow ARow in dtData.Rows)
                {
                    if (Decrypt(ARow[0].ToString()) == xPCID)
                    {
                        return ARow[0].ToString();
                    }
                }

                return "";
            }
            catch (Exception Ex)
            {
                WriteLog(Ex.Message, "devSE", "GetEncUserPCID");
                return "";
            }
        }

        public int CheckUserRegistration(string xEncUsername, string xEncPCID)
        {
            //return 2;

            try
            {
                //if (GetDefUserManagement() == 0)
                //{
                //Get from DB
                string SQL = "";
                DataTable dtData;

                SQLiteConnection MyConn = new SQLiteConnection(@"Data Source=" + devGlobals.gDB);
                MyConn.Open();

                SQL =
                "SELECT " + Environment.NewLine +
                "  tblUserReg.Register" + Environment.NewLine +
                "FROM" + Environment.NewLine +
                "  tblUserReg" + Environment.NewLine +
                "WHERE" + Environment.NewLine +
                "  tblUserReg.Username = '" + xEncUsername + "' AND" + Environment.NewLine +
                "  tblUserReg.PCID = '" + xEncPCID + "'";

                SQLiteCommand MyCommand = new SQLiteCommand(SQL, MyConn);
                SQLiteDataReader MyReader = MyCommand.ExecuteReader();

                dtData = new DataTable();
                dtData.Load(MyReader);

                MyCommand.Dispose();
                MyReader.Dispose();

                //Loop data
                foreach (DataRow ARow in dtData.Rows)
                {
                    if (Decrypt(ARow[0].ToString()) == xEncUsername + xEncPCID)
                    {
                        //Normal User
                        return 1;
                    }

                    if (Decrypt(ARow[0].ToString()) == xEncUsername + xEncPCID + "admin")
                    {
                        //Admin User
                        return 2;
                    }
                }
                //}
                //else
                //{



                //    return 1;
                //}

                return 0;
            }
            catch (Exception Ex)
            {
                WriteLog(Ex.Message, "devSE", "CheckUserRegistration");
                return 0;
            }
        }

        public void DoExtraDBStuff()
        {
            try
            {
                //DO WHATEVER

                ////Configure default DI login
                //string tUsername = GetSetting("SAPDIUSERNAME");

                //if (tUsername == "")
                //{
                //    WriteSetting("SAPDIUSERNAME", "manager");
                //    WriteSetting("SAPDIPASSWORD", "peanut84");
                //}
            }
            catch (Exception Ex)
            {
                WriteLog(Ex.Message, "devSE", "DoExtraDBStuff");
            }
        }

        public List<string> GetUserPCIDList(string xEncUser)
        {
            try
            {
                List<string> TempList = new List<string>();

                //Get from DB
                string SQL = "";
                DataTable dtData;

                SQLiteConnection MyConn = new SQLiteConnection(@"Data Source=" + devGlobals.gDB);
                MyConn.Open();

                SQL =
                "SELECT " + Environment.NewLine +
                "  tblUserReg.PCID" + Environment.NewLine +
                "FROM" + Environment.NewLine +
                "  tblUserReg" + Environment.NewLine +
                "WHERE" + Environment.NewLine +
                "  tblUserReg.Username = '" + xEncUser + "'";

                SQLiteCommand MyCommand = new SQLiteCommand(SQL, MyConn);
                SQLiteDataReader MyReader = MyCommand.ExecuteReader();

                dtData = new DataTable();
                dtData.Load(MyReader);

                MyCommand.Dispose();
                MyReader.Dispose();

                //Loop data
                foreach (DataRow ARow in dtData.Rows)
                {
                    TempList.Add(Decrypt(ARow[0].ToString()));
                }

                return TempList;
            }
            catch (Exception Ex)
            {
                WriteLog(Ex.Message, "devSE", "GetUserPCIDList");
                return new List<string>();
            }
        }

        public void CreateBullets()
        {
            try
            {
                if (onDoProgressText2 != null)
                {
                    onDoProgressText2("Loading...");
                }

                if (onDoProgress2 != null)
                {
                    onDoProgress2(1, 0);
                }

                List<string> MyBullets = new List<string>();

                string BulText = "";

                if (devGlobals.gProgramName == "PropertySoft" || devGlobals.gProgramName == "devAdmin")
                {
                    BulText =
                    "HINTS" + Environment.NewLine +
                    "--------------------------------------------" + Environment.NewLine +
                    "" + Environment.NewLine +
                    "~01~" + Environment.NewLine +
                    "You can hide the Bulletin Board by clicking" + Environment.NewLine +
                    "the green [X] after reading. Double Click" + Environment.NewLine +
                    "the gradient panel under the menu to show" + Environment.NewLine +
                    "it again." + Environment.NewLine +
                    "" + Environment.NewLine +
                    "~02~" + Environment.NewLine +
                    "New bulletins will always cause the Bulletin" + Environment.NewLine +
                    "Board to re-appear." + Environment.NewLine +
                    "" + Environment.NewLine +
                    "" + Environment.NewLine +
                    "" + Environment.NewLine +
                    "IMPORTANT" + Environment.NewLine +
                    "--------------------------------------------" + Environment.NewLine +
                    "" + Environment.NewLine +
                    "~01~" + Environment.NewLine +
                    "Enjoy the product" + Environment.NewLine +
                    "" + Environment.NewLine +
                    "" + Environment.NewLine +
                    "" + Environment.NewLine +
                    "***";

                    MyBullets.Add(BulText);

                    //BulText =
                    //"STOCK TAKE MODULE OPEN" + Environment.NewLine +
                    //"--------------------------------------------" + Environment.NewLine +
                    //"" + Environment.NewLine +
                    //"~01~" + Environment.NewLine +
                    //"The Stock Take module has been opened for" + Environment.NewLine +
                    //"those whom attended training. Enjoy ;)" + Environment.NewLine +
                    //"" + Environment.NewLine +
                    //"" + Environment.NewLine +
                    //"" + Environment.NewLine +
                    //"***";

                    //MyBullets.Add(BulText);


                    ///ETC ETC
                }

                int MyMax = 0;
                try
                {
                    //Get last bullet
                    string SQL = "";
                    DataTable dtData;

                    SQLiteConnection MyConn = new SQLiteConnection(@"Data Source=" + devGlobals.gDB);
                    MyConn.Open();

                    SQL =
                    "SELECT " + Environment.NewLine +
                    "  MAX(tblBulletinBoard.IDX) AS MyCount" + Environment.NewLine +
                    "FROM" + Environment.NewLine +
                    "  tblBulletinBoard";

                    SQLiteCommand MyCommand = new SQLiteCommand(SQL, MyConn);
                    SQLiteDataReader MyReader = MyCommand.ExecuteReader();

                    dtData = new DataTable();
                    dtData.Load(MyReader);

                    MyCommand.Dispose();
                    MyReader.Dispose();

                    if (dtData.Rows.Count > 0)
                    {
                        MyMax = Convert.ToInt32(dtData.Rows[0]["MyCount"].ToString());
                    }
                }
                catch
                {
                }

                //Add Missing bullets
                for (int i = MyMax; i < MyBullets.Count; i++)
                {
                    List<string> fFields = new List<string>();
                    List<string> vValues = new List<string>();

                    fFields.Add("DisplayText");

                    vValues.Add(MyBullets[i]);

                    InsertRec("tblBulletinBoard", fFields, vValues);

                    if (onDoProgress2 != null)
                    {
                        onDoProgress2(MyBullets.Count, i + 1);
                    }
                }

                if (onDoProgressText2 != null)
                {
                    onDoProgressText2("Complete");
                }

                if (onDoProgress2 != null)
                {
                    onDoProgress2(1, 1);
                }

                if (onDoProgressHide != null)
                {
                    onDoProgressHide(1, 0);
                    onDoProgressHide(1, 1);
                }
            }
            catch (Exception Ex)
            {
                WriteLog(Ex.Message, "devSE", "CreateBullets");
            }
        }


        public void CreateAccessRights()
        {
            try
            {
                if (onDoProgressText2 != null)
                {
                    onDoProgressText2("Loading...");
                }

                if (onDoProgress2 != null)
                {
                    onDoProgress2(1, 0);
                }


                //Accessible Rights Descriptions
                List<string> MyAccessRights = new List<string>();
                List<string> MyEncAccessRights = new List<string>();

                MyAccessRights.Add("ADMIN: Generate Registration Keys|");

                MyAccessRights.Add("USERS AND SECURITY: Maintain Users and Security|PropertySoft|");
                MyAccessRights.Add("USERS AND SECURITY: Add Users|PropertySoft|");
                MyAccessRights.Add("USERS AND SECURITY: Edit Users|PropertySoft|");
                MyAccessRights.Add("USERS AND SECURITY: Delete Users|PropertySoft|");
                MyAccessRights.Add("USERS AND SECURITY: View User Passwords|PropertySoft|");
                MyAccessRights.Add("USERS AND SECURITY: Manage User Access Rights|PropertySoft|");

                MyAccessRights.Add("SYSTEM DEFAULTS: Open System Defaults|PropertySoft|");
                MyAccessRights.Add("SYSTEM DEFAULTS: Modify System Defaults Default Databases Tab|PropertySoft|");
                MyAccessRights.Add("SYSTEM DEFAULTS: Modify System Defaults Email Setup Tab|PropertySoft|");
                MyAccessRights.Add("SYSTEM DEFAULTS: Modify System Defaults Company Details Tab|PropertySoft|");
                MyAccessRights.Add("SYSTEM DEFAULTS: Modify System Defaults Other Tab|PropertySoft|");

                MyAccessRights.Add("DATABASE CONNECTIONS: Maintain Database Connections|PropertySoft|");
                MyAccessRights.Add("DATABASE CONNECTIONS: Add Database Connections|PropertySoft|");
                MyAccessRights.Add("DATABASE CONNECTIONS: Edit Database Connections|PropertySoft|");
                MyAccessRights.Add("DATABASE CONNECTIONS: Delete Database Connections|PropertySoft|");

                //Add devAdmin to whole list
                for (int i = 0; i < MyAccessRights.Count; i++)
                {
                    MyAccessRights[i] += "devAdmin|";
                }

                Dictionary<int, string> MyTags = new Dictionary<int, string>();
                List<string> MyEncTags = new List<string>();

                MyTags.Add(0, "1000");

                MyTags.Add(1, "1001");
                MyTags.Add(2, "1002");
                MyTags.Add(3, "1003");
                MyTags.Add(4, "1004");
                MyTags.Add(5, "1005");
                MyTags.Add(6, "1006");

                MyTags.Add(7, "1007");
                MyTags.Add(8, "1008");
                MyTags.Add(9, "1009");
                MyTags.Add(10, "1010");
                MyTags.Add(11, "1011");

                MyTags.Add(12, "1012");
                MyTags.Add(13, "1013");
                MyTags.Add(14, "1014");
                MyTags.Add(15, "1015");


                //Add rights for current app
                for (int i = 0; i < MyAccessRights.Count; i++)
                {
                    if (MyAccessRights[i].Contains("|" + devGlobals.gProgramName + "|"))
                    {
                        MyEncAccessRights.Add(MyAccessRights[i].Substring(0, MyAccessRights[i].IndexOf("|")));
                        MyEncTags.Add(MyTags[i]);
                    }
                }

                //A decrypted list of tags used to determine menu item for the current app
                devGlobals.gMainMenuButtonList = MyEncTags;

                for (int i = 0; i < MyEncAccessRights.Count; i++)
                {
                    if (!AccessRightExists(MyEncAccessRights[i]))
                    {
                        List<string> fFields = new List<string>();
                        List<string> vValues = new List<string>();

                        fFields.Add("Description");
                        fFields.Add("Tag");

                        vValues.Add(Encrypt(MyEncAccessRights[i]));
                        vValues.Add(Encrypt(MyEncTags[i]));

                        InsertRec("tblAccessRights", fFields, vValues);
                    }

                    if (onDoProgress2 != null)
                    {
                        onDoProgress2(MyEncAccessRights.Count, i + 1);
                    }
                }

                if (onDoProgressText2 != null)
                {
                    onDoProgressText2("Complete");
                }

                if (onDoProgress2 != null)
                {
                    onDoProgress2(1, 1);
                }

                if (onDoProgressHide != null)
                {
                    onDoProgressHide(1, 0);
                    onDoProgressHide(1, 1);
                }
            }
            catch (Exception Ex)
            {
                WriteLog(Ex.Message, "devSE", "CreateAccessRights");
            }
        }

        public bool InsertRec(string xTableName, List<string> xFields, List<string> xValues)
        {
            string SQL = "";

            try
            {
                SQLiteConnection MyConn = new SQLiteConnection(@"Data Source=" + devGlobals.gDB);
                MyConn.Open();


                //Build SQL
                SQL =
                "INSERT INTO [" + xTableName + "]" + Environment.NewLine +
                "(" + Environment.NewLine;

                //Fields
                for (int i = 0; i < xFields.Count; i++)
                {
                    SQL += "[" + xFields[i] + "]";

                    if (i + 1 != xFields.Count)
                    {
                        SQL += ",";
                    }

                    SQL += Environment.NewLine;
                }

                SQL +=
                    ")" + Environment.NewLine +
                    "values" + Environment.NewLine +
                    "(" + Environment.NewLine;

                //Values
                for (int i = 0; i < xValues.Count; i++)
                {
                    //If the value start with || then dont put the value in quotes

                    string tmpSQL = "";
                    if (xValues[i].Contains("'"))
                    {
                        tmpSQL = "'" + xValues[i].Replace("'", "''") + "'";
                    }
                    else
                    {
                        tmpSQL = "'" + xValues[i] + "'";
                    }

                    if (xValues[i].Length > 2)
                    {
                        if (xValues[i].Substring(0, 2) == "||")
                        {
                            xValues[i] = xValues[i].Substring(2);
                            tmpSQL = xValues[i];
                        }
                    }

                    SQL += tmpSQL;

                    if (i + 1 != xFields.Count)
                    {
                        SQL += ",";
                    }

                    SQL += Environment.NewLine;
                }

                SQL += ")";

                SQLiteCommand MyCommand = new SQLiteCommand(SQL, MyConn);
                MyCommand.ExecuteNonQuery();


                //Update User table to displayt new bullets if needed
                if (xTableName == "tblBulletinBoard")
                {
                    List<string> fFields = new List<string>();
                    List<string> vValues = new List<string>();

                    fFields.Add("ShowBulletin");

                    vValues.Add("1");

                    UpdateRec("tblUsers", fFields, vValues, "");
                }

                if (!devGlobals.gBusySettingUp)
                {
                    foreach (string MyTable in devGlobals.gTamperTableList.Keys)
                    {
                        if (xTableName == MyTable)
                        {
                            CreateDBAntiTamper(devGlobals.gDB, devGlobals.gTamperTableList);
                        }
                    }
                }

                return true;
            }
            catch (Exception Ex)
            {
                WriteLog(Ex.Message, "devSE", "InsertRec");
                return false;
            }
        }

        //012
        public bool UpdateRec(string xTableName, List<string> xFields, List<string> xValues, string xWhere)
        {
            try
            {
                string SQL = "";

                SQLiteConnection MyConn = new SQLiteConnection(@"Data Source=" + devGlobals.gDB);
                MyConn.Open();


                //Build SQL
                SQL =
                "UPDATE [" + xTableName + "]" + Environment.NewLine +
                "SET" + Environment.NewLine;

                for (int i = 0; i < xFields.Count; i++)
                {
                    //Fix '
                    if (xValues[i].Contains("'"))
                    {
                        xValues[i] = xValues[i].Replace("'", "''");
                    }

                    //If the value start with || then dont put the value in quotes
                    string tmpSQL = "[" + xFields[i] + "] = '" + xValues[i] + "'";
                    if (xValues[i].Length > 2)
                    {
                        if (xValues[i].Substring(0, 2) == "||")
                        {
                            xValues[i] = xValues[i].Substring(2);

                            tmpSQL = "[" + xFields[i] + "] = " + xValues[i];
                        }
                    }

                    SQL += tmpSQL;
                    if (i + 1 != xFields.Count)
                    {
                        SQL += ",";
                    }

                    SQL += Environment.NewLine;
                }

                if (xWhere.Length > 0)
                {
                    SQL +=
                        "WHERE" + Environment.NewLine + xWhere;
                }

                SQLiteCommand MyCommand = new SQLiteCommand(SQL, MyConn);
                MyCommand.ExecuteNonQuery();

                if (!devGlobals.gBusySettingUp)
                {
                    foreach (string MyTable in devGlobals.gTamperTableList.Keys)
                    {
                        if (xTableName == MyTable)
                        {
                            CreateDBAntiTamper(devGlobals.gDB, devGlobals.gTamperTableList);
                        }
                    }
                }

                return true;
            }
            catch (Exception Ex)
            {
                WriteLog(Ex.Message, "devSE", "UpdateRec");
                return false;
            }
        }

        public bool CreateDBAntiTamper(string xDB, Dictionary<string, string> xIncludeTables)
        {
            try
            {
                string TamperString = "";

                //Loop table list
                foreach (string MyTable in xIncludeTables.Keys)
                {
                    //Get table data
                    string SQL = "";
                    DataTable dtData;

                    SQLiteConnection MyConn = new SQLiteConnection(@"Data Source=" + xDB);
                    MyConn.Open();

                    SQL =
                    "SELECT *" + Environment.NewLine +
                    "FROM" + Environment.NewLine +
                    "  " + MyTable;

                    SQLiteCommand MyCommand = new SQLiteCommand(SQL, MyConn);
                    SQLiteDataReader MyReader = MyCommand.ExecuteReader();

                    dtData = new DataTable();
                    dtData.Load(MyReader);

                    MyCommand.Dispose();
                    MyReader.Dispose();

                    //Loop data to build string
                    foreach (DataRow ARow in dtData.Rows)
                    {
                        for (int i = 0; i < dtData.Columns.Count; i++)
                        {
                            TamperString += ARow[i].ToString();
                        }
                    }
                }

                //Encrypt
                TamperString = Encrypt(TamperString);

                //Delete Current
                DeleteRec("tblAntiTamper", "");

                //Write to DB
                List<string> fFields = new List<string>();
                List<string> vValues = new List<string>();

                fFields.Add("TamperString");

                vValues.Add(TamperString);

                InsertRec("tblAntiTamper", fFields, vValues);

                return true;
            }
            catch (Exception Ex)
            {
                WriteLog(Ex.Message, "devSE", "CreateDBAntiTamper");
                return false;
            }
        }

        public bool DeleteRec(string xTableName, string xWhere)
        {
            try
            {
                string SQL = "";

                SQLiteConnection MyConn = new SQLiteConnection(@"Data Source=" + devGlobals.gDB);
                MyConn.Open();


                //Build SQL
                SQL =
                "DELETE FROM [" + xTableName + "]" + Environment.NewLine;

                if (xWhere.Length > 0)
                {
                    SQL += "WHERE" + Environment.NewLine + xWhere;
                }

                SQLiteCommand MyCommand = new SQLiteCommand(SQL, MyConn);
                MyCommand.ExecuteNonQuery();

                if (!devGlobals.gBusySettingUp)
                {
                    foreach (string MyTable in devGlobals.gTamperTableList.Keys)
                    {
                        if (xTableName == MyTable)
                        {
                            CreateDBAntiTamper(devGlobals.gDB, devGlobals.gTamperTableList);
                        }
                    }
                }

                return true;
            }
            catch (Exception Ex)
            {
                WriteLog(Ex.Message, "devSE", "DeleteRec");
                return false;
            }
        }


        public bool AccessRightExists(string xDesc)
        {
            try
            {
                //Find record
                string SQL = "";
                DataTable dtData;

                SQLiteConnection MyConn = new SQLiteConnection(@"Data Source=" + devGlobals.gDB);
                MyConn.Open();

                SQL =
                "SELECT DISTINCT " + Environment.NewLine +
                "  tblAccessRights.Description" + Environment.NewLine +
                "FROM" + Environment.NewLine +
                "  tblAccessRights";

                SQLiteCommand MyCommand = new SQLiteCommand(SQL, MyConn);
                SQLiteDataReader MyReader = MyCommand.ExecuteReader();

                dtData = new DataTable();
                dtData.Load(MyReader);

                MyCommand.Dispose();
                MyReader.Dispose();

                for (int i = 0; i < dtData.Rows.Count; i++)
                {
                    if (Decrypt(dtData.Rows[i][0].ToString()) == xDesc)
                    {
                        return true;
                    }
                }

                return false;
            }
            catch (Exception Ex)
            {
                WriteLog(Ex.Message, "devSE", "AccessRightExists");
                return false;
            }
        }


        public void CreateAppTables()
        {
            try
            {
                List<string> MyTables = new List<string>();

                //Table list
                MyTables.Add("tblSettings");
                MyTables.Add("tblUsers");
                MyTables.Add("tblUserReg");
                MyTables.Add("tblAccessRights");
                MyTables.Add("tblUserAccess");
                MyTables.Add("tblAntiTamper");
                MyTables.Add("tblDatabaseConnections");
                MyTables.Add("tblBulletinBoard");
                MyTables.Add("||DOALTER1||");
                MyTables.Add("||DOALTER2||");

                //Do it
                int TableCount = MyTables.Count + 1;

                if (onDoProgress1 != null)
                {
                    onDoProgress1(TableCount, 1);
                }

                //Create starting tables
                if (onDoProgressText1 != null)
                {
                    onDoProgressText1("Creating Tables...");
                }

                if (onDoProgress1 != null)
                {
                    onDoProgress1(TableCount, 1);
                }

                int C1 = 2;
                foreach (string ATable in MyTables)
                {
                    CreateTable(ATable);
                    if (onDoProgress1 != null)
                    {
                        onDoProgress1(TableCount, C1);
                    }

                    C1++;
                }
            }
            catch (Exception Ex)
            {
                WriteLog(Ex.Message, "devSE", "CreateAppTables");
            }
        }

        public bool CreateTable(string xTableName)
        {
            try
            {
                string SQL = "";
                DataTable dtData;

                SQLiteConnection MyConn = new SQLiteConnection(@"Data Source=" + devGlobals.gDB);
                MyConn.Open();

                //Check if table already exist
                SQL =
                "SELECT " + Environment.NewLine +
                "  sqlite_master.name" + Environment.NewLine +
                "FROM" + Environment.NewLine +
                "  sqlite_master" + Environment.NewLine +
                "WHERE" + Environment.NewLine +
                "  type = 'table' AND " + Environment.NewLine +
                "  name = '" + xTableName + "'";

                SQLiteCommand MyCommand = new SQLiteCommand(SQL, MyConn);
                SQLiteDataReader MyReader = MyCommand.ExecuteReader();

                dtData = new DataTable();
                dtData.Load(MyReader);

                MyCommand.Dispose();
                MyReader.Dispose();

                if (dtData.Rows.Count == 0)
                {
                    //If not exist create
                    if (xTableName == "tblSettings")
                    {
                        SQL =
                        "CREATE TABLE tblSettings (" + Environment.NewLine +
                        "  IDX       integer PRIMARY KEY AUTOINCREMENT NOT NULL," + Environment.NewLine +
                        "  Property  varchar(200) NOT NULL UNIQUE," + Environment.NewLine +
                        "  Value     varchar(5000)" + Environment.NewLine +
                        ");";
                    }

                    if (xTableName == "tblUsers")
                    {
                        SQL =
                        "CREATE TABLE tblUsers (" + Environment.NewLine +
                        "  IDX       integer PRIMARY KEY AUTOINCREMENT NOT NULL," + Environment.NewLine +
                        "  Username  varchar(100) NOT NULL UNIQUE," + Environment.NewLine +
                        "  Password  varchar(100) NOT NULL," + Environment.NewLine +
                        "  LoggedIn  varchar(100)" + Environment.NewLine +
                        ");";
                    }

                    if (xTableName == "tblUserReg")
                    {
                        SQL =
                        "CREATE TABLE tblUserReg (" + Environment.NewLine +
                        "  IDX       integer PRIMARY KEY AUTOINCREMENT NOT NULL," + Environment.NewLine +
                        "  Username  varchar(100) NOT NULL," + Environment.NewLine +
                        "  PCID      varchar(1000) NOT NULL," + Environment.NewLine +
                        "  Register  varchar(1000)," + Environment.NewLine +
                        "  /* Foreign keys */" + Environment.NewLine +
                        "  FOREIGN KEY (Username)" + Environment.NewLine +
                        "    REFERENCES tblUsers(Username)" + Environment.NewLine +
                        "    ON DELETE CASCADE" + Environment.NewLine +
                        "    ON UPDATE CASCADE" + Environment.NewLine +
                        ");" + Environment.NewLine +
                        "" + Environment.NewLine +
                        "CREATE UNIQUE INDEX tblUserReg_Index01" + Environment.NewLine +
                        "  ON tblUserReg" + Environment.NewLine +
                        "  (Username, PCID);";
                    }

                    if (xTableName == "tblAccessRights")
                    {
                        SQL =
                        "CREATE TABLE tblAccessRights (" + Environment.NewLine +
                        "  IDX          integer PRIMARY KEY AUTOINCREMENT NOT NULL," + Environment.NewLine +
                        "  Description  varchar(200) NOT NULL UNIQUE," + Environment.NewLine +
                        "  Tag          varchar(100) NOT NULL UNIQUE" + Environment.NewLine +
                        ");";
                    }

                    if (xTableName == "tblUserAccess")
                    {
                        SQL =
                        "CREATE TABLE tblUserAccess (" + Environment.NewLine +
                        "  IDX              integer PRIMARY KEY AUTOINCREMENT NOT NULL," + Environment.NewLine +
                        "  UsersIDX         integer NOT NULL," + Environment.NewLine +
                        "  AccessRightsIDX  integer NOT NULL," + Environment.NewLine +
                        "  /* Foreign keys */" + Environment.NewLine +
                        "  FOREIGN KEY (UsersIDX)" + Environment.NewLine +
                        "    REFERENCES tblUsers(IDX)" + Environment.NewLine +
                        "    ON DELETE CASCADE" + Environment.NewLine +
                        "    ON UPDATE CASCADE, " + Environment.NewLine +
                        "  FOREIGN KEY (AccessRightsIDX)" + Environment.NewLine +
                        "    REFERENCES tblAccessRights(IDX)" + Environment.NewLine +
                        "    ON DELETE CASCADE" + Environment.NewLine +
                        "    ON UPDATE CASCADE" + Environment.NewLine +
                        ");" + Environment.NewLine +
                        "" + Environment.NewLine +
                        "CREATE UNIQUE INDEX tblUserAccess_Index01" + Environment.NewLine +
                        "  ON tblUserAccess" + Environment.NewLine +
                        "  (UsersIDX, AccessRightsIDX);";
                    }

                    if (xTableName == "tblAntiTamper")
                    {
                        SQL =
                        "CREATE TABLE tblAntiTamper (" + Environment.NewLine +
                        "  IDX           integer PRIMARY KEY AUTOINCREMENT NOT NULL," + Environment.NewLine +
                        "  TamperString  text NOT NULL" + Environment.NewLine +
                        ");";
                    }

                    if (xTableName == "tblDatabaseConnections")
                    {
                        SQL =
                        "CREATE TABLE tblDatabaseConnections (" + Environment.NewLine +
                        "  IDX          integer PRIMARY KEY AUTOINCREMENT NOT NULL," + Environment.NewLine +
                        "  Description  varchar(200) NOT NULL UNIQUE," + Environment.NewLine +
                        "  Type         smallint NOT NULL DEFAULT 0," + Environment.NewLine +
                        "  Host         varchar(500) NOT NULL," + Environment.NewLine +
                        "  Port         integer NOT NULL," + Environment.NewLine +
                        "  Username     varchar(200) NOT NULL," + Environment.NewLine +
                        "  Password     varchar(200) NOT NULL," + Environment.NewLine +
                        "  DBName       varchar(200) NOT NULL," + Environment.NewLine +
                        "  ConnString   varchar(1000) NOT NULL" + Environment.NewLine +
                        ");";
                    }

                    if (xTableName == "tblBulletinBoard")
                    {
                        SQL =
                        "CREATE TABLE tblBulletinBoard (" + Environment.NewLine +
                        "  IDX          integer PRIMARY KEY AUTOINCREMENT NOT NULL," + Environment.NewLine +
                        "  DisplayText  text NOT NULL" + Environment.NewLine +
                        ");";
                    }


                    //Do ALTER TABLE stuff here
                    if (xTableName == "||DOALTER1||")
                    {
                        SQL =
                        "ALTER TABLE tblUsers" + Environment.NewLine +
                        "  ADD COLUMN ShowBulletin smallint NOT NULL DEFAULT 1;";
                    }

                    if (xTableName == "||DOALTER2||")
                    {
                        SQL =
                        "ALTER TABLE tblUsers" + Environment.NewLine +
                        "  ADD COLUMN KickUser smallint NOT NULL DEFAULT 0;";
                    }

                    if (SQL != "")
                    {
                        MyCommand = new SQLiteCommand(SQL, MyConn);
                        MyCommand.ExecuteNonQuery();

                        //Create default records
                        if (devGlobals.gCreateDefDBRecs)
                        {
                            if (!CreateTableRecs(xTableName))
                            {
                                return false;
                            }
                        }
                    }
                }

                return true;
            }
            catch (Exception Ex)
            {
                WriteLog(Ex.Message, "devSE", "CreateTable");
                return false;
            }
        }

        public bool CreateTableRecs(string xTableName)
        {
            try
            {
                string SQL = "";
                DataTable dtData;

                SQLiteConnection MyConn = new SQLiteConnection(@"Data Source=" + devGlobals.gDB);
                MyConn.Open();

                //Check if table already exist
                SQL =
                "SELECT " + Environment.NewLine +
                "  sqlite_master.name" + Environment.NewLine +
                "FROM" + Environment.NewLine +
                "  sqlite_master" + Environment.NewLine +
                "WHERE" + Environment.NewLine +
                "  type = 'table' AND " + Environment.NewLine +
                "  name = '" + xTableName + "'";

                SQLiteCommand MyCommand = new SQLiteCommand(SQL, MyConn);
                SQLiteDataReader MyReader = MyCommand.ExecuteReader();

                dtData = new DataTable();
                dtData.Load(MyReader);

                MyCommand.Dispose();
                MyReader.Dispose();

                if (dtData.Rows.Count != 0)
                {
                    //If exist insert
                    if (xTableName == "tblDatabaseConnections")
                    {
                        //SQL =
                        //"INSERT INTO [tblDatabaseConnections]" + Environment.NewLine +
                        //"(" + Environment.NewLine +
                        //"  [Description]," + Environment.NewLine +
                        //"  [Type]," + Environment.NewLine +
                        //"  [Host]," + Environment.NewLine +
                        //"  [Port]," + Environment.NewLine +
                        //"  [Username]," + Environment.NewLine +
                        //"  [Password]," + Environment.NewLine +
                        //"  [DBName]," + Environment.NewLine +
                        //"  [ConnString]" + Environment.NewLine +
                        //")" + Environment.NewLine +
                        //"VALUES" + Environment.NewLine +
                        //"(" + Environment.NewLine +
                        //"'BRANCH VISION'," + Environment.NewLine +
                        //"'0'," + Environment.NewLine +
                        //"'VSERVER'," + Environment.NewLine +
                        //"'1433'," + Environment.NewLine +
                        //"'cCe627t1RZT9GYfQPqDctQ=='," + Environment.NewLine +
                        //"'GonuijthMcbGRpyrXb2nDw=='," + Environment.NewLine +
                        //"'VISION'," + Environment.NewLine +
                        //"'UwspMDtFIZ8zQ7YgbOJb6zJ2wEKnaB9OwKC9nDhZOBV1GGx8prqASwRtBi32KPCq960A3dIFKtnpNI2GQux6GIjlSAoDVKHcqHVwE0pxkruJybmuvIcFYpGM1ZsKZOAdm2cBJYaMWQsuiwpuOVHWRw=='" + Environment.NewLine +
                        //");";

                        //MyCommand = new SQLiteCommand(SQL, MyConn);
                        //MyCommand.ExecuteNonQuery();

                        //MyCommand.Dispose();
                    }

                    if (xTableName == "tblSettings")
                    {
                        //SQL =
                        //"INSERT INTO [tblSettings]" + Environment.NewLine +
                        //"(" + Environment.NewLine +
                        //"  [Property]," + Environment.NewLine +
                        //"  [Value]" + Environment.NewLine +
                        //")" + Environment.NewLine +
                        //"VALUES" + Environment.NewLine +
                        //"(" + Environment.NewLine +
                        //"'VISIONCONN'," + Environment.NewLine +
                        //"'2A6h2IrkB61v3ezib1er9g=='" + Environment.NewLine +
                        //");" + Environment.NewLine +
                        //"" + Environment.NewLine +
                        //"INSERT INTO [tblSettings]" + Environment.NewLine +
                        //"(" + Environment.NewLine +
                        //"  [Property]," + Environment.NewLine +
                        //"  [Value]" + Environment.NewLine +
                        //")" + Environment.NewLine +
                        //"VALUES" + Environment.NewLine +
                        //"(" + Environment.NewLine +
                        //"'SAPCONN'," + Environment.NewLine +
                        //"'84OKK7V/F3Y2k4ZP+ojteA=='" + Environment.NewLine +
                        //");" + Environment.NewLine +
                        //"" + Environment.NewLine +
                        //"INSERT INTO [tblSettings]" + Environment.NewLine +
                        //"(" + Environment.NewLine +
                        //"  [Property]," + Environment.NewLine +
                        //"  [Value]" + Environment.NewLine +
                        //")" + Environment.NewLine +
                        //"VALUES" + Environment.NewLine +
                        //"(" + Environment.NewLine +
                        //"'EMAILSERVER'," + Environment.NewLine +
                        //"'ObQkK2a0MkpSO4OFRMWrjg=='" + Environment.NewLine +
                        //");" + Environment.NewLine +
                        //"" + Environment.NewLine +
                        //"INSERT INTO [tblSettings]" + Environment.NewLine +
                        //"(" + Environment.NewLine +
                        //"  [Property]," + Environment.NewLine +
                        //"  [Value]" + Environment.NewLine +
                        //")" + Environment.NewLine +
                        //"VALUES" + Environment.NewLine +
                        //"(" + Environment.NewLine +
                        //"'EMAILUSEAUTH'," + Environment.NewLine +
                        //"'rzsKhu1ifPy0WJ9SqGATxA=='" + Environment.NewLine +
                        //");" + Environment.NewLine +
                        //"" + Environment.NewLine +
                        //"INSERT INTO [tblSettings]" + Environment.NewLine +
                        //"(" + Environment.NewLine +
                        //"  [Property]," + Environment.NewLine +
                        //"  [Value]" + Environment.NewLine +
                        //")" + Environment.NewLine +
                        //"VALUES" + Environment.NewLine +
                        //"(" + Environment.NewLine +
                        //"'EMAILUSEENCRYPTION'," + Environment.NewLine +
                        //"'rzsKhu1ifPy0WJ9SqGATxA=='" + Environment.NewLine +
                        //");" + Environment.NewLine +
                        //"" + Environment.NewLine +
                        //"INSERT INTO [tblSettings]" + Environment.NewLine +
                        //"(" + Environment.NewLine +
                        //"  [Property]," + Environment.NewLine +
                        //"  [Value]" + Environment.NewLine +
                        //")" + Environment.NewLine +
                        //"VALUES" + Environment.NewLine +
                        //"(" + Environment.NewLine +
                        //"'EMAILUSERNAME'," + Environment.NewLine +
                        //"'MWe5t+URxITrhx6pCzhkgi0uch8Bgh153N0Psk2ksWc='" + Environment.NewLine +
                        //");" + Environment.NewLine +
                        //"" + Environment.NewLine +
                        //"INSERT INTO [tblSettings]" + Environment.NewLine +
                        //"(" + Environment.NewLine +
                        //"  [Property]," + Environment.NewLine +
                        //"  [Value]" + Environment.NewLine +
                        //")" + Environment.NewLine +
                        //"VALUES" + Environment.NewLine +
                        //"(" + Environment.NewLine +
                        //"'EMAILPASSWORD'," + Environment.NewLine +
                        //"'FE5KfTDnOtxPJkFjiVumqw=='" + Environment.NewLine +
                        //");" + Environment.NewLine +
                        //"" + Environment.NewLine +
                        //"INSERT INTO [tblSettings]" + Environment.NewLine +
                        //"(" + Environment.NewLine +
                        //"  [Property]," + Environment.NewLine +
                        //"  [Value]" + Environment.NewLine +
                        //")" + Environment.NewLine +
                        //"VALUES" + Environment.NewLine +
                        //"(" + Environment.NewLine +
                        //"'EMAILPORT'," + Environment.NewLine +
                        //"'xLmyGd3EatelSeTdYsRQjw=='" + Environment.NewLine +
                        //");" + Environment.NewLine +
                        //"" + Environment.NewLine +
                        //"INSERT INTO [tblSettings]" + Environment.NewLine +
                        //"(" + Environment.NewLine +
                        //"  [Property]," + Environment.NewLine +
                        //"  [Value]" + Environment.NewLine +
                        //")" + Environment.NewLine +
                        //"VALUES" + Environment.NewLine +
                        //"(" + Environment.NewLine +
                        //"'EMAILFROMADDR'," + Environment.NewLine +
                        //"'MWe5t+URxITrhx6pCzhkgi0uch8Bgh153N0Psk2ksWc='" + Environment.NewLine +
                        //");" + Environment.NewLine +
                        //"" + Environment.NewLine +
                        //"INSERT INTO [tblSettings]" + Environment.NewLine +
                        //"(" + Environment.NewLine +
                        //"  [Property]," + Environment.NewLine +
                        //"  [Value]" + Environment.NewLine +
                        //")" + Environment.NewLine +
                        //"VALUES" + Environment.NewLine +
                        //"(" + Environment.NewLine +
                        //"'EMAILFROMNAME'," + Environment.NewLine +
                        //"'i0c9AsZhzCAeItuteDGjAQ=='" + Environment.NewLine +
                        //");" + Environment.NewLine +
                        //"" + Environment.NewLine +
                        //"INSERT INTO [tblSettings]" + Environment.NewLine +
                        //"(" + Environment.NewLine +
                        //"  [Property]," + Environment.NewLine +
                        //"  [Value]" + Environment.NewLine +
                        //")" + Environment.NewLine +
                        //"VALUES" + Environment.NewLine +
                        //"(" + Environment.NewLine +
                        //"'EMAILSENDTESTTO'," + Environment.NewLine +
                        //"'lT3E7fChqnC9UHj4QVPhsSi7tn3ltk9GJbAYfCZldJ8='" + Environment.NewLine +
                        //");" + Environment.NewLine +
                        //"" + Environment.NewLine +
                        //"INSERT INTO [tblSettings]" + Environment.NewLine +
                        //"(" + Environment.NewLine +
                        //"  [Property]," + Environment.NewLine +
                        //"  [Value]" + Environment.NewLine +
                        //")" + Environment.NewLine +
                        //"VALUES" + Environment.NewLine +
                        //"(" + Environment.NewLine +
                        //"'USESAPCOMPANYINFO'," + Environment.NewLine +
                        //"'TnTU4E9kGI2VCIiHmSp1Tg=='" + Environment.NewLine +
                        //");" + Environment.NewLine +
                        //"" + Environment.NewLine +
                        //"INSERT INTO [tblSettings]" + Environment.NewLine +
                        //"(" + Environment.NewLine +
                        //"  [Property]," + Environment.NewLine +
                        //"  [Value]" + Environment.NewLine +
                        //")" + Environment.NewLine +
                        //"VALUES" + Environment.NewLine +
                        //"(" + Environment.NewLine +
                        //"'COMPANYNAME'," + Environment.NewLine +
                        //"'dPNTYXFVocaKJbtSySMGgQNycuhsIu1NwuGSJPiy+wA='" + Environment.NewLine +
                        //");" + Environment.NewLine +
                        //"" + Environment.NewLine +
                        //"INSERT INTO [tblSettings]" + Environment.NewLine +
                        //"(" + Environment.NewLine +
                        //"  [Property]," + Environment.NewLine +
                        //"  [Value]" + Environment.NewLine +
                        //")" + Environment.NewLine +
                        //"VALUES" + Environment.NewLine +
                        //"(" + Environment.NewLine +
                        //"'ADDRL1'," + Environment.NewLine +
                        //"'PBQpYMxpHCwfE84SYlWvfff0ZhS/rXI+CRJLzZNMC3M='" + Environment.NewLine +
                        //");" + Environment.NewLine +
                        //"" + Environment.NewLine +
                        //"INSERT INTO [tblSettings]" + Environment.NewLine +
                        //"(" + Environment.NewLine +
                        //"  [Property]," + Environment.NewLine +
                        //"  [Value]" + Environment.NewLine +
                        //")" + Environment.NewLine +
                        //"VALUES" + Environment.NewLine +
                        //"(" + Environment.NewLine +
                        //"'ADDRL2'," + Environment.NewLine +
                        //"'yFqkaXnpHEahB9aKUj7Brf9QK8GULmOmhucuB5CUuio='" + Environment.NewLine +
                        //");" + Environment.NewLine +
                        //"" + Environment.NewLine +
                        //"INSERT INTO [tblSettings]" + Environment.NewLine +
                        //"(" + Environment.NewLine +
                        //"  [Property]," + Environment.NewLine +
                        //"  [Value]" + Environment.NewLine +
                        //")" + Environment.NewLine +
                        //"VALUES" + Environment.NewLine +
                        //"(" + Environment.NewLine +
                        //"'STATEMENTEMAILSUBJECT'," + Environment.NewLine +
                        //"'X11hiVgc0j7nFHuXwW6HNg=='" + Environment.NewLine +
                        //");";



                        //MyCommand = new SQLiteCommand(SQL, MyConn);
                        //MyCommand.ExecuteNonQuery();

                        //MyCommand.Dispose();
                    }
                }

                return true;
            }
            catch (Exception Ex)
            {
                WriteLog(Ex.Message, "devSE", "CreateTableRecs");
                return false;
            }
        }

        public void DeleteUser(string xUsername)
        {
            try
            {
                DeleteRec("tblUsers", "[Username] = '" + Encrypt(xUsername) + "'");
            }
            catch (Exception Ex)
            {
                WriteLog(Ex.Message, "devSE", "DeleteUser");
            }
        }

        public string GetEncUserPassword(string xEncUsername)
        {
            try
            {
                //Find record
                string SQL = "";
                DataTable dtData;

                SQLiteConnection MyConn = new SQLiteConnection(@"Data Source=" + devGlobals.gDB);
                MyConn.Open();

                SQL =
                "SELECT " + Environment.NewLine +
                "  tblUsers.Password" + Environment.NewLine +
                "FROM" + Environment.NewLine +
                "  tblUsers" + Environment.NewLine +
                "WHERE" + Environment.NewLine +
                "  tblUsers.Username = '" + xEncUsername + "'";

                SQLiteCommand MyCommand = new SQLiteCommand(SQL, MyConn);
                SQLiteDataReader MyReader = MyCommand.ExecuteReader();

                dtData = new DataTable();
                dtData.Load(MyReader);

                MyCommand.Dispose();
                MyReader.Dispose();

                for (int i = 0; i < dtData.Rows.Count; i++)
                {
                    return dtData.Rows[i][0].ToString();
                }

                return "";
            }
            catch (Exception Ex)
            {
                WriteLog(Ex.Message, "devSE", "GetEncUserPassword");
                return "";
            }
        }

        public string GetPCID()
        {
            try
            {
                ManagementObjectCollection mbsList = null;
                ManagementObjectSearcher mbs = new ManagementObjectSearcher("Select * From Win32_processor");
                mbsList = mbs.Get();
                string id = "";
                foreach (ManagementObject mo in mbsList)
                {
                    id = mo["ProcessorID"].ToString();
                }

                ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
                ManagementObjectCollection moc = mos.Get();
                string motherBoard = "";
                foreach (ManagementObject mo in moc)
                {
                    motherBoard = (string)mo["SerialNumber"];
                }

                return id + motherBoard;
            }
            catch (Exception Ex)
            {
                WriteLog(Ex.Message, "devSE", "GetPCID");
                return "";
            }
        }

        public bool CheckINIFileTamper(string xMyFile)
        {
            try
            {
                devINIFile MyINI = new devINIFile(xMyFile);

                List<string> MySections = new List<string>();
                List<string> MyKeys = new List<string>();

                string tmpEncrypt = "";

                //Build string
                MySections = MyINI.GetSections();

                for (int C1 = 0; C1 < MySections.Count; C1++)
                {
                    if (MySections[C1] != "ANTITAMPER" && MySections[C1] != "DEBUG")
                    {
                        tmpEncrypt = tmpEncrypt + MySections[C1];
                        MyKeys = MyINI.GetSectionKeys(MySections[C1]);

                        for (int C2 = 0; C2 < MyKeys.Count; C2++)
                        {
                            tmpEncrypt = tmpEncrypt + MyKeys[C2] + MyINI.ReadString(MySections[C1], MyKeys[C2]);
                        }
                    }
                }

                //Decrypt the string
                if (Decrypt(MyINI.ReadString("ANTITAMPER", "KEY")) == tmpEncrypt)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception Ex)
            {
                WriteLog(Ex.Message, "devSE", "CheckINIFileTamper");

                return false;
            }
        }

        public string Encrypt(string plainText)
        {
            try
            {
                byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

                byte[] keyBytes = new Rfc2898DeriveBytes(devGlobals.gPasswordHash, Encoding.ASCII.GetBytes(devGlobals.gSaltKey)).GetBytes(256 / 8);
                var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.Zeros };
                var encryptor = symmetricKey.CreateEncryptor(keyBytes, Encoding.ASCII.GetBytes(devGlobals.gVIKey));

                byte[] cipherTextBytes;

                using (var memoryStream = new MemoryStream())
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                        cryptoStream.FlushFinalBlock();
                        cipherTextBytes = memoryStream.ToArray();
                        cryptoStream.Close();
                    }
                    memoryStream.Close();
                }
                return Convert.ToBase64String(cipherTextBytes);
            }
            catch (Exception Ex)
            {
                WriteLog(Ex.Message, "devSE", "Encrypt");
                return "";
            }
        }

        public string Decrypt(string encryptedText)
        {
            try
            {
                byte[] cipherTextBytes = Convert.FromBase64String(encryptedText);
                byte[] keyBytes = new Rfc2898DeriveBytes(devGlobals.gPasswordHash, Encoding.ASCII.GetBytes(devGlobals.gSaltKey)).GetBytes(256 / 8);
                var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.None };

                var decryptor = symmetricKey.CreateDecryptor(keyBytes, Encoding.ASCII.GetBytes(devGlobals.gVIKey));
                var memoryStream = new MemoryStream(cipherTextBytes);
                var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
                byte[] plainTextBytes = new byte[cipherTextBytes.Length];

                int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                memoryStream.Close();
                cryptoStream.Close();
                return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount).TrimEnd("\0".ToCharArray());
            }
            catch (Exception Ex)
            {
                WriteLog(Ex.Message, "devSE", "Decrypt");
                return "";
            }
        }

        public void SetDBPath(string xPath)
        {
            try
            {
                devINIFile MyINI = new devINIFile(devGlobals.gLocalSettingFile);

                MyINI.WriteString("DEFAULTS", "DBPATH", Encrypt(xPath));

                CreateINIFileAntiTamper(devGlobals.gLocalSettingFile);
            }
            catch (Exception Ex)
            {
                WriteLog(Ex.Message, "devSE", "SetDBPath");
            }
        }

        public bool CreateINIFileAntiTamper(string xMyFile)
        {
            try
            {
                devINIFile MyINI = new devINIFile(xMyFile);

                List<string> MySections = new List<string>();
                List<string> MyKeys = new List<string>();

                string tmpEncrypt = "";

                //Build string
                MySections = MyINI.GetSections();

                for (int C1 = 0; C1 < MySections.Count; C1++)
                {
                    if (MySections[C1] != "ANTITAMPER" && MySections[C1] != "DEBUG")
                    {
                        tmpEncrypt = tmpEncrypt + MySections[C1];
                        MyKeys = MyINI.GetSectionKeys(MySections[C1]);

                        for (int C2 = 0; C2 < MyKeys.Count; C2++)
                        {
                            tmpEncrypt = tmpEncrypt + MyKeys[C2] + MyINI.ReadString(MySections[C1], MyKeys[C2]);
                        }
                    }
                }

                //Generate encrypted string
                if (MyINI.WriteString("ANTITAMPER", "KEY", Encrypt(tmpEncrypt)))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception Ex)
            {
                WriteLog(Ex.Message, "devSE", "CreateINIFileAntiTamper");
                return false;
            }
        }

        public bool CheckDBTamper(string xDB, Dictionary<string, string> xIncludeTables)
        {
            //return true;

            try
            {
                string CurrentTamper = "";

                //Get DB Tamper string
                string SQL = "";
                DataTable dtData;

                SQLiteConnection MyConn = new SQLiteConnection(@"Data Source=" + xDB);
                MyConn.Open();

                SQL =
                "SELECT " + Environment.NewLine +
                "  tblAntiTamper.TamperString" + Environment.NewLine +
                "FROM" + Environment.NewLine +
                "  tblAntiTamper";

                SQLiteCommand MyCommand = new SQLiteCommand(SQL, MyConn);
                SQLiteDataReader MyReader = MyCommand.ExecuteReader();

                dtData = new DataTable();
                dtData.Load(MyReader);

                MyCommand.Dispose();
                MyReader.Dispose();

                if (dtData.Rows.Count == 0)
                {
                    return false;
                }

                //Loop data to build string
                foreach (DataRow ARow in dtData.Rows)
                {
                    for (int i = 0; i < dtData.Columns.Count; i++)
                    {
                        CurrentTamper = Decrypt(ARow[i].ToString());
                    }
                }


                string TamperString = "";

                foreach (string MyTable in xIncludeTables.Keys)
                {
                    try
                    {
                        //Get table data
                        SQL = "";
                        dtData.Clear();

                        MyConn = new SQLiteConnection(@"Data Source=" + xDB);
                        MyConn.Open();

                        SQL =
                        "SELECT *" + Environment.NewLine +
                        "FROM" + Environment.NewLine +
                        "  " + MyTable;

                        MyCommand = new SQLiteCommand(SQL, MyConn);
                        MyReader = MyCommand.ExecuteReader();

                        dtData = new DataTable();
                        dtData.Load(MyReader);

                        MyCommand.Dispose();
                        MyReader.Dispose();

                        //Loop data to build string
                        foreach (DataRow ARow in dtData.Rows)
                        {
                            for (int i = 0; i < dtData.Columns.Count; i++)
                            {
                                TamperString += ARow[i].ToString();
                            }
                        }
                    }
                    catch
                    {
                    }
                }

                if (CurrentTamper == TamperString)
                {
                    return true;
                }

                return false;
            }
            catch (Exception Ex)
            {
                WriteLog(Ex.Message, "devSE", "CheckDBTamper");
                return false;
            }
        }

        public bool IsAllLettersOrDigits(string xMyString)
        {
            foreach (char c in xMyString)
            {
                if (!Char.IsLetterOrDigit(c))
                    return false;
            }
            return true;
        }

        public List<string> GetEncryptedUserList()
        {
            try
            {
                List<string> MyList = new List<string>();

                string SQL = "";
                DataTable dtData;

                SQLiteConnection MyConn = new SQLiteConnection(@"Data Source=" + devGlobals.gDB);
                MyConn.Open();

                SQL =
                "SELECT DISTINCT" + Environment.NewLine +
                "  tblUsers.Username" + Environment.NewLine +
                "FROM" + Environment.NewLine +
                "  tblUsers";

                SQLiteCommand MyCommand = new SQLiteCommand(SQL, MyConn);
                SQLiteDataReader MyReader = MyCommand.ExecuteReader();

                dtData = new DataTable();
                dtData.Load(MyReader);

                MyCommand.Dispose();
                MyReader.Dispose();

                //Build user list
                MyList = BuildListFromDataTable(dtData);

                return MyList;
            }
            catch (Exception Ex)
            {
                WriteLog(Ex.Message, "devSE", "GetEncryptedUserList");
                return new List<string>();
            }
        }

        public List<string> BuildListFromDataTable(DataTable xData)
        {
            try
            {
                List<string> MyList = new List<string>();

                for (int i = 0; i < xData.Rows.Count; i++)
                {
                    MyList.Add(xData.Rows[i][0].ToString());

                }

                return MyList;
            }
            catch (Exception Ex)
            {
                WriteLog(Ex.Message, "devSE", "BuildListFromDataTable");
                return new List<string>();
            }
        }

        public bool ValidateUsernameAndPassword(string xUsername, string xPassword)
        {
            try
            {
                string SQL = "";
                DataTable dtData;

                SQLiteConnection MyConn = new SQLiteConnection(@"Data Source=" + devGlobals.gDB);
                MyConn.Open();

                SQL =
                "SELECT DISTINCT " + Environment.NewLine +
                "  tblUsers.Username," + Environment.NewLine +
                "  tblUsers.Password" + Environment.NewLine +
                "FROM" + Environment.NewLine +
                "  tblUsers";

                SQLiteCommand MyCommand = new SQLiteCommand(SQL, MyConn);
                SQLiteDataReader MyReader = MyCommand.ExecuteReader();

                dtData = new DataTable();
                dtData.Load(MyReader);

                MyCommand.Dispose();
                MyReader.Dispose();

                for (int i = 0; i < dtData.Rows.Count; i++)
                {
                    if ((Decrypt(dtData.Rows[i][0].ToString()) == xUsername) && (Decrypt(dtData.Rows[i][1].ToString()) == xPassword))
                    {
                        devGlobals.gUsername = xUsername;
                        devGlobals.gEncUsername = Encrypt(xUsername);

                        //Check if we should display the bulletin board for this user
                        try
                        {
                            SQL =
                            "SELECT " + Environment.NewLine +
                            "  tblUsers.ShowBulletin" + Environment.NewLine +
                            "FROM" + Environment.NewLine +
                            "  tblUsers" + Environment.NewLine +
                            "WHERE" + Environment.NewLine +
                            "  tblUsers.Username = '" + devGlobals.gEncUsername + "'";

                            MyCommand = new SQLiteCommand(SQL, MyConn);
                            MyReader = MyCommand.ExecuteReader();

                            dtData.Rows.Clear();
                            dtData = new DataTable();
                            dtData.Load(MyReader);

                            MyCommand.Dispose();
                            MyReader.Dispose();

                            if (dtData.Rows[0]["ShowBulletin"].ToString() == "1")
                            {
                                devGlobals.gShowBulletinBoard = true;
                            }
                            else
                            {
                                devGlobals.gShowBulletinBoard = false;
                            }
                        }
                        catch
                        {
                            devGlobals.gShowBulletinBoard = true;
                        }

                        List<string> fFields = new List<string>();
                        List<string> vValues = new List<string>();

                        //Kick previous user
                        if (UserLoggedIn(xUsername))
                        {
                            devGlobals.gSkipKickUser = true;

                            //Update DB
                            fFields = new List<string>();
                            vValues = new List<string>();

                            fFields.Add("KickUser");

                            vValues.Add(("1"));

                            UpdateRec("tblUsers", fFields, vValues, "[Username] = '" + Encrypt(xUsername) + "'");
                        }

                        //Update DB
                        fFields = new List<string>();
                        vValues = new List<string>();

                        fFields.Add("LoggedIn");

                        vValues.Add(Encrypt("1"));

                        UpdateRec("tblUsers", fFields, vValues, "[Username] = '" + Encrypt(xUsername) + "'");

                        return true;
                    }
                }

                return false;
            }
            catch (Exception Ex)
            {
                WriteLog(Ex.Message, "devSE", "ValidateUsernameAndPassword");
                return false;
            }
        }

        //019
        public void AddUser(string xUsername, string xPassword)
        {
            try
            {
                List<string> fFields = new List<string>();
                List<string> vValues = new List<string>();

                fFields.Add("Username");
                fFields.Add("Password");

                vValues.Add(Encrypt(xUsername));
                vValues.Add(Encrypt(xPassword));

                InsertRec("tblUsers", fFields, vValues);
            }
            catch (Exception Ex)
            {
                WriteLog(Ex.Message, "devSE", "AddUser");
            }
        }

        //020
        public void UpdateUser(string xOldUsername, string xUsername, string xPassword)
        {
            try
            {
                //Find record
                string SQL = "";
                DataTable dtData;

                SQLiteConnection MyConn = new SQLiteConnection(@"Data Source=" + devGlobals.gDB);
                MyConn.Open();

                SQL =
                "SELECT DISTINCT " + Environment.NewLine +
                "  tblUsers.Username" + Environment.NewLine +
                "FROM" + Environment.NewLine +
                "  tblUsers";

                SQLiteCommand MyCommand = new SQLiteCommand(SQL, MyConn);
                SQLiteDataReader MyReader = MyCommand.ExecuteReader();

                dtData = new DataTable();
                dtData.Load(MyReader);

                MyCommand.Dispose();
                MyReader.Dispose();

                for (int i = 0; i < dtData.Rows.Count; i++)
                {
                    if (Decrypt(dtData.Rows[i][0].ToString()) == xOldUsername)
                    {
                        //Update data
                        List<string> fFields = new List<string>();
                        List<string> vValues = new List<string>();

                        fFields.Add("Username");
                        fFields.Add("Password");

                        vValues.Add(Encrypt(xUsername));
                        vValues.Add(Encrypt(xPassword));

                        UpdateRec("tblUsers", fFields, vValues, "[Username] = '" + dtData.Rows[i][0].ToString() + "'");
                    }
                }
            }
            catch (Exception Ex)
            {
                WriteLog(Ex.Message, "devSE", "UpdateUser");
            }
        }

        public bool UserLoggedIn(string xUsername)
        {
            try
            {
                //Find record
                string SQL = "";
                DataTable dtData;

                SQLiteConnection MyConn = new SQLiteConnection(@"Data Source=" + devGlobals.gDB);
                MyConn.Open();

                SQL =
                "SELECT " + Environment.NewLine +
                "  tblUsers.LoggedIn" + Environment.NewLine +
                "FROM" + Environment.NewLine +
                "  tblUsers" + Environment.NewLine +
                "WHERE" + Environment.NewLine +
                "  tblUsers.Username = '" + Encrypt(xUsername) + "'";

                SQLiteCommand MyCommand = new SQLiteCommand(SQL, MyConn);
                SQLiteDataReader MyReader = MyCommand.ExecuteReader();

                dtData = new DataTable();
                dtData.Load(MyReader);

                MyCommand.Dispose();
                MyReader.Dispose();

                for (int i = 0; i < dtData.Rows.Count; i++)
                {
                    if (Decrypt(dtData.Rows[i][0].ToString()) == "1")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                return false;
            }
            catch (Exception Ex)
            {
                WriteLog(Ex.Message, "devSE", "UserLoggedIn");
                return false;
            }
        }

        public List<string> BreakUpString(string xMyString, string xSeperationCharacter)
        {
            try
            {
                List<string> MyList = new List<string>();

                string TheString = xMyString;

                //Build list
                while (TheString.Length > 0 && TheString.Contains(xSeperationCharacter))
                {
                    MyList.Add(TheString.Substring(0, TheString.IndexOf(xSeperationCharacter)));
                    TheString = TheString.Remove(0, TheString.IndexOf(xSeperationCharacter) + 1);
                }

                if (TheString.Length > 0)
                {
                    MyList.Add(TheString);
                }

                return MyList;
            }
            catch (Exception Ex)
            {
                WriteLog(Ex.Message, "devSE", "BreakUpString");
                return new List<string>();
            }
        }

        public DataTable BindingListToDataTable<T>(BindingList<T> list)
        {
            try
            {
                DataTable dt = new DataTable();

                foreach (PropertyInfo info in typeof(T).GetProperties())
                {
                    dt.Columns.Add(new DataColumn(info.Name, info.PropertyType));
                }

                foreach (T t in list)
                {
                    DataRow row = dt.NewRow();

                    foreach (PropertyInfo info in typeof(T).GetProperties())
                    {
                        row[info.Name] = info.GetValue(t, null);
                    }

                    dt.Rows.Add(row);
                }

                return dt;
            }
            catch (Exception Ex)
            {
                WriteLog(Ex.Message, "avrSE", "BindingListToDataTable");
                return new DataTable();
            }
        }

        public void WriteUserAccess(string xEncUsername, List<string> xAccessRightTags)
        {
            try
            {
                if (onDoProgressText1 != null)
                {
                    onDoProgressText1("Saving...");
                }

                if (onDoProgress1 != null)
                {
                    onDoProgress1(xAccessRightTags.Count, 0);
                }

                string CurrentUserIDX = GetUserIDX(xEncUsername).ToString();

                //Delete current
                DeleteRec("tblUserAccess", "[UsersIDX] = '" + CurrentUserIDX + "'");

                //Insert New
                int C1 = 0;
                foreach (string ARec in xAccessRightTags)
                {
                    List<string> fFields = new List<string>();
                    List<string> vValues = new List<string>();

                    fFields.Add("UsersIDX");
                    fFields.Add("AccessRightsIDX");

                    vValues.Add(CurrentUserIDX);
                    vValues.Add(GetAccessIDXFromTag(Convert.ToInt32(ARec)).ToString());

                    InsertRec("tblUserAccess", fFields, vValues);
                    C1++;

                    if (onDoProgress1 != null)
                    {
                        onDoProgress1(xAccessRightTags.Count, C1);
                    }
                }
            }
            catch (Exception Ex)
            {
                WriteLog(Ex.Message, "avrSE", "WriteUserAccess");
            }
        }

        public static IEnumerable<T> GetControlsOfType<T>(Control root)
            where T : Control
        {
            var t = root as T;
            if (t != null)
                yield return t;

            var container = root as ContainerControl;
            if (container != null)
                foreach (Control c in container.Controls)
                    foreach (var i in GetControlsOfType<T>(c))
                        yield return i;
        }

        public void AddConnection(string xDesc, int xType, string xUsername, string xPassword, string xHost, int xPort, string xDatabase, string xConnString)
        {
            try
            {
                List<string> fFields = new List<string>();
                List<string> vValues = new List<string>();

                fFields.Add("Description");
                fFields.Add("Type");
                fFields.Add("Host");
                fFields.Add("Port");
                fFields.Add("Username");
                fFields.Add("Password");
                fFields.Add("DBName");
                fFields.Add("ConnString");

                vValues.Add(xDesc);
                vValues.Add(xType.ToString());
                vValues.Add(xHost);
                vValues.Add(xPort.ToString());
                vValues.Add(Encrypt(xUsername));
                vValues.Add(Encrypt(xPassword));
                vValues.Add(xDatabase);
                vValues.Add(Encrypt(xConnString));

                InsertRec("tblDatabaseConnections", fFields, vValues);
            }
            catch (Exception Ex)
            {
                WriteLog(Ex.Message, "avrSE", "AddConnection");
            }
        }

        //051
        public void UpdateConnection(string xOldDesc, string xDesc, int xType, string xUsername, string xPassword, string xHost, int xPort, string xDatabase, string xConnString)
        {
            try
            {
                //Update data
                List<string> fFields = new List<string>();
                List<string> vValues = new List<string>();

                fFields.Add("Description");
                fFields.Add("Type");
                fFields.Add("Host");
                fFields.Add("Port");
                fFields.Add("Username");
                fFields.Add("Password");
                fFields.Add("DBName");
                fFields.Add("ConnString");

                vValues.Add(xDesc);
                vValues.Add(xType.ToString());
                vValues.Add(xHost);
                vValues.Add(xPort.ToString());
                vValues.Add(Encrypt(xUsername));
                vValues.Add(Encrypt(xPassword));
                vValues.Add(xDatabase);
                vValues.Add(Encrypt(xConnString));

                UpdateRec("tblDatabaseConnections", fFields, vValues, "[Description] = '" + xOldDesc + "'");
            }
            catch (Exception Ex)
            {
                WriteLog(Ex.Message, "avrSE", "UpdateConnection");
            }
        }

        //052
        public void DeleteConnection(string xDesc)
        {
            try
            {
                DeleteRec("tblDatabaseConnections", "[Description] = '" + xDesc + "'");
            }
            catch (Exception Ex)
            {
                WriteLog(Ex.Message, "avrSE", "DeleteConnection");
            }
        }



    }
}
