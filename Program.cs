using Mission3;

Console.WriteLine("Welcome to your food bank system!");
// Create the global list of food items to store in the bank
List<FoodItem> foodItems = new List<FoodItem>();
Main();


void Main()
{
    Console.WriteLine("How would you like to proceed? \n " +
                      "1 - Add a Food Item \n " +
                      "2 - Delete a Food Item \n " +
                      "3 - Print list of all current items \n " +
                      "4 - Exit \n");
    Console.WriteLine("Enter a number: ");

    
    // get the number that corresponds with the action the user wants
    string sInput = Console.ReadLine();
    //try to parse into an integer and if not, give an error message
    bool result = int.TryParse(sInput, out int determiner);
    if (result)
    {
        // Add a food item
        if (determiner == 1)
        {
            FoodItem item = FoodItem.addItem(); // create the food item using the addItem method
            foodItems.Add(item); // add that food item to the global list
            Console.WriteLine($"Successfully added {item.Quantity} {item.Name} to your {item.Category} inventory \n");
            Main();

        }
        // Delete a food item
        else if (determiner == 2)
        {
            // Print the list so the user can select from there.  
            List<FoodItem> orderedList = FoodItem.PrintFoodItems(foodItems);
            Console.WriteLine("Which food item would you like to delete? (Enter the number)");
            // Get the input from the user about which item to delete
            string sDelete = Console.ReadLine();
            int intDelete = int.Parse(sDelete);
            // save the item in a temporary variable to be able to print the successful deletion message.
            FoodItem deletedFood = orderedList[intDelete - 1]; 
            // Remove the item from the global list
            orderedList.Remove(orderedList[intDelete - 1]);
            Console.WriteLine($"Successfully deleted {deletedFood.Quantity} {deletedFood.Name} from you inventory\n");
            // Print again so user can see current inventory
            FoodItem.PrintFoodItems(orderedList);
            Main();


        }
        // Print list of current items
        else if (determiner == 3)
        {
            FoodItem.PrintFoodItems(foodItems);
            Main();
        }
        // Goodbye message
        else if (determiner == 4)
        {
            Console.WriteLine("Thank you using your food bank system! Goodbye!");
        }
    }
    // Error message if input is invalid
    else
    {
        Console.WriteLine("Invalid input, please try again.\n");
        Main();
    }
}