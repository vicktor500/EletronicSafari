using System.Data.Common;
using ElectronicSafari;
using Npgsql;

namespace ElectronicSafari.Repository;

public class UserRepository{
    private readonly DatabaseConnection _dbConnection;

    public UserRepository(DatabaseConnection databaseConnection){

        _dbConnection = databaseConnection;
    }

    public List<User> ListUser(){
        
        var user = new List<User>();

        using(var connection = _dbConnection.GetConnection()){
            
            using (var command = new NpgsqlCommand("Select id_usuario,nome,login,email from usuario"))
        }
    }
}
