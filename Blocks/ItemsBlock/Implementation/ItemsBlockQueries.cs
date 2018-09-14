// ItemsBlockQueries.cs
//
// Author:
//       Sales Alencar <lopesdealencar@gmail.com>
//
// Copyright (c) 2018 MIT
//

using System;
using System.Collections.Generic;
using System.Linq;
using Dharma.ItemsBlock.Components.Queries;
using Dharma.ItemsBlock.Implementation.Properties;
using Dharma.ItemsBlock.Interfaces;
using Dharma.ItemsBlock.Models;
using NLog;

namespace Dharma.ItemsBlock.Implementation
{
	internal class ItemsBlockQueries : IItemsBlockQueries
	{
		
		private readonly Logger _log;

		public ItemsBlockQueries()
		{
			_log = LogManager.GetCurrentClassLogger();
		}
		
		public IEnumerable<ItemModel> ListAllItems()
		{
			try
			{
				return new ListAllItemsQuery().Run();
			}
			catch (Exception e)
			{
				var errorId = Guid.NewGuid();
				_log.Error($"{errorId} - {e.Message}");
				var result = new ItemModel();
				result.ValidationResult.Add(string.Format(Resources.DefaultErrorMessage, errorId));
				return new List<ItemModel>() {result };
			}
		}

		public IEnumerable<ItemModel> ListItemsFromCategory(string[] categories)
		{
			try
			{
				var result = new List<ItemModel>();

				foreach (var category in categories)
				{
					result.AddRange(new ListItemsFromCategoryQuery(category).Run());
				}

				return result.Distinct();
			}
			catch (Exception e)
			{
				var errorId = Guid.NewGuid();
				_log.Error($"{errorId} - {e.Message}");
				var result = new ItemModel();
				result.ValidationResult.Add(string.Format(Resources.DefaultErrorMessage, errorId));
				return new List<ItemModel>() {result };
			}
		}

		public IEnumerable<ItemModel> ListItemsFromName(string name)
		{
			try
			{
				return new ListItemsFromNameQuery(name).Run();
			}
			catch (Exception e)
			{
				var errorId = Guid.NewGuid();
				_log.Error($"{errorId} - {e.Message}");
				var result = new ItemModel();
				result.ValidationResult.Add(string.Format(Resources.DefaultErrorMessage, errorId));
				return new List<ItemModel>() {result };
			}
		}
	}
}
