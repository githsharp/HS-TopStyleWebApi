using HS_TopStyleWebApi.DTOs.ProductDTOs;

namespace HS_TopStyleWebApi.Repository.Interfaces
{
    public interface IProductRepository
    {
        // POST - Create Product
        //Task<int> CreateProduct(CreateProductDTO product);

        // GET - Get all products// 
        Task<List<ProductDTO>> GetProduct(ProductDTO product);

        
        //GET - Get all products by category
      Task<List<ProductDTO>> GetProductByCategory(int categoryId);


        //GET - Get all products by price
         Task<List<ProductDTO>> GetProductByPrice(int price);


        // GET - Get Product by Id
        Task<ProductDTO?> GetProductById(int id);


        //GET   - Get Product by Name
        Task<ProductDTO?> GetProductByName(string name);

    }
}
