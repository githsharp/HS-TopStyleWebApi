using HS_TopStyleWebApi.Repos.Entities;
using HS_TopStyleWebApi.Services.Interfaces;
using HS_TopStyleWebApi.Repository.Repos;
using System.Threading.Tasks;
using HS_TopStyleWebApi.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using HS_TopStyleWebApi.Extensions;
using HS_TopStyleWebApi.DTOs.ProductDTOs;
using System.Collections.Generic;
using System.Linq;

namespace HS_TopStyleWebApi.Repository.Repos
{
    public class ProductRepository : IProductRepository
    {
        private readonly string _connectionString;
        //private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IConfiguration _configuration;
        private readonly ProductContext _context;

        // är ovan samma som nedan?
        public ProductRepository(IConfiguration configuration, ProductContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        // Create product
        public async Task<int> CreateProduct(CreateProductDTO product)
        {
            var newProduct = new Product
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                Description = product.Description,
                Price = product.Price,
                CategoryName = product.CategoryName,

            };

            _context.Products.Add(newProduct);
            await _context.SaveChangesAsync();

            return product.ProductId;
        }   


        // Get all products

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var products = await _context.Products.ToListAsync();

            return products.Select(p => new ProductDTO
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                Description = p.Description,
                Price = p.Price,
                CategoryId = p.CategoryId,
            });

        }   

    }
}
