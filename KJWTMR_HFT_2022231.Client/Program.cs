using ConsoleTools;
using KJWTMR_HTF_2022231.Models;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Numerics;
using Type = KJWTMR_HTF_2022231.Models.Type;
using System.Net;

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
        static RestService rest;
        #region Brand
        static void ListBrand(string entity)
        {
            if (entity == "Brand")
            {
                List<Brand> brands = rest.Get<Brand>("brand");
                foreach (var item in brands)
                {
                    Console.WriteLine(item.Id + ": " + item.Name);
                }
            }
            Console.ReadLine();
        }
        static void CreateBrand(string entity)
        {
            if (entity == "Brand")
            {
                Console.Write("Enter Brand Name: ");
                string name = Console.ReadLine();
                rest.Post(new Brand() { Name = name }, "brand");
            }
        }
        static void DeleteBrand(string entity)
        {
            if (entity == "Brand")
            {
                Console.Write("Enter Brand's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "brand");
            }
        }
        static void UpdateBrand(string entity)
        {
            if (entity == "Brand")
            {
                Console.Write("Enter Brand's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Brand one = rest.Get<Brand>(id, "brand");
                Console.Write($"New name [old: {one.Name}]: ");
                string name = Console.ReadLine();
                one.Name = name;
                rest.Put(one, "brand");
            }
        }
        #endregion

        #region Type
        static void ListType(string entity)
        {
            if (entity == "Type")
            {
                List<Type> types = rest.Get<Type>("type");
                foreach (var item in types)
                {
                    Console.WriteLine(item.Id + ": " + item.TypeName);
                }
            }
            Console.ReadLine();
        }
        static void CreateType(string entity)
        {
            if (entity == "Type")
            {
                Console.Write("Enter Type Name: ");
                string name = Console.ReadLine();
                rest.Post(new Type() { TypeName = name }, "type");
            }
        }
        static void DeleteType(string entity)
        {
            if (entity == "Type")
            {
                Console.Write("Enter Type's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "type");
            }
        }
        static void UpdateType(string entity)
        {
            if (entity == "Type")
            {
                Console.Write("Enter Type's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Type one = rest.Get<Type>(id, "type");
                Console.Write($"New name [old: {one.TypeName}]: ");
                string name = Console.ReadLine();
                one.TypeName = name;
                rest.Put(one, "type");
            }
        }
        #endregion

        #region Beer
        static void ListBeer(string entity)
        {
            if (entity == "Beer")
            {
                List<Beer> beers = rest.Get<Beer>("beer");
                foreach (var item in beers)
                {
                    Console.WriteLine(item.Id + ": BrandID:" + item.BrandId+", TypeId"+item.TypeId+", Price:"+item.Price);
                }
            }
            Console.ReadLine();
        }
        static void CreateBeer(string entity)
        {
            if (entity == "Beer")
            {
                Console.Write("Enter Beer Id: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Enter Beer Brandid: ");
                int Brandid = int.Parse(Console.ReadLine());
                Console.Write("Enter Beer Price: ");
                int Price = int.Parse(Console.ReadLine());
                Console.Write("Enter Beer TypeId: ");
                int TypeId = int.Parse(Console.ReadLine());

                string name = Console.ReadLine();
                rest.Post(new Beer() {  Id=id, BrandId=Brandid, Price=Price, TypeId=TypeId }, "beer");
            }
        }
        static void DeleteBeer(string entity)
        {
            if (entity == "Beer")
            {
                Console.Write("Enter Beer's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "beer");
            }
        }
        static void UpdateBeer(string entity)
        {
            if (entity == "Beer")
            {
                Console.Write("Enter Beer's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Beer one = rest.Get<Beer>(id, "beer");
                Console.Write($"New Brand name [old: {one.Brand.Name}]: ");
                string name = Console.ReadLine();
                one.Brand.Name = name;
                rest.Put(one, "beer");
            }
        }
        #endregion

        static void Stat(string endpoint)
        {
            var result = rest.Get<Brand>($"Stat/{endpoint}");
            //result.ToConsole();
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
            
        static void Main(string[] args)
        {
            
            //ToStringeket kell megcsinálni
            rest = new RestService("http://localhost:52522/","beer");

            var brandSubMenu = new ConsoleMenu(args, level: 1)
              .Add("List", () => ListBrand("Brand"))
              .Add("Create", () => CreateBrand("Brand"))
              .Add("Delete", () => DeleteBrand("Brand"))
              .Add("Update", () => UpdateBrand("Brand"))
              .Add("Exit", ConsoleMenu.Close);

            var typeSubMenu = new ConsoleMenu(args, level: 1)
              .Add("List", () => ListType("Type"))
              .Add("Create", () => CreateType("Type"))
              .Add("Delete", () => DeleteType("Type"))
              .Add("Update", () => UpdateType("Type"))
              .Add("Exit", ConsoleMenu.Close);

            var beerSubMenu = new ConsoleMenu(args, level: 1)
             .Add("List", () => ListBeer("Beer"))
             .Add("Create", () => CreateBeer("Beer"))
             .Add("Delete", () => DeleteBeer("Beer"))
             .Add("Update", () => UpdateBeer("Beer"))
             .Add("Exit", ConsoleMenu.Close);

            var NonCrudsMenu = new ConsoleMenu(args, level: 2)
                   .Add("List avg prices by brands", () =>
                   {
                       Stat("BrandsAvgPrice");
                       Console.ReadLine();
                   })
                   .Add("List avg prices by types", () =>
                   {
                       Stat("TypesAvgPrice");
                       Console.ReadLine();
                   })
                   .Add("List beer counts by brands", () =>
                   {
                       Stat("BrandsBeerCount");
                       Console.ReadLine();
                   })
                   .Add("List beer counts by types", () =>
                   {
                       Stat("TypesBeerCount");
                       Console.ReadLine();
                   })
                   .Add("List most expensive beers by brands", () =>
                   {
                       Stat("MostExpensiveBeerPerBrand");
                       Console.ReadLine();
                   })
                .Add("Exit", ConsoleMenu.Close);
                   
            var menu = new ConsoleMenu(args, level: 0)
               .Add("Brands", () => brandSubMenu.Show())
               .Add("Types", () => typeSubMenu.Show())
               .Add("Beers", () => beerSubMenu.Show())
               .Add("Non-Cruds", () => NonCrudsMenu.Show())
               .Add("Exit", ConsoleMenu.Close);
            menu.Show();

            //var menu = new ConsoleMenu(args, level: 1)
            //   .Add("List avg prices by brands", () =>
            //   {
            //       beerLogic.BrandsAvgPrice().ToConsole();
            //       Console.ReadLine();
            //   })
            //   .Add("List avg prices by types", () =>
            //   {
            //       beerLogic.TypesAvgPrice().ToConsole();
            //       Console.ReadLine();
            //   })
            //   .Add("List beer counts by brands", () =>
            //   {
            //       beerLogic.BrandsBeerCount().ToConsole();
            //       Console.ReadLine();
            //   })
            //   .Add("List beer counts by types", () =>
            //   {
            //       beerLogic.TypesBeerCount().ToConsole();
            //       Console.ReadLine();
            //   })
            //   .Add("List most expensive beers by brands", () =>
            //   {
            //       beerLogic.MostExpensiveBeerPerBrand().ToConsole();
            //       Console.ReadLine();
            //   })
            //   .Add("Exit", ConsoleMenu.Close);


        }
    }
}
