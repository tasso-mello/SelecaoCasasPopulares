namespace shoiq.api.Controllers.Base
{
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using System;
    using System.Threading.Tasks;

    public interface IBasePersistController<T>
	{
		[HttpPost]
		Task<IActionResult> Post(T jsonObject);
		[HttpPut]
		Task<IActionResult> Put(T jsonObject);
		[HttpDelete]
		Task<IActionResult> Delete(Guid id);
	}

	public interface IBaseReadBasicController
	{
		[HttpGet("{id}")]
		Task<IActionResult> Get(Guid id);
		[HttpGet("take")]
		Task<IActionResult> Get(int skip = 1, int take = 10);
	}

	public interface IBaseReadFullController
	{
		[HttpGet("{id}")]
		Task<IActionResult> Get(Guid id);
		[HttpGet("{name}")]
		Task<IActionResult> GetByName(string name);
		[HttpGet("take")]
		Task<IActionResult> Get(int skip = 1, int take = 10);
		[HttpGet("filter/{filter}")]
		Task<IActionResult> Get(string filter, int skip = 1, int take = 10);
	}

	/// <summary>
	/// 
	/// </summary>
	public class BaseController : ControllerBase
	{
        protected IActionResult ToResponse(string result, string method, string url = null)
			=> result.Contains("error") ? HttpErrorStatusCodeResult(result, method) : HttpSuccessStatusCodeResult(result, method, url);
		protected async Task<IActionResult> ToResponseAsync(string result, string method, string url = null)
			=> result.Contains("error") ? HttpErrorStatusCodeResult(result, method) : HttpSuccessStatusCodeResult(result, method, url);
		private IActionResult HttpErrorStatusCodeResult(string result, string method)
		{
            switch (method.ToUpper())
            {
                case "GET":
					return NotFound(result);
                case "POST":
					{
						if(result.Contains("Invalid crerdentials"))
							return Unauthorized(result);
						else
							return BadRequest(result);
					}
                default:
					return Forbid();
            }
		}
		private IActionResult HttpSuccessStatusCodeResult(string result, string method, string url = null)
		{
			switch (method.ToUpper())
			{
				case "POST":
					return Created(url ?? string.Empty, result);
				default:
					return Ok(result);
			}
		}
    }
}
