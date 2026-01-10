class InventoryManagment
{
    List<Dictionary<string, object?>> Items;
    ItemManagement itemManager = new ItemManagement();

    public InventoryManagment()
    {
        Items = new List<Dictionary<string, object?>>()
        {
            new Dictionary<string, object?>()
            {
                {"Name", "Mouse"},
                {"Quantity", 1},
                {"Price", 199.99}
            },
            new Dictionary<string, object?>()
            {
                {"Name", "Controller"},
                {"Quantity", 0},
                {"Price", 999.99}
            }
        };
    }

    public void AddItem(Dictionary<string, object?> newItem)
    {


        if (newItem == null || newItem.Count == 0)
        {
            Console.WriteLine("Cannot add an empty item.");
            return;
        }
        else
        {
            Items.Add(newItem);
            itemManager.DisplayItem(newItem);
            Console.WriteLine($"Item added successfully to index {Items.IndexOf(newItem)}.");
        }
    }

    public void DeleteItem(int index)
    {
        if (index < 0 || index >= Items.Count)
        {
            Console.WriteLine("Invalid index. No item deleted. Press any key to continue...");
            return;
        }

        Items.RemoveAt(index);
        Console.WriteLine($"Item at index {index} deleted successfully.");
    }
    public void DisplayAllItems()
    {
        if (Items.Count == 0)
        {
            Console.WriteLine("No items in inventory.");
            return;
        }
        Console.WriteLine("-------------------");
        foreach (var item in Items)
        {
            Console.WriteLine($"Item Index: {Items.IndexOf(item)}");
            itemManager.DisplayItem(item);
            Console.WriteLine("-------------------");
        }
    }
}