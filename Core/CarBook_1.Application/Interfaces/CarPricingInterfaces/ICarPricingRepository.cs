using CarBook.Domain.Entities;
using CarBook_1.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook_1.Application.Interfaces.CarPricingInterfaces
{
    public interface ICarPricingRepository
    {
        List<CarPricing> GetCarPricingWithCars();
        List<CarPricing> GerCarPricingWithTimePeriod();
        List<CarPricingViewModel> GerCarPricingWithTimePeriod1();
    }
}
