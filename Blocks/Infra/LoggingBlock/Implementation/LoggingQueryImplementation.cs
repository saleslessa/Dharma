// LoggingQueryImplementation.cs
//
// Author:
//       Sales Alencar <lopesdealencar@gmail.com>
//
// Copyright (c) 2018 MIT
using System;
using System.Collections.Generic;
using System.Linq;
using Dharma.LoggingBlock.Components.Queries;
using Dharma.LoggingBlock.Interfaces;
using Dharma.LoggingBlock.Models;
using MongoDB.Driver;

namespace Dharma.LoggingBlock.Implementation
{	
	internal class LoggingQueryImplementation : ILoggingQueries
	{

		public LoggingBlockModel GetLoggingFromId(string id)
		{
			if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var guidId))
			{
				return new LoggingBlockModel(new List<string>() { "Invalid Id", "Other random error just to see in Json Format" });
			}

			var query = new GetLoggingFromIdQuery(id);


				return query.Run().SingleOrDefault();
		}

		public IEnumerable<LoggingBlockModel> ListAllLoggingFromType(string blockName, LoggingBlockType type)
		{
			if (string.IsNullOrEmpty(blockName)) 
			return Enumerable.Empty<LoggingBlockModel>();

			return new ListAllLoggingFromTypeQuery(blockName, type).Run();
		}

		public IEnumerable<LoggingBlockModel> ListLoggingFromBlock(string blockName)
		{
			if (string.IsNullOrEmpty(blockName)) return Enumerable.Empty<LoggingBlockModel>();

			return new ListLoggingFromBlockQuery(blockName).Run();
		}

		public IEnumerable<LoggingBlockModel> ListLoggingFromBlockNameAndType(string blockName, string type)
		{
			if (string.IsNullOrEmpty(blockName) || string.IsNullOrEmpty(type)) 
				return Enumerable.Empty<LoggingBlockModel>();

			var typeEnum = (LoggingBlockType)Enum.Parse(typeof(LoggingBlockType), type);

			return new ListLoggingFromBlockNameAndTypeQuery(blockName, typeEnum).Run();
		}
	}
}
