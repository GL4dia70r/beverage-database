// David Allen
// 11/15/2022 - 11/21/2022
// Assignment 5: Databases
using cis237_assignment_5.Models;
using System;

namespace cis237_assignment_5
{
    class UserInterface
    {
        const int MAX_MENU_CHOICES = 6;
        private BeverageContext _context;
        /*
        |----------------------------------------------------------------------
        | Public Methods
        |----------------------------------------------------------------------
        */

        // Display Welcome Greeting
        public void DisplayWelcomeGreeting()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("----------------------------------+");
            Console.WriteLine("     Welcome to the wine program! |");
            Console.WriteLine("----------------------------------+");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
        }

        // Display Menu And Get Response
        public int DisplayMenuAndGetResponse()
        {
            // Declare variable to hold the selection
            string selection;

            // Display menu, and prompt
            this.DisplayMenu();
            Console.WriteLine();
            this.DisplayPrompt();

            // Get the selection they enter
            selection = this.GetSelection();

            // While the response is not valid
            while (!this.VerifySelectionIsValid(selection))
            {
                // Display error message
                this.DisplayErrorMessage();

                // Display the prompt again
                this.DisplayPrompt();

                // Get the selection again
                selection = this.GetSelection();
            }
            // Return the selection casted to an integer
            return Int32.Parse(selection);
        }

        // Get the search query from the user
        public string GetSearchQuery()
        {
            Console.WriteLine();
            Console.WriteLine("What item (ID) would you like to search for?");
            Console.Write("> ");
            return Console.ReadLine();
        }

        public string GetDeleteSearchQuery()
        {
            Console.WriteLine();
            Console.WriteLine("What item (ID) would you like to Delete?");
            Console.Write("> ");
            return Console.ReadLine();
        }

        // Get New Item Information From The User.
        public string[] GetNewItemInformation()
        {
            string id = this.GetStringField("Id");
            string name = this.GetStringField("Name");
            string pack = this.GetStringField("Pack");
            string price = this.GetDecimalField("Price");
            string active = this.GetBoolField("Active");

            return new string[] { id, name, pack, price, active };
        }

        // Get New Item Information From The User.
        public string[] UpdateItemInformation()
        {
            string id = null;
            string name = this.GetUpdateStringField("Name");
            string pack = this.GetUpdateStringField("Pack");
            string price = this.GetUpdateDecimalField("Price");
            string active = this.GetUpdateBoolField("Active");

            return new string[] { id, name, pack, price, active };
        }

