using Dapper;
using Meu_Projeto.Endpoints.Categories;
using Microsoft.Data.SqlClient;

namespace Meu_Projeto.Infra.Data
{
    public class QueryAllUsersWithClaimName
    {
        private readonly IConfiguration configuration;
        public QueryAllUsersWithClaimName(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<IEnumerable<EmployeesResponse>> Execute(int page ,int rows)
        {
                var Dbctx = new SqlConnection(configuration["ConnectionString:MsSql"]);
                //Dapper
                var query =
                    @"select Email, ClaimValue as Name
                from AspNetUsers u inner join                                   
                 AspNetUserClaims c   
                    on u.id = c.UserId and claimtype = 'Name' order by name
                       OFFSET (@page -1) * @rows ROWS FETCH NEXT @rows ROWS ONLY ";
              return await Dbctx.QueryAsync<EmployeesResponse>(query, new { page, rows });
            
        }
    }
}
