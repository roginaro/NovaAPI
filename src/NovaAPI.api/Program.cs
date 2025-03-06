using NovaAPI.api.Configuration;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Para a program.cs, recomendo criar uma extension só para a injeção de dependência e por camada
// Por exemplo, quando você tiver a sua camada de services, você pode criar uma extension só para ela fazer as injeções 
// Lembre: A injeção de dependência é feita por camada, então você pode ter uma extension para cada camada
// Lembre 2: As extensions podem ser criadas em um projeto separado, por exemplo, NovaAPI.infra mas não é aconselhável pois criará um acoplamento entre os projetos
// Lembre 3: Normalmente criamos extensios por assunto, por exemplo, uma extension para injeção de dependência, outra para configuração de swagger, outra para configuração de banco de dados, etc.
builder.Services.AddNovaAPIConfiguration();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
