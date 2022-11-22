using ConsoleTools;
using KJWTMR_HFT_2022231.Repository;
using KJWTMR_HTF_2022231.Logic;
using KJWTMR_HTF_2022231.Models.Data;
using System.Collections.Generic;
using System;
using System.Linq;

namespace KJWTMR_HFT_2022231.Client
{
    static class Extensions
    {
        public static void ToConsole<T>(this IEnumerable<T> input)
        {
            Console.WriteLine("*** BEGIN ");
            foreach (T item in input)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("*** END ");
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            BeerShopDBContext ctx = new BeerShopDBContext();
            
            BeerRepository beerRepo = new BeerRepository(ctx);
            BrandRepository brandRepo = new BrandRepository(ctx);
            TypeRepository typeRepo = new TypeRepository(ctx);

            BeerLogic beerLogic = new BeerLogic(beerRepo);
            BrandLogic brandLogic = new BrandLogic(brandRepo);
            TypeLogic typeLogic = new TypeLogic(typeRepo);
            ;
            var menu = new ConsoleMenu(args, level: 0)
               .Add("List avg prices by brands", () =>
               {
                   beerLogic.BrandsAvgPrice().ToConsole();             
                   Console.ReadLine();
               })
               .Add("List avg prices by types", () =>
               {
                   beerLogic.TypesAvgPrice().ToConsole();
                   Console.ReadLine();
               })
               .Add("List beer counts by brands", () =>
               {
                   beerLogic.BrandsBeerCount().ToConsole();                  
                   Console.ReadLine();
               })
               .Add("List beer counts by types", () =>
               {
                   beerLogic.TypesBeerCount().ToConsole();
                   Console.ReadLine();
               })
               .Add("List most expensive beers by brands", () =>
               {
                   beerLogic.MostExpensiveBeerPerBrand().ToConsole();
                   Console.ReadLine();
               })
               .Add("Exit", ConsoleMenu.Close);

            menu.Show();          
        }
    }
}
