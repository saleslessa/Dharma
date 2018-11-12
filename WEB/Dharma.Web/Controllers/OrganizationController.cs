using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Dharma.Web.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrganizationController : Dharma.OrganizationBlock.Controllers.OrganizationController
	{
	}
}
