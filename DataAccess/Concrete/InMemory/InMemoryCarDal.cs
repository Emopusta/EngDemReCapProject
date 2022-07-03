using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{ Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 200000 , Description = "3.20", ModelYear = "2003"},
                new Car{ Id = 2, BrandId = 1, ColorId = 1, DailyPrice = 1000000 , Description = "5.30", ModelYear = "2015"},
                new Car{ Id = 3, BrandId = 2, ColorId = 1, DailyPrice = 250000, Description = "301", ModelYear = "2015"},
                new Car{ Id = 4, BrandId = 2, ColorId = 1, DailyPrice = 780000, Description = "508", ModelYear = "2019"},
                new Car{ Id = 5, BrandId = 3, ColorId = 1, DailyPrice = 700000, Description = "polo", ModelYear = "2021"},
                new Car{ Id = 6, BrandId = 3, ColorId = 1, DailyPrice = 1500000, Description = "golf", ModelYear = "2021"}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.FirstOrDefault(p => p.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(p => p.Id == id).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.FirstOrDefault(p => p.Id == car.Id);
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.BrandId = car.BrandId;
        }
    }
}
