using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle
{
    public class VehicleContext
    {
        public VehicleContext(bool isPurchase)
        {
            IsPurchase = isPurchase;
        }

        public bool IsPurchase { get; set; }

    }
}
