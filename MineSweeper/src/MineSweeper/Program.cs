using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MineSweeper.Core;
using MineSweeper.Core.Abstractions;

var host = CreateHostBuilder(args).Build();

using var loggerFactory = LoggerFactory.Create(loggingBuilder => loggingBuilder
    .SetMinimumLevel(LogLevel.Trace)
    .AddConsole());

var logger = host.Services.GetRequiredService<ILoggerFactory>().CreateLogger<Program>();
logger.LogDebug("Starting application");

var gameController = host.Services.GetRequiredService<IGameController>();
gameController.Start();

static IHostBuilder CreateHostBuilder(string[] args)
{
    return Host.CreateDefaultBuilder(args)
        .ConfigureServices(
            (_, services) => services
                .AddSingleton<IPlayerView, PlayerView>()
                .AddSingleton<IMineGenerator, MineGenerator>()
                .AddSingleton<IMineSweeperBoard, MineSweeperBoard>()
                .AddSingleton<IGameController, MineSweeperController>()
        );
}