using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devGeneric.devClasses.devDynamic
{
    public class devINIFile
    {
        public string MyFile;

        public devINIFile(string xFile)
        {
            MyFile = xFile;
        }

        public bool WriteString(string xSection, string xKey, string xValue)
        {
            if (xSection.Length > 0 && xKey.Length > 0)
            {
                string MyLine = "";
                int SectionLine;
                int NextSectionLine;
                int KeyLine;
                int CountModify = 0;

                List<string> MyLines = new List<string>();

                try
                {
                    //Check if file exists
                    if (File.Exists(MyFile))
                    {
                        //Read the file
                        StreamReader MyINIRead = new StreamReader(MyFile, Encoding.Unicode);

                        while (MyINIRead.Peek() >= 0)
                        {
                            MyLine = MyINIRead.ReadLine();

                            MyLines.Add(MyLine);
                        }

                        MyINIRead.Close();

                        //Check if the Section exists
                        SectionLine = -1;
                        NextSectionLine = MyLines.Count;
                        KeyLine = -1;
                        for (int C1 = 0; C1 < MyLines.Count; C1++)
                        {
                            if (MyLines[C1] == "[" + xSection + "]")
                            {
                                SectionLine = C1;

                                //Find the end of the section
                                for (int C2 = SectionLine + 1; C2 < NextSectionLine; C2++)
                                {
                                    if (MyLines[C2] != "")
                                    {
                                        if ((MyLines[C2].Substring(0, 1) == "[") && (MyLines[C2].Substring(MyLines[C2].Length - 1, 1) == "]"))
                                        {
                                            NextSectionLine = C2;
                                        }
                                    }
                                }
                            }
                        }

                        if (SectionLine > -1)
                        {
                            //Check if Key exists
                            for (int C1 = SectionLine; C1 < NextSectionLine; C1++)
                            {
                                if (MyLines[C1] != "")
                                {
                                    try
                                    {
                                        if (MyLines[C1].Substring(0, xKey.Length + 1) == xKey + "=")
                                        {
                                            KeyLine = C1;
                                        }
                                    }
                                    catch (Exception)
                                    {
                                    }
                                }
                            }
                        }

                        //Build a new list
                        if (KeyLine > -1)
                        {
                            MyLines[KeyLine] = xKey + "=" + xValue;
                        }
                        else
                        {
                            if (SectionLine > -1)
                            {
                                //Create only the key
                                List<string> MyTempLines = new List<string>();

                                if (NextSectionLine == MyLines.Count())
                                {
                                    CountModify = 0;
                                }
                                else
                                {
                                    CountModify = 1;
                                }

                                for (int C1 = 0; C1 < NextSectionLine - CountModify; C1++)
                                {
                                    MyTempLines.Add(MyLines[C1]);
                                }

                                MyTempLines.Add(xKey + "=" + xValue);

                                for (int C1 = NextSectionLine - CountModify; C1 < MyLines.Count; C1++)
                                {
                                    MyTempLines.Add(MyLines[C1]);
                                }

                                MyLines.Clear();

                                for (int C1 = 0; C1 < MyTempLines.Count; C1++)
                                {
                                    MyLines.Add(MyTempLines[C1]);
                                }
                            }
                            else
                            {
                                //Create the section and the key
                                MyLines.Add("");
                                MyLines.Add("[" + xSection + "]");
                                MyLines.Add(xKey + "=" + xValue);
                            }
                        }

                        //Write the file
                        StreamWriter MyINIWrite = new StreamWriter(MyFile, false, Encoding.Unicode);

                        for (int C1 = 0; C1 < MyLines.Count; C1++)
                        {
                            MyINIWrite.WriteLine(MyLines[C1]);
                        }

                        MyINIWrite.Close();

                        return true;
                    }
                    else
                    {
                        MyLines.Clear();

                        //Create the section and the key
                        MyLines.Add("[" + xSection + "]");
                        MyLines.Add(xKey + "=" + xValue);

                        StreamWriter MyINIWrite = new StreamWriter(MyFile, false, Encoding.Unicode);

                        for (int C1 = 0; C1 < MyLines.Count; C1++)
                        {
                            MyINIWrite.WriteLine(MyLines[C1]);
                        }

                        MyINIWrite.Close();

                        return true;
                    }
                }
                catch (Exception Ex)
                {
                    devSE SE = new devSE();
                    SE.WriteLog(Ex.Message, "devINIFile", "WriteString");
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        public string ReadString(string xSection, string xKey)
        {
            if (xSection.Length > 0 && xKey.Length > 0)
            {
                string MyLine = "";
                int SectionLine;
                int NextSectionLine;
                int KeyLine;

                List<string> MyLines = new List<string>();

                try
                {
                    //Check if file exists
                    if (File.Exists(MyFile))
                    {
                        //Read the file
                        StreamReader MyINIRead = new StreamReader(MyFile, Encoding.Unicode);

                        while (MyINIRead.Peek() >= 0)
                        {
                            MyLine = MyINIRead.ReadLine();

                            MyLines.Add(MyLine);
                        }

                        MyINIRead.Close();

                        //Check if the Section exists
                        SectionLine = -1;
                        NextSectionLine = MyLines.Count;
                        KeyLine = -1;
                        for (int C1 = 0; C1 < MyLines.Count; C1++)
                        {
                            if (MyLines[C1] == "[" + xSection + "]")
                            {
                                SectionLine = C1;

                                //Find the end of the section
                                for (int C2 = SectionLine + 1; C2 < NextSectionLine; C2++)
                                {
                                    if (MyLines[C2] != "")
                                    {
                                        if ((MyLines[C2].Substring(0, 1) == "[") && (MyLines[C2].Substring(MyLines[C2].Length - 1, 1) == "]"))
                                        {
                                            NextSectionLine = C2;
                                        }
                                    }
                                }
                            }
                        }

                        if (SectionLine > -1)
                        {
                            //Check if Key exists
                            for (int C1 = SectionLine; C1 < NextSectionLine; C1++)
                            {
                                if (MyLines[C1] != "")
                                {
                                    try
                                    {
                                        if (MyLines[C1].Substring(0, xKey.Length + 1) == xKey + "=")
                                        {
                                            KeyLine = C1;
                                        }
                                    }
                                    catch (Exception)
                                    {
                                    }
                                }
                            }
                        }

                        //Get key value
                        if (KeyLine > -1)
                        {
                            return MyLines[KeyLine].Substring(xKey.Length + 1);
                        }
                        else
                        {
                            return "";
                        }
                    }
                    else
                    {
                        return "";
                    }
                }
                catch (Exception Ex)
                {
                    devSE SE = new devSE();
                    SE.WriteLog(Ex.Message, "devINIFile", "ReadString");

                    return "";
                }
            }
            else
            {
                return "";
            }
        }

        public List<string> GetSections()
        {
            string MyLine = "";

            List<string> MyLines = new List<string>();
            List<string> MyReturn = new List<string>();

            try
            {
                //Check if file exists
                if (File.Exists(MyFile))
                {
                    //Read the file
                    StreamReader MyINIRead = new StreamReader(MyFile, Encoding.Unicode);

                    while (MyINIRead.Peek() >= 0)
                    {
                        MyLine = MyINIRead.ReadLine();

                        MyLines.Add(MyLine);
                    }

                    MyINIRead.Close();

                    //Build a list of the sections
                    for (int C1 = 0; C1 < MyLines.Count; C1++)
                    {
                        if (MyLines[C1] != "")
                        {
                            if ((MyLines[C1].Substring(0, 1) == "[") && (MyLines[C1].Substring(MyLines[C1].Length - 1, 1) == "]"))
                            {
                                MyReturn.Add(MyLines[C1].Substring(1, (MyLines[C1].Length - 2)));
                            }
                        }
                    }

                    return MyReturn;
                }
                else
                {
                    return new List<string>();
                }
            }
            catch (Exception Ex)
            {
                devSE SE = new devSE();
                SE.WriteLog(Ex.Message, "devINIFile", "GetSections");

                return new List<string>();
            }
        }

        public List<string> GetSectionKeys(string xSection)
        {
            if (xSection.Length > 0)
            {
                string MyLine = "";
                int SectionLine;
                int NextSectionLine;
                int KeyLine;

                List<string> MyLines = new List<string>();
                List<string> MyReturn = new List<string>();

                try
                {
                    //Check if file exists
                    if (File.Exists(MyFile))
                    {
                        //Read the file
                        StreamReader MyINIRead = new StreamReader(MyFile, Encoding.Unicode);

                        while (MyINIRead.Peek() >= 0)
                        {
                            MyLine = MyINIRead.ReadLine();

                            MyLines.Add(MyLine);
                        }

                        MyINIRead.Close();

                        //Check if the Section exists
                        SectionLine = -1;
                        NextSectionLine = MyLines.Count;
                        KeyLine = -1;
                        for (int C1 = 0; C1 < MyLines.Count; C1++)
                        {
                            if (MyLines[C1] == "[" + xSection + "]")
                            {
                                SectionLine = C1;

                                //Find the end of the section
                                for (int C2 = SectionLine + 1; C2 < NextSectionLine; C2++)
                                {
                                    if (MyLines[C2] != "")
                                    {
                                        if ((MyLines[C2].Substring(0, 1) == "[") && (MyLines[C2].Substring(MyLines[C2].Length - 1, 1) == "]"))
                                        {
                                            NextSectionLine = C2;
                                        }
                                    }
                                }
                            }
                        }

                        if (SectionLine > -1)
                        {
                            //Build key list
                            for (int C1 = SectionLine + 1; C1 < NextSectionLine; C1++)
                            {
                                if ((MyLines[C1] != "") && (MyLines[C1].IndexOf("=") > -1))
                                {
                                    MyReturn.Add(MyLines[C1].Substring(0, (MyLines[C1].IndexOf("="))));
                                }
                            }
                        }

                        return MyReturn;
                    }
                    else
                    {
                        return new List<string>();
                    }
                }
                catch (Exception Ex)
                {
                    devSE SE = new devSE();
                    SE.WriteLog(Ex.Message, "devINIFile", "GetSectionKeys");

                    return new List<string>();
                }
            }
            else
            {
                return new List<string>();
            }
        }

        public bool UpdateSection(string xSection, string xNewSection)
        {
            if (xSection.Length > 0 && xNewSection.Length > 0)
            {
                string MyLine = "";
                int SectionLine;
                int NextSectionLine;
                int KeyLine;
                int CountModify = 0;

                List<string> MyLines = new List<string>();

                try
                {
                    //Check if file exists
                    if (File.Exists(MyFile))
                    {
                        //Read the file
                        StreamReader MyINIRead = new StreamReader(MyFile, Encoding.Unicode);

                        while (MyINIRead.Peek() >= 0)
                        {
                            MyLine = MyINIRead.ReadLine();

                            MyLines.Add(MyLine);
                        }

                        MyINIRead.Close();

                        //Check if the Section exists
                        SectionLine = -1;
                        NextSectionLine = MyLines.Count;
                        KeyLine = -1;
                        for (int C1 = 0; C1 < MyLines.Count; C1++)
                        {
                            if (MyLines[C1] == "[" + xSection + "]")
                            {
                                MyLines[C1] = "[" + xNewSection + "]";
                            }
                        }

                        //Write the file
                        StreamWriter MyINIWrite = new StreamWriter(MyFile, false, Encoding.Unicode);

                        for (int C1 = 0; C1 < MyLines.Count; C1++)
                        {
                            MyINIWrite.WriteLine(MyLines[C1]);
                        }

                        MyINIWrite.Close();

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception Ex)
                {
                    devSE SE = new devSE();
                    SE.WriteLog(Ex.Message, "devINIFile", "UpdateSection");

                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        public bool DeleteSection(string xSection)
        {
            if (xSection.Length > 0)
            {
                string MyLine = "";
                int SectionLine;
                int NextSectionLine;
                int KeyLine;
                int CountModify = 0;

                List<string> MyLines = new List<string>();

                try
                {
                    //Check if file exists
                    if (File.Exists(MyFile))
                    {
                        //Read the file
                        StreamReader MyINIRead = new StreamReader(MyFile, Encoding.Unicode);

                        while (MyINIRead.Peek() >= 0)
                        {
                            MyLine = MyINIRead.ReadLine();

                            MyLines.Add(MyLine);
                        }

                        MyINIRead.Close();

                        //Check if the Section exists
                        SectionLine = -1;
                        NextSectionLine = MyLines.Count;
                        KeyLine = -1;
                        for (int C1 = 0; C1 < MyLines.Count; C1++)
                        {
                            if (MyLines[C1] == "[" + xSection + "]")
                            {
                                SectionLine = C1;

                                //Find the end of the section
                                for (int C2 = SectionLine + 1; C2 < NextSectionLine; C2++)
                                {
                                    if (MyLines[C2] != "")
                                    {
                                        if ((MyLines[C2].Substring(0, 1) == "[") && (MyLines[C2].Substring(MyLines[C2].Length - 1, 1) == "]"))
                                        {
                                            NextSectionLine = C2;
                                        }
                                    }
                                }
                            }
                        }


                        if (SectionLine > -1)
                        {
                            //Delete the section
                            List<string> MyTempLines = new List<string>();

                            if (NextSectionLine == MyLines.Count())
                            {
                                CountModify = 0;
                            }
                            else
                            {
                                CountModify = 1;
                            }

                            for (int C1 = 0; C1 < SectionLine - CountModify; C1++)
                            {
                                MyTempLines.Add(MyLines[C1]);
                            }

                            for (int C1 = NextSectionLine - CountModify; C1 < MyLines.Count; C1++)
                            {
                                MyTempLines.Add(MyLines[C1]);
                            }

                            MyLines.Clear();

                            for (int C1 = 0; C1 < MyTempLines.Count; C1++)
                            {
                                MyLines.Add(MyTempLines[C1]);
                            }

                            //Write the file
                            StreamWriter MyINIWrite = new StreamWriter(MyFile, false, Encoding.Unicode);

                            for (int C1 = 0; C1 < MyLines.Count; C1++)
                            {
                                MyINIWrite.WriteLine(MyLines[C1]);
                            }

                            MyINIWrite.Close();

                            return true;
                        }

                        return false;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception Ex)
                {
                    devSE SE = new devSE();
                    SE.WriteLog(Ex.Message, "devINIFile", "DeleteSection");

                    return false;
                }
            }
            else
            {
                return true;
            }
        }
    }
}
