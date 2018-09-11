// ItemModelTests.cs
//
// Author:
//       Sales Alencar <lopesdealencar@gmail.com>
//
// Copyright (c) 2018 MIT
//
using System;
using System.Linq;
using Dharma.ItemsBlock.Models;
using NUnit.Framework;

namespace ItemsBlock.Models.Tests
{
	[TestFixture]
	public class ItemModelTests
	{
		[TestCase("")]
		[TestCase(" ")]
		public void ItemModelValidateName_Should_HaveValidationRegardingName(string param)
		{
			// Arrange
			var model = new ItemModel() { Name = param };

			// Act
			var result = model.IsValid();

			// Assert
			Assert.False(result);
			Assert.True(model.ValidationResult.Errors.Any(t => t.Value == "Invalid Name"));
		}

		[TestCase("Some name")]
		public void ItemModelValidateName_Should_NotHaveValidationRegardingName(string param)
		{
			// Arrange
			var model = new ItemModel() { Name = param };

			// Act
			var result = model.IsValid();

			// Assert
			Assert.False(result);
			Assert.False(model.ValidationResult.Errors.Any(t => t.Value == "Invalid Name"));
		}

		[TestCase("cat1", "cat2", "cat3")]
		public void ItemHasNoDuplicateCategories_Should_HaveValidCategories(string p1, string p2, string p3)
		{
			// Arrange
			var model = new ItemModel() { Categories = new string[]{p1, p2, p3}.AsEnumerable() };

			// Act
			var result = model.IsValid();

			// Assert
			Assert.False(result);
			Assert.False(model.ValidationResult.Errors.Any(t => t.Value == "Category missing"));
		}

		[TestCase("cat1", "", "cat1")]
		[TestCase(" ", "", "")]
		[TestCase(" ", " ", "")]
		public void ItemHasNoDuplicateCategories_Should_HaveInvalidModel(string p1, string p2, string p3)
		{
			// Arrange
			var model = new ItemModel() { Categories = new string[] { p1, p2, p3 }.AsEnumerable() };

			// Act
			var result = model.IsValid();

			// Assert
			Assert.False(result);
			Assert.True(model.ValidationResult.Errors.Any(t => t.Value == "Category missing"));
		}

		[Test]
		public void ItemHasValidTypeAndAmount_Should_HaveValidModelRegardingAmountAndType()
		{
			// Arrange
			var model = new ItemModel() { Amount = 10, Type = ItemType.Amount };

			// Act
			var result = model.IsValid();

			// Assert
			Assert.False(result);
			Assert.False(model.ValidationResult.Errors.Any(t => t.Value == "Item Type requires quantity"));

		}

		[Test]
		public void ItemHasValidTypeAndAmount_Should_HaveInvalidModelRegardingAmountAndType()
		{
			// Arrange
			var modelAmount = new ItemModel() { Amount = null, Type = ItemType.Amount };
			var modelService = new ItemModel() { Amount = null, Type = ItemType.Service };
			var modelHours = new ItemModel() { Amount = null, Type = ItemType.Hour };

			// Act
			var resultAmount = modelAmount.IsValid();
			var resultService = modelService.IsValid();
			var resultHours = modelHours.IsValid();

			// Assert
			Assert.True(resultAmount == resultService == resultHours == false);
			Assert.True(modelAmount.ValidationResult.Errors.Any(t => t.Value == "Item Type requires quantity"));
			Assert.False(modelService.ValidationResult.Errors.Any(t => t.Value == "Item Type requires quantity"));
			Assert.False(modelHours.ValidationResult.Errors.Any(t => t.Value == "Item Type requires quantity"));

		}
	}
}
