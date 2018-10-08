using SharedObjects.CLASSES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SharedObjects.DATA
{
    public class tblClient
    {
        public DataTable GetData()
        {
            DataTable theData = new DataTable();

            //ASK THE DAL
            DALClient client = new DALClient();

            try
            {
                return clsHelpers.DeSerializeToDT(client.DoWork("GetAllClientRecs").ToString());
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }

        public string AddRec(string Name, string Surname, int Gender, int Age)
        {
            //ASK THE DAL
            DALClient client = new DALClient();

            try
            {
                return client.DoWork("ClientRecsAdd|" + Name.ToString() + "|" + Surname + "|" + Gender.ToString() + "|" + Age.ToString() + "|").ToString();
            }
            catch
            {
                return "-1";
            }
        }
        public string EditRec(string IDX, string Name, string Surname, int Gender, int Age)
        {
            //ASK THE DAL
            DALClient client = new DALClient();

            try
            {
                return client.DoWork("ClientRecsEdit|" + IDX.ToString() + "|" + Name.ToString() + "|" + Surname + "|" + Gender.ToString() + "|" + Age.ToString() + "|").ToString();
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
                return client.DoWork("ClientRecsRemove|" + IDX.ToString() + "|").ToString();
            }
            catch
            {
                return "-1";
            }
        }
    }
}
