using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Business.BrandAndModel;

namespace Services.Controllers
{

    [Route("/api/[controller]")]
    [ApiController]
    [EnableCors("AllowAll")]
    public class BrandModelController : Controller
    {

        [HttpGet("GetBrands")]
        public async Task<IActionResult> GetBrands()
        {
            var list = await BrandAndModelLogic.GetBrand();
            if (!list.Any())
            {
                return NotFound();
            }
            return Ok(list);
        }


        [HttpGet("GetModels")]
        public async Task<IActionResult> GetModels()
        {
            var list = await BrandAndModelLogic.GetModels();
            if (!list.Any())
            {
                return NotFound();
            }
            return Ok(list);
        }

        [HttpGet("GetModels/{brandId}")]
        public async Task<IActionResult> GetModels(int brandId)
        {
            var list = await BrandAndModelLogic.GetModelByBrandId(brandId);
            if (!list.Any())
            {
                return NotFound();
            }
            return Ok(list);
        }

    }
}