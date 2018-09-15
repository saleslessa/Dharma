// LoggingController.cs
//
// Author:
//       Sales Alencar <lopesdealencar@gmail.com>
//
// Copyright (c) 2018 MIT

using System;
using System.Linq;
using Autofac;
using Dharma.Core;
using Dharma.LoggingBlock.Implementation;
using Dharma.LoggingBlock.Interfaces;
using Dharma.LoggingBlock.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Dharma.LoggingBlock.Controllers
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
    public class LoggingController : DharmaController, IDisposable
    {
        private readonly ILoggingQueries _queries;
        private readonly ILoggingCommands _commands;
        private readonly ILifetimeScope _lifetimeScope;

        public LoggingController()
        {
            var container = new ContainerBuilder();
            container.RegisterType<LoggingQueryImplementation>().As<ILoggingQueries>();
            container.RegisterType<LoggingCommandImplementation>().As<ILoggingCommands>();

            _lifetimeScope = container.Build().BeginLifetimeScope();
            _queries = _lifetimeScope.Resolve<ILoggingQueries>();
            _commands = _lifetimeScope.Resolve<ILoggingCommands>();
        }

        [HttpGet("get/{id}")]
        public IActionResult Get(string id)
        {
            var result = _queries.GetLoggingFromId(id).Map();
            return Ok(result);
        }

        [HttpGet("{blockName}")]
        public IActionResult GetByBlockName(string blockName)
        {
            var models = _queries.ListLoggingFromBlock(blockName).ToList();
            return GenericGet(models.Select(t => t.Map()));
        }

        [HttpGet("{blockName}/{type}")]
        public IActionResult GetByBlockNameAndType(string blockName, string type)
        {
            var models = _queries.ListLoggingFromBlockNameAndType(blockName, type).ToList();
            return GenericGet(models.Select(t => t.Map()));
        }

        [HttpPost]
        public IActionResult Post([FromBody] LoggingBlockViewModel logging)
        {
            var model = _commands.AddLog(logging.Map());
            
            if (!model.IsValid())
                return BadRequest(model.ValidationResult.ListAll());

            return Ok(model.Map());
        }

        public void Dispose()
        {
            _lifetimeScope?.Dispose();
        }
    }
}