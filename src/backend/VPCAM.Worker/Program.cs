using MassTransit;
using Microsoft.EntityFrameworkCore;
using VPCAM.Worker.Consumers;
using VPCAM.Worker.Data;
using VPCAM.Worker.Services;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddDbContext<WorkerDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSingleton<IVideoProcessor, MockVideoProcessor>();

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<VideoProcessedConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", "/", h => {
            h.Username("guest");
            h.Password("guest");
        });

        cfg.ReceiveEndpoint("video-processing-queue", e =>
        {
            e.ConfigureConsumer<VideoProcessedConsumer>(context);
        });
    });
});

var host = builder.Build();
host.Run();

