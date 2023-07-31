using Meu_Projeto.Domain.Products;
using Meu_Projeto.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace Meu_Projeto.Endpoints.Categories;

public class CategoryPut
{
    public static string Template => "/Categories/{id:guid}";
    public static string[] Methods => new string[] { HttpMethod.Put.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action([FromRoute] Guid id, CategoryRequest categoryRequest, ApplicationDbContext context)
    {
        var category = context.Categories.Where(q => q.Id == id).FirstOrDefault();

        if (category == null)
        {
            return Results.NotFound();

        }

        category.EditInfo(categoryRequest.Name, categoryRequest.Active);

        if (!category.IsValid)
        {
            return Results.ValidationProblem(category.Notifications.ConvertToProblemDetaills());

        }

        context.SaveChanges();

        return Results.Ok();
    }
}
