

using Autofac;
using Autofac.Extensions.DependencyInjection;
using BrainStorming;
using BrainStorming.Connection;
using BrainStorming.Intrefaces;
using ClosedXML.Excel;
using Hangfire;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


IConfiguration config =  new ConfigurationBuilder()
                                    .AddJsonFile("appsetting.json")
                                    .AddEnvironmentVariables()
                                    .Build();
using IHost host = Host.CreateDefaultBuilder(args).
                   ConfigureServices((_, services) =>
                   {
                       services.AddScoped<ITestService, TestService>();
                       services.AddHangfire(x => x.UseSqlServerStorage(config.GetSection("Local").Value));
                       services.AddHangfireServer();
                   })
                   .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                   .ConfigureContainer<ContainerBuilder>(containerBuilder =>
                   {
                       containerBuilder.RegisterModule(new AutofacBusinessModule());
                   })
                   .Build();

GlobalConfiguration.Configuration.UseSqlServerStorage(config.GetSection("Local").Value);



var salamz = host.Services.GetRequiredService<IIsbService>();
//salamz.GetContracts();

//string? cons = config.GetSection("number").Value;

//ConnectionWithInsuarence insuarence = new(config);
//await insuarence.GetContracts();



//IsbService connectionWithISB = new(config);
//await connectionWithISB.GetContracts();


///XML Excel
//using (var workbook = new XLWorkbook())
//{
//    var worksheet = workbook.AddWorksheet("Students");
//    var currrentRow = 1;
//    worksheet.Cell(currrentRow,1).Value = "StudentId";
//    worksheet.Cell(currrentRow,2).Value = "Name";
//    worksheet.Cell(currrentRow, 2).Value = "Roll";
//    workbook.SaveAs("Salam.xlsx");
//}


//int b = int.Parse(Console.ReadLine()!);
//int c = b + 5;

//Model model = new();
//model.Number = 1;
//AddMethod add = new();
//var salam = add.Add(model);



//Console.WriteLine(cons);


//using (var server = new BackgroundJobServer())
//{
//    Console.WriteLine("Hangfire Server started. Press any key to exit...");
//    Console.ReadKey();
//}

RecurringJob.AddOrUpdate<ITestService>("getConsole", m => m.TestMe(), Cron.Minutely);

using (var server = new BackgroundJobServer())
{
    Console.WriteLine("Hangfire Server started. Press any key to exit...");
    Console.ReadKey();
}

