using System.Net.Http.Headers;
using Domain;

namespace Infrastructure;

public class InMemoryProductRepository : IProductRepository
{
    private readonly List<Product> _products=new List<Product>();


    public async Task AddAsync(Product product)
    {
        _products.Add(product);
        await Task.CompletedTask;
    }

    public async Task DeleteAsync(int id)
    {
        var product= _products.FirstOrDefault(p=>p.Id==id);
        if (product!=null){
            _products.Remove(product);
        }
        await Task.CompletedTask;
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await Task.FromResult(_products);
    }

    public async Task<Product> GetByIdAsync(int id)
    {
        var product=_products.FirstOrDefault(p=>p.Id==id);
        return await Task.FromResult(product);
    }

    public async Task UpdateAsync(Product product)
    {
        var existingProduct= _products.FirstOrDefault(p=>p.Id==product.Id);
        
        if (existingProduct !=null){
            existingProduct.Name=product.Name;
            existingProduct.Price= product.Price;
        }
        await Task.CompletedTask;

    }
}
