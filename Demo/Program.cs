using Demo.Context;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var context = new NorthwindContext();
            #region Joins
            var Results = context.Employees.Join(context.Orders, e => e.EmployeeId, o => o.EmployeeId,
                (e, o) => new
                {
                    e.FirstName,
                    e.LastName,
                    o.OrderId,
                    o.OrderDate
                });
            foreach (var r in Results)
            {
                Console.WriteLine($"{r.FirstName} {r.LastName} {r.OrderId} {r.OrderDate}");
            }
            #endregion
            Console.ReadKey();
        }
    }
}
