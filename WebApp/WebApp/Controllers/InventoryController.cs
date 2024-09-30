using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class InventoryController : Controller
    {
        HttpClient client;
        private readonly IWebHostEnvironment env;

        public InventoryController(IWebHostEnvironment env)
        {
            this.env = env;
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            client = new HttpClient(clientHandler);
        }
        public IActionResult Index()
        {
            List<Inventory> invList = new List<Inventory>();
            string url = "https://localhost:7254/api/Inventory";
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsondata = response.Content.ReadAsStringAsync().Result;
                var obj = JsonConvert.DeserializeObject<List<Inventory>>(jsondata);
                if (obj != null)
                {
                    invList = obj;
                }
            }
            return View(invList);
        }

        public IActionResult GetCategory()
        {
            List<ItemCategory> catList = new List<ItemCategory>();
            string url = "https://localhost:7254/api/Category/GetCategory";
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsondata = response.Content.ReadAsStringAsync().Result;
                var obj = JsonConvert.DeserializeObject<List<ItemCategory>>(jsondata);
                if (obj != null)
                {
                    catList = obj;
                }
            }
            return View();
        }

        //// Load Basic Details section via AJAX
        //public IActionResult LoadBasicDetails()
        //{
        //    return PartialView("_BasicDetailsForm");
        //}

        //// Load Stock Details section via AJAX
        //public IActionResult LoadStockDetails()
        //{
        //    return PartialView("_StockDetailsForm");
        //}

        //// Load Pricing Details section via AJAX
        //public IActionResult LoadPricingDetails()
        //{
        //    return PartialView("_PricingDetailsForm");
        //}

        public IActionResult AddInventory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddInventory(Inventory i)
        {
            string url = "https://localhost:7254/api/Inventory/AddInventory";
            var jsondata = JsonConvert.SerializeObject(i);
            StringContent stringContent = new StringContent(jsondata, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(url, stringContent).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(i);
        }

        public IActionResult AddItems()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddItems(InventoryViewModel i)
        {
            var path = env.WebRootPath;
            i.CategoryId = 2;
            i.BusinessId = 1;
            var filePath = "Content/Images/" + i.Image.FileName;
            var fullPath = Path.Combine(path, filePath);
            UploadFile(i.Image, fullPath);

            var inventory = new Inventory
            {
                CategoryID = i.CategoryId,
                
                ItemName = i.ItemName,
                BusinessId = i.BusinessId,
                SalesPrice = i.SalesPrice,
                GSTTaxRate = i.GSTTaxRate,
                MeasuringUnit = i.MeasuringUnit,
                OpeningStock = i.OpeningStock,
                PurchasePrice = i.PurchasePrice,
                ItemCode = i.ItemCode,
                ItemType = i.ItemType,
                HSNCode = i.HSNCode,
                Description = i.Description,
                Image = fullPath
            };

            string url = "https://localhost:7254/api/Inventory/AddInventory";
            var jsondata = JsonConvert.SerializeObject(inventory);
            StringContent stringContent = new StringContent(jsondata, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(url, stringContent).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(i);
        }

        public void UploadFile(IFormFile file, string fullPath)
        {
            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
        }
        public IActionResult DeleteItems(int id)
        {
            string url = "https://localhost:7254/api/Inventory/DeleteInventory/";
            HttpResponseMessage response = client.DeleteAsync(url + id).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
