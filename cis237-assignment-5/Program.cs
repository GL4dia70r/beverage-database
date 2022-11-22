// David Allen
// 11/15/2022 - 11/21/2022
// Assignment 5: Databases
using cis237_assignment_5.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient.Server;
using System;
using System.Linq;

namespace cis237_assignment_5
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set Console Window Size
            Console.BufferHeight = Int16.MaxValue - 1;
            Console.WindowHeight = 140;
            Console.WindowWidth = 120;

            // Create an instance of the UserInterface class
            UserInterface userInterface = new UserInterface();

            BeverageContext drinkContext = new BeverageContext();

            // Create an instance of the BeverageCollection class
            BeverageRepository repositoryCollection = new BeverageRepository();

            // Display the Welcome Message to the user
            userInterface.DisplayWelcomeGreeting();

            // Display the Menu and get the response. Store the response in the choice integer
            // This is the 'primer' run of displaying and getting.
            int choice = userInterface.DisplayMenuAndGetResponse();

            // While the choice is not exit program
            while (choice != 6)
            {
                switch (choice)
                {
                    case 1:
                        // Print Entire List Of Items
                        foreach (Beverage drink in drinkContext.Beverages)
                        {
                            if (!String.IsNullOrWhiteSpace(repositoryCollection.DrinkToString(drink)))
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                // Display all of the items
                                userInterface.DisplayAllItems(repositoryCollection.DrinkToString(drink));
                                Console.WriteLine("-------------------------------");
                                Console.ForegroundColor = ConsoleColor.Gray;
                            }
                            else
                            {
                                // Display error message for all items
                                userInterface.DisplayAllItemsError();
                            }
                        }
                        break;

                    case 2:
                        // Search For An Item
                        string searchQuery = userInterface.GetSearchQuery();
                        Beverage itemToFind = drinkContext.Beverages.Find(searchQuery);
                        if (itemToFind != null)
                        {
                            userInterface.DisplayItemFound(repositoryCollection.DrinkToString(itemToFind));
                        }
                        else
                        {
                            userInterface.DisplayItemFoundError();
                        }
                        break;

                    case 3:
                        // Add A New Item To The List
                        string[] newItemInformation = userInterface.GetNewItemInformation();
                        if (drinkContext.Beverages.Find(newItemInformation[0]) == null)
                        {
                            repositoryCollection.AddNew(
                                newItemInformation[0],
                                newItemInformation[1],
                                newItemInformation[2],
                                decimal.Parse(newItemInformation[3]),
                                (newItemInformation[4] == "True")
                            );
                            userInterface.DisplayAddWineItemSuccess();
                        }
                        else
                        {
                            userInterface.DisplayItemAlreadyExistsError();
                        }
                        break;

                    case 4:
                        // Update A Item To The List
                        string searchIdQuery = userInterface.GetSearchQuery();

                        Beverage itemUpdate = drinkContext.Beverages.Where(drink => drink.Id == searchIdQuery).First();

                        userInterface.DisplayItemFound(repositoryCollection.DrinkToString(itemUpdate));

                        string[] updateInformation = userInterface.UpdateItemInformation();

                        if (searchIdQuery == itemUpdate.Id)
                        {
                            repositoryCollection.Update(
                                updateInformation[0] = searchIdQuery,
                                updateInformation[1],
                                updateInformation[2],
                                decimal.Parse(updateInformation[3]),
                                (updateInformation[4] == "True")
                                );

                            userInterface.DisplayUpdateItemSuccess();
                            Console.WriteLine();
                        }
                        else
                        {
                            userInterface.DisplayUpdateItemError();
                            Console.WriteLine();
                        }
                        break;

                    case 5:
                        // Delete A Item From The List
                        string searchIdToDelete = userInterface.GetSearchQuery();
                        Beverage itemToDelete = drinkContext.Beverages.Find(searchIdToDelete);
                        if (searchIdToDelete != null)
                        {
                            repositoryCollection.Delete(searchIdToDelete);
                            Console.WriteLine();
                        }
                        break;
                }
                // Get the new choice of what to do from the user
                choice = userInterface.DisplayMenuAndGetResponse();
                Console.WriteLine();
            }
        }
    }
}
