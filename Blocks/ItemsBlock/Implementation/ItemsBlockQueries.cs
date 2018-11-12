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
using Dharma.Core;
using Dharma.ItemsBlock.Components.Queries;
using Dharma.ItemsBlock.Interfaces;
using Dharma.ItemsBlock.Models;

namespace Dharma.ItemsBlock.Implementation
{
	internal class ItemsBlockQueries : IItemsBlockQueries
    {
        public IEnumerable<ItemModel> ListAllItems()
        {
            try
            {
                return new ListAllItemsQuery().Run();
            }
            catch (Exception e)
            {
                var result = ErrorHandler.LogError<ItemModel>(e);
                return new List<ItemModel>() {result};
            }
        }

        public IEnumerable<ItemModel> ListItemsFromCategory(IEnumerable<string> categories)
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
                var result = ErrorHandler.LogError<ItemModel>(e);
                return new List<ItemModel>() {result};
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
                var result = ErrorHandler.LogError<ItemModel>(e);
                return new List<ItemModel>() {result};
            }
        }
    }
}