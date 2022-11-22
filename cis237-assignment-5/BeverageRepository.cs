// David Allen
// 11/15/2022 - 11/21/2022
// Assignment 5: Databases
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using cis237_assignment_5.Models;

namespace cis237_assignment_5
{
    class BeverageRepository : IBeverageRepository
    {
        // Private Variables
        private BeverageContext context;
        private Beverage beverages;

        // Constructor. Must pass the size of the collection.
        public BeverageRepository()
        {
            this.context = new BeverageContext();
        }

        // Add a new item to the collection
        public void AddNew(
            string id,
            string name,
            string pack,
            decimal price,
            bool active
        )
        {
            beverages = new Beverage(id, name, pack, price, active);

            try
            {
                // Add a new Beverage to the collection. Increase the Length variable.
                context.Beverages.Add(beverages);

                context.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                context.Beverages.Remove(beverages);

                Console.WriteLine("Unable to add the record. Primary key may already be in use." + e);
            }
        }

        public void Update(
            string id,
            string name,
            string pack,
            decimal price,
            bool active
        )
        {
            Beverage _updateDrink = context.Beverages.Find(id);

            if (_updateDrink.Id == id)
            {
                try
                {
                    _updateDrink.Id = id;
                    _updateDrink.Name = name;
                    _updateDrink.Pack = pack;
                    _updateDrink.Price = price;
                    _updateDrink.Active = active;

                    context.Beverages.Update(_updateDrink);

                    context.SaveChanges();
                }
                catch (DbUpdateException e)
                {
                    Console.WriteLine("Could not update.." +
                        Environment.NewLine +
                        e);
                }
            }
            else
            {
                Console.WriteLine("ID does not exist...");
            }

        }

        public void Delete(string id)
        {
            Beverage _drinkToDelete = context.Beverages.Find(id);

            if (_drinkToDelete != null)
            {
                try
                {
                    context.Beverages.Remove(_drinkToDelete);

                    context.SaveChanges();

                    Console.WriteLine();
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("The drink was deleted from the database.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine();
                }
                catch (DbUpdateException e)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(
                        "Unforturnatley, the item could not be deleted..." +
                        Environment.NewLine + e.Message);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The item does not exist in the current list...");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine();
            }
        }

        // ToString override method to convert the collection to a string
        public string DrinkToString(Beverage drink)
        {
            return      $"ID: {drink.Id}" +
                        Environment.NewLine +

                        $"NAME: {drink.Name}" +
                        Environment.NewLine +

                        $"PACK: {drink.Pack}" +
                        Environment.NewLine +

                        $"PRICE: {drink.Price.ToString("C")}" +
                        Environment.NewLine +

                        $"ACTIVE: {drink.Active}" +
                        Environment.NewLine;
        }

        // Find an item by it's Id
        public void Find(string fieldname) // Not used, overthinking this one for some reason...
        {
            context.Beverages.Find(fieldname);
        }
    }
}
