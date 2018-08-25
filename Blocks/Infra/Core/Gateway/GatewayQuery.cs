// Gateway.cs
//
// Author:
//       Sales Alencar <lopesdealencar@gmail.com>
//
// Copyright (c) 2018 MIT
//
using System;
using System.Linq.Expressions;

namespace Dharma.Core.Gateway
{
  internal class GatewayQuery<T> : BaseQuery<T> where T : GatewayModel, new()
  {

    T _model;

    public GatewayQuery(T model)
    {
      _model = model;
    }

    protected override string server => GatewayResources.Server;

    protected override int port => Convert.ToInt32(GatewayResources.Port);

    protected override string database => GatewayResources.Database;

    protected override string user => GatewayResources.User;

    protected override string pwd => GatewayResources.Pwd;

    protected override Expression<Func<T, bool>> _filter => (t => t.Service == _model.Service);

  }

}
