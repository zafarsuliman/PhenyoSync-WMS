using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PhenyoSyncAPI.Controllers
{
    [ApiController]
    [Route("api/warehousemanager")]
    public class WarehouseManager : Controller
    {
        [Authorize(Roles = "WarehouseManager")]
        [HttpGet("inventory")]
        public IActionResult GetInventory()
        {
            return Ok("Warehouse inventory data");
        }
    }
}
