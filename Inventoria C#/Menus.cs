class Menus
{
    public static void ShowMainMenu()
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
            Menus.ShowInventoryMenu(); // Call the inventory menu function
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

    public static void ShowInventoryMenu()
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
            System.Console.WriteLine("View Item selected.");
            Console.ReadKey(true);
            continue;
        case '2':
            Console.Clear();
            System.Console.WriteLine("Add Items selected.");
            Console.ReadKey(true);
            continue;
        case '3':
            Console.Clear();
            System.Console.WriteLine("Delete Items selected.");
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