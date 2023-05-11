using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Channels;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

internal class Program
{
    private static void Main(string[] args)
    {
       CarMethod();
    }

    private static void CarAddMethod()
    {
        Car car1 = new Car
            { BrandId = 2, ColorId = 2, DailyPrice = 129, Descriptions = "Yusuf", Id = 12, ModelYear = 2009 };
        ICarService car = new CarManager(new EfCarDal());
        var result = car.Add(car1).Message;
        Console.WriteLine();
    }

    private static void ColorMethod()
    {
        IColorService color = new ColorManager(new EfColorDal());
        foreach (var itemColor in color.GetColorList().Data)
        {
            Console.WriteLine(itemColor.ColorName);
        }
    }

    private static void BrandMethod()
    {
        IBrandService brandService = new BrandManager(new EfBrandDal());
        foreach (var item in brandService.GetAllByBrand(2).Data)
        {
            Console.WriteLine(item.BrandName);
            Console.WriteLine(brandService.GetAllByBrand(2).IsSuccess);
        }
    }

    private static void CarMethod()
    {
        CarManager carManager = new CarManager(new EfCarDal());
        var result = carManager.GetCarDetail();
        var result2 = carManager.GetAll().Message;
        if ( result.IsSuccess == false)
        {
            foreach (var item in carManager.GetCarDetail().Data)
            {
                Console.WriteLine(item.ColorName + "  / " + "  Günlük Kiralık Fiyatı : " + +item.DailyPrice + "  / " + "  Model Yılı :  : " + item.BrandName + " / ");
                Console.WriteLine(result.Data);
            }
        }
        else
        {
            Console.WriteLine("1");
            Console.WriteLine(result.Message);
        }
        
    }                 
}