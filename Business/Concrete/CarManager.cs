using Business.Abstract;
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

        public void Add(Car car)
        {

            if (GetById(car.Id) == null)
            {
                _carDal.Add(car);
                Console.WriteLine(car.Id + " id'li Kayıt Veritabanına Eklendi.");
            }
            else
            {
                Console.WriteLine("[Businnes]Olmaz olsun öyle id.");
                Car hold = GetById(car.Id);
                Console.WriteLine(car.Id + " bu sıraya yazmaya çalışıyorsun, isteği yazdım bir kenara.");


                Console.WriteLine("Ama yine de senin için yeni bir kayıt açabilirim. Açayım mı ? [E/H]");
                string nrAnswer = Console.ReadLine().Trim().ToLower();

                if (nrAnswer.Equals("e"))
                {
                    int getLastId = _carDal.GetAll().OrderByDescending(c => c.Id).FirstOrDefault().Id;
                    
                    car.Id = (getLastId + 1);
                    _carDal.Add(car);
                    Console.WriteLine(car.Id + " id'li Kayıt Veritabanına Eklendi.");
                }
                else if (nrAnswer.Equals("h"))
                {
                    //Update yazılınca burası yazılacak, update 'de bir ara yazılacak ^^
                    Console.WriteLine("Peki update yapayım mı ?[E/H]"); //burada eğer parametre olarak verilen car 'ın referansı,
                                                                        //entity referansı ile .. yani onun id 'si 1 artmış olabilir. Buna dikkat.
                                                                        //update(hold)}
                    string updAnswer = Console.ReadLine().Trim().ToLower();
                    if (updAnswer.Equals("h"))
                    {
                        Console.WriteLine("Tamam tamam anladım, aramızda.");
                    }
                }
                else { Console.WriteLine("Eksik veya yanlış bir harf tuşladınız, lütfen daha sonra yeniden deneyiniz."); }


                    //c => c.Id == c.Id
                }
            }


        public Car GetById(int id)
        {
            return _carDal.Get(c=>c.Id == id);
        }

        public List<Car> GetAll()
        {
            // ... iş kuralları
            // örn: if(sisteme giriş yaptıysa ve yetkisi varsa)
            return _carDal.GetAll();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }

        //public Car GetById(int carId)
        //{
        //    Car carReached = null;

        //    if (carId > 0) { 
        //        carReached = _carDal.GetById(carId);
        //        if(carReached != null) { 
        //            return carReached;
        //        }else { Console.WriteLine("Obje dönmedi."); }
        //    }else { Console.WriteLine("CarID, 0'dan büyük olmalıdır."); }

        //    return carReached;
        //}

        //public void Add(Car car)
        //{
        //    Dictionary<string, bool> addCarRules = new Dictionary<string, bool> {
        //        { "carId", car.Id > 0 && _carDal.GetById(car.Id) == null },
        //        { "brandId", car.BrandId > 0 },
        //        { "colorId", car.ColorId > 0 },
        //        { "dPrice", car.DailyPrice > 0 },
        //        { "mYear", car.ModelYear > 1500 && car.ModelYear <= (DateTime.Today.Year+1) },
        //        { "description", car.Description.Length > 0 && car.Description.Length < 500}
        //    };


        //    bool checkedRulesStatement = false;
        //    foreach (var ruleValue in addCarRules.Values)
        //    {
        //        if (ruleValue)
        //        {
        //            checkedRulesStatement = ruleValue;
        //        }
        //        else { checkedRulesStatement = false;  break; }
        //        //checkedRulesStatement = rule ? (true) : (false);
        //        // if (addCarRules.Values.Any(val => val == true && val != false)) { _carDal.Add(car);
        //        // else { Console.WriteLine("Yapılan Ekleme İşlemi İş Kurallarına Uymamaktadır."); 
        //    }

        //    if (checkedRulesStatement) { 
        //        _carDal.Add(car); 
        //    } else { Console.WriteLine("Yapılan Ekleme İşlemi İş Kurallarına Uymamaktadır."); }
        //}

        //public void Delete(Car car)
        //{
        //    try { 
        //        bool carReached = _carDal.GetAll().Any(c => c.Id == car.Id);
        //        if(carReached) { 
        //        _carDal.Delete(car);
        //        }
        //    }catch(Exception e)
        //    {
        //        Console.WriteLine("We need to talking about delete process.");
        //        Console.WriteLine("{0}",e);
        //    }
        //}

        //public void Update(Car car)
        //{
        //    try
        //    {
        //        bool carReached = _carDal.GetAll().Any(c => c.Id == car.Id);
        //        if (carReached) { _carDal.Update(car); }
        //        else { Console.WriteLine("Öyle bir araba yok ki, hiç olmadı."); }

        //    }
        //    catch (Exception e)
        //    {

        //        throw e;
        //    }
        //}
    }
}
