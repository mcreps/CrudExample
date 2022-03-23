using System.Data.SqlClient;
using CrudExample.Models;
using Dapper;
using NLog;

namespace CrudExample.Data;

public class DataProvider
{
    private Logger _logger = LogManager.GetCurrentClassLogger();
    private string _connStr = "Server=DESKTOP-IFN84LU\\SQLEXPRESS;Database=FlightData;Trusted_Connection=True;";
    
    public Task<List<Car>> GetCars(string dbName)
    {
        _logger.Trace("Entering...");
        List<Car> results = new();
        const string sql = "SELECT * FROM [dbo].[Cars_Crud]";
        using SqlConnection conn = new(_connStr);
        try
        {
            conn.Open();
            conn.ChangeDatabase(dbName);
            results = conn.Query<Car>(sql).ToList();
            
            return Task.FromResult(results);
        }
        catch (Exception e)
        {
            _logger.Trace($"SQLException: {e.Message}");
        }
        return Task.FromResult(results);
    }
    
    public Task SaveCar(string dbName, Car car)
    {
        return Task.CompletedTask;
    }
    
    public Task DeleteCar(string dbName, string guid)
    {
        return Task.CompletedTask;
    }
}