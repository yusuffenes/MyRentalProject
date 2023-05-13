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
        BrandMethod();
    }

    private static void RentalMethod()
    {
        IRentalService rental = new RentalManager(new EfRentalDal());
        var result = rental.GetAll();
        foreach (var item in result.Data)
        {
            Console.WriteLine(item.CarId);
        }
    }

    private static void ColorMethod1()
    {
        IColorService color = new ColorManager(new EfColorDal());
        var result = color.GetColorList();
        foreach (var itemUser in result.Data)
        {
            Console.WriteLine(itemUser.Name);
        }
    }

    private static void CarAddMethod()
    {
        Car car1 = new Car
            { BrandId = 2, ColorId = 2, DailyPrice = 129, Description = "Yusuf", Id = 12, ModelYear = 2009 };
        ICarService car = new CarManager(new EfCarDal());
        var result = car.Add(car1).Message;
        Console.WriteLine();
    }

    private static void ColorMethod()
    {
        IColorService color = new ColorManager(new EfColorDal());
        foreach (var itemColor in color.GetColorList().Data)
        {
            Console.WriteLine(itemColor.Name);
        }
    }

    private static void BrandMethod()
    {

        IBrandService brandService = new BrandManager(new EfBrandDal());

        var result = brandService.GetBrands();
        foreach (var item in brandService.GetBrands().Data)
        {
            Console.WriteLine(item.Name);
            Console.WriteLine(result.IsSuccess);
        }
    }

    private static void CarMethod()
    {
        CarManager carManager = new CarManager(new EfCarDal());
        var result = carManager.GetCarDetail();
       
        if ( result.IsSuccess == true)
        {
            foreach (var item in carManager.GetCarDetail().Data)
            {
                Console.WriteLine(item.CarId );
                Console.WriteLine(result.Message);
            }
        }
        
        
    }                 
}