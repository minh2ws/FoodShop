using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TblOrderDTO
    {
        public string idOrder { get; set; }
        public string idCustomer { get; set; }
        public string idEmployee { get; set; }
        public float priceSum { get; set; }
        public float discount { get; set; }
        public float total { get; set; }
        public DateTime orderDate { get; set; }
    }
}
