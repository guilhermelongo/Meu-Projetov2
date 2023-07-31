
using Dapper;
using Meu_Projeto.Endpoints.Categories;
using Meu_Projeto.Infra.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System.Security.Claims;

namespace Meu_Projeto.Endpoints.Employees;

public class EmployeesGetAll
{
    public static string Template => "/employees";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action(int? page, int? rows, QueryAllUsersWithClaimName query)
    {


        #region Paginação
        //var users = userManager.Users.Skip((page - 1)* rows).Take(rows).ToList();
        // var employees = new List<EmployeesResponse>();
        // foreach ( var item in users )
        // {
        //     var claims = userManager.GetClaimsAsync(item).Result;
        //     var claimName = claims.FirstOrDefault(c=> c.Type == "Name");
        //     var userName = claimName != null ? claimName.Value : string.Empty;
        //     employees.Add(new EmployeesResponse(item.Email, userName));
        // }
        //return Results.Ok(employees);
        #endregion
        if (page.HasValue && rows <= 10)
            return Results.Ok(query.Execute(page.Value, rows.Value));

        else
            return Results.BadRequest("Parametros Inconsistentes");
    }

}
