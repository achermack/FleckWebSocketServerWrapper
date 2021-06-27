using Fleck;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http.Features;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace WebSocketServerWrapper
{
    public class WebSocketServerWrapper : IServer
    {
        private readonly string _serverString;
        private readonly Action<IWebSocketConnection> _config;
        public WebSocketServerWrapper(string serverString, Action<IWebSocketConnection> config)
        {
            _serverString = serverString;
            _config = config;
        }
        public IFeatureCollection Features => new FeatureCollection();

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public Task StartAsync<TContext>(IHttpApplication<TContext> application, CancellationToken cancellationToken) where TContext : notnull
        {
            Task startFleckServer = Task.Factory.StartNew(() =>
            {
                new WebSocketServer(_serverString).Start(_config);
            });
            return startFleckServer;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}