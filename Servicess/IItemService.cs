using MyWebApi.Models;

namespace MyWebApi.Servicess
{
    public interface IItemService
    {
        IEnumerable<Item> GetItems();
        Item? GetItemById(int id);
        Item AddItem(Item item);
        Item? DeleteItem(int id);
        Item UpdateItem(int id,Item item);
       
    }
}
