﻿using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        public List<Car> GetAll();
        public Car GetById(int id);
        public void Add(Car car);
        List<CarDetailDto> GetCarDetails();
    }
}
