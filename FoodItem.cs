using System.Runtime.InteropServices.JavaScript;
using System.Linq;

namespace Mission3;

public class FoodItem
{
    public string Name {get; set;}
    public string Category {get; set;}
    public int Quantity {get; set;}
    public DateTime Date {get; set;}
    
    public FoodItem(string name, string category, int quantity, DateTime xDate)
    // Constructor for the FoodItem Objects, gives them their attributes
    {
        Name = name;
        Category = category;
        Quantity = quantity;
        Date = xDate;
    }

    public static FoodItem addItem()
    {
        // Get all user input and create a new FoodItem object
        Console.WriteLine("Answer the questions to add new item");
        Console.WriteLine("What is the name of the food item?");
        string name = Console.ReadLine();
        Console.WriteLine("In what category is the food item?");
        string category = "";
        category = Console.ReadLine();
        Console.WriteLine("What is the quantity of the food item?");
        string sQuant = Console.ReadLine();
        int quantity = int.Parse(sQuant);
        Console.WriteLine("When does this item expire? (MM/DD/YYYY)");
        string sDate = Console.ReadLine();
        DateTime xDate = DateTime.Parse(sDate);
        
        FoodItem food = new FoodItem(name, category, quantity, xDate);
        
        return food;
    }

    public static List<FoodItem> PrintFoodItems(List<FoodItem> foodItems)
    {
        // sort the food so the soonest expiring comes first
        var orderedFoodList = foodItems.OrderBy(item => item.Date).ToList();
        DateTime currentDate = DateTime.Now;
        Console.WriteLine("Current Inventory (Soonest expiring listed first):");
        // loop through the list and print out the soonest expiring foods
        for (int i = 0; i < orderedFoodList.Count; i++)
        {
            int daysRemaining = orderedFoodList[i].Date.Subtract(currentDate).Days;
            // if the food is expired, tell them how long ago. 
            if (daysRemaining < 0)
            {
                Console.WriteLine(
                    $"{i + 1} - Expired {Math.Abs(daysRemaining)} Days ago on {orderedFoodList[i].Date.ToShortDateString()} " +
                    $"- {orderedFoodList[i].Name}: {orderedFoodList[i].Quantity}");
            }
            // tell the user how many days until it expires. 
            else if (daysRemaining > 0)
            {
                Console.WriteLine(
                    $"{i + 1} - Expires in {daysRemaining} Days on {orderedFoodList[i].Date.ToShortDateString()} " +
                    $"- {orderedFoodList[i].Name}: {orderedFoodList[i].Quantity}");
            }
            // if daysRemaining is zero, item expires today
            else
            {
                Console.WriteLine(
                    $"{i + 1} - Expires today, {orderedFoodList[i].Date.ToShortDateString()} " +
                    $"- {orderedFoodList[i].Name}: {orderedFoodList[i].Quantity}");
            }
        }
        return orderedFoodList;
    }
}