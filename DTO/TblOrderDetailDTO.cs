using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TblOrderDetailDTO
    {
        public string idOrder { get; set; }
        public string idProduct { get; set; }
        public int quantity { get; set; }
        public float price { get; set; }
    }
}
