using EShop.Domain.DomainModels;
using EShop.Domain.DTO;
using EShop.Repository;
using EShop.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Service.Implementation
{
    public class ProductService : IProductService
    {

        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<ProductInShoppingCart> _productsInShoppingCartsRepository;
        private readonly IShoppingCartService _cartService;

        public ProductService(IRepository<Product> productRepository, IRepository<ProductInShoppingCart> productsInShoppingCartsRepository, IShoppingCartService cartService)
        {
            _productRepository = productRepository;
            _productsInShoppingCartsRepository = productsInShoppingCartsRepository;
            _cartService = cartService;
        }

        public Product Add(Product product)
        {
            product.Id = Guid.NewGuid();
            return _productRepository.Insert(product);
        }

        public void AddToCart(AddToCartDTO addToCartDTO, Guid userId)
        {
            var shoppingCart = _cartService.GetByUserId(userId);

            var product = _productRepository.Get(selector: x => x, predicate: x => x.Id == addToCartDTO.ProductId);

            var existingProductInShoppingCart = _productsInShoppingCartsRepository
                .Get(selector: x => x,
                predicate: x => x.ProductId == addToCartDTO.ProductId && x.ShoppingCartId == shoppingCart.Id);

            if(existingProductInShoppingCart != null)
            {
                existingProductInShoppingCart.Quantity += addToCartDTO.Quantity;
                _productsInShoppingCartsRepository.Update(existingProductInShoppingCart);
            }
            else
            {
                ProductInShoppingCart newProduct = new ProductInShoppingCart
                {
                    Id = Guid.NewGuid(),
                    ProductId = addToCartDTO.ProductId,
                    Product = product,
                    ShoppingCartId = shoppingCart.Id,
                    ShoppingCart = shoppingCart,
                    Quantity = addToCartDTO.Quantity
                };
                _productsInShoppingCartsRepository.Insert(newProduct);
            }
        }

        public Product DeleteById(Guid Id)
        {
            var product = GetById(Id);
            if (product == null)
            {
                throw new Exception("This products does not exist!");
            }
            _productRepository.Delete(product);
            return product;
        }

        public List<Product> GetAll()
        {
            return _productRepository.GetAll(selector: x => x).ToList();
        }

        public Product? GetById(Guid Id)
        {
            return _productRepository.Get(selector: x => x, predicate: x => x.Id == Id);
        }

        public Product Update(Product product)
        {
            return _productRepository.Update(product);
        }
    }
}
