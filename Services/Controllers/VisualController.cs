using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Business;

namespace Services.Controllers
{
    public class VisualController : BaseController
    {
        [HttpGet("GetImage/{visualId}")]
        public async Task<IActionResult> GetImage(int visualId, int? width = null, int? height = null)
        {
            var visual = await VisualLogic.GetVisual(GetDepartmentCode(), visualId);
            if (visual == null)
            {
                return NotFound();
            }
            var dataBytes = VisualLogic.GetDataBytes(visual.Data, width, height);
            return File(dataBytes, "image/png");
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Models.Visual model)
        {
            var visualId = await VisualLogic.Create(GetDepartmentCode(), model);
            return Ok(visualId);
        }
    }
}