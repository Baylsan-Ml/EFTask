using Microsoft.EntityFrameworkCore;

namespace EFTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ApplicationDbContext app= new ApplicationDbContext();


            List<User> Users=new List<User>(){
                new User { Name = "Ahmad", Price = 10.50m },
                new User { Name = "Lina", Price = 25.00m },
                new User { Name = "Omar", Price = 7.75m },
                new User { Name = "Sara", Price = 15.20m },
                new User { Name = "Yousef", Price = 100.00m },
                new User { Name = "Ola", Price = 60.70m },
                new User { Name = "Reem", Price = 75.70m }
            };

            //Add
            app.Users.AddRange(Users);
            app.SaveChanges();
            Console.WriteLine("Data Added Successfully!");

            var result = Users.Where(user => user.Price > 50);
            foreach (var user in result)
            {
                Console.WriteLine(user.Name);
            }
            List<int> Ids= [3, 5, 7];
            var target = Users.Where(user => Ids.Contains(user.Id));
           
            //Update
            app.Users.Update(new User { Id = 5, Name = "Hasan", Price = 150.50m });
            app.SaveChanges();
            //Remove
            app.Users.Remove(new User { Id = 6});
            app.SaveChanges();




        }

    }
}
