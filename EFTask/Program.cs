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
            #region
            app.Users.AddRange(Users);
            app.SaveChanges();
            Console.WriteLine("Data Added Successfully!");
            #endregion

            // READ
            #region 
            var users = app.Users.ToList();
            foreach (var user in users)
            {
                Console.WriteLine($"Id: {user.Id}, Name: {user.Name}, Price: {user.Price}");
            }
            #endregion

            //LinQ
            #region
            var OrderByPrice = app.Users.OrderByDescending(u => u.Price).ToList();
            var MaxPrice = app.Users.Max(u => u.Price);
            var MinPrice = app.Users.Min(u => u.Price);
            var AveragePrice = app.Users.Average(u => u.Price);
            Console.WriteLine($"Max Price: {MaxPrice}, Min Price: {MinPrice}, Average Price: {AveragePrice}");
            var count = app.Users.Count(u => u.Price > 50);
            Console.WriteLine($"Count of Users that have Price > 50 : {count}");
            var result = Users.Where(user => user.Price > 50);
            foreach (var user in result)
            {
                Console.WriteLine(user.Name);
            }
            var containsMaLetters = app.Users.Where(u => u.Name.Contains("ma")).ToList();

            List<int> Ids = [3, 5, 7];
            var target = Users.Where(user => Ids.Contains(user.Id));
            #endregion
            //Update
            #region
            app.Users.Update(new User { Id = 5, Name = "Hasan", Price = 150.50m });
            app.SaveChanges();
            #endregion
            //Remove
            #region
            var userToRemove = app.Users.Find(6);
            if (userToRemove != null)
            {
                app.Users.Remove(userToRemove);
                app.SaveChanges();
            }
            #endregion



        }

    }
}
