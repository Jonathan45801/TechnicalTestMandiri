using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Domain.Entities
{
    public class ProductHeader
    {
        public int Id { get; set; }
        public string? NamaProduct { get; set; }
        public string? DescriptionProduct { get; set;}
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        public string? CreatedBy { get; set; }
        public virtual ICollection<ProductDetail> Details { get; private set; }
    }
}
