using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            

            //Car car1 = new Car { Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 200000, Description = "3.20", ModelYear = "2003" };
            //Car car2 = new Car { Id = 2, BrandId = 1, ColorId = 1, DailyPrice = 1000000, Description = "5.30", ModelYear = "2015" };
            //Car car3 = new Car { Id = 3, BrandId = 2, ColorId = 1, DailyPrice = 250000, Description = "301", ModelYear = "2015" };
            //Car car4 = new Car { Id = 4, BrandId = 2, ColorId = 1, DailyPrice = 780000, Description = "508", ModelYear = "2019" };
            //Car car5 = new Car { Id = 5, BrandId = 3, ColorId = 1, DailyPrice = 700000, Description = "polo", ModelYear = "2021" };
            //Car car6 = new Car { Id = 6, BrandId = 3, ColorId = 1, DailyPrice = 1500000, Description = "golf", ModelYear = "2021" };

            //Wrong Car Parameters ==
            //Car car = new Car() { Id = 7, BrandId = 3, ColorId = 2, DailyPrice = 1000000, Description = "Tiguan", ModelYear = "2020"};
            //carManager.AddCar(car);

            //delete car4 from database
            //carManager.DeleteCar(car4);


            //Car newCar = new Car { BrandId = 2, ColorId = 2, DailyPrice = 1600000, Description = "5008", ModelYear = "2020" };
            //carManager.AddCar(newCar);

            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine(item.Id + " " + item.Description);
            }
            Console.WriteLine("------------------------------");

            foreach (var item in carManager.GetAllCarDetail())
            {
                Console.WriteLine(item.Id + " / " + item.BrandName + " / " + item.ColorName + " / " + item.Description);
                
            }
            

            //foreach (var item in carManager.GetCarsByBrandId(2))
            //{
            //    Console.WriteLine(item.Description);
            //}


        }
    }
}
