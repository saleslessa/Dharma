// BaseConnection.cs
//
// Author:
//       Sales Alencar <lopesdealencar@gmail.com>
//
// Copyright (c) 2018 MIT
using System;
using MongoDB.Driver;

namespace Dharma.Core
{
  /// <summary>
  /// Base connection.
  /// </summary>
  public abstract class BaseConnection<T> where T : BaseModel, new()
  {
    /// <summary>
    /// Gets the server.
    /// </summary>
    /// <value>The server.</value>
    protected abstract string server { get; }

    /// <summary>
    /// Gets the port.
    /// </summary>
    /// <value>The port.</value>
    protected abstract int port { get; }

    /// <summary>
    /// Gets the database.
    /// </summary>
    /// <value>The database.</value>
    protected abstract string database { get; }

    /// <summary>
    /// Gets the user.
    /// </summary>
    /// <value>The user.</value>
    protected abstract string user { get; }

    /// <summary>
    /// Gets the pwd.
    /// </summary>
    /// <value>The pwd.</value>
    protected abstract string pwd { get; }

    /// <summary>
    /// Method to be implemented by child classes and has to return the database instance where target block's data relies on
    /// </summary>
    /// <returns>The connection.</returns>
    protected IMongoCollection<T> GetConnection()
    {
      var client = new MongoClient(new MongoClientSettings()
      {
        Server = new MongoServerAddress(server, port),
        ReadEncoding = new System.Text.UTF8Encoding(false, false),
        Credential = MongoCredential.CreateCredential(database, user, pwd)
      });

      var db = client.GetDatabase(database);
      return db.GetCollection<T>((new T()).ToString());
    }
  }
}
