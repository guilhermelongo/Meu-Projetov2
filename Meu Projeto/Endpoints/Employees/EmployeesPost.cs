
using Meu_Projeto.Endpoints.Categories;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Meu_Projeto.Endpoints.Employees;

public class EmployeesPost
{
    public static string Template => "/employees";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action(EmployeesRequest employeesRequest, UserManager<IdentityUser> userManager )
    {

        var user = new IdentityUser {UserName = employeesRequest.Email, Email = employeesRequest.Email };

        var result = userManager.CreateAsync(user, employeesRequest.password).Result;

        if (!result.Succeeded)
        {
            return Results.ValidationProblem(result.Errors.ConvertToProblemDetaills());
        }
        var userClaims = new List<Claim>
        {
            new Claim("EmployeeCode", employeesRequest.EmployeesCode),
            new Claim("Name", employeesRequest.Name)
        };
        var claimResult = userManager.AddClaimsAsync(user, userClaims).Result;
        if (!claimResult.Succeeded)
        {
            return Results.BadRequest(claimResult.Errors.First());
        }
        
        return Results.Created($"/employees/{user.Id}", user.Id);


    }
}
