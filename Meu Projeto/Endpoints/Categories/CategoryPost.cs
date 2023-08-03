using Meu_Projeto.Domain.Products;
using Meu_Projeto.Infra.Data;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Meu_Projeto.Endpoints.Categories;

public class CategoryPost
{
    public static string Template => "/Categories";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;
    //[AllowAnonymous]
    [Authorize]
    public static async Task<IResult> Action(CategoryRequest categoryRequest,HttpContext http, ApplicationDbContext context)
    {
        var userId =  http.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
        var newcategory = new Category(categoryRequest.Name, userId, userId);
    
        if (!newcategory.IsValid)
        {
            return Results.ValidationProblem(newcategory.Notifications.ConvertToProblemDetaills());
        }
        
          
        

       await context.Categories.AddAsync(newcategory);
       await context.SaveChangesAsync();
        return Results.Created($"/categories/{newcategory.Id}", newcategory.Id);



    }
}
