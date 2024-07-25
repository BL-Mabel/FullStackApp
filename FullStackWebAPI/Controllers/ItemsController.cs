using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FullStackWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private static List<Item> items = new List<Item>
    {
        new Item { Id = 1, Name = "Item 1", Description = "Description 1" },
        new Item { Id = 2, Name = "Item 2", Description = "Description 2" },
    };

        [HttpGet]
        public IEnumerable<Item> Get()
        {
            return items;
        }

        [HttpPost]
        public void Post([FromBody] Item item)
        {
            items.Add(item);
        }

        [HttpPut]
        public void Put([FromBody] Item item)
        {
            var existingItem = items.Find(i => i.Id == item.Id);
            if (existingItem != null)
            {
                existingItem.Name = item.Name;
                existingItem.Description = item.Description;
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var item = items.Find(i => i.Id == id);
            if (item != null)
            {
                items.Remove(item);
            }
        }
    }

    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

