using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook_1.Dto.AuthorDtos
{
    public class CreateAuthorDto
    {
        public string name { get; set; }
        public string imageUrl { get; set; }
        public string description { get; set; }

    }
}
