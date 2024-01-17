using DesafioRodonaves.Infra.Ioc;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.
    builder.Services.AddControllersWithViews();

    // Adiciona servi�o de documenta��o do swagger
    builder.Services.AddSwaggerGen();

    // Adiciona os servi�os de inje��o de dep�ndencia.
    builder.Services.AddInfrastructure(builder.Configuration);
}


var app = builder.Build();
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        
    }


    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();

}
    