        // Display Item Found Success
        public void DisplayItemFound(string itemInformation)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Environment.NewLine + "Item Found!");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(itemInformation + Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.Gray;
            
        }

        // Display Item Found Error
        public void DisplayItemFoundError()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(Environment.NewLine + "A Match was not found" + Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        // Display Add Wine Item Success
        public void DisplayAddWineItemSuccess()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Environment.NewLine + "The Item was successfully added" + Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void DisplayUpdateItemSuccess()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Environment.NewLine + "The Item was successfully updated" + Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void DisplayUpdateItemError()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(Environment.NewLine + "The Item was not successfully updated" + Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        // Display Item Already Exists Error
        public void DisplayItemAlreadyExistsError()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(Environment.NewLine + "An Item With That Id Already Exists" + Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /*
        |----------------------------------------------------------------------
        | Private Methods
        |----------------------------------------------------------------------
        */

        // Display the Menu
        private void DisplayMenu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("What would you like to do?");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("------------------------------------+");
            Console.WriteLine("1. Print The Entire List Of Items   |");
            Console.WriteLine("2. Search For An Item               |");
            Console.WriteLine("3. Add New Item To The List         |");
            Console.WriteLine("4. Update An Item From The List     |");
            Console.WriteLine("5. Delete Item From The List        |");
            Console.WriteLine("6. Exit Program                     |");
            Console.WriteLine("------------------------------------+");
        }

        // Display the Prompt
        private void DisplayPrompt()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Enter Your Choice: ");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        // Display the Error Message
        private void DisplayErrorMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(
                Environment.NewLine + 
                "That is not a valid option. Please make a valid choice" + 
                Environment.NewLine
                );
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        // Get the selection from the user
        private string GetSelection()
        {
            return Console.ReadLine();
        }

        // Verify that a selection from the main menu is valid
        private bool VerifySelectionIsValid(string selection)
        {
            // Declare a returnValue and set it to false
            bool returnValue = false;

            try
            {
                // Parse the selection into a choice variable
                int choice = Int32.Parse(selection);

                // If the choice is between 0 and the maxMenuChoice
                if (choice > 0 && choice <= MAX_MENU_CHOICES)
                {
                    // Set the return value to true
                    returnValue = true;
                }
            }
            // If the selection is not a valid number, this exception will be thrown
            catch (Exception e)
            {
                // Set return value to false even though it should already be false
                returnValue = false;
            }

            // Return the reutrnValue
            return returnValue;
        }

        // Get a valid string field from the console
        private string GetStringField(string fieldName)
        {
            Console.WriteLine();
            Console.WriteLine("What is the new Item's {0}", fieldName);
            string value = null;
            bool valid = false;
            while (!valid)
            {
                value = Console.ReadLine();
                if (!String.IsNullOrWhiteSpace(value))
                {
                    valid = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You must provide a(n) {0}.", fieldName);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine();
                    Console.WriteLine("What is the new Item's {0}", fieldName);
                    Console.Write("> ");
                }
            }
            return value;
        }

        private string GetUpdateStringField(string fieldName)
        {
            Console.WriteLine();
            Console.WriteLine("What is the Item's new {0}", fieldName);
            string value = null;
            bool valid = false;
            while (!valid)
            {
                value = Console.ReadLine();
                if (!String.IsNullOrWhiteSpace(value))
                {
                    valid = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You must provide a {0}.", fieldName);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine();
                    Console.WriteLine("What is the new Item's {0}", fieldName);
                    Console.Write("> ");
                }
            }
            return value;
        }

        // Get a valid decimal field from the console
        private string GetDecimalField(string fieldName)
        {
            Console.WriteLine();
            Console.WriteLine("What is the new Item's {0}", fieldName);
            decimal value = 0;
            bool valid = false;
            while (!valid)
            {
                try
                {
                    value = decimal.Parse(Console.ReadLine());
                    valid = true;
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That is not a valid {0}. Please enter a valid {0}.", fieldName);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine();
                    Console.WriteLine("What is the new Item's {0}", fieldName);
                    Console.Write("> ");
                }
            }

            return value.ToString();
        }

        private string GetUpdateDecimalField(string fieldName)
        {
            Console.WriteLine();
            Console.WriteLine("What is the Item's new {0}", fieldName);
            decimal value = 0;
            bool valid = false;
            while (!valid)
            {
                try
                {
                    value = decimal.Parse(Console.ReadLine());
                    valid = true;
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That is not a valid {0}. Please enter a valid {0}.", fieldName);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine();
                    Console.WriteLine("What is the new Item's {0}", fieldName);
                    Console.Write("> ");
                }
            }

            return value.ToString();
        }

        // Get a valid bool field from the console
        private string GetBoolField(string fieldName)
        {
            Console.WriteLine();
            Console.WriteLine("Should the new Item be {0} (y/n)", fieldName);
            string input = null;
            bool value = false;
            bool valid = false;
            while (!valid)
            {
                input = Console.ReadLine();
                if (input.ToLower() == "y" || input.ToLower() == "n")
                {
                    valid = true;
                    value = (input.ToLower() == "y");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That is not a valid Entry.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine();
                    Console.WriteLine("Should the Item be {0} (y/n)", fieldName);
                    Console.Write("> ");
                }
            }

            return value.ToString();
        }

        private string GetUpdateBoolField(string fieldName)
        {
            Console.WriteLine();
            Console.WriteLine("Should the Item be newly {0} (y/n)", fieldName);
            string input = null;
            bool value = false;
            bool valid = false;
            while (!valid)
            {
                input = Console.ReadLine();
                if (input.ToLower() == "y" || input.ToLower() == "n")
                {
                    valid = true;
                    value = (input.ToLower() == "y");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That is not a valid Entry.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine();
                    Console.WriteLine("Should the Item be {0} (y/n)", fieldName);
                    Console.Write("> ");
                }
            }

            return value.ToString();
        }
    }
}
