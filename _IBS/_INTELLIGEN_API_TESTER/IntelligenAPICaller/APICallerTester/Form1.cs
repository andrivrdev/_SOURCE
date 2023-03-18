using IntelligenAPICaller;
using IntelligenAPICaller.DATA;
using IntelligenAPICaller.HELPERS;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace APICallerTester
{
    public partial class Form1 : Form
    {
        string zBaseURI2 = "http://192.168.101.171:4113/";
        string zBaseURI = "https://www.intelligen.co.za/";
        

        BindingList<tblDestination> ztblDestination = null;


        public Form1()
        {
            InitializeComponent();

            clsHelper xclsHelper = new clsHelper();
            BindingList<tblDestination> ztblDestination = new BindingList<tblDestination>();



            grdDestination.DataSource = ztblDestination;
        }

        private async void btnGetToken_Click(object sender, EventArgs e)
        {
            try
            {
                tblUser xtblUser = new tblUser();
                xtblUser.userName = edtGetTokenUsername.Text;
                xtblUser.password = edtGetTokenPassword.Text;
                xtblUser.grant_type = "password";

                // Get a new token
                var xResponse = await API.GetAccessToken(zBaseURI, xtblUser);
                edtGetTokenToken.Text = xResponse;
            }
            catch 
            {
                edtGetTokenToken.Text = "Error";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            edtGetUnitListToken.Text = edtGetTokenToken.Text;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                List<tblListBoxItem> xtblListBoxItem = new List<tblListBoxItem>();

                // Get data
                xtblListBoxItem = await API.GetUnitList(zBaseURI, edtGetUnitListToken.Text);
                grdGetUnitList.DataSource = xtblListBoxItem;
            }
            catch
            {
                edtGetTokenToken.Text = "Error";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            edtGetUnitStatesToken.Text = edtGetTokenToken.Text;
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            try
            {
                List<tblUnitState> xtblUnitState = new List<tblUnitState>();



                // Get data
                xtblUnitState = await API.GetUnitStates(zBaseURI, edtGetUnitStatesToken.Text, edtGetUnitStatesUnitIDs.Text);
                grdGetUnitStates.DataSource = xtblUnitState;
            }
            catch
            {
                edtGetTokenToken.Text = "Error";
            }
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            try
            {
                lblPostDispatchOutput.Text = "Executing...";

                tblDispatch xtblDispatch = new tblDispatch();

                xtblDispatch.Unit = new tblDispatchUnit();
                xtblDispatch.Destinations = new List<tblDestination>();
                xtblDispatch.CustomFields = new List<tblCustomField>();


                xtblDispatch.DispatchID = 0;
                xtblDispatch.CreatedDateTimeUTC = DateTime.Parse(DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString() + " " + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString());
                xtblDispatch.StartDateTimeUTC = DateTime.Parse(DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString() + " " + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString());
                xtblDispatch.DurationInMinutes = 0;
                xtblDispatch.LoginID = 0;
                xtblDispatch.AccountID = 0;

                xtblDispatch.OrderNr = edtPostDispatchOrderNr.Text;
                xtblDispatch.Description = edtPostDispatchDescription.Text;
                xtblDispatch.Client = edtPostDispatchClient.Text;
                xtblDispatch.ClientCellNr = edtPostDispatchClientCellNr.Text;
                xtblDispatch.ClientEmail = edtPostDispatchClientEmail.Text;

                xtblDispatch.DispatchStatus = 0;
                xtblDispatch.DispatchStatusText = "";

                xtblDispatch.UnitID = Convert.ToInt32(edtPostDispatchUnitID.Text);

                xtblDispatch.Alias = "";
                xtblDispatch.DispatchETAUTC = DateTime.Parse(DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString() + " " + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString());

                tblDispatchUnit xtblDispatchUnit = new tblDispatchUnit();
                xtblDispatchUnit.UnitID = 0;
                xtblDispatchUnit.DispatchETAUTC = DateTime.Parse(DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString() + " " + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString());
                xtblDispatchUnit.Alias = "";

                xtblDispatch.Unit = xtblDispatchUnit;

                xtblDispatch.LastUnitID = 0;
                xtblDispatch.SignalRConnection = "";

                tblDestination xtblDestination = new tblDestination();
                xtblDestination.Waypoints = new List<tblWaypoint>();

                xtblDestination.DispatchID = 0;
                xtblDestination.DestinationType = 3;
                xtblDestination.Destination = "Kosie";
                xtblDestination.AreaID = null;
                xtblDestination.AreaDataWKT = "";
                xtblDestination.Longitude = 153.068670;
                xtblDestination.Latitude = -27.603370;
                xtblDestination.Tolerance = 0;
                xtblDestination.Mapcode = "";

                tblWaypoint xtblWaypoint = new tblWaypoint();
                xtblWaypoint.DispatchID = 0;
                xtblWaypoint.WaypointID = 0;
                xtblWaypoint.AreaID = 0;
                xtblWaypoint.Waypoint = "";
                xtblWaypoint.Latitude = 0;
                xtblWaypoint.Longitude = 0;
                xtblWaypoint.Sequence = 0;

                xtblDestination.Waypoints.Add(xtblWaypoint);

                xtblDispatch.Destinations.Add(xtblDestination);


                /*  xtblDispatch.Destinations = new IList<tblDestination>();
                  foreach (tblDestination ARec in (BindingList<tblDestination>)grdDestination.DataSource)
                  {
                      xtblDispatch.Destinations.Add(ARec);
                  }*/

                tblCustomField xtblCustomField = new tblCustomField();
                xtblCustomField.DispatchID = 0;
                xtblCustomField.CustomFieldID = 0;
                xtblCustomField.CustomField = "";
                xtblCustomField.Label = "";
                xtblCustomField.TypeID = 0;
                xtblCustomField.Type = "";
                xtblCustomField.Value = "";
                xtblCustomField.Identifier = "";
                xtblCustomField.Required = false;
                xtblCustomField.DropDownListValues = "";

                //xtblDispatch.CustomFields.Add(xtblCustomField);
                xtblDispatch.GUID = "";

                xtblDispatch.DispatchTypeID = Convert.ToInt32(edtPostDispatchDispatchTypeID.Text);

                xtblDispatch.DispatchType = "";
                xtblDispatch.RoutingOrder = 0;
                xtblDispatch.SendStatusUpdatesToPlaza = true;

                // Post data
                var xResponse = await API.PostDispatch(zBaseURI, edtPostDispatchToken.Text, xtblDispatch);
                lblPostDispatchOutput.Text = xResponse;
            }
            catch (Exception ex)
            {
                lblPostDispatchOutput.Text = ex.Message;
            }
        }

        public class person
        {
            public string name { get; set; }
            public string surname { get; set; }
        }

        private async void button8_Click(object sender, EventArgs e)
        {
            try
            {
                lblPostDispatchOutput.Text = "Executing...";

                //Read the file
                StreamReader xCSVFile = new StreamReader(edtFileName.Text, Encoding.ASCII);

                List<string> xLines = new List<string>();

                while (xCSVFile.Peek() >= 0)
                {
                    xLines.Add(xCSVFile.ReadLine());
                }

                xCSVFile.Close();

                bool xSkipHeader = true;
                foreach (string ALine in xLines)
                {
                    if (!xSkipHeader)
                    {
                        try
                        {
                            string[] xFields = ALine.Split('|');

                            tblDispatch xtblDispatch = new tblDispatch();

                            xtblDispatch.Unit = new tblDispatchUnit();
                            xtblDispatch.Destinations = new List<tblDestination>();
                            xtblDispatch.CustomFields = new List<tblCustomField>();


                            xtblDispatch.DispatchID = 0;
                            xtblDispatch.CreatedDateTimeUTC = DateTime.Parse(DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString() + " " + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString());
                            xtblDispatch.StartDateTimeUTC = DateTime.Parse(xFields[5]);
                            xtblDispatch.DurationInMinutes = 0;
                            xtblDispatch.LoginID = 0;
                            xtblDispatch.AccountID = 0;

                            xtblDispatch.OrderNr = xFields[0].Trim();
                            xtblDispatch.Description = xFields[1].Trim();
                            xtblDispatch.Client = xFields[2].Trim();
                            xtblDispatch.ClientCellNr = xFields[3].Trim();
                            xtblDispatch.ClientEmail = xFields[4].Trim();

                            xtblDispatch.DispatchStatus = 0;
                            xtblDispatch.DispatchStatusText = "";

                            xtblDispatch.UnitID = Convert.ToInt32(edtPostDispatchUnitID.Text);

                            xtblDispatch.Alias = "";
                            xtblDispatch.DispatchETAUTC = DateTime.Parse(DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString() + " " + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString());

                            tblDispatchUnit xtblDispatchUnit = new tblDispatchUnit();
                            xtblDispatchUnit.UnitID = 0;
                            xtblDispatchUnit.DispatchETAUTC = DateTime.Parse(DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString() + " " + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString());
                            xtblDispatchUnit.Alias = "";

                            xtblDispatch.Unit = xtblDispatchUnit;

                            xtblDispatch.LastUnitID = 0;
                            xtblDispatch.SignalRConnection = "";

                            tblDestination xtblDestination = new tblDestination();
                            xtblDestination.Waypoints = new List<tblWaypoint>();

                            xtblDestination.DispatchID = 0;
                            xtblDestination.DestinationType = 3;
                            xtblDestination.Destination = xFields[6].Trim();
                            xtblDestination.AreaID = null;
                            xtblDestination.AreaDataWKT = "";
                            xtblDestination.Longitude = Convert.ToDouble(xFields[7].Replace('.', ','));
                            xtblDestination.Latitude = Convert.ToDouble(xFields[8].Replace('.', ','));
                            xtblDestination.Tolerance = 0;
                            xtblDestination.Mapcode = "";

                            tblWaypoint xtblWaypoint = new tblWaypoint();
                            xtblWaypoint.DispatchID = 0;
                            xtblWaypoint.WaypointID = 0;
                            xtblWaypoint.AreaID = 0;
                            xtblWaypoint.Waypoint = "";
                            xtblWaypoint.Latitude = 0;
                            xtblWaypoint.Longitude = 0;
                            xtblWaypoint.Sequence = 0;

                            xtblDestination.Waypoints.Add(xtblWaypoint);
                            xtblDispatch.Destinations.Add(xtblDestination);


                            /*  xtblDispatch.Destinations = new IList<tblDestination>();
                              foreach (tblDestination ARec in (BindingList<tblDestination>)grdDestination.DataSource)
                              {
                                  xtblDispatch.Destinations.Add(ARec);
                              }*/

                            tblCustomField xtblCustomField = new tblCustomField();
                            xtblCustomField.DispatchID = 0;
                            xtblCustomField.CustomFieldID = 0;
                            xtblCustomField.CustomField = "";
                            xtblCustomField.Label = "";
                            xtblCustomField.TypeID = 0;
                            xtblCustomField.Type = "";
                            xtblCustomField.Value = "";
                            xtblCustomField.Identifier = "";
                            xtblCustomField.Required = false;
                            xtblCustomField.DropDownListValues = "";

                            //xtblDispatch.CustomFields.Add(xtblCustomField);
                            xtblDispatch.GUID = "";

                            xtblDispatch.DispatchTypeID = Convert.ToInt32(edtPostDispatchDispatchTypeID.Text);

                            xtblDispatch.DispatchType = "";
                            xtblDispatch.RoutingOrder = 0;
                            xtblDispatch.SendStatusUpdatesToPlaza = true;

                            // Post data
                            var xResponse = await API.PostDispatch(zBaseURI, edtPostDispatchToken.Text, xtblDispatch);
                            lblPostDispatchOutput.Text = lblPostDispatchOutput.Text + xResponse + Environment.NewLine;
                        }
                        catch (Exception ex)
                        {
                            lblPostDispatchOutput.Text = lblPostDispatchOutput.Text + ex.Message + Environment.NewLine;
                        }
                    }

                    xSkipHeader = false;
                }
            }
            catch (Exception ex)
            {
                lblPostDispatchOutput.Text = lblPostDispatchOutput.Text + ex.Message + Environment.NewLine;
            }
        }
    }
}
