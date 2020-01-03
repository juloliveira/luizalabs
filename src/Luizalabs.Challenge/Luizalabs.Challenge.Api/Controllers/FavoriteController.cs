using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Luizalabs.Challenge.Contracts.v1.Requests;
using Luizalabs.Challenge.Services.Favorities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Luizalabs.Challenge.Api.Controllers
{
    [Route("api/customer/{customerId}/[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        private IFavoriteService _favoriteService;

        public FavoriteController(IFavoriteService favoriteService)
        {
            _favoriteService = favoriteService;
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromRoute]long customerId, FavoritePut favoritePut)
        {
            await _favoriteService.Include(customerId, favoritePut);

            return Ok(new { result = "success" });
        }
    }
}