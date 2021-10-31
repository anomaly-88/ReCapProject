using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
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
            CarManager carManager = new CarManager(new EfCarDal());
            
            //###Fnc###
            
            //Get
            void fGetAllDescription() { 
                foreach(var car in carManager.GetAll())
                {
                    Console.WriteLine(car.Description);
                }
            }
            
            
            void fGetOneDescription(int id)
            {
                Car c = carManager.GetById(id);
                Console.WriteLine(c.Description);
            }

            //Add
            void fAddCar(int id, int brId, int coId, double price, int mYear, string dText)
            {
                carManager.Add(new Car { Id = id, BrandId = brId, ColorId = coId, DailyPrice = price, ModelYear = mYear, Description = dText });

            }


            //Test
            void fUIExceptionTest(Car car)
            {
                try
                {
                    carManager.Add(car);


                }
                catch (Exception)
                {

                    Console.WriteLine("Bu Id de bir data zaten var ki");
                }
            }
            //###EOF###




            fAddCar(2,1,1,1337.12, 1999,"Benim için \"eh..\", promising one more a step for mankind.");
            fAddCar(3, 1, 1, 1337.12, 2222, "Birds flyn u know how i feel");

            fGetAllDescription();

            // fUIExceptionTest(car1);




            fGetOneDescription(2);
           
            
        }
    }
}
