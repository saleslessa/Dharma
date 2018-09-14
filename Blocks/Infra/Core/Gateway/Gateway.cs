// Gateway.cs
//
// Author:
//       Sales Alencar <lopesdealencar@gmail.com>
//
// Copyright (c) 2018 MIT
//
using System.Text;
using System.Linq;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace Dharma.Core.Gateway
{
  /// <summary>
  /// Gateway.
  /// </summary>
  public static class Gateway
  {
    /// <summary>
    /// Gets the gateway.
    /// </summary>
    /// <returns>The gateway.</returns>
    /// <param name="service">Service.</param>
    public static GatewayModel GetGateway(string service)
    {
      return new GatewayQuery<GatewayModel>(new GatewayModel() { Service = service }).Run().FirstOrDefault();
    }

    /// <summary>
    /// Method to communicate between blocks
    /// </summary>
    /// <param name="blockName">Block name.</param>
    /// <param name="verb">Verb.</param>
    /// <param name="body">Body.</param>
    public static T CallBlock<T>(string blockName, HttpVerbsEnum verb, dynamic body = null)
    {
      try
      {
        var request = (HttpWebRequest)WebRequest.Create(GetGateway(blockName).Location);
        request.ContentType = "application/json; charset=UTF-8";
        request.Accept = "application/json";

        request.Method = System.Enum.GetName(typeof(HttpVerbsEnum), verb);

        if(body != null)
        {
          //byte[] postBytes = Encoding.UTF8.GetBytes(body);
          request.ContentLength = body.Length;


          // TODO: Authentication
          using (var streamWriter = new StreamWriter(request.GetRequestStream()))
          {
            streamWriter.Write(body);
            streamWriter.Flush();
            streamWriter.Close();
          }
        }

        dynamic result;
        var httpResponse = (HttpWebResponse)request.GetResponse();
        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        {
          result = JsonConvert.DeserializeObject<T>(streamReader.ReadToEnd());
        }

        return result;
      }
      catch (System.Exception ex)
      {
        throw;
      }
    }
  }
}
