﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Luizalabs.Challenge.Contracts.v1.Requests;
using Luizalabs.Challenge.Contracts.v1.Responses;
using Luizalabs.Challenge.Core;
using Luizalabs.Challenge.Core.Interfaces;
using Luizalabs.Challenge.Services.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Luizalabs.Challenge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class ProductController : ControllerBase
    {
        private IMapper _mapper;
        private IProducts _products;
        private IProductInsertService _productService;
        private IProductPagination _productPagination;

        public ProductController(
            IMapper mapper,
            IProducts products, 
            IProductInsertService productService, 
            IProductPagination productPagination)
        {
            _mapper = mapper;
            _products = products;
            _productService = productService;
            _productPagination = productPagination;
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProductPost productPost)
        {
            Product product = await _productService.Insert(productPost);

            return Ok(new Response<long>(product.Id));
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]int page = 1)
        {
            var pagination = await _productPagination.Page(page, size: 10);

            return Ok(new Response<Pagination>(pagination));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute]long id)
        {
            var product = await _products.GetById(id);
            var response = _mapper.Map<ProductDetail>(product);

            return Ok(new Response<ProductDetail>(response));
        }
    }
}