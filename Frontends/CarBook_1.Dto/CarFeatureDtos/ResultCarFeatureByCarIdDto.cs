using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook_1.Dto.CarFeatureDtos
{
    public class ResultCarFeatureByCarIdDto
    {
        public int carFeatureId { get; set; }
        public int featureId { get; set; }
        public string featureName { get; set; }
        public bool available { get; set; }
    }
}
