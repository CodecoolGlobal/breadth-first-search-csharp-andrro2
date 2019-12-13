using BFS_c_sharp.Model;
using System;
using System.Collections.Generic;

namespace BFS_c_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            RandomDataGenerator generator = new RandomDataGenerator();
            List<UserNode> users = generator.Generate();
            BreadthSearch breadthSearch = new BreadthSearch(users);

            foreach (var user in users)
            {
                Console.WriteLine(user);
            }
            int distance = breadthSearch.DistanceBetweenUsers(users[0], users [1]);
            Console.WriteLine("Distance between users: " + distance);

            List<UserNode> friendsOfFriends = breadthSearch.GetFriendsOfFriends(users[0], 10);
            string result = string.Join(", ", friendsOfFriends);
            Console.WriteLine(result);
            Console.WriteLine("Done");
            Console.ReadKey();
        }
    }
}
