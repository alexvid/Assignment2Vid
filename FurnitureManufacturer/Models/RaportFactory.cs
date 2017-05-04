using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FurnitureManufacturer.Models
{
    public class RaportFactory
    {
        public Raport createRaport(string type) {
            if (type == "Txt")
            {
                return new TxtRaport();
            }
            else if (type == "Xml")
                return new XmlRaport();
            else return null;
    }
    }
}
