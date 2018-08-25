// QueriesTests.cs
//
// Author:
//       Sales Alencar <lopesdealencar@gmail.com>
//
// Copyright (c) 2018 MIT
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Dharma.LoggingBlock.Components.Queries;
using Dharma.LoggingBlock.Models;
using NUnit.Framework;

namespace Dharma.LoggingBlock.Component.Tests
{
	[TestFixture(Category = "UnitTest")]
	public class QueriesTests
	{
		[Test]
		public void GetLoggingFromIdTestFilter_Should_ReturnJustOneModel()
		{
			// Arrange
			var mockDataSet = new List<LoggingBlockModel>()
			{
				new LoggingBlockModel("Origin1", "Message1", LoggingBlockType.Error),
				new LoggingBlockModel("Origin2", "Message2", LoggingBlockType.Error)
			};

			var testId = mockDataSet.First().Id;

			var query = new TestGetLoggingFromIdQuery(testId);

			// Act
			var result = mockDataSet.Where(query.getFilter().Compile());

			// Assert
			Assert.True(result.Count() == 1);
			Assert.AreEqual(result.Single().Id, testId);
			Assert.AreEqual(result.Single().Message, "Message1");
		}

		[Test]
		public void GetLoggingFromIdQuery_Should_ReturnCorrectColection()
		{
			// Arrange
			var mockDataSet = new List<LoggingBlockModel>()
			{
				new LoggingBlockModel("Origin1", "Message1", LoggingBlockType.Error),
				new LoggingBlockModel("Origin2", "Message2", LoggingBlockType.Error),
				new LoggingBlockModel("Origin1", "Message3", LoggingBlockType.Warning),
				new LoggingBlockModel("Origin1", "Message4", LoggingBlockType.Error)
			};

			var query = new TestListAllLoggingFromTypeQuery("Origin1", LoggingBlockType.Error);

			// Act
			var result = mockDataSet.Where(query.getFilter().Compile());

			//Assert
			Assert.AreEqual(result.Count(), 2);
			Assert.False(result.Any(t => t.BlockOrigin == "Origin2"));
			Assert.False(result.Any(t => t.Type != LoggingBlockType.Error));
			Assert.True(result.All(t => t.BlockOrigin == "Origin1"));

		}
	}

	#region testclasses
	/// <summary>
	/// Just a test class to access the filter and test it
	/// </summary>
	internal class TestGetLoggingFromIdQuery : GetLoggingFromIdQuery
	{
		public TestGetLoggingFromIdQuery(string id) : base(id)
		{

		}
		public Expression<Func<LoggingBlockModel, bool>> getFilter()
		{
			return base._filter;
		}
	}

	internal class TestListAllLoggingFromTypeQuery : ListAllLoggingFromTypeQuery
	{
		public TestListAllLoggingFromTypeQuery(string blockName, LoggingBlockType loggingType) : base(blockName, loggingType)
		{

		}

		public Expression<Func<LoggingBlockModel, bool>> getFilter()
		{
			return base._filter;
		}
	}

	#endregion
}
