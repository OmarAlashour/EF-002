using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

SqlConnection conn = new SqlConnection(configuration.GetSection("constr").Value);

var sql = "UPDATE Wallets SET Holder = @Holder, Balance = @Balance " +
    $"WHERE Id = @Id";

SqlParameter idParameter = new SqlParameter
{
    ParameterName = "@Id",
    SqlDbType = SqlDbType.Int,
    Direction = ParameterDirection.Input,
    Value = 12,
};
SqlParameter holderParameter = new SqlParameter
{
    ParameterName = "@Holder",
    SqlDbType = SqlDbType.VarChar,
    Direction = ParameterDirection.Input,
    Value = "Mohanned",
};

SqlParameter balanceParameter = new SqlParameter
{
    ParameterName = "@Balance",
    SqlDbType = SqlDbType.Decimal,
    Direction = ParameterDirection.Input,
    Value = 50000,
};

SqlCommand command = new SqlCommand(sql, conn);

command.Parameters.Add(idParameter);
command.Parameters.Add(holderParameter);
command.Parameters.Add(balanceParameter);

command.CommandType = CommandType.Text;

try
{
    conn.Open();
    if (command.ExecuteNonQuery() > 0)
    {
        Console.WriteLine("Wallet updated successfully");
    }
    else
    {
        Console.WriteLine("No rows were updated. Check if the row with Id = 1 exists.");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");
}
finally
{
    conn.Close();
}

Console.ReadKey();