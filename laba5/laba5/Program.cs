var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();// Добавляет Swagger
builder.Services.AddSwaggerGen();// Добавляет Swagger

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())// Включает Swagger в режиме разработки
{
    app.UseSwagger();// Включает Swagger
    app.UseSwaggerUI();// Включает Swagger UI
}

app.UseHttpsRedirection();// Включает перенаправление HTTP-запросов на HTTPS
app.UseAuthorization();// Включает авторизацию

app.MapControllers();// Добавляет контроллеры

app.Run();// Запускает приложение
