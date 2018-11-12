using System;
using System.Dynamic;
using System.Runtime.CompilerServices;
using System.Text;
using Dharma.Core;
using Dharma.Core.Gateway;
using Dharma.OrganizationBlock.Components.Commands;
using Dharma.OrganizationBlock.Interfaces;
using Dharma.OrganizationBlock.Models;
using Newtonsoft.Json;

namespace Dharma.OrganizationBlock.Implementation
{
	internal class OrganizationBlockCommands : IOrganizationBlockCommands
	{
		public OrganizationModel Add(OrganizationModel model)
		{
			try
			{
				if (!model.IsValid())
				{
					LogError(model);
				}else 
				{
					new OrganizationBlockBaseCommand(model).Add();
				}

				return model;
			}
			catch (Exception ex)
			{
				return ErrorHandler.LogError<OrganizationModel>(ex);
			}
		}

		public ValidationResult Remove(string Id)
		{
			try
			{
				var model = new OrganizationModel() { Id = Id };
				new OrganizationBlockBaseCommand(model).Remove();
				return model.ValidationResult;
			}
			catch (Exception ex)
			{
				var validationResult = ErrorHandler.LogError<OrganizationModel>(ex).ValidationResult;
				return validationResult;
			}
		}

		public OrganizationModel Update(OrganizationModel model)
		{
			try
			{
				if(!model.IsValid())
				{
					LogError(model);
				}else 
				{
					new OrganizationBlockBaseCommand(model).Update();
				}
				return model;
			}
			catch (Exception ex)
			{
				return ErrorHandler.LogError<OrganizationModel>(ex);
			}
		}

		private static void LogError(OrganizationModel model, [CallerMemberName] string caller = "Unknown")
		{
			if (model == null) throw new ArgumentNullException(nameof(model));

			dynamic errorObj = new ExpandoObject();

			errorObj.BlockOrigin = "OrganizationBlock";
			errorObj.Type = "Warning";


			var errorMessage = new StringBuilder();
			errorMessage.Append("Following Errors occured while trying to ");
			errorMessage.Append(caller);
			errorMessage.Append(" OrganizationModel object: ");

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
