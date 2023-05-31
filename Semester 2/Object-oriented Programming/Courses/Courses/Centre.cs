namespace Courses;

using System;
using System.Collections.Generic;

class Centre
{
    public class PersonNotAuthenticated : Exception { }
    public class PersonHasAlreadyRegistered : Exception { }

    private readonly Dictionary<string, string> table = new Dictionary<string, string>();
    private readonly Dictionary<string, string> admin = new Dictionary<string, string>();

    public Centre(Person adm)
    {
        admin.Add(adm.id, adm.id);
    }

    public void Authentication(Person person)
    {
        if (!table.ContainsKey(person.id) || !person.OKPW(table[person.id]))
        {
            throw new PersonNotAuthenticated();
        }
    }

    public string Register(Person person, Person adm)
    {
        if (!(admin.ContainsKey(adm.id) && adm.OKPW(admin[adm.id])))
        {
            throw new PersonNotAuthenticated();
        }

        if (table.ContainsKey(person.id))
        {
            throw new PersonHasAlreadyRegistered();
        }

        table[person.id] = person.id;
        person.centre = this;
        return table[person.id];
    }

    public void ModifyPassword(Person person, string oldpw, string newpw)
    {
        Authentication(person);
        if (table[person.id] != oldpw)
        {
            throw new Person.WrongPassword();
        }
        table[person.id] = newpw;
    }
}