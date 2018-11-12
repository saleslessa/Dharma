// LoggingBlockModelExtension.cs
//
// Author:
//       Sales Alencar <lopesdealencar@gmail.com>
//
// Copyright (c) 2018 MIT

using System;
using Dharma.LoggingBlock.Models;

namespace Dharma.LoggingBlock.ViewModels
{
	internal static class LoggingBlockModelExtension
	{
		internal static LoggingBlockViewModel Map(this LoggingBlockModel model)
		{
			var result = new LoggingBlockViewModel() { 
				BlockOrigin = model.BlockOrigin,
				Id = model.Id,
				Message = model.Message,
				Type = Enum.GetName(typeof(LoggingBlockType), model.Type),
				TimeStamp = model.TimeStamp
			};
			
			result.SetValidationResult(model.ValidationResult);

			return result;
		}

		internal static LoggingBlockModel Map(this LoggingBlockViewModel model)
		{
			return new LoggingBlockModel()
			{
				BlockOrigin = model.BlockOrigin,
				Id = model.Id,
				Message = model.Message,
				Type = model.Type != null
					? (LoggingBlockType) Enum.Parse(typeof(LoggingBlockType), model.Type)
					: LoggingBlockType.Error,
				TimeStamp = model.TimeStamp
			};
		}
	}
}
