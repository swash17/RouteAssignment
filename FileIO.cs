using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace SwashSim_RouteAssign
{
    public class FileIO
    {

        public void WriteODdemandFile(string filename, List<XXE_DataStructures.ODdata> OD)
        {
            XmlTextWriter xtw = new XmlTextWriter(filename, System.Text.Encoding.UTF8);
            //indent tags by 2 characters
            xtw.Formatting = Formatting.Indented;
            xtw.Indentation = 2;
            //enclose attributes' values in double quotes
            xtw.QuoteChar = '"';
            xtw.WriteStartDocument(true);
            xtw.WriteStartElement("XXE_OD");

            //write <ODdata> information
            xtw.WriteStartElement("ODdata");
            for (int id = 1; id < OD.Count; id++)
            {
                //write a new <Link id="nnn"> element
                xtw.WriteStartElement("O-D");
                xtw.WriteAttributeString("id", id.ToString());
                //write the fields of each link
                xtw.WriteElementString("OrigZone", OD[id].OrigZone.ToString());
                xtw.WriteElementString("DestZone", OD[id].DestZone.ToString());
                xtw.WriteElementString("NumTrips", OD[id].NumTrips.ToString());
                xtw.WriteEndElement();  //close the <O-D> tag
            }
            xtw.WriteEndElement();  //close the <ODdata> tag

            xtw.WriteEndElement();  //close the <XXE_XML> tag
            xtw.WriteEndDocument();
            xtw.Close();
        }

        public void ReadODdemandFile(string filename, List<XXE_DataStructures.ODdata> OD)
        {
            XmlTextReader xtr;
            xtr = new XmlTextReader(filename);
            int ODnum = 0;      //index for centroid number

            while (xtr.Read())
            {
                if (xtr.NodeType == XmlNodeType.Element)
                {
                    switch (xtr.Name)
                    {
                        //Origin-Destination Data Elements
                        case "OrigZone":
                            XXE_DataStructures.ODdata NewODpair = new XXE_DataStructures.ODdata();
                            OD.Add(NewODpair);
                            OD[ODnum + 1].OrigZone = xtr.ReadElementContentAsInt();
                            break;
                        case "DestZone":
                            OD[ODnum + 1].DestZone = xtr.ReadElementContentAsInt();
                            break;
                        case "NumTrips":
                            OD[ODnum + 1].NumTrips = xtr.ReadElementContentAsInt();
                            ODnum++;    //increment centroid number

                            break;
                    }
                }
            }
       
            xtr.Close();
        }
    }
}
