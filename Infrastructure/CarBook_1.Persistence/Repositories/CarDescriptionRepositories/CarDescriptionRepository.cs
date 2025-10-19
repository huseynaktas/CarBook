using CarBook.Domain.Entities;
using CarBook_1.Application.Interfaces.CarDescriptionInterfaces;
using CarBook_1.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook_1.Persistence.Repositories.CarDescriptionRepositories
{
    public class CarDescriptionRepository : ICarDescriptionRepository
    {
        private readonly CarBookContext _context;

        public CarDescriptionRepository(CarBookContext context)
        {
            _context = context;
        }

        public CarDescription GetCarDescription(int carId)
        {
            var values = _context.CarDescriptions.Where(x => x.CarId == carId).FirstOrDefault();
            return values;
        }
    }
}
