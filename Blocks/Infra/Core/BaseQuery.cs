// BaseQuery.cs
//
// Author:
//       Sales Alencar <lopesdealencar@gmail.com>
//
// Copyright (c) 2018 MIT
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MongoDB.Driver;

namespace Dharma.Core
{
	/// <summary>
	/// Base class to be used by all Query classes (CQRS pattern). To use this class you have to:
	/// - Associate the class to a Model class
	/// - Implement the filter parameter based on your Model class
	/// - Create your own parameter filter on your child classes through class properties and filling on class constructor
	/// </summary>
  public abstract class BaseQuery<T> : BaseConnection<T> where T : BaseModel, new()
	{
		/// <summary>
		/// Filter
		/// </summary>
		/// <value>The filter.</value>
    protected abstract Expression<Func<T, bool>> _filter { get; }

    /// <summary>
    /// Implemented method that will get the block connection and run the query against its database instance
    /// </summary>
    /// <returns>A list of models that matches the criteria</returns>
    public IEnumerable<T> Run() 
    {
      return GetConnection().Find(_filter).ToList();  
    }

	}
}
