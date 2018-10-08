using SharedObjects.CLASSES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SharedObjects.DATA
{
    public class tblExport
    {
        public DataTable GetData()
        {
            DataTable theData = new DataTable();

            //ASK THE DAL
            DALClient client = new DALClient();

            try
            {
                return clsHelpers.DeSerializeToDT(client.DoWork("GetRecsForExport").ToString());
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }

    }
}
