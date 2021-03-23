using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CartDTO
    {
        public string orderId { get; set; }
        public List<TblOrderDetailDTO> itemsList { get; set; }
    }
}
