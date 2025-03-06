using NovaAPI.api.Configuration;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Para a program.cs, recomendo criar uma extension s� para a inje��o de depend�ncia e por camada
// Por exemplo, quando voc� tiver a sua camada de services, voc� pode criar uma extension s� para ela fazer as inje��es 
// Lembre: A inje��o de depend�ncia � feita por camada, ent�o voc� pode ter uma extension para cada camada
// Lembre 2: As extensions podem ser criadas em um projeto separado, por exemplo, NovaAPI.infra mas n�o � aconselh�vel pois criar� um acoplamento entre os projetos
// Lembre 3: Normalmente criamos extensios por assunto, por exemplo, uma extension para inje��o de depend�ncia, outra para configura��o de swagger, outra para configura��o de banco de dados, etc.
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
