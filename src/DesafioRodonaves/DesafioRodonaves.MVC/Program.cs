using DesafioRodonaves.Infra.Ioc;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
{

    builder.Services.AddControllers();
    // Add services to the container.
    builder.Services.AddControllersWithViews();

    // Adiciona serviço de documentação do swagger
    builder.Services.AddSwaggerGen();

    // Adiciona os serviços de injeção de depêndencia.
    builder.Services.AddInfrastructure(builder.Configuration);

    // Desabilita model state
    builder.Services.Configure<ApiBehaviorOptions>(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
    });
}


var app = builder.Build();
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        
    }
    // Configuração de middlewares: GlobalException,
    app.UseInfrastructure(builder.Configuration);

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();

}
    
