using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Domain.Entities
{
    public class UserLoginToken
    {
        public int Id { get; set; }
        public string? AuthToken { get; set; }
        public string? Type { get; set; }
        public int UserLoginId { get; set; }
        public DateTime ExpiresAt { get;set; }
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        public string? CreatedBy { get; set; }
        public virtual UserLogin? UserLogins { get; set; }
    }
}
