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
            UserManager userManager = new UserManager(new EfUserDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            //CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            //Car car1 = new Car { Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 200000, Description = "3.20", ModelYear = "2003" };
            //Car car2 = new Car { Id = 2, BrandId = 1, ColorId = 1, DailyPrice = 1000000, Description = "5.30", ModelYear = "2015" };
            //Car car3 = new Car { Id = 3, BrandId = 2, ColorId = 1, DailyPrice = 250000, Description = "301", ModelYear = "2015" };
            //Car car4 = new Car { Id = 4, BrandId = 2, ColorId = 1, DailyPrice = 780000, Description = "508", ModelYear = "2019" };
            //Car car5 = new Car { Id = 5, BrandId = 3, ColorId = 1, DailyPrice = 700000, Description = "polo", ModelYear = "2021" };
            //Car car6 = new Car { Id = 6, BrandId = 3, ColorId = 1, DailyPrice = 1500000, Description = "golf", ModelYear = "2021" };

            //Wrong Car Parameters ==
            //Car car = new Car() { Id = 7, BrandId = 3, ColorId = 2, DailyPrice = 1000000, Description = "Tiguan", ModelYear = "2020"};
            //carManager.AddCar(car);

            //User user1 = new User { FirstName = "Emre", LastName = "Duman", Password = "123", Email = "emopusta@asdasd" };
            //User user2 = new User { FirstName = "Emopusta", LastName = "Dmn", Password = "1234", Email = "asdaasd@asdasd" };
            //userManager.Add(user1);
            //userManager.Add(user2); 

            //Customer customer = new Customer { UserId = 1, CompanyName = "PO" };
            //customerManager.Add(customer);

            //RentalTest(rentalManager);


            foreach(var item in rentalManager.GetById(1).Data)
            {
                Console.WriteLine(item.CarName + " / " + item.UserName + " / " );
            }
            //AddNewCarTest(carManager);

            //ListCarsTest(carManager);

            //ListItemsByBrandIdTest(carManager);

        }

        private static void RentalTest(RentalManager rentalManager)
        {
            Rental rental = new Rental() { CarId = 1, CustomerId = 1, Id = 1, RentDate = DateTime.Now, ReturnDate = DateTime.Now.AddDays(3) }; ;

            rentalManager.Add(rental);
        }

        private static void ListItemsByBrandIdTest(CarManager carManager)
        {
            foreach (var item in carManager.GetCarsByBrandId(2).Data)
            {
                Console.WriteLine(item.Description);
            }
        }

        private static void AddNewCarTest(CarManager carManager)
        {
            Car newCar = new Car { BrandId = 2, ColorId = 2, DailyPrice = 1600000, Description = "5008", ModelYear = "2020" };
            carManager.AddCar(newCar);
        }

        private static void ListCarsTest(CarManager carManager)
        {
            foreach (var item in carManager.GetAll().Data)
            {
                Console.WriteLine(item.Id + " " + item.Description);
            }
            Console.WriteLine("------------------------------");

            foreach (var item in carManager.GetAllCarDetail().Data)
            {
                Console.WriteLine(item.Id + " / " + item.BrandName + " / " + item.ColorName + " / " + item.Description);

            }
        }
    }
}
