using HS_TopStyleWebApi.DTOs.ProductDTOs;

namespace HS_TopStyleWebApi.Repository.Interfaces
{
    public interface IProductRepository
    {
        // POST - Create Product
        //Task<int> CreateProduct(CreateProductDTO product);
        //alt:
        //Task<int> CreateProduct(CreateProductDTO product);

        // GET - Get all products// 
        //
        // ***  NEDAN SKA IN IGEN I MODIFIERAD FORM  ***
        //
        Task<List<ProductDTO>> GetProduct(ProductDTO product);
        //alt denna:
        //Task<IEnumerable<SearchProductDTO>> GetProducts();
        
        //GET - Get all products by category
      Task<List<ProductDTO>> GetProductByCategory(int categoryId);
        //alt denna:
        //Task<IEnumerable<SearchProductDTO>> GetProductsByCategory(int categoryId);

        //GET - Get all products by price
         Task<List<ProductDTO>> GetProductByPrice(int price);
        //alt denna:
        //Task<IEnumerable<SearchProductDTO>> GetProductsByPrice(int price);

        // GET - Get Product by Id
        Task<ProductDTO?> GetProductById(int id);
        //alt:
        //Task<SearchProductDTO> SearchProduct();

        //GET   - Get Product by Name

        Task<ProductDTO?> GetProductByName(string name);


        // DELETE - Delete Product by Id
        // *** Task<ProductDTO?> DeleteProductById(int id);
        //alt:
        //Task<Boolean> DeleteProduct(int productId);
    }
}
