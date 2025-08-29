using Demo.Context;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var context = new NorthwindContext();
            #region Joins
            //var Results = context.Employees.Join(context.Orders, e => e.EmployeeId, o => o.EmployeeId,
            //    (e, o) => new
            //    {
            //        e.FirstName,
            //        e.LastName,
            //        o.OrderId,
            //        o.OrderDate
            //    });
            //foreach (var r in Results)
            //{
            //    Console.WriteLine($"{r.FirstName} {r.LastName} {r.OrderId} {r.OrderDate}");
            //}
            #endregion

            #region Grouping
            var Results = context.Employees.GroupJoin(context.Orders, e => e.EmployeeId, o => o.EmployeeId,
                (e, o) => new
                {
                    e.FirstName,
                    e.LastName,
                    o
                });
            foreach (var r in Results)
            {
                Console.WriteLine($"{r.FirstName} {r.LastName} ");
                foreach (var order in r.o)
                {
                    Console.WriteLine($"\t{order.ShipName} {order.OrderId} {order.OrderDate}");
                }
            }
            #endregion
            Console.ReadKey();
        }
    }
}
