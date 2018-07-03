using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using LostInTheWoods.Models;
 
namespace LostInTheWoods.Factory
{
    public class TrailFactory : IFactory<Trail>
    {
        private string connectionString;
        public TrailFactory()
        {
            connectionString = "server=localhost;userid=root;password=root;port=3306;database=Trails;SslMode=None";
        }
        internal IDbConnection Connection
        {
            get {
                return new MySqlConnection(connectionString);
            }
        }

        public void Add(Trail item){
            using(IDbConnection dbConnection = Connection){
                string query = "INSERT INTO Trail (trailName, Description, trailLength, elevationChange, Longitude, Latitude) VALUES (@trailName,@Description,@trailLength,@elevationChange,@Longitude,@Latitude)";
                dbConnection.Open();
                dbConnection.Execute(query,item);
            }
        }

        public IEnumerable<Trail> FindAll(){
            using(IDbConnection dbConnection = Connection){
                dbConnection.Open();
                return dbConnection.Query<Trail>("SELECT * FROM Trail");
            }
        }

        public Trail FindByID(int id){
            using (IDbConnection dbConnection = Connection){
                dbConnection.Open();
                return dbConnection.Query<Trail>("SELECT * FROM Trail WHERE id = @ID", new Trail{Id = id}).FirstOrDefault();
            }
        }
    }
}
