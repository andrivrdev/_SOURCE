using SharedObjects.CLASSES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SharedObjects.DATA
{
    public class tblClientContact
    {
        public DataTable GetData(string IDX)
        {
            DataTable theData = new DataTable();

            //ASK THE DAL
            DALClient client = new DALClient();

            try
            {
                return clsHelpers.DeSerializeToDT(client.DoWork("GetClientContactRecs|" + IDX + "|").ToString());
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }

        public string AddRec(string ClientIDX, string ContactTypeIDX, string Contact)
        {
            //ASK THE DAL
            DALClient client = new DALClient();

            try
            {
                return client.DoWork("ClientContactRecsAdd|" + ClientIDX.ToString() + "|" + ContactTypeIDX + "|" + Contact.ToString() + "|").ToString();
            }
            catch
            {
                return "-1";
            }
        }
        public string EditRec(string IDX, string ClientIDX, string ContactTypeIDX, string Contact)
        {
            //ASK THE DAL
            DALClient client = new DALClient();

            try
            {
                return client.DoWork("ClientContactRecsEdit|" + IDX.ToString() + "|" + ClientIDX.ToString() + "|" + ContactTypeIDX + "|" + Contact.ToString() + "|").ToString();
            }
            catch
            {
                return "-1";
            }
        }

        public string DeleteRec(string IDX)
        {
            //ASK THE DAL
            DALClient client = new DALClient();

            try
            {
                return client.DoWork("ClientContactRecsRemove|" + IDX.ToString() + "|").ToString();
            }
            catch
            {
                return "-1";
            }
        }



    }
}
