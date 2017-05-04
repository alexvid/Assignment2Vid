using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FurnitureManufacturer.Models
{
    public interface Raport
    {
        string getType();
        void deleteOldFile();
        void getRaport(int ID, int IDEmployee, int IDOperation, string TableName, DateTime Date);
    }
}
