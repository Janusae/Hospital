var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI();
    app.UseSwagger();
    app.Use(async (context, next) =>
    {
        context.Response.Redirect("swagger/index.html");
        return;
        await next();
    }
    );
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
