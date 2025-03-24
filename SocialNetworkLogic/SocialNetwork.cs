namespace SocialNetworkLogic;

public class SocialNetwork
{
    private Dictionary<string, List<string>> friendLists;

    public SocialNetwork()
    {
        friendLists = new Dictionary<string, List<string>>();
    }

    public void AddUser(string name)
    {
        if (friendLists.ContainsKey(name))
        {
            Console.WriteLine($"{name} already exists.");
            return;
        }

        friendLists[name] = new List<string>();
        Console.WriteLine($"{name} has been added.");
    }

    public Dictionary<string, List<string>> GetNetwork()
    {
        return friendLists;
    }

    public void RemoveUser(string name)
    {
        if (!friendLists.ContainsKey(name))
        {
            Console.WriteLine($"{name} does not exist.");
            return;
        }

        var listOfFriends = friendLists[name];
        foreach(var friend in listOfFriends)
        {
            friendLists[friend].Remove(name);
        }
        friendLists.Remove(name);
        Console.WriteLine($"{name} has been removed from the network.");
    }
}
