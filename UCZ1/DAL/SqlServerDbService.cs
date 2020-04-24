using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using UCZ1.DTOs.Requests;

namespace UCZ1.DAL
{
    public class SqlServerDbService : IDbService
    {
        private readonly string connectionString = "Data Source=db-mssql.pjwstk.edu.pl; Initial Catalog = s18445; Integrated Security = True";
    
    public GetAnimalsResponse GetAnimals(string orderBy)
        {
            GetAnimalsResponse response;
            if(orderBy == null)
            {
                orderBy = "AdmissionDate";
            }

            using(var connection = new SqlConnection(connectionString))
            using(var command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = $"SELECT Name, Type, AdmissionDate, OWNER.LastName FROM ANIMAL,OWNER  where ANIMAL.IdOwner=OWNER.IdOwner ORDER BY {orderBy}";
                //command.Parameters.AddWithValue("orderBy", orderBy);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        throw new Exception("Error brak danych");
                    }

                    while (reader.Read())
                    {
                        response = new GetAnimalsResponse
                        {
                            Name = reader["Name"].ToString(),
                            AnimalType = reader["Type"].ToString(),
                            DateOfAdmission = DateTime.Parse(reader["AdmissionDate"].ToString()),
                            LastNameOfOwner = reader["LastName"].ToString()
                        };
                    }

                }
                
            }
            return response;

        }
    
    }
}
