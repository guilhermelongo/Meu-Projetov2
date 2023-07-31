using Meu_Projeto.Domain.Products;
using Meu_Projeto.Infra.Data;

namespace Meu_Projeto.Endpoints.Categories;

public class CategoryGetAll
{
    public static string Template => "/Categories";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action( ApplicationDbContext context)
    {
        var category = context.Categories.ToList();

        var response = category.Select(c => new CategoryResponse {Id = c.Id, Active = c.Active, Name = c.Name });

        return Results.Ok(response);
    }
}
