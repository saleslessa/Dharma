// LoggingController.cs
//
// Author:
//       Sales Alencar <lopesdealencar@gmail.com>
//
// Copyright (c) 2018 MIT

using System;
using System.Linq;
using Autofac;
using Dharma.Core.Gateway;
using Dharma.LoggingBlock.Implementation;
using Dharma.LoggingBlock.Interfaces;
using Dharma.LoggingBlock.Models;
using LoggingBlock.Implementation;
using LoggingBlock.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LoggingBlock.Controllers
{
	/// <summary>
	/// Logging Block. Responsible for logging information for other blocks provided through a RESTful API 
	/// <para>
	/// #### Operations available:
	/// </para>
	/// | Type | Operation | Behavior |
	/// | ---- | --------- | ------ |
	/// | GET | <value>[endpoint]</value>/get/{id} | Endpoint that returns a specific logging through its ID |
	/// | GET | <value>[endpoint]</value>/{blockName} | Endpoint that returns all logging information about a specific Block |
	/// | GET | <value>[endpoint]</value>/{blockName}/{type} | Endpoint that returns all logging information about a specific block and type | 
	/// | POST | <value>[endpoint]</value> | Endpoint to save logging information. It needs to pass a full <value>LoggingBlockViewModel</value> strutucture in body |
	/// </summary>
	[Route("api/[controller]")]
	[ApiController]
	public class LoggingController : ControllerBase
	{
		private readonly ContainerBuilder _container;

		public LoggingController()
		{
			_container = new ContainerBuilder();
			_container.RegisterType<LoggingQueryImplementation>().As<ILoggingQueries>();
			_container.RegisterType<LoggingCommandImplementation>().As<ILoggingCommands>();

		}

		[HttpGet("get/{id}")]
		public IActionResult Get(string id)
		{
			try
			{
				using(var lifeTime = _container.Build().BeginLifetimeScope())
				{
					var query = lifeTime.Resolve<ILoggingQueries>();
					return Ok(query.GetLoggingFromId(id).Map());	
				}
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		[HttpGet("{blockName}")]
		public IActionResult GetByBlockName(string blockName)
		{
			try
			{
				using (var lifeTime = _container.Build().BeginLifetimeScope())
				{
					var query = lifeTime.Resolve<ILoggingQueries>();
					return Ok(query.ListLoggingFromBlock(blockName).Select(t => t.Map()));
				}
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet("{blockName}/{type}")]
		public IActionResult GetByBlockNameAndType(string blockName, string type)
		{
			try
			{
				using (var lifeTime = _container.Build().BeginLifetimeScope())
				{
					var query = lifeTime.Resolve<ILoggingQueries>();
					return Ok(query.ListLoggingFromBlockNameAndType(blockName, type).Select(t => t.Map()));
				}
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet("gateway/{service}")]
		public IActionResult TestGateway(string service)
		{
			try
			{
				return Ok(Gateway.GetGateway(service));
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPost]
		public IActionResult Post([FromBody]LoggingBlockViewModel logging)
		{
			try
			{
				using (var lifeTime = _container.Build().BeginLifetimeScope())
				{
					var command = lifeTime.Resolve<ILoggingCommands>();
					var typeEnum = (LoggingBlockType)Enum.Parse(typeof(LoggingBlockType), logging.Type);

					var model = command.AddLog(logging.BlockOrigin, logging.Message, typeEnum);
					if (!model.IsValid())
						return BadRequest(model.ValidationResult.ListAll());

					return Ok(model.Map());
				}

			}
			catch (Exception ex)
			{
				return Ok(ex.Message);
			}
		}
	}
}
