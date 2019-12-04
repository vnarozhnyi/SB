using Newtonsoft.Json;
using System;
using System.Data.SqlClient;
using ORM.Models;


namespace ORM
{
    public class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=BattleShipDB;Integrated Security=True";
            // public SqlConnection _dbconnection = new SqlConnection(connectionString);
            //_dbconnection.Open();
            UnitOfWork uow = new UnitOfWork(connectionString);
            //Repository repository = new Repository();
            Ship ship = new Ship();

            //uow.repository.Insert(new Types { Id = 4, TypeOf = "Main" });
            //uow.repository.Insert(new Directions { Id = 14, Direction = "Left" });

            uow.repository.Insert(new Ship { Speed = 1, Range = 2, Length = 3, Direction = Ship.Directions.Down, Type = Ship.Types.Carrier });


            //Console.WriteLine(JsonConvert.SerializeObject(uow.repository.Select(new Ship { })));


            //uow.repository.Update(new Field { Id = 2, X = 5, Y = 9 });
            //uow.repository.Delete(new Types { Id = 3 });


            uow._dbconnection.Close();
        }
    }
}
