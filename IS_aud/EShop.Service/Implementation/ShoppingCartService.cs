using EShop.Domain.DomainModels;
using EShop.Domain.DTO;
using EShop.Repository;
using EShop.Service.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Service.Implementation
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IRepository<ShoppingCart> _cartRepository;

        public ShoppingCartService(IRepository<ShoppingCart> cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public ShoppingCart GetByUserId(Guid id)
        {
            return _cartRepository.Get(selector: x => x, predicate: x => x.OwnerId == id.ToString());
        }

        public ShoppingCartDTO GetByUserIdIncudingProducts(Guid id)
        {
            var shoppingCart = _cartRepository.Get(selector: x => x,
                predicate: x => x.OwnerId == id.ToString(),
                include: x => x.Include(y => y.ProductInShoppingCarts).ThenInclude(z => z.Product));

            var allProducts = shoppingCart.ProductInShoppingCarts.ToList();

            var allProductsPrices = allProducts.Select(x => new
            {
                ProductPrice = x.Product.Price,
                Quantity = x.Quantity
            });

            double total = 0.0;

            foreach(var item in allProductsPrices)
            {
                total += item.ProductPrice * item.Quantity;
            }

            ShoppingCartDTO model = new ShoppingCartDTO
            {
                Products = allProducts,
                TotalPrice = total
            };

            return model;
        }
    }
}
