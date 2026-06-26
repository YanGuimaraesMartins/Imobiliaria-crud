namespace Imobiliaria.Models
{
    public class Imovel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public decimal ValorAluguel { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Tipo { get; set; } 
    }
}
