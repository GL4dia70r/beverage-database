// David Allen
// 11/15/2022 - 11/21/2022
// Assignment 5: Databases
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using cis237_assignment_5.Models;
using System.IO;

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

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(
                    Environment.NewLine + 
                    "Unable to add the record. Primary key may already be in use." + 
                    Environment.NewLine +
                    e
            );
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        // Updates current item in the collection
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
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(
                        Environment.NewLine + 
                        "Could not update.." +
                        Environment.NewLine +
                        e
                );
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(
                    Environment.NewLine + 
                    "ID does not exist..." + 
                    Environment.NewLine
            );
                Console.ForegroundColor = ConsoleColor.Gray;
            }

        }

        // Deletes item from the current collection
        public void Delete(string id)
        {
            Beverage _drinkToDelete = context.Beverages.Find(id);

            if (_drinkToDelete != null)
            {
                try
                {
                    context.Beverages.Remove(_drinkToDelete);

                    context.SaveChanges();

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(
                        Environment.NewLine + 
                        "The drink was deleted from the database." + 
                        Environment.NewLine
                );
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                catch (DbUpdateException e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(
                        Environment.NewLine +
                        "Unforturnatley, the item could not be deleted..." +
                        Environment.NewLine + e.Message
                );
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(
                    Environment.NewLine + 
                    "The item either does not exist in the current list or entry was blank..." +
                    Environment.NewLine +
                    Environment.NewLine +
                    "Please enter a valid ID to update (try printing list first)." +
                    Environment.NewLine
            );
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        // Prints collection
        public void PrintList()
        {
            foreach (Beverage drink in context.Beverages)
            {
                if (!String.IsNullOrWhiteSpace(DrinkToString(drink)))
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    // Display all of the items
                    Console.WriteLine(DrinkToString(drink));
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("--------------------------------------------------+" + Environment.NewLine);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    // Display error message for all items
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(
                        Environment.NewLine + 
                        "There are no items to print..." + 
                        Environment.NewLine
                );
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
        }

        // ToString override method to convert the collection to a string
        public override string ToString()
        {
            // Declare a return string
            string returnString = "";

            // Loop through all of the beverages
            foreach (Beverage beverage in context.Beverages)
            {
                // If the current beverage is not null, concat it to the return string
                if (beverage != null)
                {
                    returnString += beverage.ToString() + Environment.NewLine;
                }
            }
            // Return the return string
            return returnString;
        }

        // Returns beverages in string format
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
        public Beverage Find(string id) // Not used, overthinking this one for some reason...
        {
            Beverage drinkId = context.Beverages.Find(id);

            return drinkId;
        }
    }
}
