// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

using Microsoft.AspNetCore.Mvc;

namespace Dharma.Web.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LoggingController : LoggingBlock.Controllers.LoggingController
	{

	}
}
