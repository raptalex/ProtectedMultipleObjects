using System;

class Package
{
    protected int _id;
    protected string _name;
    protected string _description;

    public Package()
    {
        _id = 0;
        _name = "none";
        _description = "none";
    }

    public Package(int id, string name, string desc)
    {
        _id = id;
        _name = name;
        _description = desc;
    }

    public void setId(int id)
    {
        _id = id;
    }
    public void setName(string name)
    {
        _name = name;
    }
    public void setDesc(string desc)
    {
        _description = desc;
    }
    public int getId()
    {
        return _id;
    }
    public string getName()
    {
        return _name;
    }
    public string getDesc()
    {
        return _description;
    }

    public virtual void modify()
    {
        Console.Write("Set id: ");
        setId(int.Parse(Console.ReadLine()));
        Console.Write("Set name: ");
        setName(Console.ReadLine());
        Console.Write("Set description: ");
        setDesc(Console.ReadLine());
    }
    public virtual void display()
    {
        Console.WriteLine("ID: {0}", getId());
        Console.WriteLine("Name: {0}", getName());
        Console.WriteLine("Description: {0}", getDesc());
    }
}

class Food : Package
{
    protected string _expires;
    protected string _type;

    public Food() : base()
    {
        _expires = "unknown";
        _type = "unknown";
    }

    public Food(int id, string name, string desc, string expireDate, string type) : base(id, name, desc)
    {
        _expires = expireDate;
        _type = type;
    }

    public string getExpireDate()
    {
        return _expires;
    }
    public string getType()
    {
        return _type;
    }
    public void setExpireDate(string edate)
    {
        _expires = edate;
    }
    public void setType(string type)
    {
        _type = type;
    }
    public override void display()
    {
        base.display();
        Console.WriteLine("Expiration Date: {0}", _expires);
        Console.WriteLine("Food Type: {0}", _type);
    }
    public override void modify()
    {
        base.modify();
        Console.Write("Set expiration date: ");
        setExpireDate(Console.ReadLine());
        Console.Write("Set food type: ");
        setType(Console.ReadLine());
    }
}

class Program
{
    public static void Main()
    {
        Console.WriteLine("How many packages are you adding?");

        int numPackages = 0;

        while (!int.TryParse(Console.ReadLine(), out numPackages))
            Console.WriteLine("How many packages are you adding?");

        Package[] packages = new Package[numPackages];

        Console.WriteLine("How many food items are you adding?");

        int numFood = 0;

        while (!int.TryParse(Console.ReadLine(), out numFood))
            Console.WriteLine("How many food items are you adding?");

        Food[] foodItems = new Food[numFood];

        int choice, type, index;
        int packageCounter = 0, foodCounter = 0;

        choice = Menu();

        while (choice != 4)
        {
            Console.WriteLine("Enter 1 for package or 2 for food item");
            while (!int.TryParse(Console.ReadLine(), out type))
                Console.WriteLine("Enter 1 for package or 2 for food item");

            try
            {
                switch (choice)
                {
                    case 1:
                        if (type == 1)
                        {
                            if (packageCounter <= numPackages)
                            {
                                packages[packageCounter] = new Package();
                                packages[packageCounter].modify();
                                packageCounter++;
                            }
                            else
                            {
                                Console.WriteLine("The max amount of packages has been added");
                            }
                        }
                        else
                        {
                            foodItems[foodCounter] = new Food();
                            foodItems[foodCounter].modify();
                            foodCounter++;
                        }
                        break;
                    case 2:
                        Console.WriteLine("Enter the record number you wish to modify");
                        while (!int.TryParse(Console.ReadLine(), out index))
                            Console.WriteLine("Enter the record number you wish to modify");

                        // arrays start at 0
                        index--;

                        if (type == 1)
                        {
                            while (index > packageCounter - 1 || index < 0)
                            {
                                Console.WriteLine("Out of range, please enter the number again");
                                while (!int.TryParse(Console.ReadLine(), out index))
                                    Console.WriteLine("Out of range, please enter the number again");
                                index--;
                            }
                            packages[index].modify();
                        }
                        else
                        {
                            while (index > foodCounter - 1 || index < 0)
                            {
                                Console.WriteLine("Out of range, please enter the number again");
                                while (!int.TryParse(Console.ReadLine(), out index))
                                    Console.WriteLine("Out of range, please enter the number again");
                                index--;
                            }
                            foodItems[index].modify();
                        }
                        break;
                    case 3:
                        if (type == 1)
                        {
                            foreach (Package p in packages)
                                p.display();
                        }
                        else
                        {
                            foreach (Food f in foodItems)
                                f.display();
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid option, please try again");
                        break;
                }
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            choice = Menu();
        }
    }
    private static int Menu()
    {
        // Copied verbatim
        Console.WriteLine("Please make a selection from the menu");
        Console.WriteLine("1-Add  2-Change  3-Print  4-Quit");
        int selection = 0;
        while (selection < 1 || selection > 4)
            while (!int.TryParse(Console.ReadLine(), out selection))
                Console.WriteLine("1-Add  2-Change  3-Print  4-Quit");
        return selection;
    }
}