using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
            //if (GetById(car.Id) == null)
            //{
            //    _carDal.Add(car);
            //    Console.WriteLine(car.Id + " id'li Kayıt Veritabanına Eklendi.");
            //    return new SuccessResult(Messages.CarAdded);
            //}
            //else
            //{
            //    Console.WriteLine("[Businnes]Olmaz olsun öyle id.");
            //    Car hold = (Car)GetById(car.Id);
            //    Console.WriteLine(car.Id + " bu sıraya yazmaya çalışıyorsun, isteği yazdım bir kenara.");


            //    Console.WriteLine("Ama yine de senin için yeni bir kayıt açabilirim. Açayım mı ? [E/H]");
            //    string nrAnswer = Console.ReadLine().Trim().ToLower();

            //    if (nrAnswer.Equals("e"))
            //    {
            //        int getLastId = _carDal.GetAll().OrderByDescending(c => c.Id).FirstOrDefault().Id;

            //        car.Id = (getLastId + 1);
            //        _carDal.Add(car);
            //        Console.WriteLine(car.Id + " id'li Kayıt Veritabanına Eklendi.");
            //        return new SuccessResult(Messages.CarAdded);
            //    }
            //    else if (nrAnswer.Equals("h"))
            //    {
            //        //Update yazılınca burası yazılacak, update 'de bir ara yazılacak ^^
            //        Console.WriteLine("Peki update yapayım mı ?[E/H]"); //burada eğer parametre olarak verilen car 'ın referansı,
            //                                                            //entity referansı ile .. yani onun id 'si 1 artmış olabilir. Buna dikkat.
            //                                                            //update(hold)}
            //        string updAnswer = Console.ReadLine().Trim().ToLower();
            //        if (updAnswer.Equals("h"))
            //        {
            //            Console.WriteLine("Tamam tamam anladım, aramızda.");
            //        }
            //    }
            //    else { Console.WriteLine("Eksik veya yanlış bir harf tuşladınız, lütfen daha sonra yeniden deneyiniz."); }


            //c => c.Id == c.Id
        //}
        }
            


        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c=>c.Id == id));
        }

        public IDataResult<List<Car>> GetAll()
        {
            // ... iş kuralları
            // örn: if(sisteme giriş yaptıysa ve yetkisi varsa)
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IResult DeleteById(int id)
        {
            Car getCar = GetById(id).Data;
            _carDal.Delete(getCar);
            return new SuccessResult(Messages.CarDeleted);
        }
    }
}
