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
        if (socialNetworkDictionary.ContainsKey(name))
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
        if (!socialNetworkDictionary.ContainsKey(name))
        {
            Console.WriteLine($"{name} does not exist.");
            return;
        }

        var listOfFriends = socialNetworkDictionary[name];
        foreach(var friend in listOfFriends)
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



    private bool userExists(string user)
    {
        return socialNetworkDictionary.ContainsKey(user);
    }
    private bool twoUsersExists(string user1, string user2)
    {
        return socialNetworkDictionary.ContainsKey(user1) && socialNetworkDictionary.ContainsKey(user2);
    }
}
