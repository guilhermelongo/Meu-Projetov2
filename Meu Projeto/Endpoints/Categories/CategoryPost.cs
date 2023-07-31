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

        var newcategory = new Category(categoryRequest.Name, "Teste", "Teste");
    
        if (!newcategory.IsValid)
        {
            return Results.ValidationProblem(newcategory.Notifications.ConvertToProblemDetaills());
        }
        
          
        

        context.Categories.Add(newcategory);
        context.SaveChanges();
        return Results.Created($"/categories/{newcategory.Id}", newcategory.Id);



    }
}
