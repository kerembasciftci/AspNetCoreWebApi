using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Core.DTOs;
using Udemy.Core.Models;
using Udemy.Core.Repositories;
using Udemy.Core.Services;
using Udemy.Core.UnitOfWorks;

namespace Udemy.Service.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        public IProductRepository _productRepository { get; set; }
        public IMapper _mapper { get; set; }
        public ProductService(IGenericRepository<Product> repository, IUnitOfWork unitOfWork, IProductRepository productRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetProductsWithCategory()
        {
            var products = await _productRepository.GetProductsWithCategory();
            var productsDto = _mapper.Map<List<ProductWithCategoryDto>>(products);
            return CustomResponseDto<List<ProductWithCategoryDto>>.Success(200,productsDto);
        }

      
    }
}
