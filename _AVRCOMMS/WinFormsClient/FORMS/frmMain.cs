using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Shared.CLASSES;
using DevExpress.XtraEditors;
using System.Threading;
using Shared.DATA;

namespace WinFormsClient.FORMS
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        //SAFE THREAD LOCKING
        private Object thisLock = new Object();

        //THREADS
        Thread threadGUI;
        Thread threadWorker;

        //GUI
        bool gui_threadMustRun = false;

        //WORKER
        bool worker_status = false;
        bool worker_threadMustRun = false;



        public frmMain()
        {
            InitializeComponent();

            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            ribbonMain.ApplicationIcon = Icon.ExtractAssociatedIcon(Application.ExecutablePath).ToBitmap();
            pictureEdit1.Properties.ContextMenuStrip = new ContextMenuStrip();
        }

        private void btnExit_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                timer1.Stop();
                if (!clsSQLiteDB.CheckIfDBExist(0, false))
                {
                    XtraMessageBox.Show("There is no settings file. A new default file will be automatically created.");
                    clsSQLiteDB.CreateDB(0);
                }

                clsGlobal.gDebugLog = true;

                if (gui_threadMustRun == false)
                {
                    gui_threadMustRun = true;
                    StartGUI();
                }

                this.Enabled = true;
            }
            catch (Exception Ex)
            {
                clsSE.WriteLog(1, Ex.Message, "frmMain", "timer1_Tick");
            }
        }

        private void StartGUI()
        {
            threadGUI = new Thread(new ThreadStart(StartGUIThread));
            threadGUI.Start();
        }

        private void StartGUIThread()
        {
            try
            {
                while (gui_threadMustRun)
                {
                    lock (thisLock)
                    {
                        if (worker_status == true)
                        {
                            ribbonMain.Invoke((MethodInvoker)delegate
                            {
                                btnStart.Enabled = false;
                                btnStop.Enabled = true;
                            });
                        }
                        else
                        {
                            ribbonMain.Invoke((MethodInvoker)delegate
                            {
                                btnStart.Enabled = true;
                                btnStop.Enabled = false;
                            });
                        }
                    }

                    Thread.Sleep(100);
                }
            }
            catch (Exception Ex)
            {
                lock (thisLock)
                {
                    clsSE.WriteLog(1, Ex.Message, "frmMain", "StartGUIThread");
                }
            }
        }

        private void btnAbout_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmAbout myForm = new frmAbout();
            myForm.ShowDialog();
        }

        private void btnStart_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (worker_status == true)
                {
                    worker_threadMustRun = false;
                }
                else
                {
                    worker_threadMustRun = true;
                    StartWorker();
                }
            }
            catch (Exception Ex)
            {
                lock (thisLock)
                {
                    clsSE.WriteLog(1, Ex.Message, "frmMain", "btnStart_ItemClick");
                }
            }
        }

        private void StartWorker()
        {
            threadWorker = new Thread(new ThreadStart(StartWorkerThread));
            threadWorker.Start();
        }

        private void StartWorkerThread()
        {
            try
            {
                lock (thisLock)
                {
                    worker_status = true;
                }

                int xCount = 0;

                while (worker_threadMustRun)
                {
                    if (xCount == 10000)
                    {
                        xCount = 0;


                        clsSE.WriteLog(3, "Sending heartbeat", "frmMain", "StartWorkerThread");

                        tblClientDetail xtblClientDetail = new tblClientDetail();

                        clsDoThreaded xclsDoThreaded = new clsDoThreaded();

                        string result = clsSE.Decrypt(xclsDoThreaded.Send(clsSE.Pack("Client_Heartbeat", xtblClientDetail.dtClientDetail)));
                    }
                    // clsSE.WriteLog(3, "Receiving command: " + result, "frmMain", "StartWorkerThread");

                    xCount = xCount + 1;
                    Thread.Sleep(100);
                }

                lock (thisLock)
                {
                    worker_status = false;
                }
            }
            catch (Exception Ex)
            {
                lock (thisLock)
                {
                    clsSE.WriteLog(1, Ex.Message, "frmMain", "StartWorkerThread");
                    worker_status = false;
                }
            }
        }
    }
}