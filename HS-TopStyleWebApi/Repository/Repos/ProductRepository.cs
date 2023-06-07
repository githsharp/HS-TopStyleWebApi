using HS_TopStyleWebApi.Repos.Entities;
using HS_TopStyleWebApi.Services.Interfaces;
using HS_TopStyleWebApi.Repository.Repos;
using System.Threading.Tasks;
using HS_TopStyleWebApi.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
//using HS_TopStyleWebApi.Extensions;
using HS_TopStyleWebApi.DTOs.ProductDTOs;
using System.Collections.Generic;
using System.Linq;
using HS_TopStyleWebApi.DTOs.OrderDTOs;
using System.Collections;
using Microsoft.AspNetCore.Http.HttpResults;

namespace HS_TopStyleWebApi.Repository.Repos
{
    public class ProductRepository : IProductRepository
    {

        private readonly ProductContext _db;
        public ProductRepository(ProductContext db)
        {
            _db = db;
        }

        public async Task<List<ProductDTO>> GetProduct(ProductDTO product)
        {
            return await _db.Products.Select(p => new ProductDTO
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                Description = p.Description,
                Price = p.Price,
                CategoryId = p.CategoryId,
            }).ToListAsync();
            
        }
        //getProductByCategory
        public async Task<List<ProductDTO>> GetProductByCategory(int categoryId)
        {
            return await _db.Products.Where(p => p.CategoryId == categoryId).Select(p => new ProductDTO
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                Description = p.Description,
                Price = p.Price,
                CategoryId = p.CategoryId,
            }).ToListAsync();
        }
        //getProductByPrice
        public async Task<List<ProductDTO>> GetProductByPrice(int price)
        {
            return await _db.Products.Where(p => p.Price == price).Select(p => new ProductDTO
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                Description = p.Description,
                Price = p.Price,
                CategoryId = p.CategoryId,
            }).ToListAsync();
        }
        // get ProductById
        public async Task<ProductDTO?> GetProductById(int id)
        {
            return await _db.Products.Where(p => p.ProductId == id).Select(p => new ProductDTO
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                Description = p.Description,
                Price = p.Price,
                CategoryId = p.CategoryId,
            }).FirstOrDefaultAsync();
        }

        // get ProductByName
        public async Task<ProductDTO?> GetProductByName(string name)
        {
            return await _db.Products.Where(p => p.ProductName == name).Select(p => new ProductDTO
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                Description = p.Description,
                Price = p.Price,
                CategoryId = p.CategoryId,
            }).FirstOrDefaultAsync();
        }
    }
}