using Meu_Projeto.Domain;

namespace Meu_Projeto.Endpoints.Categories
{
    public class CategoryRequest 
    {
        public string Name { get; set; }
        public bool Active { get; set; }
    }
}