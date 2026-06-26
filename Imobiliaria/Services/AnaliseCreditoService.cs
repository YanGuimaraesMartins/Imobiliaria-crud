namespace Imobiliaria.Services
{
    public class AnaliseCreditoService
    {
        public async Task<bool> ConsultarScoreSoap(string cpf)
        {
            
            return await Task.Run(() => {
                
                return cpf.Length == 11;
            });
        }
    }
}