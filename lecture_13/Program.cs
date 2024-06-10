namespace lecture_13
{
    public class FoodItem
    {
        // Fields
        public string Name;
        public double Qty;
        public double Calories;

        // Parameterized Constructor
        public FoodItem(string name, double qty, double calories)
        {
            Name = name;
            Qty = qty;
            Calories = calories;
        }

        // Default Constructor
        public FoodItem()
        {
            Name = "No Name";
            Qty = 0;
            Calories = 0;
        }

        // Method to calculate total calories
        public double TotalCalories()
        {
            return Qty * Calories;
        }

        // Method to display food information
        public string DisplayFoodInformation()
        {
            return $"Name: {Name}, Quantity: {Qty}, Calories per unit: {Calories}, Total Calories: {TotalCalories()}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            FoodItem[] foodItems = new FoodItem[5];
            int foodCount = 0;

            // Preload initial data
            PreloadFoodItems(foodItems, ref foodCount);

            while (true)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Add a New Food Item");
                Console.WriteLine("2. Double the Size of the Array");
                Console.WriteLine("3. Display All Food Items");
                Console.WriteLine("4. Exit");
                Console.WriteLine("Enter your choice: ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        try
                        {
                            AddNewFoodItem(foodItems, ref foodCount);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "2":
                        DoubleArraySize(ref foodItems);
                        Console.WriteLine("Array size doubled successfully.");
                        break;
                    case "3":
                        DisplayAllFoodItems(foodItems, foodCount);
                        break;
                    case "4":
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine(); // Add an additional blank line for better readability
            }
        }

        static void PreloadFoodItems(FoodItem[] foodItems, ref int foodCount)
        {
            foodItems[foodCount++] = new FoodItem("Apple", 7, 95);
            foodItems[foodCount++] = new FoodItem("Banana", 4, 105);
            foodItems[foodCount++] = new FoodItem("Chicken Breast", 8, 165);
            foodItems[foodCount++] = new FoodItem("Broccoli", 5, 55);
            foodItems[foodCount++] = new FoodItem("Almonds", 7, 70);
        }

        static void AddNewFoodItem(FoodItem[] foodItems, ref int foodCount)
        {
            if (foodCount >= foodItems.Length)
            {
                throw new InvalidOperationException("No more space to add new food items. Please double the size of the array first.");
            }

            Console.WriteLine("Enter the name: ");
            string? name = Console.ReadLine();

            Console.WriteLine("Enter the quantity: ");
            double qty = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter the calories per unit: ");
            double calories = double.Parse(Console.ReadLine());

            foodItems[foodCount++] = new FoodItem(name, qty, calories);
            Console.WriteLine("Food item added successfully.");
        }

        static void DoubleArraySize(ref FoodItem[] foodItems)
        {
            FoodItem[] newFoodItems = new FoodItem[foodItems.Length * 2];
            Array.Copy(foodItems, newFoodItems, foodItems.Length);
            foodItems = newFoodItems;
        }

        static void DisplayAllFoodItems(FoodItem[] foodItems, int foodCount)
        {
            for (int i = 0; i < foodCount; i++)
            {
                Console.WriteLine(foodItems[i].DisplayFoodInformation());
            }
        }
    }
}


