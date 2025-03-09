using Microsoft.AspNetCore.Mvc;
using SimpleApp.Entities;
using SimpleApp.Repositories.Interface;

namespace SimpleApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Products product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    product.CreatedAt = DateTime.Now;
                    await _productRepository.AddProduct(product);
                    TempData["SuccessMessage"] = "Product added successfully!";
                    return RedirectToAction("Index", "Home");
                }
                return View(product);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An internal error occurred";
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var product = await _productRepository.GetProductById(id);
                if (product == null)
                {
                    TempData["ErrorMessage"] = "Product not found!";
                    return RedirectToAction("Index", "Home");
                }
                return View(product);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An internal error occurred";
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Products product)
        {
            try
            {
                await _productRepository.UpdateProduct(product);
                TempData["SuccessMessage"] = "Product updated successfully!";
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An internal error occurred";
                return RedirectToAction("Index", "Home");
            }
        }

            public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _productRepository.DeleteProduct(id);
                TempData["SuccessMessage"] = "Product deleted successfully!";
                return RedirectToAction("Index", "Home");
            }
            catch(Exception ex){
                TempData["ErrorMessage"] = "An internal error occurred";
                return RedirectToAction("Index","Home");
            }
        }
    }
}
