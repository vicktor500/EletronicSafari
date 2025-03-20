using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ElectronicSafari.Models;
using Npgsql;
using System.Data;
using Microsoft.AspNetCore.Identity.UI.Services;

public class DatabaseConnection
{
    private readonly String? _connectionString;

    public DatabaseConnection(IConfiguration configuration)
{
#pragma warning disable CS8601
          _connectionString = configuration.GetConnectionString("DefaultConnection");
#pragma warning restore CS8601
}

    public NpgsqlConnection GetConnection()
    {
        var connection = new NpgsqlConnection(_connectionString);
        connection.Open();
        return connection;
    }
}
