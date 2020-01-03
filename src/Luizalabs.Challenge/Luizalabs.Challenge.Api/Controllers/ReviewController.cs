using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Luizalabs.Challenge.Contracts.v1.Requests;
using Luizalabs.Challenge.Contracts.v1.Responses;
using Luizalabs.Challenge.Core;
using Luizalabs.Challenge.Services.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Luizalabs.Challenge.Api.Controllers
{
    [Route("api/product/{id}/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private IProductReviewService _productReviewService;

        public ReviewController(IProductReviewService productReviewService)
        {
            _productReviewService = productReviewService;
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromRoute]long id, [FromBody]ReviewPut reviewPut)
        {
            Review review = await _productReviewService.Insert(productId: id, reviewPut);

            return Ok(new Response<long>(review.Id));
        }
    }
}