using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        string _opMsg;
        List<Car> _cars;
        
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car{ Id = 1, BrandId = 1, ColorId = 2, ModelYear = 2000, DailyPrice = 150.500, Description = "Yazılım Mimarından Temiz" },
                new Car{ Id = 2, BrandId = 5, ColorId = 99, ModelYear = 2020, DailyPrice = 100.100, Description = "Bayandan Temiz"  },
                new Car{ Id = 3, BrandId = 7, ColorId = 40, ModelYear = 2021, DailyPrice = 88.00, Description = "Aynaları yok"},
                new Car{ Id = 4, BrandId = 3, ColorId = 88, ModelYear = 2022, DailyPrice = 222.222, Description = "Coderdan Temiz"},
                new Car{ Id = 5, BrandId = 8, ColorId = 88, ModelYear = 1999, DailyPrice = 133.337, Description = "Hackerdan Temiz"} 
            };
        }

        public void Add(Car car)
        {
            try{
                _cars.Add(car);
                _opMsg = "[InMemoryCarDal]Ekleme işlemi başarılı.";
            }
            catch (Exception e)
            {
                _opMsg = "[InMemoryCarDal]Add Operation not completed.";
                Console.WriteLine("{0} Exception caught.", e);
            }
            
        }

        public void Delete(Car car)
        {
            try
            {
                Car CarHold = _cars.SingleOrDefault(c => car.Id == c.Id);
                _cars.Remove(CarHold);
                _opMsg = "[InMemoryCarDal]Delete Operation Successfully Competed.";
            }
            catch (Exception e)
            {
                _opMsg = "[InMemoryCarDal]Delete Operation not completed.";
                throw e;
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            _opMsg = "[InMemoryCarDal]Returned All Cars";
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int carId)
        {
            Car holdCar = _cars.SingleOrDefault(c => c.Id == carId);

            //Car holdCar = null;

            //foreach (var car in _cars)
            //{
            //    if(car.Id == carId) { holdCar = car; }
            //}

            _opMsg = "[InMemoryCarDal]Getting..";
            return holdCar;
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car holdCar = _cars.SingleOrDefault(c => c.Id == car.Id);
            holdCar.BrandId = car.BrandId;
            holdCar.ColorId = car.ColorId;
            holdCar.ModelYear = car.ModelYear;
            holdCar.DailyPrice = car.DailyPrice;
            holdCar.Description = car.Description;

            _opMsg = "[InMemoryCarDal]Updated.";
        }
    }
}
