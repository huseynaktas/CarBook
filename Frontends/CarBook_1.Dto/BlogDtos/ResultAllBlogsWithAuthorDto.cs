using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook_1.Dto.BlogDtos
{
    public class ResultAllBlogsWithAuthorDto
    {

        public int blogId { get; set; }
        public int authorId { get; set; }
        public string authorName { get; set; }
        public int categoryId { get; set; }
        public object categoryName { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string coverImageUrl { get; set; }
        public DateTime createdDate { get; set; }
        public string authorDescription { get; set; }
        public string authorImageUrl { get; set; }


    }
}
