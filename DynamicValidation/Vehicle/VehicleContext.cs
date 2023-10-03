using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle
{
    public class VehicleContext
    {
        public bool IsPurchase { get; set; }
        public FluentValidation.Severity CreditApprovedSeverity { get; set; }
    }
}
