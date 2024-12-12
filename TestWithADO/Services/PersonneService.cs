using TestWithADO.Models;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
namespace TestWithADO.Services
{
    public class PersonneService
    {
    
            private readonly string _connectionString;

            public PersonneService(IConfiguration configuration)
            {
                _connectionString = configuration.GetConnectionString("DefaultConnection");
            }

            // Récupérer toutes les personnes
            public List<Personne> GetAllPersonnes()
            {
                var personnes = new List<Personne>();

                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT PersonneID, Nom, Prenom, DateNaissance FROM Personne";

                    using (var command = new SqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                personnes.Add(new Personne
                                {
                                    PersonneID = reader.GetInt32(0),
                                    Nom = reader.GetString(1),
                                    Prenom = reader.GetString(2),
                                    DateNaissance = reader.GetDateTime(3)
                                });
                            }
                        }
                    }
                }

                return personnes;
            }

            // Ajouter une personne
            public void AddPersonne(Personne personne)
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Personne (Nom, Prenom, DateNaissance) VALUES (@Nom, @Prenom, @DateNaissance)";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nom", personne.Nom);
                        command.Parameters.AddWithValue("@Prenom", personne.Prenom);
                        command.Parameters.AddWithValue("@DateNaissance", personne.DateNaissance);
                        command.ExecuteNonQuery();
                    }
                }
            }

            // Mettre à jour une personne
            public void UpdatePersonne(Personne personne)
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Personne SET Nom = @Nom, Prenom = @Prenom, DateNaissance = @DateNaissance WHERE PersonneID = @PersonneID";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nom", personne.Nom);
                        command.Parameters.AddWithValue("@Prenom", personne.Prenom);
                        command.Parameters.AddWithValue("@DateNaissance", personne.DateNaissance);
                        command.Parameters.AddWithValue("@PersonneID", personne.PersonneID);
                        command.ExecuteNonQuery();
                    }
                }
            }

            // Supprimer une personne
            public void DeletePersonne(int id)
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Personne WHERE PersonneID = @PersonneID";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PersonneID", id);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }
    }
