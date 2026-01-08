class InventoryManagment
{
    List<ItemManagement> Items;

    public InventoryManagment()
    {
        Items = new List<ItemManagement>();
    }

    public void AddItem(ItemManagement newItem)
    {
        if (newItem == null || newItem.Item.Count == 0)
        {
            Console.WriteLine("Cannot add an empty item.");
            return;
        }
        else
        {
            Items.Add(newItem);
        }
    }
}