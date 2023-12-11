﻿using UltimateLibrary.BusinessLogic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UltimateLibrary.Interfaces;
using PerfectConsoleApp;
using UltimateLibrary.Helpers;

using IHost host = CreateHostBuilder(args).Build(); 
using var scope = host.Services.CreateScope();

var services = scope.ServiceProvider;

try
{
    services.GetRequiredService<App>().Run(args);
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}

static IHostBuilder CreateHostBuilder(string[] args)
{
    return Host.CreateDefaultBuilder(args)
        .ConfigureServices((_, services) => {
            services.AddSingleton<IMessages, Messages>();
            services.AddSingleton<IConsoleHelper, ConsoleHelper>();
            services.AddSingleton<IInputReader, InputReader>();
            services.AddSingleton<App>();
        });
}