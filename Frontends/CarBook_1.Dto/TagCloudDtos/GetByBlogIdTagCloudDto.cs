using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook_1.Dto.TagCloudDtos
{
    public class GetByBlogIdTagCloudDto
    {
        public int tagCloudId { get; set; }
        public int blogId { get; set; }
        public string title { get; set; }
    }
}
