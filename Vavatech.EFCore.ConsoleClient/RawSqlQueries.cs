using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Vavatech.EFCore.ConsoleClient
{
    class RawSqlQueries
    {
        public static void Test()
        {
            ExecuteReaderTest();

            QueryTest();

            ParameterizedQueryTest();

            RawQueryTest();
        }

        private static void QueryTest()
        {
            // uspGetActiveCustomers

            string sql = "exec uspGetActiveCustomers";

            using (var context = new MyContext())
            {
                var customers = context.Customers.FromSql(sql).ToList();
            }
        }


        // zla praktyka (podatne na Sql Injection)
        //private static void ParameterizedQueryTest()
        //{
        //    string firstName = "A";

        //    string sql = $"exec uspGetCustomersByFirstName '{firstName}'";

        //    using (var context = new MyContext())
        //    {
        //        var customers = context.Customers.FromSql(sql).ToList();
        //    }
        //}

        private static void ParameterizedQueryTest()
        {
            string firstName = "A";

            string sql = $"exec uspGetCustomersByFirstName @firstName";

            var firstNameParameter = new SqlParameter("firstName", firstName);

            using (var context = new MyContext())
            {
                var customers = context.Customers
                    .FromSql(sql, firstNameParameter)
                    .ToList();
            }
        }

        private static void RawQueryTest()
        {
            string sql = $"select * from dbo.Customers";

            using (var context = new MyContext())
            {
                var customers = context.Customers
                    .FromSql(sql)
                    .OrderBy(c=>c.LastName)
                    .ToList();
            }
        }

        private static void ExecuteSqlTest()
        {
            string sql = "UPDATE dbo.Customers SET IsDeleted = not IsDeleted";

            using (var context = new MyContext())
            {
                context.Database.ExecuteSqlCommand(sql);
            }
        }


        private static void ExecuteReaderTest()
        {
            string sql = $"select * from dbo.Customers";

            using (var context = new MyContext())
            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = sql;

                context.Database.OpenConnection();

                using (var reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        int id = reader.GetInt32(0);
                    }
                }
            }
        }
    }
}
