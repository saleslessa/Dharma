// ListLoggingFromBlockNameAndTypeQuery.cs
//
// Author:
//       Sales Alencar <lopesdealencar@gmail.com>
//
// Copyright (c) 2018 MIT
using System;
using System.Linq.Expressions;
using Dharma.LoggingBlock.Models;

namespace Dharma.LoggingBlock.Components.Queries
{
	internal class ListLoggingFromBlockNameAndTypeQuery: LoggingBlockBaseQuery
	{
		private readonly string _blockName;
		private readonly LoggingBlockType _type;
		public ListLoggingFromBlockNameAndTypeQuery(string blockName, LoggingBlockType type)
		{
			_blockName = blockName;
			_type = type;
		}

		protected override Expression<Func<LoggingBlockModel, bool>> _filter => (t => t.BlockOrigin == _blockName && t.Type == _type);

	}
}
