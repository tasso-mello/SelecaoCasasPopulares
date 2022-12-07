namespace api.casa.popular.Controllers.Business
{
    using core.casa.popular.Contracts;
    using domain.casa.popular.Models;
    using Microsoft.AspNetCore.Mvc;
    using shoiq.api.Controllers.Base;
    using System;
    using System.Threading.Tasks;

    [ApiController]
    [Route("[controller]")]
    public class PessoaController : BaseController, IBaseReadBasicController
    {
        private readonly IPessoaCore _pessoaCore;
        public PessoaController(IPessoaCore pessoaCore)
        {
            _pessoaCore = pessoaCore;
        }

        [HttpGet]
        public async Task<IActionResult> Get(Guid id)
            => await ToResponseAsync(await _pessoaCore.Get(id), Request.Method);

        [HttpGet("take")]
        public async Task<IActionResult> Get(int skip = 1, int take = 10)
            => await ToResponseAsync(await _pessoaCore.Get(skip, take), Request.Method);

        [HttpGet("filter/{filter}")]
        public async Task<IActionResult> Get(string filter, int skip = 1, int take = 10)
            => await ToResponseAsync(await _pessoaCore.Get(filter, skip, take), Request.Method);
    }
}