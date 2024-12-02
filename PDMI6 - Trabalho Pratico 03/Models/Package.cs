using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp2.Models
{
    public class Package
    {
        public string PackageId { get; set; }
        public string Status { get; set; }
        public DateTime ShippingDate { get; set; }
        public DateTime EstimatedDeliveryDate { get; set; }
        public string CurrentLocation { get; set; }
        public List<string> EventHistory { get; set; }
    }
}
