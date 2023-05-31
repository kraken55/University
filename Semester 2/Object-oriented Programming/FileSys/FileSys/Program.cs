using System;
using System.Collections.Generic;
using TextFile;

namespace FileSys;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(Onecase("input.txt"));
    }

    struct Item
    {
        public char sign;
        public Registration? reg;

        public Item(char c, Registration? r = null)
        {
            sign = c;
            reg = r;
        }
    };

    class WrongStructureException : Exception { };

    static int Onecase(string filename)
    {
        FileSystem root = new FileSystem();

        TextFileReader reader = new TextFileReader(filename);
        Stack<Item> stack = new Stack<Item>();

         while (ReadItem(ref reader, out char sign, out int size))
         {
            switch (sign)
            {
                case 'F':
                    stack.Push(new Item('F', new File(size)));
                    break;
                case 'K':
                    stack.Push(new Item('K'));
                    break;
                case 'V':
                    Folder folder = new Folder();
                    while (stack.Peek().sign != 'K')
                    {
                        folder.Add(stack.Peek().reg);
                        stack.Pop();
                    }
                    Item item = stack.Peek();
                    stack.Pop();
                    item.sign = 'F';
                    item.reg = folder;
                    stack.Push(item);
                    break;
            }
         }

         while (stack.Count > 0)
         {
            if (stack.Peek().sign == 'K')
            {
                throw new WrongStructureException();
            }
            root.Add(stack.Peek().reg);
            stack.Pop();
         }

         int res = root.GetSize();

         return res;

        
    }

    static bool ReadItem(ref TextFileReader reader, out char sign, out int size)
    {
        size = -1;
        bool res = reader.ReadChar(out sign);
        if (res)
        {
            if (sign == 'F')
            {
                reader.ReadInt(out size);
            }
        }

        return res;
    }
}
