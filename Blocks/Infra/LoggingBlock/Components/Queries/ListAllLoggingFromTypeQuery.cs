// ListAllLoggingFromTypeQuery.cs
//
// Author:
//       Sales Alencar <lopesdealencar@gmail.com>
//
// Copyright (c) 2018 MIT
using System;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using Dharma.Core;
using Dharma.LoggingBlock.Models;

[assembly: InternalsVisibleTo("LoggingBlock.Component.Tests")]
[assembly: InternalsVisibleTo("LoggingBlock.Implementation")]
namespace Dharma.LoggingBlock.Components.Queries
{
	internal class ListAllLoggingFromTypeQuery : BaseQuery<LoggingBlockModel>
	{

		private readonly string _blockName;
		private readonly LoggingBlockType _type;

		public ListAllLoggingFromTypeQuery(string blockName, LoggingBlockType type)
		{
			_blockName = blockName;
			_type = type;
		}

		protected override Expression<Func<LoggingBlockModel, bool>> _filter => (t => t.BlockOrigin == _blockName && t.Type == _type);

		protected override string server => LoggingBlockQuery.Server;

		protected override int port => Convert.ToInt32(LoggingBlockQuery.Port);

		protected override string database => LoggingBlockQuery.Database;

		protected override string user => LoggingBlockQuery.User;

		protected override string pwd => LoggingBlockQuery.Pwd;

	}
}
