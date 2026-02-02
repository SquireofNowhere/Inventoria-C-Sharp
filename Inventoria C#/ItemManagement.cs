using System.Linq.Expressions;

class ItemManagement
{
    public Dictionary<string, object?> Item { get; set; } = new Dictionary<string, object?>(StringComparer.OrdinalIgnoreCase);


    public Dictionary<string, object?> CreateItem()
    {


        string ColumnName;
        object? ColumnValue;

        Console.Clear();
        Console.WriteLine("Creating a new item.");

        while (true)
        {
            ColumnName = "Name";
            Console.WriteLine($"\nEnter the value for '{ColumnName}': ");
            ColumnValue = GetColumnValue();

            if (ColumnValue == null || string.IsNullOrEmpty(ColumnValue.ToString()))
            {
                Console.WriteLine("Invalid Column Value. Please try again.");
                continue;

            }
            Item[ColumnName] = ColumnValue;
            break;
        }

        while (true)
        {
            ColumnName = "Quantity";
            Console.WriteLine($"\nEnter the value for '{ColumnName}': ");
            ColumnValue = GetColumnValue();

            if (ColumnValue == null || string.IsNullOrEmpty(ColumnValue.ToString()))
            {
                Console.WriteLine("Invalid Column Value. Please try again.");
                continue;

            }
            Item[ColumnName] = ColumnValue;
            break;
        }




        while (true)
        {

            ColumnName = "Location";
            Console.WriteLine($"\nEnter the value for '{ColumnName}': ");
            ColumnValue = GetColumnValue();

            if (ColumnValue == null || string.IsNullOrEmpty(ColumnValue.ToString()))
            {
                Console.WriteLine("Invalid Column Value. Please try again.");
                continue;

            }
            Item[ColumnName] = ColumnValue;
            break;
        }

        System.Console.WriteLine("\nCreate Next Field? (Leave blank to finish)\n");
        while (true)
        {


            ColumnName = GetColumnName(); //takes user input for column name



            if (!string.IsNullOrEmpty(ColumnName))
            {
                ColumnValue = GetColumnValue(); //takes user input for column value

                if (ColumnValue == null || string.IsNullOrEmpty(ColumnValue.ToString()))
                {
                    Console.WriteLine("Invalid Column Value. Please try again.");
                    continue;

                }

                Item[ColumnName] = ColumnValue;
            }
            else
            {
                break;
            }
        }

        return Item;
    }


    public string GetColumnName() //takes user input for column name
    {
        Console.WriteLine("\nEnter the Column Name: ");

        string? input = Console.ReadLine();

        string ColumnName;

        if (!string.IsNullOrEmpty(input))
        {
            ColumnName = input;
        }
        else
        {
            ColumnName = string.Empty;
        }

        return ColumnName;


    }

    public object? GetColumnValue() //takes user input for column value
    {
        Console.WriteLine("\nEnter the Column Value: ");
        string? input = Console.ReadLine();

        object? ColumnValue;


        if (!string.IsNullOrEmpty(input))
        {
            ColumnValue = input;
        }
        else
        {
            ColumnValue = null;
        }

        return ColumnValue;
    }

    public Dictionary<string, object?> EditColumn(int index)
    {
        InventoryManagment inventoryManager = new InventoryManagment();

        Dictionary<string, object?> updatedInstance = inventoryManager.FetchInventoryItem(index);

        Console.WriteLine("-------------------");
        Console.WriteLine($"Item Index: {index + 1}\n");
        DisplayItem(updatedInstance);
        Console.WriteLine("-------------------");

        System.Console.WriteLine("\n Which field would you like to update? (Leave blank to finish)");

        string? input = GetColumnName();

        //this while is for changes, if the input is invalid it will not ask for changes and will instead return the original instance.
        while (!string.IsNullOrEmpty(input))
        {
            string ColumnName = input;

            Console.WriteLine($"\n\nEnter the new value for '{ColumnName}': ");

            object? ColumnValue = GetColumnValue();

            if (ColumnValue == null || string.IsNullOrEmpty(ColumnValue.ToString()))
            {
                Console.WriteLine("Invalid Column Value. Please try again.");
            }
            else if (updatedInstance.ContainsKey(ColumnName))
            {
                updatedInstance[ColumnName] = ColumnValue; //instance Value actually updated here
                Console.WriteLine($"\n'{ColumnName}' updated successfully to {ColumnValue}.");
                break;
            }
            else
            {
                Console.WriteLine($"Column '{ColumnName}' does not exist in the item. Please try again.");

            }
        }


        return updatedInstance;
    }

    public void DisplayItem(Dictionary<string, object?> theItem)
    {
        Console.WriteLine("Item Details:\n");
        foreach (var kvp in theItem)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }
    }

}