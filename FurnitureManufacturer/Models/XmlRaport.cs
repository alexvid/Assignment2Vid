using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace FurnitureManufacturer.Models
{
    class XmlRaport : Raport
    {

        string path = @"Raport.xml";
        string Raport.getType()
        {
            return "Xml";
        }

        public void deleteOldFile()
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        public void getRaport(int ID, int IDEmployee, int IDOperation, string TableName, DateTime Date)
        {
            if (!File.Exists(path))
            {
                using (XmlWriter writer = XmlWriter.Create(path))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Report");


                    writer.WriteStartElement("Activity");

                    writer.WriteElementString("ID", ID.ToString());
                    writer.WriteElementString("IDEmployee", IDEmployee.ToString());
                    writer.WriteElementString("IDOperation", IDOperation.ToString());
                    writer.WriteElementString("TableName", TableName);
                    writer.WriteElementString("Date", Date.ToString());

                    writer.WriteEndElement();


                    writer.WriteEndDocument();
                }
            }
            else
            {
                XDocument xDocument = XDocument.Load(path);
                XElement root = xDocument.Element("Report");
                IEnumerable<XElement> rows = root.Descendants("Activity");
                XElement firstRow = rows.First();
                firstRow.AddBeforeSelf(
                    new XElement("Activity",
                    new XElement("ID", ID.ToString()),
                    new XElement("IDEmployee", IDEmployee.ToString()),
                    new XElement("IDOperation", IDOperation.ToString()),
                    new XElement("TableName", TableName),
                    new XElement("Date", Date.ToString())));
                xDocument.Save(path);
               
            }
        }
    }
}
