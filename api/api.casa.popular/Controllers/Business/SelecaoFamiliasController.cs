namespace api.casa.popular.Controllers.Business
{
    using core.casa.popular.Contracts;
    using core.casa.popular.Implementation;
    using domain.casa.popular.Models;
    using Microsoft.AspNetCore.Mvc;
    using shoiq.api.Controllers.Base;
    using System;
    using System.Threading.Tasks;

    [ApiController]
    [Route("[controller]")]
    public class SelecaoFamiliasController : BaseController
    {
        private readonly ISelecaoFamiliasCore _selecaoFamiliasCore;
        public SelecaoFamiliasController(ISelecaoFamiliasCore selecaoFamiliasCore)
        {
            _selecaoFamiliasCore = selecaoFamiliasCore;
        }

        [HttpGet("take")]
        public async Task<IActionResult> Get()
            => await ToResponseAsync(await _selecaoFamiliasCore.Get(), Request.Method);
    }
}