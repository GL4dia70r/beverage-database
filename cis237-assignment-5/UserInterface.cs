// David Allen
// 11/15/2022 - 11/21/2022
// Assignment 5: Databases
using System;

namespace cis237_assignment_5
{
    class UserInterface
    {
        const int MAX_MENU_CHOICES = 6;

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
            Console.WriteLine("What would you like to search for?");
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

        // Display Import Success
        public void DisplayImportSuccess()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Wine List Has Been Imported Successfully");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
        }

        // Display Import Error
        public void DisplayImportError()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("There was an error importing the CSV");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
        }

        // Display All Items
        public void DisplayAllItems(string allItemsOutput)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Printing List");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(allItemsOutput);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
        }

        // Display All Items Error
        public void DisplayAllItemsError()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("There are no items in the list to print");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
        }

        // Display Item Found Success
        public void DisplayItemFound(string itemInformation)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Item Found!");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(itemInformation);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            
        }

        // Display Item Found Error
        public void DisplayItemFoundError()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("A Match was not found");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
        }

        // Display Add Wine Item Success
        public void DisplayAddWineItemSuccess()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The Item was successfully added");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
        }

        public void DisplayUpdateItemSuccess()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The Item was successfully updated");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
        }

        public void DisplayUpdateItemError()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The Item was not successfully updated");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
        }

        // Display Item Already Exists Error
        public void DisplayItemAlreadyExistsError()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("An Item With That Id Already Exists");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
        }

        /*
        |----------------------------------------------------------------------
        | Private Methods
        |----------------------------------------------------------------------
        */

        // Display the Menu
        private void DisplayMenu()
        {
            Console.WriteLine();
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
            Console.WriteLine();
        }

        // Display the Prompt
        private void DisplayPrompt()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Enter Your Choice: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
        }

        // Display the Error Message
        private void DisplayErrorMessage()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("That is not a valid option. Please make a valid choice");
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
                    Console.WriteLine("You must provide a value.");
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
                    Console.WriteLine("You must provide a value.");
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
                    Console.WriteLine("That is not a valid Decimal. Please enter a valid Decimal.");
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
                    Console.WriteLine("That is not a valid Decimal. Please enter a valid Decimal.");
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
