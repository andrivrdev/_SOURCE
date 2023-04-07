using SharedObjects.CLASSES;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace SharedObjects.DATA
{
    public class tblContactType
    {
        public DataTable GetData()
        {
            DataTable theData = new DataTable();

            //ASK THE DAL
            DALClient client = new DALClient();

            try
            {
                return clsHelpers.DeSerializeToDT(client.DoWork("GetAllContactTypeRecs").ToString());
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }
        public string AddRec(int Type, string Description)
        {
            //ASK THE DAL
            DALClient client = new DALClient();

            try
            {
                return client.DoWork("ContactTypeRecsAdd|" + Type.ToString() + "|" + Description + "|").ToString();
            }
            catch
            {
                return "-1";
            }
        }
        public string EditRec(string IDX,  int Type, string Description)
        {
            //ASK THE DAL
            DALClient client = new DALClient();

            try
            {
                return client.DoWork("ContactTypeRecsEdit|" + IDX.ToString() + "|" + Type.ToString() + "|" + Description + "|").ToString();
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
                return client.DoWork("ContactTypeRecsRemove|" + IDX.ToString() + "|").ToString();
            }
            catch
            {
                return "-1";
            }
        }
    }
}
