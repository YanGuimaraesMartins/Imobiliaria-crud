using System.Data.SqlClient;
using Imobiliaria.Models;

namespace Imobiliaria.Repositories
{
    public class ImovelRepository
    {
        private readonly string _connectionString;

       
        public ImovelRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<Imovel> ListarTodos(string bairro = null)
        {
            var lista = new List<Imovel>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Imoveis";
                if (!string.IsNullOrEmpty(bairro)) sql += " WHERE Bairro LIKE @bairro";

                SqlCommand cmd = new SqlCommand(sql, conn);
                if (!string.IsNullOrEmpty(bairro)) cmd.Parameters.AddWithValue("@bairro", "%" + bairro + "%");

                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Imovel
                        {
                            Id = (int)reader["Id"],
                            Titulo = reader["Titulo"].ToString(),
                            ValorAluguel = (decimal)reader["ValorAluguel"],
                            Bairro = reader["Bairro"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public void Inserir(Imovel imovel)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string sql = "INSERT INTO Imoveis (Titulo, ValorAluguel, Cidade, Bairro, Tipo) VALUES (@titulo, @valor, @cidade, @bairro, @tipo)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@titulo", imovel.Titulo);
                cmd.Parameters.AddWithValue("@valor", imovel.ValorAluguel);
                cmd.Parameters.AddWithValue("@cidade", imovel.Cidade ?? "");
                cmd.Parameters.AddWithValue("@bairro", imovel.Bairro);
                cmd.Parameters.AddWithValue("@tipo", imovel.Tipo ?? "");
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public Imovel ObterPorId(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Imoveis WHERE Id = @id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Imovel
                        {
                            Id = (int)reader["Id"],
                            Titulo = reader["Titulo"].ToString(),
                            ValorAluguel = (decimal)reader["ValorAluguel"],
                            Bairro = reader["Bairro"].ToString()
                        };
                    }
                }
            }
            return null;
        }

        public void Atualizar(Imovel imovel)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string sql = "UPDATE Imoveis SET Titulo=@titulo, ValorAluguel=@valor, Bairro=@bairro WHERE Id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", imovel.Id);
                cmd.Parameters.AddWithValue("@titulo", imovel.Titulo);
                cmd.Parameters.AddWithValue("@valor", imovel.ValorAluguel);
                cmd.Parameters.AddWithValue("@bairro", imovel.Bairro);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Excluir(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string sql = "DELETE FROM Imoveis WHERE Id = @id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}