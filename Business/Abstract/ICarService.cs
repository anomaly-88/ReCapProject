using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        public List<Car> GetAll();
        public Car GetById(int carId);

        public void Add(Car car);
        public void Update(Car car);
        public void Delete(Car car);
    }
}
