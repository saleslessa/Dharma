﻿// CommandsTests.cs
//
// Author:
//       Sales Alencar <lopesdealencar@gmail.com>
//
// Copyright (c) 2018 MIT

using Dharma.LoggingBlock.Components.Commands;
using Dharma.LoggingBlock.Models;
using NUnit.Framework;

namespace Dharma.LoggingBlock.Components.Tests
{
	[TestFixture]
	public class CommandsTests
	{
		[Test]
		public void AddLoggingCommand_Should_LogSuccessfuly()
		{
			// Arrange
			var model = new LoggingBlockModel("TestBlock", "Some message", LoggingBlockType.Error);
			var command = new LoggingBlockBaseCommand(model);

			// Act
			command.Add();

			// Assert
			Assert.True(command.SuccessfulOperation);
		}
	}
}
