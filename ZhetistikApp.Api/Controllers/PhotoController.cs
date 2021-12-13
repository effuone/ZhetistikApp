using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ZhetistikApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetPhotoAsync()
        {

        }
    }
}
