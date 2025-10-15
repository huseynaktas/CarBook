using CarBook.Domain.Entities;
using CarBook_1.Application.Interfaces.CarFeatureInterfaces;
using CarBook_1.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook_1.Persistence.Repositories.CarFeatureRepositories
{
    public class CarFeatureRepository : ICarFeatureRepository
    {
        private readonly CarBookContext _context;

        public CarFeatureRepository(CarBookContext context)
        {
            _context = context;
        }

        public List<CarFeature> GetCarFeaturesByCarId(int carId)
        {
            var values = _context.CarFeatures.Include(y => y.Feature).Where(x => x.CarId == carId).ToList();
            return values;
        }
    }
}
