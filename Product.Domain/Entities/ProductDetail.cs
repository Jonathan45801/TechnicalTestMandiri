using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Domain.Entities
{
    public class ProductDetail
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Harga { get; set; }
        public int TerJual { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        public string? CreatedBy { get; set; }
        public DateTime LastUpdatedTime { get; set; } = DateTime.Now;
        public string? LastUpdatedBy { get;set; }
        public virtual ProductHeader? Product { get; set; }
    }
}
