using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Domain.CustomEntities
{
    public class ProductAll
    {
        public int Id { get; set; }
        public string? NamaProduct { get; set; }
        public string? DescriptionProduct { get; set; }
        public string? Harga { get; set; }

    }
}
