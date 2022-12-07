namespace api.casa.popular.Controllers.Tools
{
    using domain.casa.popular.Extensions;
    using Microsoft.AspNetCore.Mvc;
    using shoiq.api.Controllers.Base;

    [ApiController]
    [Route("[controller]")]
    public class SecurityController : BaseController
    {
        [HttpGet("encrypt")]
        private IActionResult EncryptString(string toEncrypt)
            => Ok(toEncrypt.Encode());

        [HttpGet("decrypt")]
        private IActionResult DecryptString(string toDecrypt)
            => Ok(toDecrypt.Decode());
    }
}
