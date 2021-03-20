using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TblProductsDTO
    {
        public string idProduct { get; set; }
        public string name { get; set; }
        public float price { get; set; }
        public int quantity { get; set; }
        public bool status { get; set; }
        public string idCategory { get; set; }
        public string categoryName { get; set; }
    }
}
