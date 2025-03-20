
using Microsoft.AspNetCore.Mvc;
using ElectronicSafari.Models;
using Npgsql;
using System.Data;
using Microsoft.AspNetCore.Identity.UI.Services;


namespace ElectronicSafari.Repository;

public class UserRepository{
    private readonly DatabaseConnection _dbConnection;
    private readonly IWebHostEnvironment _webHostEnvironmen;

    public UserRepository(DatabaseConnection databaseConnection,IWebHostEnvironment webHostEnvironment){

        _dbConnection = databaseConnection;
        _webHostEnvironmen = webHostEnvironment;
    }

    public List<User> ListUser()
    {
      
        var users = new List<User>();

        using (var connection = _dbConnection.GetConnection()){
            
            using (var command = new NpgsqlCommand("Select id_usuario,nome,login,email from usuario",(NpgsqlConnection)connection))
            {
                using (var reader = command.ExecuteReader()){

                    while(reader.Read())
                    {
                        users.Add(new User
                        {
                            Id = reader.GetInt32(0),
                            Nome = reader.GetString(1),
                            Login = reader.GetString(2),
                            Tipo = reader.GetString(3),
                            Foto = reader.IsDBNull(4)? null: reader.GetString(4),
                        });
                    }
                }
            }
        }
        return users;
    }



public async Task InsertUser(User user, IFormFile arquivo)
{
    string caminhoArquivo = await Upload(arquivo,"img");

    using (var connection = _dbConnection.GetConnection())
    {
        using (var command = connection.CreateCommand())
        {
            
            command.CommandText = "INSERT INTO usuario(nome,login,senha,tipo,foto) values (@nome,@login,@senha,@tipo,@foto)";

            var nomeParam = command.CreateParameter();
            nomeParam.ParameterName = "@nome";
            nomeParam.Value = user.Nome;
            command.Parameters.Add(nomeParam);

            var loginParam = command.CreateParameter();
            loginParam.ParameterName = "@login";
            loginParam.Value = user.Login;
            command.Parameters.Add(loginParam);

            var senhaParam = command.CreateParameter();
            senhaParam.ParameterName = "@senha";
            senhaParam.Value = user.Senha;
            command.Parameters.Add(senhaParam);

            var tipoParam = command.CreateParameter();
            tipoParam.ParameterName = "@tipo";
            tipoParam.Value = user.Tipo;
            command.Parameters.Add(nomeParam);

            user.Foto = caminhoArquivo;
            var fotoParam = command.CreateParameter();
            fotoParam.ParameterName = "@foto";
            fotoParam.Value = user.Foto;
            command.Parameters.Add(fotoParam);

            command.ExecuteNonQuery();
        }
    }
}

    public async Task<string> Upload(IFormFile arquivo, string pasta)
    {   
        if(arquivo == null || arquivo.Length == 0)
        {
            return "";
        }
        string caminhoPasta = Path.Combine(_webHostEnvironmen.WebRootPath,pasta);

            if(!Directory.Exists(caminhoPasta))
            Directory.CreateDirectory(caminhoPasta);

        string nomeArquivo = Guid.NewGuid().ToString()+Path.GetExtension(arquivo.FileName);
        string caminhoCompleto = Path.Combine(caminhoPasta,nomeArquivo);

        using(var strem = new FileStream)

    }
}