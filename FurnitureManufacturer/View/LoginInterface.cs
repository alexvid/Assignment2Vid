using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FurnitureManufacturer
{
    public interface LoginInterface
    {
        event Action LoginBtn;
        void LoginV();

    }
}
