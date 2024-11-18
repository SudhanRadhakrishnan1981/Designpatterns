using EFModellayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFServiceLayer.Service
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }
        public void AddProduct(Product product)
        {
            var userRepository = _unitOfWork.GetRepository<Product>();
            userRepository.AddAsync(product);

            // Additional logic, if any...

            _unitOfWork.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(Product product)
        {
            var userRepository = _unitOfWork.GetRepository<Product>();
            userRepository.Update(product);

            // Additional logic, if any...

            _unitOfWork.SaveChanges();
        }
    }
}
