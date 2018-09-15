// ItemsController.cs
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
using Dharma.ItemsBlock.Implementation;
using Dharma.ItemsBlock.Interfaces;
using Dharma.ItemsBlock.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Dharma.ItemsBlock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : DharmaController, IDisposable
    {
        private readonly IItemsBlockQueries _queries;
        private readonly IItemsBlockCommands _commands;
        private readonly ILifetimeScope _lifetimeScope;

        public ItemsController()
        {
            var container = new ContainerBuilder();
            container.RegisterType<ItemsBlockQueries>().As<IItemsBlockQueries>();
            container.RegisterType<ItemsBlockCommands>().As<IItemsBlockCommands>();

            _lifetimeScope = container.Build().BeginLifetimeScope();
            _queries = _lifetimeScope.Resolve<IItemsBlockQueries>();
            _commands = _lifetimeScope.Resolve<IItemsBlockCommands>();
        }

        [HttpGet("GetFromCategory/{category}")]
        public IActionResult GetFromCategory(string category)
        {
            var result = _queries.ListItemsFromCategory(new[] {category});
            return GenericGet(result.Select(t => t.Map()));
        }

        [HttpGet("GetFromName/{name}")]
        public IActionResult GetFromName(string name)
        {
            var models = _queries.ListItemsFromName(name);
            return GenericGet(models.Select(t => t.Map()));
        }

        [HttpGet]
        public IActionResult Get()
        {
            var models = _queries.ListAllItems();
            return GenericGet(models.Select(t => t.Map()));
        }

        [HttpPost]
        public IActionResult Post([FromBody] ItemsBlockViewModel model)
        {
            var result = _commands.Add(model.Map());

            if (!result.IsValid())
                return BadRequest(result.ValidationResult.ListAll());

            return Ok(result.Map());
        }

        public void Dispose()
        {
            _lifetimeScope?.Dispose();
        }
    }
}