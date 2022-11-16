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
        private Beverage[] beverages;
        private int beverageLength;

        // Constructor. Must pass the size of the collection.
        public BeverageRepository(int size)
        {
            this.beverages = new Beverage[size];
            this.beverageLength = 0;
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
            // Add a new Beverage to the collection. Increase the Length variable.
            beverages[beverageLength] = new Beverage(id, name, pack, price, active);
            beverageLength++;
            //newBeverages.Id = id;
            //newBeverages.Name = name;
            //newBeverages.Pack = pack;
            //newBeverages.Price = price;
            //newBeverages.Active = active;

            //try
            //{
            //    context.Beverages.Add(newBeverages);

            //    context.SaveChanges();
            //}
            //catch (DbUpdateException e)
            //{
            //    context.Beverages.Remove(newBeverages);

            //    Console.WriteLine("Unable to add the recording... \n May already exist in current list.");
            //}
        }

        public void Update(
            string id,
            string name,
            string pack,
            decimal price,
            bool active
        )
        {
            beverages[beverageLength] = context.Beverages.Find(id);

            foreach (Beverage beverage in beverages)
            {
                if (beverage.Id == id)
                {
                    beverage.Id = id;
                    beverage.Name = name;
                    beverage.Pack = pack;
                    beverage.Price = price;
                    beverage.Active = active;

                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("ID does not exist...");
                }
            }



        }

        public void Delete()
        {

        }

        // ToString override method to convert the collection to a string
        public override string ToString()
        {
            // Declare a return string
            string returnString = "";

            // Loop through all of the beverages
            foreach (Beverage beverage in beverages)
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

        // Find an item by it's Id
        public string Find(string id)
        {
            // Declare return string for the possible found item
            string returnString = null;

            // For each Beverage in beverages
            foreach (Beverage beverage in beverages)
            {
                // If the beverage is not null
                if (beverage != null)
                {
                    // If the beverage Id is the same as the search Id
                    if (beverage.Id == id)
                    {
                        // Set the return string to the result
                        // of the beverage's ToString method.
                        returnString = beverage.ToString();
                    }
                }
            }
            // Return the returnString
            return returnString;
        }
    }
}
