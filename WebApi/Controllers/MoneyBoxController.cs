using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MoneyBoxController : ControllerBase
	{
		private readonly IMoneyBoxService _moneyBoxService;

		public MoneyBoxController(IMoneyBoxService moneyBoxService)
		{
			_moneyBoxService = moneyBoxService;
		}

		[HttpGet("GetMoneyBoxAmount")]
		public IActionResult GetMoneyBoxAmount()
		{
			return Ok(_moneyBoxService.TGetAll().FirstOrDefault().TotalAmount);
		}
	}
}
