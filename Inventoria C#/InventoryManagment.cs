class InventoryManagment
{
    private List<Dictionary<string, object?>> Instances;
    ItemManagement itemManager = new ItemManagement();

    public InventoryManagment()
    {
        Instances = new List<Dictionary<string, object?>>()

        {
            new Dictionary<string, object?>(StringComparer.OrdinalIgnoreCase)
            {
                {"Name", "Mouse"},
                {"Quantity", 1},
                {"Location", "My Room 414"},
                {"Price", 199.99}
            },
            new Dictionary<string, object?>(StringComparer.OrdinalIgnoreCase)
            {
                {"Name", "Controller"},
                {"Quantity", 0},
                {"Location", "My Room 414"},
                {"Price", 999.99}
            }
        };
    }

    public void AddInstance(Dictionary<string, object?> newInstance)
    {


        if (newInstance == null || newInstance.Count == 0)
        {
            Console.WriteLine("Cannot add an empty item.");
            return;
        }
        else
        {
            Instances.Add(newInstance);
            itemManager.DisplayItem(newInstance);
            Console.WriteLine($"Item added successfully to index {Instances.IndexOf(newInstance) + 1}.");
        }
    }

    public void DeleteInstance(int index)
    {
        if (index < 0 || index >= Instances.Count)
        {
            Console.WriteLine("Invalid index. No item deleted. Press any key to continue...");
            return;
        }

        Instances.RemoveAt(index);
        Console.WriteLine($"Item at index {index} deleted successfully.");
    }

    public void UpdateInstance(int index, Dictionary<string, object?> updatedItem)
    {
        if (index < 0 || index >= Instances.Count)
        {
            Console.WriteLine("Invalid index. No item updated. Press any key to continue...");
            return;
        }

        // Handling no changes made
        if (Instances[index].SequenceEqual(updatedItem))
        {
            Console.WriteLine("No changes detected. Item not updated.");
            return;
        }

        Instances[index] = updatedItem;
        Console.WriteLine($"Item at index {index + 1} updated successfully.");
    }


    public void DisplayAllItems()
    {
        if (Instances.Count == 0)
        {
            Console.WriteLine("No items in inventory.");
            return;
        }
        Console.WriteLine("-------------------");
        foreach (var item in Instances)
        {

            itemManager.DisplayItem(item);
            Console.WriteLine("-------------------");
        }

        System.Console.WriteLine("\n\n\nPress any key to continue...");
    }

    public Dictionary<string, object?> FetchInventoryItem(int index)
    {

        var item = Instances[index];
        Console.WriteLine($"Item Index: {index + 1}");


        return item;


    }
}


