// LoggingBlockModelExtension.cs
//
// Author:
//       Sales Alencar <lopesdealencar@gmail.com>
//
// Copyright (c) 2018 MIT
using System;
using Dharma.LoggingBlock.Models;

namespace LoggingBlock.ViewModels
{
	internal static class LoggingBlockModelExtension
	{
		internal static LoggingBlockViewModel Map(this LoggingBlockModel model)
		{
			return new LoggingBlockViewModel() { 
				BlockOrigin = model.BlockOrigin,
				Id = model.Id,
				Message = model.Message,
				Type = Enum.GetName(typeof(LoggingBlockType), model.Type)
			};
		}

		internal static LoggingBlockModel Map(this LoggingBlockViewModel model)
		{
			return new LoggingBlockModel()
			{
				BlockOrigin = model.BlockOrigin,
				Id = model.Id,
				Message = model.Message,
				Type = (LoggingBlockType)Enum.Parse(typeof(LoggingBlockType), model.Type)
			};
		}
	}
}
