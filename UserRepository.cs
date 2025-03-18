
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
                            Name = reader.GetString(1),
                            Login = reader.GetString(2),
                            Email = reader.GetString(3),
                            Photo = reader.IsDBNull(4)? null: reader.GetString(4),
                        });
                    }
                }
            }
        }
        return users;
    }

}
