# Fleck WebSocketServer Wrapper

This library provides a WebSocketServerWrapper around Fleck to use in ASP.NET Core Applications (as opposed to Kestrel or others)

Usage:
First, create a ASP.NET Core web project or use an existing one and configure as follows:

``` csharp
// In Program.cs
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseServer(new WebSocketServerWrapper("ws://0.0.0.0:8181", socket =>
                    {
                            socket.OnOpen = () => Console.WriteLine("Open!");
                            socket.OnClose = () => Console.WriteLine("Close!");
                            socket.OnMessage = message => socket.Send(message);
                    }));
                    webBuilder.UseStartup<Startup>();
                });

```