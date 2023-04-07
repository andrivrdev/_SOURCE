using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel;
using ClientDataTest.CLASSES;

namespace ClientDataTest.DATA
{
    public class tblClient
    {
        public int IDX { get; set; }
        public string Name { get; set; }
        public string Cell { get; set; }
        public string Email { get; set; }
        public string IsValid { get; set; }

        public BindingList<tblClient> GenerateData(int xRecCount)
        {
            BindingList<tblClient> xTheData = new BindingList<tblClient>();

            //Populate class
            for (int i = 1; i <= xRecCount; i++)
            {
                tblClient xARec = new tblClient();

                xARec.IDX = i;
                xARec.Name = devGeneral.GenerateAWord();
                xARec.Cell = devGeneral.GenerateANumber(10);
                xARec.Email = devGeneral.GenerateAnEMail();
                xARec.IsValid = "False";

                xTheData.Add(xARec);
            }

            return xTheData;
        }
    }
}
