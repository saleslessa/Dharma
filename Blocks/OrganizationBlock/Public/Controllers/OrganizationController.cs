// OrganizationController.cs
//
// Author:
//       Sales Alencar <lopesdealencar@gmail.com>
//
// Copyright (c) 2018 MIT
//
using System;
using System.Linq;
using Autofac;
using Dharma.Core;
using Dharma.OrganizationBlock.Implementation;
using Dharma.OrganizationBlock.Interfaces;
using Dharma.OrganizationBlock.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Dharma.OrganizationBlock.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrganizationController : DharmaController, IDisposable
	{
		private readonly IOrganizationBlockQueries _queries;
		private readonly IOrganizationBlockCommands _commands;
		private readonly ILifetimeScope _lifetimeScope;

		public OrganizationController()
		{
			var container = new ContainerBuilder();
			container.RegisterType<OrganizationBlockQueries>().As<IOrganizationBlockQueries>();
			container.RegisterType<OrganizationBlockCommands>().As<IOrganizationBlockCommands>();

			_lifetimeScope = container.Build().BeginLifetimeScope();
			_queries = _lifetimeScope.Resolve<IOrganizationBlockQueries>();
			_commands = _lifetimeScope.Resolve<IOrganizationBlockCommands>();
		}

		[HttpGet("{id}")]
		public IActionResult Get(string id)
		{
			var model = _queries.Get(id);
			return GenericGet(model.Select(t => t.ToBasic()));
		}

		[HttpGet("ListFromArea/{latitude}/{longitude}/{radius}")]
		public IActionResult ListOrganizationsFromArea(string latitude, string longitude, string radius)
		{
			if(!int.TryParse(radius, out var convertedRadius) || !double.TryParse(latitude, out var convertedLat) || !double.TryParse(longitude, out var convertedLong))
			{
				return BadRequest($"Invalid radius");
			}

			var result = _queries.ListAllFromArea(convertedLat, convertedLong, convertedRadius);
			return GenericGet(result.Select(t => t.ToBasic()));
		}

		[HttpGet("")]
		public IActionResult Get()
		{
			var models = _queries.ListAll();
			return GenericGet(models.Select(t => t.ToBasic()));
		}

		[HttpDelete("{id}")]
		public IActionResult Remove(string id)
		{
			if (!Guid.TryParse(id, out var convertedId))
			{
				return BadRequest($"Invalid Id");
			}

			var result = _commands.Remove(id);

			if (result.Errors.Any())
			{
				return BadRequest(result.ListAll());
			}

			return Ok();
		}

		[HttpPost]
		public IActionResult Add([FromBody] AddOrganizationViewModel viewModel)
		{
			var result = _commands.Add(viewModel.ToModel());

			if (!result.IsValid())
			{
				return BadRequest(result.ValidationResult.ListAll());
			}

			return Ok(result.Map());
		}

		public void Dispose()
		{
			_lifetimeScope?.Dispose();
		}
	}
}
