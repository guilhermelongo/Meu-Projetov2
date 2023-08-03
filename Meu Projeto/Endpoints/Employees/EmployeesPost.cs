
using Meu_Projeto.Endpoints.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Meu_Projeto.Endpoints.Employees;

public class EmployeesPost
{
    public static string Template => "/employees";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;
    [Authorize(Policy = "EmployeePolicy")]
    public static async Task<IResult> Action(EmployeesRequest employeesRequest,HttpContext http ,UserManager<IdentityUser> userManager )
    {
        var userId = http.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
        var newUser = new IdentityUser {UserName = employeesRequest.Email, Email = employeesRequest.Email };

        var result = await userManager.CreateAsync(newUser, employeesRequest.password);

        if (!result.Succeeded)
        {
            return Results.ValidationProblem(result.Errors.ConvertToProblemDetaills());
        }
        var userClaims = new List<Claim>
        {
            new Claim("EmployeeCode", employeesRequest.EmployeesCode),
            new Claim("Name", employeesRequest.Name),
            new Claim ("CreateBy", employeesRequest.Name),
        };
        var claimResult = await userManager.AddClaimsAsync(newUser, userClaims);
        if (!claimResult.Succeeded)
        {
            return Results.BadRequest(claimResult.Errors.First());
        }
        
        return Results.Created($"/employees/{newUser.Id}", newUser.Id);


    }
}
