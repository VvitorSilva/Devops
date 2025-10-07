using Microsoft.AspNetCore.Mvc;
using EsgApp.Models;
using EsgApp.Services;

namespace EsgApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItensController : ControllerBase
    {
        private readonly ItemService _service;

        public ItensController(ItemService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<Item>> Get() => _service.Get();

        [HttpPost]
        public ActionResult<Item> Post(Item item) => _service.Create(item);
    }
}