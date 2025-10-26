using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApi.Models;
using MyWebApi.Servicess;
using System.Collections.Generic;

namespace MyWebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Item>> GetItems()
        {
            var items = _itemService.GetItems();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public ActionResult<Item> GetItemById(int id)
        {
            var item = _itemService.GetItemById(id);
            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpPost]
        public ActionResult<Item> AddItem(Item item)
        {
            var newItem = _itemService.AddItem(item);
            return Ok(newItem);
        }

        [HttpDelete("{id}")]
        public ActionResult<Item> DeleteItem(int id)
        {
            var deletedItem = _itemService.DeleteItem(id);
            if (deletedItem == null)
                return NotFound();

            return Ok(deletedItem);
        }

        [HttpPut("{id}")]
        public ActionResult<Item> UpdateItem(int id, Item item)
        {
            var existingItem = _itemService.UpdateItem(id, item);
            if (existingItem == null)
                return NotFound();

            existingItem.Name = item.Name;
            existingItem.Age = item.Age;

            return Ok(existingItem);
        }
    }
}
