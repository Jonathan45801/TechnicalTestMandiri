using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Interface
{
    public interface IAuth
    {
        public int Id { get; set; }
        public string? userName { get; set; }
    }
}
