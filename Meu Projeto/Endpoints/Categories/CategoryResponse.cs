using Meu_Projeto.Domain.Products;
using Meu_Projeto.Infra.Data;

namespace Meu_Projeto.Endpoints.Categories;

public class CategoryResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool Active { get; set; }

}
