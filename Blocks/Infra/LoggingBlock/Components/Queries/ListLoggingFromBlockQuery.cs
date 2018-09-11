// ListLoggingFromBlock.cs
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
	internal class ListLoggingFromBlockQuery : LoggingBlockBaseQuery
	{

		private readonly string _blockName;

		public ListLoggingFromBlockQuery(string blockName)
		{
			_blockName = blockName;
		}

		protected override Expression<Func<LoggingBlockModel, bool>> _filter => (t => t.BlockOrigin == _blockName);

	}
}
