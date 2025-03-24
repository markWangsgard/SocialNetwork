using System.Text;

namespace SocialNetworkLogic;

public class SocialNetwork
{
    private Dictionary<string, List<string>> socialNetworkDictionary;

    public SocialNetwork()
    {
        socialNetworkDictionary = new Dictionary<string, List<string>>();
    }

    public void AddUser(string name)
    {
        if (userExists(name))
        {
            Console.WriteLine($"{name} already exists.");
            return;
        }

        socialNetworkDictionary[name] = new List<string>();
        Console.WriteLine($"{name} has been added.");
    }

    public Dictionary<string, List<string>> GetNetwork()
    {
        return socialNetworkDictionary;
    }

    public void RemoveUser(string name)
    {
        if (!userExists(name))
        {
            Console.WriteLine($"{name} does not exist.");
            return;
        }

        var listOfFriends = socialNetworkDictionary[name];
        foreach (var friend in listOfFriends)
        {
            socialNetworkDictionary[friend].Remove(name);
        }
        socialNetworkDictionary.Remove(name);
        Console.WriteLine($"{name} has been removed from the network.");
    }

    public void AddFriend(string user1, string user2)
    {
        if (!twoUsersExists(user1, user2))
        {
            Console.WriteLine("One or both users do not exist.");
            return;
        }
        if (socialNetworkDictionary[user1].Contains(user2))
        {
            Console.WriteLine($"{user1} and {user2} are already friends.");
            return;
        }
        socialNetworkDictionary[user1].Add(user2);
        socialNetworkDictionary[user2].Add(user1);
        Console.WriteLine($"{user1} and {user2} are now friends.");
    }

    public void RemoveFriend(string user1, string user2)
    {
        if (twoUsersExists(user1, user2))
        {
            Console.WriteLine("One or both users do not exist.");
            return;
        }
        if (!socialNetworkDictionary[user1].Contains(user2))
        {
            Console.WriteLine($"{user1} and {user2} are not friends.");
            return;
        }

        socialNetworkDictionary[user1].Remove(user2);
        socialNetworkDictionary[user2].Remove(user1);
        Console.WriteLine($"{user1} and {user2} are no longer friends.");
    }

    public void DisplayFriends(string user)
    {
        if (!userExists(user))
        {
            Console.WriteLine($"{user} does not exist.");
            return;
        }
        if (socialNetworkDictionary[user].Count() <= 0)
        {
            Console.WriteLine($"{user} has no friends.");
            return;
        }

        string friendList = String.Join(", ", socialNetworkDictionary[user]);
        Console.WriteLine($"{user}'s friends: {friendList}");
    }

    public void FindMutualFriends(string user1, string user2)
    {
        if (twoUsersExists(user1, user2))
        {
            Console.WriteLine("One or both users do not exist.");
        }

        List<string> mutualFriends = socialNetworkDictionary[user1].Intersect(socialNetworkDictionary[user2]).ToList();

        if (mutualFriends.Count == 0)
        {
            Console.WriteLine($"{user1} and {user2} have no mutual friends.");
            return;
        }

        Console.WriteLine($"Mutual friends of {user1} and {user2}: {String.Join(", ", mutualFriends)}");
    }

    private bool userExists(string user)
    {
        return socialNetworkDictionary.ContainsKey(user);
    }
    private bool twoUsersExists(string user1, string user2)
    {
        return socialNetworkDictionary.ContainsKey(user1) && socialNetworkDictionary.ContainsKey(user2);
    }
}
