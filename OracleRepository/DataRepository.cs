using Oracle.ManagedDataAccess.Client;
using OracleRepository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OracleRepository
{
    public class DataRepository<TEntity> where TEntity : Entity
    {
        OracleConnection connection = OracleDataContext.GetConnection();
       
        public TEntity Get(int id)
        {
            connection.Open();
            OracleCommand command = connection.CreateCommand();
            if(typeof(TEntity) == typeof(User))
            command.CommandText = "";
            OracleDataReader reader = command.ExecuteReader();
            if(reader.Read())
            {
               
            }

            connection.Close();
        }
    }
}
