using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook_1.Dto.AuthorDtos
{
    public class ResultGetAuthorByBlogAuthorIdDto
    {
        public int blogId { get; set; }
        public int authorId { get; set; }
        public string authorName { get; set; }
        public string authorDescription { get; set; }
        public string authorImageUrl { get; set; }
    }
}
