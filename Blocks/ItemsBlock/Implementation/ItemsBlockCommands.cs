// ItemsBlockCommands.cs
//
// Author:
//       Sales Alencar <lopesdealencar@gmail.com>
//
// Copyright (c) 2018 MIT
//

using System;
using System.Dynamic;
using System.Runtime.CompilerServices;
using System.Text;
using Dharma.Core;
using Dharma.Core.Gateway;
using Dharma.ItemsBlock.Components.Commands;
using Dharma.ItemsBlock.Interfaces;
using Dharma.ItemsBlock.Models;
using Newtonsoft.Json;

namespace Dharma.ItemsBlock.Implementation
{
    internal class ItemsBlockCommands : IItemsBlockCommands
    {
        public ItemModel Add(ItemModel model)
        {
            try
            {
                if (!model.IsValid())
                {
                    LogError(model);
                }
                else
                {
                    new AddItemModelCommand(model).Run();                    
                }

                return model;
            }
            catch (Exception e)
            {
                return ErrorHandler.LogError<ItemModel>(e);
            }
        }

        public ItemModel Update(ItemModel model)
        {
            try
            {
                if (!model.IsValid())
                {
                    LogError(model);
                }
                else
                {
                    new UpdateItemModelCommand(model).Run();
                }

                return model;
            }
            catch (Exception e)
            {
                return ErrorHandler.LogError<ItemModel>(e);
            }
        }

        private static void LogError(ItemModel model, [CallerMemberName] string caller = "Unknown")
        {
            if (model == null) throw new ArgumentNullException(nameof(model));
            
            dynamic errorObj = new ExpandoObject();

            errorObj.BlockOrigin = "ItemsBlock";
            errorObj.Type = "Warning";


            var errorMessage = new StringBuilder();
            errorMessage.Append("Following Errors occured while trying to ");
            errorMessage.Append(caller);
            errorMessage.Append(" ItemViewModel object: ");
			
            foreach (var validationMessage in model.ValidationResult.Errors)
            {
                errorMessage.Append($"{validationMessage.Value}; ");
            }

            errorObj.Message = errorMessage.ToString();
            var jsonObject = JsonConvert.SerializeObject(errorObj);

            try
            {
                Gateway.CallBlock<object>("LoggingBlock", HttpVerbsEnum.POST, jsonObject);
            }
            catch (Exception e)
            {
                ErrorHandler.LogError<ItemModel>(e);
            }
        }
    }
}