using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarDetailDto:IDto
    {
        public int carId { get; set; }
        public string bName { get; set; }
        public string coName { get; set; }
        public string Description { get; set; }
    }
}
