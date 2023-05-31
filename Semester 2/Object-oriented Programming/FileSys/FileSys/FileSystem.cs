namespace FileSys;

abstract class Registration
{
    public abstract int GetSize();
}

class File : Registration
{
    private int size;

    public File(int size)
    {
        this.size = size;
    }

    public override int GetSize()
    {
        return size;
    }
}

class Folder : Registration
{
    private List<Registration> items;

    public Folder()
    {
        items = new List<Registration>();
    }

    public void Add(Registration r)
    {
        items.Add(r);
    }

    public void Remove(Registration r)
    {
        items.Remove(r);
    }

    public override int GetSize()
    {
        int totalSize = 0;

        foreach (Registration r in items)
        {
            totalSize += r.GetSize();
        }

        return totalSize;
    }
}


class FileSystem : Folder
{

}