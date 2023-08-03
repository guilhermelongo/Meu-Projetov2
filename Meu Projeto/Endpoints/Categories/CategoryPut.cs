using Meu_Projeto.Domain.Products;
using Meu_Projeto.Infra.Data;
using Microsoft.AspNetCore.Mvc;
using static System.Net.WebRequestMethods;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Meu_Projeto.Endpoints.Categories;

public class CategoryPut
{
    public static string Template => "/Categories/{id:guid}";
    public static string[] Methods => new string[] { HttpMethod.Put.ToString() };
    public static Delegate Handle => Action;
    [Authorize(Policy ="EmployeePolicy")]
    public static IResult Action([FromRoute] Guid id, HttpContext http, CategoryRequest categoryRequest, ApplicationDbContext context)
    {
        var userId = http.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;

        var category = context.Categories.Where(q => q.Id == id).FirstOrDefault();

        if (category == null)
        {
            return Results.NotFound();

        }

        category.EditInfo(categoryRequest.Name, categoryRequest.Active, userId);

        if (!category.IsValid)
        {
            return Results.ValidationProblem(category.Notifications.ConvertToProblemDetaills());

        }

        context.SaveChanges();

        return Results.Ok();
    }
}
