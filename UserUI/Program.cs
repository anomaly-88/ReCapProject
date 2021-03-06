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




            LofCarDtoTest();




            //fAddCar(3, 1, 2, 1337.12, 1999, "Benim için \"eh..\", promising one more a step for mankind.");
            //fAddCar(4, 2, 1, 1212.12, 2222, "Birds flyn u know how i feel");
            //fAddCar(5, 2, 1, 1357.12, 2222, "ummh..");
            //fAddCar(6, 2, 1, 1357.12, 2222, "Drive to nothing");
            //LofCarDtoTest();


            //fGetAllDescription();

            // fUIExceptionTest(car1);

            //fGetOneDescription(2);






            //###Fnc###

            //Get
            void LofCarDtoTest()
            {

                Console.WriteLine("Just a Moment..");
                int i = 0;

                foreach (var car in carManager.GetCarDetails().Data)
                {
                    
                    if (i == 0) { Console.Clear(); Console.WriteLine("-------------------------------"); i = 1; }

                    Console.WriteLine("ID: " + car.carId +
                                      "\nBrand: " + car.bName +
                                      "\nColor: " + car.coName +
                                      "\nDescription: " + car.Description);

                    Console.WriteLine("-------------------------------");
                }
            }

            void fGetAllDescription() { 
                foreach(var car in carManager.GetAll().Data)
                {
                    Console.WriteLine(car.Description);
                }
            }
            
            
            void fGetOneDescription(int id)
            {
                Car c = carManager.GetById(id).Data;
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





        }
    }
}
