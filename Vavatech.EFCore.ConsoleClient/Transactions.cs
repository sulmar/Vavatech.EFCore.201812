using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace Vavatech.EFCore.ConsoleClient
{
    class Transactions
    {

        public static void Test()
        {
            DbTransactionTest();

            DistributedTransactionTest();
        }


       private static void DistributedTransactionTest()
        {
            try
            {
                using (var context1 = new MyContext())
                using (var context2 = new MyContext())
                using (var transactionScope = new TransactionScope())
                {
                    var customer = context1.Customers.First();
                    customer.IsDeleted = !customer.IsDeleted;
                    context1.SaveChanges();

                    var product = context2.Products.First();
                    product.Color = "Red";
                    context2.SaveChanges();

                    transactionScope.Complete();
                }
            }
            catch(Exception e)
            {

            }
        }


        // https://docs.microsoft.com/pl-pl/ef/core/saving/transactions
        private static void DbTransactionTest()
        {
            using (var context = new MyContext())
            using (var transaction = context.Database.BeginTransaction() )
            {

                try
                {
                    var customer = context.Customers.First();
                    customer.IsDeleted = !customer.IsDeleted;
                    context.SaveChanges();

                    var product = context.Products.First();
                    product.Color = "Red";
                    context.SaveChanges();

                    transaction.Commit();
                }
                catch(Exception e)
                {
                    transaction.Rollback();
                }

            }
        }
    }
}
