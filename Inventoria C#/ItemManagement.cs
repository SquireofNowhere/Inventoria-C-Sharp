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
            ColumnName = GetColumnName();
            ColumnValue = GetColumnValue();


            if (!string.IsNullOrEmpty(ColumnName))
            {
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
        Console.WriteLine("Enter the Column Name: ");

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
        Console.WriteLine("Enter the Column Value: ");
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

    public void DisplayItem()
    {
        Console.WriteLine("Item Details:");
        foreach (var kvp in Item)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }
    }

}