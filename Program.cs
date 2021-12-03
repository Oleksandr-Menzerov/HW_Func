using System;
using System.Collections.Generic;
using System.Linq;

namespace HW_Func
{
    class Program
    {
        public class User
        {
            public string Name { get; set; }
            public string Gender { get; set; }
            public int Age { get; set; }
            public override string ToString()
            {
                return Name + " " + Gender + " " + Age;
            }
        }
        public static bool AgeFilter(User user, string filter)
        {
            _ = int.TryParse(string.Join("", filter.Where(c => char.IsDigit(c))), out int age);
            string sign = string.Join("", filter.Where(c => !char.IsDigit(c)));
            return sign switch
            {
                "<" => (user.Age < age),
                "<=" => (user.Age <= age),
                ">" => (user.Age > age),
                ">=" => (user.Age >= age),
                "=" or "" => (user.Age == age),
                "!=" => (user.Age != age),
                _ => new(),
            };
        }
        public static bool GenderFilter(User user, string gender)
        {
            return user.Gender == gender;
        }
        public static bool NameFilter(User user, string name)
        {
            return user.Name.Contains(name);
        }
        public static void myFilter(List<User> users, Func<User, string, bool> selectorFunc, string selector)
        {
            var filteredUsers =
                    (from user in users
                     where selectorFunc(user, selector)
                     select user).ToList();
            foreach (var user in filteredUsers)
            {
                Console.WriteLine(user.ToString());
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            List<User> users = new();
            users.Add(new() { Age = 19, Name = "Sam", Gender = "M" });
            users.Add(new() { Age = 18, Name = "Mary", Gender = "F" });
            users.Add(new() { Age = 29, Name = "John", Gender = "M" });
            users.Add(new() { Age = 16, Name = "Liz", Gender = "F" });
            users.Add(new() { Age = 9, Name = "Leo", Gender = "M" });
            users.Add(new() { Age = 24, Name = "Dora", Gender = "F" });
            users.Add(new() { Age = 69, Name = "Max", Gender = "M" });
            users.Add(new() { Age = 28, Name = "Ann", Gender = "F" });
            users.Add(new() { Age = 26, Name = "Vic", Gender = "M" });
            users.Add(new() { Age = 15, Name = "Nancy", Gender = "F" });
            users.Add(new() { Age = 99, Name = "Eddie", Gender = "M" });
            users.Add(new() { Age = 43, Name = "Lily", Gender = "F" });
            users.Add(new() { Age = 14, Name = "Fred", Gender = "M" });
            users.Add(new() { Age = 29, Name = "Abby", Gender = "F" });
            users.Add(new() { Age = 17, Name = "Rick", Gender = "M" });
            Func<User, string, bool> selector = AgeFilter;
            myFilter(users, selector, ">18");
            selector = GenderFilter;
            myFilter(users, selector, "F");
            selector = NameFilter;
            myFilter(users, selector, "i");
        }
    }
}
