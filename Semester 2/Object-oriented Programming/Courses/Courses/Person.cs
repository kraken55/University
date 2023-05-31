using System;
using System.Collections.Generic;

namespace Courses;

class Person
{
    public class WrongPassword : Exception { }

    public readonly string name;
    public string id { get; private set; }
    private string password;
    public Centre centre;
    
    protected readonly List<Course> courses = new List<Course>();

    public Person(string name, string id)
    {
        this.name = name;
        this.id = id;
        password = id;
    }

    public void ModifyPassword(string oldpw, string newpw)
    {
        if (password != oldpw)
        {
            throw new WrongPassword();
        }
        password = newpw;
    }

    public bool OKPW(string pw)
    {
        return pw == password;
    }
}