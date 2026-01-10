class Menus
{
    public static void ShowMainMenu(ItemManagement itemManager, InventoryManagment inventoryManager)
    {

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Hello, Inventoria!\n");
            System.Console.WriteLine("Main Menu");
            System.Console.WriteLine("1. Inventory");
            System.Console.WriteLine("0. Exit \n");

            System.Console.WriteLine("Press a number to select an option");

            var input = System.Console.ReadKey(true).KeyChar; //reads the Menu input from user

            switch (input) //switch statement to handle menu options
            {
                case '1':
                    Menus.ShowInventoryMenu(itemManager, inventoryManager); // Call the inventory menu function
                    break;
                case '0':
                    System.Console.WriteLine("Exiting the program.");
                    return; // Exit the program
                default:
                    Console.Clear();
                    System.Console.WriteLine("Invalid option. Please try again.\nClick any key to continue...");
                    Console.ReadKey(true);
                    break;
            }
        }
    }

    public static void ShowInventoryMenu(ItemManagement itemManager, InventoryManagment inventoryManager)
    {

        while (true)
        {
            Console.Clear();
            System.Console.WriteLine("Inventory Menu\n");
            System.Console.WriteLine("1. View Item");
            System.Console.WriteLine("2. Add Items");
            System.Console.WriteLine("3. Delete Items");
            System.Console.WriteLine("0. Back to Main Menu \n");

            System.Console.WriteLine("Press a number to select an option");

            var input = System.Console.ReadKey(true).KeyChar; //reads the Inventory input from user

            switch (input) //switch statement to handle menu options
            {
                case '1':
                    Console.Clear();
                    System.Console.WriteLine("View Item selected.\n");
                    inventoryManager.DisplayAllItems();

                    Console.ReadKey(true);
                    continue;
                case '2':
                    Console.Clear();
                    System.Console.WriteLine("Add Items selected.\n");


                    inventoryManager.AddItem(itemManager.CreateItem());
                    // Add the created item to the inventory
                    Console.ReadKey(true);
                    continue;
                case '3':
                    Console.Clear();
                    System.Console.WriteLine("Delete Items selected.\n");

                    System.Console.WriteLine("Enter the index of the item to delete: ");
                    int index;

                    try
                    {
                        index = int.Parse(Console.ReadLine() ?? string.Empty);
                    }
                    catch (FormatException)
                    {
                        Console.Clear();
                        System.Console.WriteLine("Invalid input. Please enter a valid integer index.\nClick any key to continue...");
                        Console.ReadKey(true);
                        continue;
                    }

                    inventoryManager.DeleteItem(index);
                    Console.ReadKey(true);
                    continue;
                case '0':
                    System.Console.WriteLine("Going back to the main menu.");
                    return;
                default:
                    Console.Clear();
                    System.Console.WriteLine("Invalid option. Please try again.\nClick any key to continue...");
                    Console.ReadKey(true);
                    break;
            }
        }
    }
}