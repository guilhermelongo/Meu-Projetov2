using Meu_Projeto.Endpoints.Categories;
using Meu_Projeto.Endpoints.Employees;
using Meu_Projeto.Infra.Data;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSqlServer<ApplicationDbContext>(builder.Configuration["ConnectionString:MsSql"]);
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<QueryAllUsersWithClaimName>();

var app = builder.Build();
app.MapMethods(EmployeesPost.Template, EmployeesPost.Methods, EmployeesPost.Handle);
app.MapMethods(EmployeesGetAll.Template, EmployeesGetAll.Methods, EmployeesGetAll.Handle);
app.MapMethods(CategoryGetAll.Template, CategoryGetAll.Methods, CategoryGetAll.Handle);
app.MapMethods(CategoryPut.Template, CategoryPut.Methods, CategoryPut.Handle);
app.MapMethods(CategoryDelete.Template, CategoryDelete.Methods, CategoryDelete.Handle);



app.Run();

