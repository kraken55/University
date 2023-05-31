package cafe;

public class Bartender 
{
    private int legalAge;

    public Bartender(int legalAge)
    {
        this.legalAge = legalAge;
    }

    public boolean order(Guest guest)
    {
        if (guest instanceof Adult)
        {
            return true;
        }
        
        if (guest instanceof Minor)
        {
            if (guest.getAge() >= legalAge)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        return false;
    }
}
