using System;
using System.Collections.Generic;
public class User
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    public User(string name, string email, string role)
    {
        Name = name;
        Email = email;
        Role = role;
    }
}
public class UserManager
{
    private readonly List<User> _users = new List<User>();
    private User FindByEmail(string email)
    {
        foreach (var u in _users)
        {
            if (u.Email == email) return u;
        }
        return null;
    }
    public bool AddUser(User user)
    {
        if (FindByEmail(user.Email) != null) return false;
        _users.Add(user);
        return true;
    }
    public bool RemoveUser(string email)
    {
        var existing = FindByEmail(email);
        if (existing == null) return false;
        _users.Remove(existing);
        return true;
    }
    public bool UpdateUser(string email, string newName, string newRole)
    {
        var existing = FindByEmail(email);
        if (existing == null) return false;
        existing.Name = newName;
        existing.Role = newRole;
        return true;
    }
    public List<User> GetAll() => new List<User>(_users);
}