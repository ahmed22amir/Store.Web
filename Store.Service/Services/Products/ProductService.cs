﻿using Store.Data.Entity;
using Store.Repository.InterFaces;
using Store.Service.Services.Products.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyList<BrandTypeDetailsDto>> GetAllBrandsAsync()
        {
            var brands = await _unitOfWork.Repository<ProductBrand,int>().GetAllAsync();
            IReadOnlyList<BrandTypeDetailsDto> MappedBrands = brands.Select(x => new BrandTypeDetailsDto
            {
                Id = x.Id,
                CreatedAt = x.CreatedAt,
                Name = x.Name,
            }).ToList();
            return MappedBrands;
        }

        public async Task<IReadOnlyList<ProductDto>> GetAllProductsAsync()
        {
            var products = await _unitOfWork.Repository<Product, int>().GetAllAsync();
            var MappedProducts = products.Select(x => new ProductDto
            {
                Id= x.Id,
                Name = x.Name,
                BrandName = x.Brand.Name,
                TypeName = x.Type.Name,
                CreatedAt= x.CreatedAt,
                Description = x.Description,
                ImageUrl = x.ImageUrl,
                Price = x.Price,
            }).ToList();
            return MappedProducts;
        }

        public async Task<IReadOnlyList<BrandTypeDetailsDto>> GetAllTypesAsync()
        {
            var types = await _unitOfWork.Repository<ProductType, int>().GetAllAsync();
            var MappedTypes = types.Select(x => new BrandTypeDetailsDto
            {
                Id = x.Id,
                Name = x.Name,
                CreatedAt = x.CreatedAt
            }).ToList();
            return MappedTypes;
        }

        public async Task<ProductDto> GetProductByIdAsync(int? id)
        {
            if (id is null)
            {
                throw new Exception("Id is null");
            }
            var product = await _unitOfWork.Repository<Product, int>().GetByIdAsync(id.Value);
            if (product is null)
            {
                throw new Exception("product not found");
            }

            var MappedProduct = new ProductDto
            {
                Id= product.Id,
                Name = product.Name,
                CreatedAt = product.CreatedAt,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                Price = product.Price,
                BrandName = product.Brand.Name,
                TypeName = product.Type.Name,
            };
            return MappedProduct;

        }
    }
}
