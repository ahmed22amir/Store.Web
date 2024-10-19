﻿using AutoMapper;
using Store.Data.Entity;
using Store.Repository.InterFaces;
using Store.Repository.Specification.ProductSpecs;
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
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper) 
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<BrandTypeDetailsDto>> GetAllBrandsAsync()
        {
            var brands = await _unitOfWork.Repository<ProductBrand,int>().GetAllAsync();
            var MappedBrands = _mapper.Map<IReadOnlyList<BrandTypeDetailsDto>>(brands);
            return MappedBrands;
        }

        //public async Task<IReadOnlyList<ProductDto>> GetAllProductsAsync()
        //{
        //    var products = await _unitOfWork.Repository<Product, int>().GetAllAsync();
        //    var MappedProducts = _mapper.Map<IReadOnlyList<ProductDto>>(products);
        //    return MappedProducts;
        //}

        public async Task<IReadOnlyList<ProductDto>> GetAllProductsAsync(ProductSpecification input)
        {
            var specs = new ProductWithSpecification(input);
            var products = await _unitOfWork.Repository<Product, int>().GetAllWithSpecificationAsync(specs);
            var MappedProducts = _mapper.Map<IReadOnlyList<ProductDto>>(products);
            return MappedProducts;
        }

        public async Task<IReadOnlyList<BrandTypeDetailsDto>> GetAllTypesAsync()
        {
            var types = await _unitOfWork.Repository<ProductType, int>().GetAllAsync();
            var MappedTypes = _mapper.Map<IReadOnlyList<BrandTypeDetailsDto>>(types);
            return MappedTypes;
        }

        public async Task<ProductDto> GetProductByIdAsync(int? id)
        {
            if (id is null)
            {
                throw new Exception("Id is null");
            }
            var specs = new ProductWithSpecification(id);
            var product = await _unitOfWork.Repository<Product, int>().GetWithSpecificationByIdAsync(specs);
            if (product is null)
            {
                throw new Exception("product not found");
            }

            var MappedProduct = _mapper.Map<ProductDto>(product);
            return MappedProduct;

        }
    }
}
