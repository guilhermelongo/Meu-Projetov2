using Meu_Projeto.Domain.Products;
using Meu_Projeto.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace Meu_Projeto.Endpoints.Categories;

public class CategoryDelete
{
    public static string Template => "/Categories/{id}";
    public static string[] Methods => new string[] { HttpMethod.Delete.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action([FromRoute] Guid id, ApplicationDbContext context)
    {
        var category = context.Categories.Where(q=> q.Id == id).FirstOrDefault();
        context.Categories.Remove(category);
        context.SaveChanges();
        return Results.Ok();
    }
}
