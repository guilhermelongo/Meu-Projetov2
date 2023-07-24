namespace Meu_Projeto.Domain.Products;

public class Products : Entity
{
    public Guid CategoryId { get; set; }
    public string Description { get; set; }
    public Category category { get; set; }
    public bool HasStock { get; set; }
    public bool Active { get; set; } = true;


}
