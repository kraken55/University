package music.fan;

import music.recording.Artist;

public class Fan 
{
    private final String name;
    private final Artist favourite;
    private int moneySpent;

    public String getName()
    {
        return name;
    }

    public Artist getFavourite()
    {
        return favourite;
    }

    public int getMoneySpent()
    {
        return moneySpent;
    }


    public Fan(String name, Artist favourite)
    {
        this.name = name;
        this.favourite = favourite;
    }

    public int buyMerchandise(int basePrice, Fan... fans)
    {
        if (fans.length == 1)
        {
            basePrice *= 0.9;
        }
        else if (fans.length >= 2)
        {
            basePrice *= 0.8;
        }

        int spending = basePrice * (fans.length + 1);
        favourite.getLabel().gotIncome(spending / 2);
        return spending;
    }

    public boolean favesAtSameLabel(Fan friend)
    {
        if (friend.getFavourite() == this.favourite)
        {
            return true;
        }

        return false;
    }

    public String toString1()
    {
        return "Name: " + name + "\nFavourite artist: " + favourite + "\nMoney spent: " + moneySpent + "\n";
    }

    public String toString2()
    {
        return "Name: %s\nFavourite artist: %s\nMoney spent: %d\n".formatted(name, favourite, moneySpent);
    }

    public String toString3()
    {
        return String.format("Name: %s\nFavourite artist: %s\nMoney spent: %d\n", name, favourite, moneySpent);
    }

    public String toString4()
    {
        StringBuilder sb = new StringBuilder();
        sb.append("Name: " + name + "\n");
        sb.append("Favourite artist: " + favourite + "\n");
        sb.append("Money spent: " + moneySpent + "\n");
        return sb.toString();
    }
}