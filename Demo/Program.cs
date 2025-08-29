using Demo.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

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
            //var Results = context.Employees.GroupJoin(context.Orders, e => e.EmployeeId, o => o.EmployeeId,
            //    (e, o) => new
            //    {
            //        e.FirstName,
            //        e.LastName,
            //        o
            //    });
            //foreach (var r in Results)
            //{
            //    Console.WriteLine($"{r.FirstName} {r.LastName} ");
            //    foreach (var order in r.o)
            //    {
            //        Console.WriteLine($"\t{order.ShipName} {order.OrderId} {order.OrderDate}");
            //    }
            //}
            #endregion
            //Create view
            #region Viewing
            //context.Database.ExecuteSqlRaw(@"Create View EmployeeView
            //                       as 
            //                           select e.EmployeeId , e.FirstName ,e.LastName ,e.Address ,e.City 
            //                            from Employees e");

            //context.Database.ExecuteSqlRaw(@"Drop view EmployeeView");
            #endregion
            #region Call Procedures
            var result =  context.Procedures.SelectALLEmployeesAsync().GetAwaiter().GetResult();
            foreach (var r in result)
            {
                Console.WriteLine($"{r.EmployeeID} {r.FirstName} {r.LastName} {r.Address} {r.City}");
            }
            #endregion
            Console.ReadKey();
        }
    }
}
