using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook_1.Dto.ReviewDtos
{
    public class ResultReviewByCarIdDto
    {
            public int reviewId { get; set; }
            public string customerName { get; set; }
            public string customerImg { get; set; }
            public string comment { get; set; }
            public int ratingValue { get; set; }
            public DateTime reviewDate { get; set; }
            public int carId { get; set; }
       

    }
}
