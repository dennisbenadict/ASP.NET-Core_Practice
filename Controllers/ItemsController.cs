using asp.net_core_Practice.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Linq;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace asp.net_core_Practice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        private static List<Item> Items = new List<Item>
        {
            new Item { Id = 1, Name = "Shoe", Price = 2000 },
            new Item { Id = 2, Name = "Tshirt", Price = 1000 },
            new Item { Id = 3, Name = "Jeans", Price = 700 }
        };
        [HttpGet]
        public ActionResult<IEnumerable<Item>> GetItems()
        {
            return Ok(Items);
        }
        [HttpGet("{id}")]
        public ActionResult<Item> GetItemById(int id)
        {
            var item = Items.FirstOrDefault(i => i.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(item);
            }
        }
        [HttpPost]
        public ActionResult<Item>CreateItem(Item newItem)
        {
            newItem.Id = Items.Max(i => i.Id) + 1;
            Items.Add(newItem);
            return CreatedAtAction(nameof(GetItemById), new { id = newItem.Id }, newItem);
        }
        [HttpPut("{id}")]
        public ActionResult<Item>updateItem(int id,Item updateItem)
        {
            var item = Items.FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            else
            {
                item.Name = updateItem.Name;
                item.Price = updateItem.Price;
                return NoContent();
            }
        }
        [HttpDelete("{id}")]
        public ActionResult deleteItem(int id)
        {
            var item = Items.FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            else
            {
                Items.Remove(item);
                return NoContent();
            }
        }
        }
    }

