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
        //private readonly string _connectionString;
        //private readonly IJwtTokenGenerator _jwtTokenGenerator;
        //private readonly IConfiguration _configuration;
        //private readonly ProductContext _context;
        //private readonly string _connectionString;

        private readonly ProductContext _context;
        public ProductRepository(ProductContext context)
        {
            _context = context;
        }

        // är ovan samma som nedan?
        //public ProductRepository(IConfiguration configuration, ProductContext context)
        //{
        //    //_configuration = configuration;
        //    //_context = context;
        //    //_db = db;
        //    _connectionString = connectionString.GetConnectionString("Default");
        //}

        // Create product
        //public async Task<int> CreateProduct(CreateProductDTO product)
        //{
        //    var newProduct = new Product
        //    {
        //        ProductId = product.ProductId,
        //        ProductName = product.ProductName,
        //        Description = product.Description,
        //        Price = product.Price,
        //        CategoryId = product.CategoryId,

        //    };
        //    _context.Products.Add(newProduct);
        //    await _context.SaveChangesAsync();

        //    return product.ProductId;
        //}


        //var officeList = _db.Offices.ToList();

        public async Task<List<ProductDTO>> GetProduct(ProductDTO product)
        {
            // add return of list with await

            return await _context.Products.Select(p => new ProductDTO
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                Description = p.Description,
                Price = p.Price,
                CategoryId = p.CategoryId,
            }).ToListAsync();
            
            //return new List<ProductDTO>();
        }
        //getProducgtByCategory
        public async Task<List<ProductDTO>> GetProductByCategory(int categoryId)
        {
            return await _context.Products.Where(p => p.CategoryId == categoryId).Select(p => new ProductDTO
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
            return await _context.Products.Where(p => p.Price == price).Select(p => new ProductDTO
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
            return await _context.Products.Where(p => p.ProductId == id).Select(p => new ProductDTO
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
            return await _context.Products.Where(p => p.ProductName == name).Select(p => new ProductDTO
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

//    /// ************************

//    {
//        new ProductDTO
//        {
//        ProductId = product.ProductId,
//        ProductName = product.ProductName,
//        Description = product.Description,
//        Price = product.Price,
//        CategoryName = product.CategoryName,
//        }
//    };
//}  


//await _context.Products.ToListAsync();
//return _context.Products.Select(p => new ProductDTO
//{
//    ProductId = p.ProductId,
//    ProductName = p.ProductName,
//    Description = p.Description,
//    Price = p.Price,
//    CategoryName = p.CategoryName,
//}); 


//        var employeesWithOffice = _db.Employees
//           .Include(e => e.Office)
//           .ToList();
//var products = await _context.Products.ToListAsync();

//return products.Select(p => new ProductDTO
//{
//    ProductId = p.ProductId,
//    ProductName = p.ProductName,
//    Description = p.Description,
//    Price = p.Price,
//    CategoryId = p.CategoryId,
//});
