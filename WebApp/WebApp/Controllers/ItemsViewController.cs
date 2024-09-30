using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebApp.Models;
using System.Text;
using Rotativa.AspNetCore;


namespace WebApp.Controllers
{
    public class ItemsViewController : Controller
    {
        private readonly HttpClient _httpClient;




        public ItemsViewController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        // GET: ItemsView/Index
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("https://localhost:44354/api/CA/items"); // API endpoint
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var items = JsonConvert.DeserializeObject<List<Item>>(jsonString);
                return View(items);
            }
            return View();
        }

        // GET: ItemsView/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ItemsView/Create
        [HttpPost]
        public async Task<IActionResult> Create(Item item)
        {
            if (ModelState.IsValid)
            {
                var jsonData = JsonConvert.SerializeObject(item);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("https://localhost:44354/api/CA/items", content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(item);
        }

        // GET: ItemsView/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var response = await _httpClient.GetAsync($"https://localhost:44354/api/CA/items/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var item = JsonConvert.DeserializeObject<Item>(jsonString);
                return View(item);
            }
            return NotFound();
        }

        // POST: ItemsView/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Item item)
        {
            if (id != item.ItemId)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var jsonData = JsonConvert.SerializeObject(item);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync($"https://localhost:44354/api/CA/items/{id}", content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(item);
        }

        // GET: ItemsView/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _httpClient.GetAsync($"https://localhost:44354/api/CA/items/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var item = JsonConvert.DeserializeObject<Item>(jsonString);
                return View(item);
            }
            return NotFound();
        }

        // POST: ItemsView/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:44354/api/CA/items/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }
        public async Task<IActionResult> Downloadpdf()
        {
            var response = await _httpClient.GetAsync("https://localhost:44354/api/CA/items/downloadpdf }\r\n");
            if (response.IsSuccessStatusCode)
            {
                var pdf = await response.Content.ReadAsByteArrayAsync();
                return File(pdf, "application/pdf", "ItemsList.pdf");
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DownloadExcel()
        {
            var response = await _httpClient.GetAsync("https://localhost:44354/api/CA/items/downloadexcel");
            if (response.IsSuccessStatusCode)
            {
                var excel = await response.Content.ReadAsByteArrayAsync();
                return File(excel, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ItemsList.xlsx");
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Share()
        {
            return View();
        }
        // POST: ItemsView/Share
        [HttpPost]
        public IActionResult Share(string name, string email, string whatsapp)
        {
            // Here you can also log or store the sharing information if needed

            // This will not return a view as it's handled by the form in Share.cshtml
            return RedirectToAction(nameof(Index)); // Redirect back to the index or any other action
        }




    }
}
