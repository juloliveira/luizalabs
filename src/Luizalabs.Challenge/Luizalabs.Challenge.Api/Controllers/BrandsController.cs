using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Luizalabs.Challenge.Contracts.v1.Requests;
using Luizalabs.Challenge.Contracts.v1.Responses;
using Luizalabs.Challenge.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Luizalabs.Challenge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private IBrands _brands;

        public BrandsController(IBrands brands)
        {
            _brands = brands;
        }

        [HttpPost]
        public async Task<IActionResult> Post(BrandPost brandPost)
        {
            var brand = brandPost.CreateDomain();
            await _brands.Insert(brand);

            return Ok(new Response<long>(brand.Id));
        }
    }
}