using ManagementSystem.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagementSystem.Repository
{
    public class Repository<TEntity> where TEntity : Entity
    {
        public TEntity Get(int id)
        {
            OracleConnection connection = OracleDataContext.GetConnection();
            connection.Open();
            OracleCommand command = connection.CreateCommand();
            OracleDataReader reader = null;
            if(typeof(TEntity) == typeof(Person))
            {
                Person person = null;
                command.CommandText = "select * from meal_user where id = " + id;
                reader = command.ExecuteReader();
                if(reader.Read())
                {
                    person = new Person { Id = reader.GetInt32(0), Name = reader.GetString(1), IsAdmin = reader.GetInt32(2) == 1, Email = reader.GetString(3), PhoneNo = reader.GetString(4) };
                }

                connection.Close();
                return person as TEntity;
            }

            return null;
            
        }
        
        public User CheckValidLogin(User user)
        {
            OracleConnection connection = OracleDataContext.GetConnection();
            connection.Open();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "select id, is_valid from user_table where username = '" + user.Username + "' and password = '" + user.Password + "'";
            OracleDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                user.Id = reader.GetInt32(0);
                user.IsValid = reader.GetInt32(1) == 1;
            }

            return user;

        }

        public void Save(TEntity entity)
        {
            OracleConnection connection = OracleDataContext.GetConnection();
            connection.Open();
            OracleCommand command = connection.CreateCommand();
            if(typeof(TEntity) == typeof(Person))
            {
                Person p = entity as Person;
                command.CommandText = "insert into meal_user values(DEFAULT,'" + p.Name + "', " + (p.IsAdmin ? 1 : 0) + ", '"+p.Email+"', '"+p.PhoneNo+"')";
            }

            else if (typeof(TEntity) == typeof(User))
            {
                User u = entity as User;
                command.CommandText = "insert into user_table values(DEFAULT,'" + u.Username + "', '"+ u.Password +"', " + (u.IsValid ? 1 : 0) + ")";
            }

            command.ExecuteNonQuery();
            connection.Close();
            return;
        }
    }
}