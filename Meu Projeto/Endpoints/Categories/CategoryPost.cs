using Meu_Projeto.Domain.Products;
using Meu_Projeto.Infra.Data;

namespace Meu_Projeto.Endpoints.Categories;

public class CategoryPost
{
    public static string Template => "/Categories";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action(categoryRequest categoryRequest, ApplicationDbContext context)
    {
        var category = new Category
        {
            Name = categoryRequest.Name,
            CreatedBy = "Teste",
            CreatedOn = DateTime.Now,
            EditeddBy = "Teste",
            EditedOn = DateTime.Now,
        };
        context.Categories.Add(category);
        context.SaveChanges();
        return Results.Created($"/categories/{ category.Id}", category.Id);
    }
}
