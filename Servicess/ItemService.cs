using Microsoft.AspNetCore.Http.HttpResults;
using MyWebApi.Models;

namespace MyWebApi.Servicess
{
    public class ItemService : IItemService
    {
        private readonly List<Item> items = new List<Item>
        {
            new Item{Id=1,Name="Dennis",Age=20 },
            new Item{Id=2,Name="Ajit",Age=22 }
        };
        public IEnumerable<Item> GetItems()
        {
            return items;
        }
        public Item? GetItemById(int id)
        {
            var item = items.FirstOrDefault(i => i.Id == id);
            return item;
        }
        public Item AddItem(Item item)
        {
            item.Id = items.Max(x => x.Id) + 1;
            items.Add(item);
            return item;
        }
        public Item? DeleteItem(int id)
        {
            var deleteItem = items.FirstOrDefault(i => i.Id == id);
            items.Remove(deleteItem);
            return deleteItem;
        }
        public Item UpdateItem(int id, Item item)
        {
            var existingItem = items.FirstOrDefault(i => i.Id == id);
            if (existingItem == null)
            {
                return null;
            }
            else
            {
                existingItem.Name = item.Name;
                existingItem.Age = item.Age;
                return existingItem;
            }
        }
    }
}
