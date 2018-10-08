using SharedObjects;
using SharedObjects.CLASSES;
using SharedObjects.FORMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace DashBoard
{
    public partial class frmMain : Form
    {
        //SAFE THREAD LOCKING
        private Object thisLock = new Object();

        //THREADS
        Thread threadGUI;
        Thread threadServer;
        Thread threadDAL;

        //GUI
        bool gui_threadMustRun = false;

        //SERVER
        Type server_serviceType = null;
        string server_httpBaseAddress = null;
        Uri[] server_baseAddress = null;
        ServiceHost server_host = null;
        bool server_status = false;
        bool server_threadMustRun = false;

        //DAL
        Type dal_serviceType = null;
        string dal_httpBaseAddress = null;
        Uri[] dal_baseAddress = null;
        ServiceHost dal_host = null;
        bool dal_status = false;
        bool dal_threadMustRun = false;

        public frmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (server_status == true)
            {
                server_threadMustRun = false;
            }
            else
            {
                server_threadMustRun = true;
                StartServer();
            }
        }

        #region Helper Methods

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
                        if (server_status == true)
                        {
                            lblServerStatus.Invoke((MethodInvoker) delegate 
                            {
                                lblServerStatus.Text = "Running...";
                            });
                        }
                        else
                        {
                            lblServerStatus.Invoke((MethodInvoker)delegate
                            {
                                lblServerStatus.Text = "Stopped";
                            });
                        }
                    }

                    lock (thisLock)
                    {
                        if (dal_status == true)
                        {
                            lblDALStatus.Invoke((MethodInvoker)delegate
                            {
                                lblDALStatus.Text = "Running...";
                            });
                        }
                        else
                        {
                            lblDALStatus.Invoke((MethodInvoker)delegate
                            {
                                lblDALStatus.Text = "Stopped";
                            });
                        }
                    }

                    Thread.Sleep(100);
                }
            }
            catch
            {

            }
        }

        private void StartServer()
        {
            threadServer = new Thread(new ThreadStart(StartServerThread));
            threadServer.Start();
        }

        private void StartDAL()
        {
            threadDAL = new Thread(new ThreadStart(StartDALThread));
            threadDAL.Start();
        }

        private void StartServerThread()
        {
            try
            {
                while (server_threadMustRun)
                {
                    bool isRunning = false;

                    if (server_host != null)
                    {
                        if (server_status == true)
                        {
                            isRunning = true;
                        }
                    }

                    if (!isRunning)
                    {
                        server_serviceType = typeof(Server.Server);
                        server_httpBaseAddress = ConfigurationManager.AppSettings["serverHTTPBaseAddress"];
                        server_baseAddress = new Uri[] { new Uri(server_httpBaseAddress) };
                        server_host = new ServiceHost(server_serviceType, server_baseAddress);

                        server_host.Opened += Server_host_Opened;
                        server_host.Closed += Server_host_Closed;

                        server_host.Open();
                    }

                    Thread.Sleep(200);
                }

                server_host.Close();
            }
            catch
            {
                lock (thisLock)
                {
                    server_status = false;
                }
            }
        }

        private void StartDALThread()
        {
            try
            {
                while (dal_threadMustRun)
                {
                    bool isRunning = false;

                    if (dal_host != null)
                    {
                        if (dal_status == true)
                        {
                            isRunning = true;
                        }
                    }

                    if (!isRunning)
                    {
                        dal_serviceType = typeof(DAL.DAL);
                        dal_httpBaseAddress = ConfigurationManager.AppSettings["dalHTTPBaseAddress"];
                        dal_baseAddress = new Uri[] { new Uri(dal_httpBaseAddress) };
                        dal_host = new ServiceHost(dal_serviceType, dal_baseAddress);

                        dal_host.Opened += Dal_host_Opened;
                        dal_host.Closed += Dal_host_Closed;

                        dal_host.Open();
                    }

                    Thread.Sleep(200);
                }

                dal_host.Close();
            }
            catch
            {
                lock (thisLock)
                {
                    dal_status = false;
                }
            }
        }

        private void Dal_host_Closed(object sender, EventArgs e)
        {
            lock (thisLock)
            {
                dal_status = false;
            }
        }

        private void Dal_host_Opened(object sender, EventArgs e)
        {
            lock (thisLock)
            {
                dal_status = true;
            }
        }

        private void Server_host_Closed(object sender, EventArgs e)
        {
            lock (thisLock)
            {
                server_status = false;
            }
        }

        private void Server_host_Opened(object sender, EventArgs e)
        {
            lock (thisLock)
            {
                server_status = true;
            }
        }

        #endregion

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            gui_threadMustRun = false;
            server_threadMustRun = false;
            dal_threadMustRun = false;
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dal_status == true)
            {
                dal_threadMustRun = false;
            }
            else
            {
                dal_threadMustRun = true;
                StartDAL();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmClient myForm = new frmClient();
            myForm.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            clsHelpers.GetLocalDB("ThreeTierDB", false);
            clsHelpers.GetLocalDB("ThreeTierDB", false);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            if (clsHelpers.CheckDB("ThreeTierDB", false))
            {
                MessageBox.Show("A new database must be created! This will be done automatically when you continue.");
                clsHelpers.GetLocalDB("ThreeTierDB", false);
            }

            if (gui_threadMustRun == false)
            {
                gui_threadMustRun = true;
                StartGUI();
            }

            this.Enabled = true;
        }
    }
}
