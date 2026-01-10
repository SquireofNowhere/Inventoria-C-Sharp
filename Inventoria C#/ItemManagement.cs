using System.Linq.Expressions;

class ItemManagement
{
    public Dictionary<string, object?> Item { get; set; } = new Dictionary<string, object?>();


    public Dictionary<string, object?> CreateItem()
    {
        Item = new Dictionary<string, object?>();

        string ColumnName;
        object? ColumnValue;


        while (true)
        {
            Console.Clear();
            System.Console.WriteLine("Creating a new item.");

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

    public void DisplayItem(Dictionary<string, object?> theItem)
    {
        Console.WriteLine("Item Details:");
        foreach (var kvp in theItem)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }
    }

}