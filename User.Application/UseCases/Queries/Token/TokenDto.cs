using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Application.Model.Query;

namespace User.Application.UseCases.Queries.Token
{
    public record TokenDto : BaseDto
    {
        public int Id { get; set; }
        public string? userName { get; set; }
    }

}
