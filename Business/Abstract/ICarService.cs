using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        void AddCar(Car car);
        void DeleteCar(Car car);
        List<Car> GetAll();

        List<Car> GetCarsByBrandId(int id);

        List<Car> GetCarsByColorId(int id);

        List<CarDetailDto> GetAllCarDetail();
    }
}
