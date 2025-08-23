using CarBook.Domain.Entities;
using CarBook_1.Application.Interfaces.CarPricingInterfaces;
using CarBook_1.Application.ViewModels;
using CarBook_1.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook_1.Persistence.Repositories.CarPricingRepositories
{
    public class CarPricingRepository: ICarPricingRepository
    {
        private readonly CarBookContext _context;

        public CarPricingRepository(CarBookContext context)
        {
            _context = context;
        }

        public List<CarPricing> GerCarPricingWithTimePeriod()
        {
            //var values = from x in _context.CarPricings
            //             group x by x.PricingId into g
            //             select new
            //             {
            //                 CarId = g.Key,
            //                 DailyPrice = g.Where(y => y.PricingId == 1).Sum(z => z.Amount),
            //                 WeeklyPrice = g.Where(y => y.PricingId == 2).Sum(z => z.Amount),
            //                 MonthlyPrice = g.Where(y => y.PricingId == 3).Sum(z => z.Amount),
            //             };
            //return values.ToList();

            

            throw new NotImplementedException();
        }

        public List<CarPricingViewModel> GerCarPricingWithTimePeriod1()
        {
            List<CarPricingViewModel> values = new List<CarPricingViewModel>();
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "Select * From(Select Model, CoverImageUrl, PricingId, Amount From CarPricings Inner Join Cars On Cars.CarId = CarPricings.CarId Inner Join Brands On Brands.BrandId = Cars.BrandId) As SourceTable Pivot(Sum(Amount) For PricingId In ([1], [2], [3])) as PivotTable";
                command.CommandType = System.Data.CommandType.Text;
                _context.Database.OpenConnection();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CarPricingViewModel carPricingViewModel = new CarPricingViewModel()
                        {
                            Model = reader["Model"].ToString(),
                            CoverImageUrl = reader["CoverImageUrl"].ToString(),
                            Amounts = new List<decimal>
                            {
                                Convert.ToDecimal(reader[2]),
                                Convert.ToDecimal(reader[3]),
                                Convert.ToDecimal(reader[4])
                            }
                        };
                        values.Add(carPricingViewModel);
                    }
                }
                _context.Database.CloseConnection();
                return values;
            }
        }

        public List<CarPricing> GetCarPricingWithCars()
        {
            var values = _context.CarPricings.Include(x => x.Car).ThenInclude(y => y.Brand).Include(x => x.Pricing).Where(z => z.PricingId == 1).ToList();
            return values;
        }

        
    }
}
