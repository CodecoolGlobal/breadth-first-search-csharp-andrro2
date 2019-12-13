using BFS_c_sharp.Model;
using System.Collections.Generic;
using System.Linq;

namespace BFS_c_sharp
{

    class BreadthSearch
    {
        private readonly List<UserNode> _users;
        private Queue<UserNode> searchQueue = new Queue<UserNode>();
        private List<UserNode> visited;
        private List<UserNode> friendOfFriends;

        public BreadthSearch(List<UserNode> users)
        {
            _users = users;
        }

        public int DistanceBetweenUsers(UserNode from, UserNode to)
        {
            visited = new List<UserNode>();

            if (from.Equals(to))
            {
                return 0;
            }

            List<UserNode> temp = new List<UserNode>();
            int distance = 0;
            searchQueue.Enqueue(from);
            while (searchQueue.Count > 0)
            {
                UserNode nextUser = searchQueue.Dequeue();
                if (nextUser.Equals(to))
                { 
                    break;
                }

                if (visited.Contains(nextUser))
                {
                    continue;
                }

                visited.Add(nextUser);

                foreach (var friend in nextUser.Friends)
                {
                    if (!temp.Contains(friend))
                    {
                        temp.Add(friend);
                    }
                }

                if (searchQueue.Count == 0 && temp.Count > 0)
                {
                    distance++;
                    foreach (var user in temp)
                    {
                        searchQueue.Enqueue(user);
                    }
                    temp.Clear();
                }


            }

            return distance;
        }

        public List<UserNode> GetFriendsOfFriends(UserNode from, int distance)
        {
            friendOfFriends = new List<UserNode>();
            FriendOfFriendsSearch(from, distance);
            return friendOfFriends;
        }

        private void FriendOfFriendsSearch(UserNode from, int distance)
        {
            foreach (UserNode friend in from.Friends)
            {
                if (!friendOfFriends.Contains(friend))
                {
                    friendOfFriends.Add(friend);
                }
                if (distance > 0)
                {
                    FriendOfFriendsSearch(friend, distance - 1);
                }
                
            }
        }
    }
}
