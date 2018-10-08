using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL : IDAL
    {
        public object DoWork(object objData)
        {

            //ASK THE SERVER TO DO THE WORK
            ServerClient client = new ServerClient();
            return client.DoWork(objData);
        }
    }
}
