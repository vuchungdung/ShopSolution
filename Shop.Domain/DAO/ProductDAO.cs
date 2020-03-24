using Shop.Domain.Dtos;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.DAO
{
    public class ProductDAO
    {
        private ShopDbContext _context;
        public ProductDAO(ShopDbContext context)
        {
            _context = context;
        }
        public List<Product> GetAll()
        {
            return _context.Products.ToList();
        }
        public int Create(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product.ID;
        }
        
        public bool Delete(int id)
        {
            var query = _context.Products.Where(x => x.ID == id).SingleOrDefault();
            if (query != null)
            {
                _context.Products.Remove(query);
                _context.SaveChanges();
                return true;
            }
            else
            {
                _context.SaveChanges();
                return false;
            }
        }
    }
}
