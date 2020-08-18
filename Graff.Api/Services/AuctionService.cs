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

        public AuctionService(
            GenericRepository<Product> productRepository, 
            GenericRepository<Bid> bidRepository, 
            GenericRepository<Person> personRepository)
        {
            _productRepository = productRepository;
            _bidRepository = bidRepository;
            _personRepository = personRepository;
        }
       
        public string AddNewPerson(Person person)
        {
            var id = _personRepository.Create(person);
            
            return id;
        }

        public string AddNewBid(string personId, string productId, decimal value)
        {
            ValidatePersonExists(personId);

            var product = _productRepository.GetById(productId);

            ValidateProductFound(product);
            ValidateNewBidMustBiggerThanLast(product, value);
            
            var id = _bidRepository.Create(new Bid(personId, productId, value));
            return id;
        }

        public List<Bid> GetBidsByPersonId(string personId)
        {
            ValidatePersonExists(personId);
            var bids = _bidRepository.GetAll().Where(bid => bid.OwnerId == personId).ToList();

            return bids;
        }

        private void ValidateProductFound([AllowNull] Product product)
        {
            if (product != null)
            {
                throw new Exception("Produto não encontrado!");
            }
        }

        private void ValidateNewBidMustBiggerThanLast(Product product, decimal value)
        {
            if (product.CurrentValue >= value)
            {
                throw new Exception("Seu lance deve ser maior do que o último.");
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
