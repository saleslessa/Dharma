﻿// Model.cs
//
// Author:
//       Sales Alencar <lopesdealencar@gmail.com>
//
// Copyright (c) 2018 MIT
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dharma.Core
{
	/// <summary>
	/// Base class for all models of the project
	/// </summary>
	public abstract class BaseModel
	{

    /// <summary>
    /// Autogenerated Id of loggign message
    /// </summary>
    /// <value>The identifier.</value>
    [Key]
    public string Id { get; set; }

    /// <summary>
    /// Validation property of a model
    /// </summary>
    [NotMapped]
    public ValidationResult ValidationResult { get; }

		/// <summary>
		/// Initializes a new instance of the <see cref="T:Dharma.AbstractBlock.Model"/> class.
		/// </summary>
		public BaseModel()
		{
			ValidationResult = new ValidationResult();
		}

		/// <summary>
		/// Validate this instance.
		/// </summary>
		protected abstract void Validate();

    /// <summary>
    /// Ises the valid.
    /// </summary>
    /// <returns><c>true</c>, if valid was ised, <c>false</c> otherwise.</returns>
		public bool IsValid()
		{
			this.Validate();
			return this.ValidationResult.IsValid();
		}

    public override string ToString()
    {
      return this.GetType().Name;
    }
  }
}
