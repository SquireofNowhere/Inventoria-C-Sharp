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
            System.Console.WriteLine("1. View Inventory");
            System.Console.WriteLine("2. Add Items");
            System.Console.WriteLine("3. Delete Items");
            System.Console.WriteLine("4. Edit Items");
            System.Console.WriteLine("0. Back to Main Menu \n");

            System.Console.WriteLine("Press a number to select an option");

            var input = System.Console.ReadKey(true).KeyChar; //reads the Inventory input from user

            switch (input) //switch statement to handle menu options
            {
                case '1': //View Item
                    Console.Clear();
                    System.Console.WriteLine("View Inventory selected.\n");
                    inventoryManager.DisplayAllItems();

                    Console.ReadKey(true);
                    continue;

                case '2': //Add Item
                    Console.Clear();
                    System.Console.WriteLine("Add Items selected.\n");


                    inventoryManager.AddInstance(itemManager.CreateItem());
                    // Add the created item to the inventory
                    Console.ReadKey(true);
                    continue;

                case '3': //Delete Item
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

                case '4': //Edit Item

                    Console.Clear();

                    Console.WriteLine("Update Items selected.\n");
                    System.Console.WriteLine("Enter the index of the item to update: ");
                    int EditIndex;

                    try
                    {
                        EditIndex = int.Parse(Console.ReadLine() ?? string.Empty) - 1;
                        if (EditIndex < 0)
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

                    Dictionary<string, object?> updatedInstance = inventoryManager.FetchInventoryItem(EditIndex);
                    Console.Clear();
                    Console.WriteLine("-------------------");
                    Console.WriteLine($"Item Index: {EditIndex + 1}");
                    itemManager.DisplayItem(updatedInstance);
                    Console.WriteLine("-------------------\n");

                    Menus.ShowEditMenu(itemManager, inventoryManager, EditIndex);


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

    public static void ShowEditMenu(ItemManagement itemManager, InventoryManagment inventoryManager, int EditIndex)
    {
        // Future implementation for a dedicated update menu if needed



        System.Console.WriteLine("1. Edit Column");
        System.Console.WriteLine("2. Delete Column");
        System.Console.WriteLine("3. Add Column");
        System.Console.WriteLine("0. Back to Inventory Menu \n");

        System.Console.WriteLine("Press a number to select an option");

        var input = System.Console.ReadKey(true).KeyChar; //reads the Inventory input from user

        switch (input) //switch statement to handle menu options
        {
            case '1':
                Console.Clear();
                System.Console.WriteLine("Edit Column selected.\n");

                System.Console.WriteLine("1. Edit Column Name");
                System.Console.WriteLine("2. Edit Column Value");
                System.Console.WriteLine("0. Back to Edit Menu \n");

                System.Console.WriteLine("Press a number to select an option");

                var EditColumninput = System.Console.ReadKey(true).KeyChar; //reads the Inventory input from user

                switch (EditColumninput) //switch statement to handle menu options
                {
                    case '1':
                        Console.Clear();
                        System.Console.WriteLine("Edit Column Name selected.\n");
                        Console.ReadKey(true);
                        break;

                    case '2':
                        Console.Clear();
                        System.Console.WriteLine("Edit Column Value selected.\n");

                        while (true)
                        {
                            inventoryManager.UpdateInstance(EditIndex, itemManager.EditColumn(EditIndex));

                            Console.WriteLine("Would you like to edit another Column? (y/n): ");
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

                        break;

                    case '0':
                        Console.WriteLine("Going back to the Edit menu.");
                        return;

                    default:
                        Console.Clear();
                        System.Console.WriteLine("Invalid option. Please try again.\nClick any key to continue...");
                        Console.ReadKey(true);
                        break;
                }



                break;

            case '2':
                Console.Clear();
                System.Console.WriteLine("Delete Column selected.\n");
                // Future implementation for deleting a column
                Console.ReadKey(true);
                break;

            case '3':
                Console.Clear();
                System.Console.WriteLine("Add Column selected.\n");
                // Future implementation for adding a column
                Console.ReadKey(true);
                break;

            case '0':
                Console.WriteLine("Going back to the Inventory menu.");
                return;

            default:
                Console.Clear();
                System.Console.WriteLine("Invalid option. Please try again.\nClick any key to continue...");
                Console.ReadKey(true);
                break;
        }
    }
}