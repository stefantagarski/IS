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
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<ProductInShoppingCart> _productsInCartsRepository;
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<ProductsInOrder> _productsInOrderRepository;

        public ShoppingCartService(IRepository<ShoppingCart> cartRepository, IRepository<Product> productRepository, IRepository<ProductInShoppingCart> productsInCartsRepository, IRepository<Order> orderRepository, IRepository<ProductsInOrder> productsInOrderRepository)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
            _productsInCartsRepository = productsInCartsRepository;
            _orderRepository = orderRepository;
            _productsInOrderRepository = productsInOrderRepository;
        }

        public bool DeleteFromCart(Guid id, string userId)
        {
            var shoppingCart = _cartRepository.Get(selector: x => x, predicate: x => x.OwnerId == userId);

            var productToDelete = _productsInCartsRepository.Get(selector: x => x,
                predicate: x => x.ProductId == id && x.ShoppingCartId == shoppingCart.Id);

            _productsInCartsRepository.Delete(productToDelete);

            return true;
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

        public AddToCartDTO GetProductInfo(Guid id)
        {
            var product = _productRepository.Get(selector: x => x, predicate: x => x.Id == id);
            var dto = new AddToCartDTO
            {
                ProductId = id,
                ProductName = product.Name,
                Quantity = 1
            };
            return dto;
        }

        public bool OrderProducts(string userId)
        {
            var shoppingCart = _cartRepository.Get(selector: x => x,
               predicate: x => x.OwnerId == userId,
               include: x => x.Include(y => y.ProductInShoppingCarts).ThenInclude(z => z.Product));

            var newOrder = new Order
            {
                Id = Guid.NewGuid(),
                Owner = shoppingCart.Owner,
                OwnerId = userId,
                Total = 0.0
            };

            _orderRepository.Insert(newOrder);

            var allProductsInOrder = shoppingCart.ProductInShoppingCarts.Select(x => new ProductsInOrder
            {
                OrderId = newOrder.Id,
                Order = newOrder,
                ProductId = x.ProductId,
                Product = x.Product,
                Quantity = x.Quantity
            });

            double total = 0.0;

            foreach (var product in allProductsInOrder)
            {
                total += product.Product.Price * product.Quantity;
                _productsInOrderRepository.Insert(product);
            }

            newOrder.Total = total;
            _orderRepository.Update(newOrder);

            shoppingCart.ProductInShoppingCarts.Clear();
            _cartRepository.Update(shoppingCart);

            return true;
        }
    }
}
