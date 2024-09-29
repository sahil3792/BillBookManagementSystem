using Items.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public InventoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Route("AddInventory/")]
        [HttpPost]
        public IActionResult AddInventory(Inventory inventory)
        {
            var category = _context.Categories.FirstOrDefault(c => c.CategoryName == inventory.Category.CategoryName);
            if (category == null)
            {
                category = new Category
                {
                    CategoryName = inventory.Category.CategoryName
                };
                _context.Categories.Add(category);
                _context.SaveChanges();
            }
            inventory.CategoryId = category.CategoryId;

            _context.Database.ExecuteSqlRaw("EXEC AddInventory @CategoryId, @ItemName, @SalesPrice, @GSTTaxRate, @MeasuringUnit, @OpeningStock, @PurchasePrice, @ItemCode, @HSNCode, @Description, @BusinessId,@ItemType,@Image",
                new SqlParameter("@CategoryId", inventory.CategoryId),
                new SqlParameter("@ItemName", inventory.ItemName),
                new SqlParameter("@SalesPrice", inventory.SalesPrice),
                new SqlParameter("@GSTTaxRate", inventory.GSTTaxRate),
                new SqlParameter("@MeasuringUnit", inventory.MeasuringUnit),
                new SqlParameter("@OpeningStock", inventory.OpeningStock),
                new SqlParameter("@PurchasePrice", inventory.PurchasePrice),
                new SqlParameter("@ItemCode", inventory.ItemCode),
                new SqlParameter("@HSNCode", inventory.HSNCode),
                new SqlParameter("@Description", inventory.Description),
                new SqlParameter("@BusinessId", inventory.BusinessId),
                new SqlParameter("ItemType", inventory.ItemType),
                new SqlParameter("Image", inventory.Image));

            return Ok("Item added");
        }

        [Route("UpdateInventory/{id}/")]
        [HttpPut]
        public IActionResult UpdateInventory(int id, Inventory inventory)
        {
            if (id != inventory.Id)
                return BadRequest("Inventory ID mismatch");

            _context.Database.ExecuteSqlRaw("EXEC UpdateInventory @Id, @CategoryId, @ItemName, @SalesPrice, @GSTTaxRate, @MeasuringUnit, @OpeningStock, @PurchasePrice, @ItemCode, @HSNCode, @Description, @BusinessId,@ItemType,@Image",
                new SqlParameter("@Id", inventory.Id),
                new SqlParameter("@CategoryId", inventory.CategoryId),
                new SqlParameter("@ItemName", inventory.ItemName),
                new SqlParameter("@SalesPrice", inventory.SalesPrice),
                new SqlParameter("@GSTTaxRate", inventory.GSTTaxRate),
                new SqlParameter("@MeasuringUnit", inventory.MeasuringUnit),
                new SqlParameter("@OpeningStock", inventory.OpeningStock),
                new SqlParameter("@PurchasePrice", inventory.PurchasePrice),
                new SqlParameter("@ItemCode", inventory.ItemCode),
                new SqlParameter("@HSNCode", inventory.HSNCode),
                new SqlParameter("@Description", inventory.Description),
                new SqlParameter("@BusinessId", inventory.BusinessId),
                new SqlParameter("@ItemType", inventory.ItemType),
                new SqlParameter("@Image", inventory.Image));

            return NoContent();
        }

        [Route("DeleteInventory/{id}/")]
        [HttpDelete]
        public IActionResult DeleteInventory(int id)
        {
            _context.Database.ExecuteSqlRaw("EXEC DeleteInventory @Id", new SqlParameter("@Id", id));
            return NoContent();
        }

        [HttpGet]
        public ActionResult<List<Inventory>> GetAllInventories()
        {
            var inventories = _context.Inventories.ToList();
            return Ok(inventories);
        }

        [Route("{id}/")]
        [HttpGet]
        public ActionResult<Inventory> GetInventoryById(int id)
        {
            var inventory = _context.Inventories.Find(id);
            if (inventory == null)
                return NotFound();
            return Ok(inventory);
        }


    }
}
