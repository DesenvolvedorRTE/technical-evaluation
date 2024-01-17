using DesafioRodonaves.Infra.Ioc;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
{

    builder.Services.AddControllers();
    // Add services to the container.
    builder.Services.AddControllersWithViews();

    // Adiciona servi�o de documenta��o do swagger
    builder.Services.AddSwaggerGen();

    // Adiciona os servi�os de inje��o de dep�ndencia.
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
    // Configura��o de middlewares: GlobalException,
    app.UseInfrastructure(builder.Configuration);

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();

}
    
