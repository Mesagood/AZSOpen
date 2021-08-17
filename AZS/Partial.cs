using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZS
{
    partial class OrdersFromSupplier
    {
        public string FullOrderDetails
        {
            get
            {
                АЗСEntities db = new АЗСEntities();
                string details = string.Empty;
                foreach (var item in db.DetailsOrdersSupplies)
                {
                    if (item.IdOrder==IdOrder)
                    {
                        details += item.Petrol.Name + " " + item.PetrolCount+"\n";
                    }
                }
                return details;
            }
        }
    }
}
