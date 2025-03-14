﻿using EFModellayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFServiceLayer.Service
{
    public interface IProductService
    {
     
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);


        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductById(int id);



    }
}
