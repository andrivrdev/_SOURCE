using SharedObjects.CLASSES;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml.Serialization;

namespace Server
{
    public class Server : IServer
    {

        public object DoWork(object objData)
        {
            try
            {
                if (clsHelpers.con != null)
                {

                }
                else
                {
                    return clsHelpers.GetLocalDB("ThreeTierDB", false);
                }

                if (objData.ToString().Contains("CheckDB") )
                {
                    return clsHelpers.GetLocalDB("ThreeTierDB", false);
                }

                if (objData.ToString().Contains("GetRecsForExport"))
                {
                    return clsHelpers.GetRecsForExport();
                }

                if (objData.ToString().Contains("GetClientContactRecs"))
                {
                    return clsHelpers.GetClientContactRecs(objData.ToString());
                }

                if (objData.ToString().Contains("ClientContactRecsAdd"))
                {
                    return clsHelpers.ClientContactRecsAdd(objData.ToString());
                }

                if (objData.ToString().Contains("ClientContactRecsEdit"))
                {
                    return clsHelpers.ClientContactRecsEdit(objData.ToString());
                }

                if (objData.ToString().Contains("ClientContactRecsRemove"))
                {
                    return clsHelpers.ClientContactRecsRemove(objData.ToString());
                }

                if (objData.ToString().Contains("GetAllClientRecs"))
                {
                    return clsHelpers.GetAllClientRecs();
                }

                if (objData.ToString().Contains("ClientRecsAdd"))
                {
                    return clsHelpers.ClientRecsAdd(objData.ToString());
                }

                if (objData.ToString().Contains("ClientRecsEdit"))
                {
                    return clsHelpers.ClientRecsEdit(objData.ToString());
                }

                if (objData.ToString().Contains("ClientRecsRemove"))
                {
                    return clsHelpers.ClientRecsRemove(objData.ToString());
                }

                if (objData.ToString().Contains("GetAllContactTypeRecs"))
                {
                    return clsHelpers.GetAllContactTypeRecs();
                }

                if (objData.ToString().Contains("ContactTypeRecsAdd"))
                {
                    return clsHelpers.ContactTypeRecsAdd(objData.ToString());
                }

                if (objData.ToString().Contains("ContactTypeRecsEdit"))
                {
                    return clsHelpers.ContactTypeRecsEdit(objData.ToString());
                }

                if (objData.ToString().Contains("ContactTypeRecsRemove"))
                {
                    return clsHelpers.ContactTypeRecsRemove(objData.ToString());
                }

                return "Invalid Message";
            }
            catch (Exception ex)
            {
                return "Invalid Message - " + ex.Message;
            }
        }
    }
}
