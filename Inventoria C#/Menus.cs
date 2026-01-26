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
            System.Console.WriteLine("4. Update Items");
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


                    inventoryManager.AddInstance(itemManager.CreateItem());
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
                        index = int.Parse(Console.ReadLine() ?? string.Empty) - 1;

                        if (index < 0)
                        {
                            Console.Clear();
                            System.Console.WriteLine("Index cannot be less than 1.\nClick any key to continue...");
                            Console.ReadKey(true);
                            continue;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.Clear();
                        System.Console.WriteLine("Invalid input. Please enter a valid integer.\nClick any key to continue...");
                        Console.ReadKey(true);
                        continue;
                    }



                    inventoryManager.DeleteInstance(index);
                    Console.ReadKey(true);
                    continue;
                case '4':

                    Console.Clear();

                    // System.Console.WriteLine("UPDATE UNDER CONSTRUCTION - Feature coming soon!\n");
                    // Console.ReadKey(true);
                    // continue;

                    Console.WriteLine("Update Items selected.\n");
                    System.Console.WriteLine("Enter the index of the item to update: ");
                    int updateIndex;

                    try
                    {
                        updateIndex = int.Parse(Console.ReadLine() ?? string.Empty) - 1;

                        if (updateIndex < 0)
                        {
                            Console.Clear();
                            System.Console.WriteLine("Index cannot be less than 1.\nClick any key to continue...");
                            Console.ReadKey(true);
                            continue;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.Clear();
                        System.Console.WriteLine("Invalid input. Please enter a valid integer index.\nClick any key to continue...");
                        Console.ReadKey(true);
                        continue;
                    }

                    // Create the updated item and replace the existing one
                    while (true)
                    {
                        inventoryManager.UpdateInstance(updateIndex, itemManager.UpdateItem(updateIndex));

                        Console.WriteLine("Would you like to update another item? (y/n): ");
                        var choice = Console.ReadKey(true).KeyChar;
                        if (choice == 'y' || choice == 'Y')
                        {
                            continue;
                        }
                        else if (choice == 'n' || choice == 'N')
                        {
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            System.Console.WriteLine("Invalid option. Returning to Inventory Menu.\nClick any key to continue...");
                            Console.ReadKey(true);
                            break;
                        }
                    }


                    continue;

                case '0':
                    Console.WriteLine("Going back to the main menu.");
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