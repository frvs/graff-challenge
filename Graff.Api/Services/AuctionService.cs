using Graff.Api.Entities;
using Graff.Api.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Graff.Api.Services
{
    public class AuctionService
    {
        private GenericRepository<Product> _productRepository;
        private GenericRepository<Bid> _bidRepository;
        private GenericRepository<Person> _personRepository;

        public AuctionService(GenericRepository<Product> productRepository, GenericRepository<Bid> bidRepository, GenericRepository<Person> personRepository)
        {
            _productRepository = productRepository;
            _bidRepository = bidRepository;
            _personRepository = personRepository;
        }
       
        public string AddNewProduct(Product product)
        {
            var id = _productRepository.Create(product);

            return id;
        }

        public string AddNewPerson(Person person)
        {
            var id = _personRepository.Create(person);
            
            return id;
        }

        public string AddNewBid(Bid bid)
        {
            ValidatePersonExists(bid.OwnerId);

            var product = _productRepository.GetById(bid.ProductId);

            ValidateProductFound(product);
            ValidateNewBidMustBiggerThanLast(product, bid.Value);
            
            var id = _bidRepository.Create(bid);
            return id;
        }

        public List<Product> GetAllProducts()
        {
            var products = _productRepository.GetAll();
            var bids = _bidRepository.GetAll();

            LoadBids(products, bids);

            return products;
        }

        private void LoadBids(List<Product> products, List<Bid> bids)
        {
            foreach (var productIds in bids.Select(bids => bids.ProductId).Distinct())
            {
                var product = products.First(p => p.Id == productIds);
                product.Bids = bids.Where(b => b.ProductId == product.Id).ToList();
            }
        }

        public List<Bid> GetBidsByPersonId(string personId)
        {
            ValidatePersonExists(personId);
            var bids = _bidRepository.GetAll().Where(bid => bid.OwnerId == personId).ToList();

            return bids;
        }

        private void ValidateProductFound([AllowNull] Product product)
        {
            if (product == null)
            {
                throw new Exception("Produto não encontrado!");
            }
        }

        private void ValidateNewBidMustBiggerThanLast(Product product, decimal value)
        {
            if (product.CurrentValue >= value)
            {
                throw new Exception($"Seu lance deve ser maior do que o último (R$ {product.CurrentValue}).");
            }
        }

        private void ValidatePersonExists(string personId)
        {
            if (_personRepository.GetById(personId) == null)
            {
                throw new Exception("Pessoa não encontrada!");
            }
        }
    }
}
