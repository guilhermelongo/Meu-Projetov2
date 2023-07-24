using Meu_Projeto.Endpoints.Categories;
using Meu_Projeto.Infra.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSqlServer<ApplicationDbContext>(builder.Configuration["ConnectionString:MsSql"]);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.MapMethods(CategoryPost.Template, CategoryPost.Methods, CategoryPost.Handle);

app.Run();

