using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            
            //Fnc
            void GetAllDescription() { 
                foreach(var car in carManager.GetAll())
                {
                    Console.WriteLine(car.Description);
                }
            }
            //EOF



            GetAllDescription();
            Console.WriteLine(
                "\n### Add ###\n" +
                "Here we go..\n");
            carManager.Add(new Car { Id = 888, ColorId = 888, BrandId = 888, DailyPrice = 888.888, ModelYear = 2022, Description = "Test" });   //T
            carManager.Add(new Car { Id = 777, ColorId = 0, BrandId = 777, DailyPrice = 777.777, ModelYear = 2021, Description = "Test1" }); //F (c..id = 0)
            carManager.Add(new Car { Id = 666, ColorId = 6, BrandId = 6, DailyPrice = 6, ModelYear = 2023, Description = "Test2" });//F (m..year > this year +1)
            carManager.Add(new Car { Id = 555, ColorId = 5, BrandId = 5, DailyPrice = 5, ModelYear = 2000, Description = "" });//F (description lenght <2
            carManager.Add(new Car { Id = 999, ColorId = 5, BrandId = 5, DailyPrice = 5, ModelYear = 2000, Description = "Test999" });    //T
            carManager.Add(new Car { Id = 1, ColorId = 5, BrandId = 5, DailyPrice = 5, ModelYear = 2000, Description = "Test5" });//F car id is present in the list
            GetAllDescription();


            Console.WriteLine(
                "\n### Get'nDelete ###\n" +
                "Here we go..\n");
            Console.WriteLine("Record Selected for Deletion: {0}{1}", carManager.GetById(999).Description, "\n");
            Car delCar = carManager.GetById(999);
            carManager.Delete(delCar);
            GetAllDescription();



            Console.WriteLine(
                "\n### Get'nUpdate ###\n" +
                "Here we go..\n");
            Console.WriteLine("Record Selected for Updation: {0}{1}", carManager.GetById(1).Description, "\n");
            Car updCar = carManager.GetById(1);
            updCar.Description = "aaaaabbbbbbbccccccc";
            carManager.Update(updCar);
            GetAllDescription();

        }
    }
}
