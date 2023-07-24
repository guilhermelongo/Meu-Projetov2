using Meu_Projeto.Domain.Products;
using Meu_Projeto.Infra.Data;

namespace Meu_Projeto.Endpoints.Categories;

public class CategoryPost
{
    public static string Template => "/Categories";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action(CategoryRequest categoryRequest, ApplicationDbContext context)
    {
        var response = context.Categories.Where(q=> q.Name == categoryRequest.Name).FirstOrDefault();
        if(response == null)
        {
            var newcategory = new Category
            {
                Name = categoryRequest.Name,
                CreatedBy = "Teste",
                CreatedOn = DateTime.Now,
                EditeddBy = "Teste",
                EditedOn = DateTime.Now,
            };

            context.Categories.Add(newcategory);
            context.SaveChanges();
            return Results.Created($"/categories/{newcategory.Id}", newcategory.Id);

        }
        return Results.Conflict("Produto ja Existe");

    }
}
