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
using Dharma.ItemsBlock.Implementation;
using Dharma.ItemsBlock.Interfaces;
using Dharma.ItemsBlock.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Dharma.ItemsBlock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly ContainerBuilder _container;

        public ItemsController()
        {
            _container = new ContainerBuilder();
            _container.RegisterType<ItemsBlockQueries>().As<IItemsBlockQueries>();
            _container.RegisterType<ItemsBlockCommands>().As<IItemsBlockCommands>();
        }

        [HttpGet("get/{id}")]
        public IActionResult Get(string id)
        {
            throw new NotImplementedException();
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            using (var lifeTime = _container.Build().BeginLifetimeScope())
            {
                var query = lifeTime.Resolve<IItemsBlockQueries>();

                var result = query.ListAllItems();

                return Ok(result.Select(t => t.Map()));
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] ItemsBlockViewModel model)
        {
            using (var lifeTime = _container.Build().BeginLifetimeScope())
            {
                var command = lifeTime.Resolve<IItemsBlockCommands>();

                var result = command.Add(model.Map());

                if (!result.IsValid())
                    return BadRequest(result.ValidationResult.ListAll());

                return Ok(result.Map());
            }
        }
    }
}