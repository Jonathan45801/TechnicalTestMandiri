using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Product.Domain.Entities
{
    public class User
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        
        public string? userName { get; set; }
    }
}
