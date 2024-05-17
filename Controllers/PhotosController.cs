using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using mvcTest.Models;

public class PhotosController : Controller
{
    private readonly HttpClient _httpClient;
    public PhotosController()
    {
        _httpClient = new HttpClient();
    }

    public async Task<IActionResult> Index(int page = 1, int pageSize = 3) // Cambio de pageSize a 3 por defecto
    {
        string apiUrl = $"https://jsonplaceholder.typicode.com/photos";
        var response = await _httpClient.GetAsync(apiUrl);
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var allPhotos = JsonConvert.DeserializeObject<List<Photo>>(content);

            // Cálculo de la paginación
            int totalCount = allPhotos.Count;
            var paginatedPhotos = allPhotos.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            ViewBag.TotalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            ViewBag.CurrentPage = page;
            ViewBag.PageSize = pageSize;

            return View(paginatedPhotos);
        }

        return View(new List<Photo>()); // Retorna una lista vacía si falla la respuesta
    }
}
