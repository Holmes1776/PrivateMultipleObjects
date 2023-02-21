using System;
using System.ComponentModel.Design;

using System.Reflection;


namespace Inheritance
{
    //Base Class
    class Character
    {
        private int _Num;
        private string _FirstName;
        private string _LastName;
        private int _Age;

        // default constructor
        public Character()
        {
            _Num = 0;
            _FirstName = string.Empty;
            _LastName = string.Empty;
            _Age = 0;
        }
        //parameterized constructor
        public Character(int num, string firstName, string lastName, int age)
        {
            _Num = num;
            _FirstName = firstName;
            _LastName = lastName;
            _Age = age;
        }
        // Get and Set Methods
        public int getNum() { return _Num; }
        public string getFirstName() { return _FirstName; }
        public string getLastName() { return _LastName; }
        public int getAge() { return _Age; }
        public void setNum(int num) { _Num = num; }
        public void setFirstName(string firstName) { _FirstName = firstName; }
        public void setLastName(string lastName) { _LastName = lastName; }
        public void setAge(int age) { _Age = age; }

        public virtual void addChange()
        {
            Console.Write("Identification Number=");
            setNum(int.Parse(Console.ReadLine()));
            Console.Write("First Name=");
            setFirstName(Console.ReadLine());
            Console.Write("Last Name=");
            setLastName(Console.ReadLine());
            Console.Write("Age=");
            setAge(int.Parse(Console.ReadLine()));
        }
        public virtual void print()
        {
            Console.WriteLine();
            Console.WriteLine($"      Identification Number: {getNum()}");
            Console.WriteLine($"    Name: {getFirstName()} {getLastName()}");
            Console.WriteLine($"     Age: {getAge()}");
        }
    }
    class MainCharacter : Character
    {
        private double _Height;
        private string _Ethnicity;

        public MainCharacter()
            : base()
        {
            _Ethnicity = string.Empty;
            _Height = 0;
        }
        public MainCharacter(int num, string firstname, string lastname, int age, double height, string location)
            : base(num, firstname, lastname, age)
        {
            _Height = height;
            _Ethnicity = location;
        }
        public void setHeight(double height) { _Height = height; }
        public void setEthnicity(string ethnicity) { _Ethnicity = ethnicity; }
        public double getHeight() { return _Height; }
        public string getEthnicity() { return _Ethnicity; }
        public override void addChange()
        {
            base.addChange();
            Console.Write("Height (in)=");
            setHeight(double.Parse(Console.ReadLine()));
            Console.Write("Ethnicity=");
            setEthnicity(Console.ReadLine());
        }
        public override void print()
        {
            base.print();
            Console.WriteLine($"  Height (in): {getHeight()}");
            Console.WriteLine($"Ethnicity: {getEthnicity()}");
            Console.WriteLine();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("How many characters would you like to enter?");
            int maxchar;
            while (!int.TryParse(Console.ReadLine(), out maxchar))
                Console.WriteLine("Please enter a whole number");
            // array of Character objects
            Character[] chars = new Character[maxchar];
            Console.WriteLine("How many main characters do you want to enter?");
            int maxMain;
            while (!int.TryParse(Console.ReadLine(), out maxMain))
                Console.WriteLine("Please enter a whole number");
            // array of MainCharacter objects
            MainCharacter[] main = new MainCharacter[maxMain];

            int choice, rec, type;
            int chaCounter = 0, mainCounter = 0;
            choice = Menu();
            while (choice != 4)
            {
                Console.WriteLine("Enter 1 for Main Character or 2 for a normal Character");
                while (!int.TryParse(Console.ReadLine(), out type))
                    Console.WriteLine("1 for Main Character or 2 for normal Character");
                try
                {
                    switch (choice)
                    {
                        case 1: // Add
                            if (type == 1) //MainCharacter
                            {
                                if (mainCounter <= maxMain)
                                {
                                    main[mainCounter] = new MainCharacter(); // places an object in the array instead of null
                                    main[mainCounter].addChange();
                                    mainCounter++;
                                }
                                else
                                    Console.WriteLine("The maximum number of Main Characters has been added");

                            }
                            else //Character
                            {
                                if (chaCounter <= maxchar)
                                {
                                    chars[chaCounter] = new Character(); // places an object in the array instead of null
                                    chars[chaCounter].addChange();
                                    chaCounter++;
                                }
                                else
                                    Console.WriteLine("The maximum number normal Characters has been added");
                            }

                            break;
                        case 2: //Change
                            Console.Write("Enter the identification number you want to change: ");
                            while (!int.TryParse(Console.ReadLine(), out rec))
                                Console.Write("Enter the record number you want to change: ");
                            rec--;  // subtract 1 because array index begins at 0
                            if (type == 1) //MainCharacter
                            {
                                while (rec > mainCounter - 1 || rec < 0)
                                {
                                    Console.Write("The number you entered was out of range, try again");
                                    while (!int.TryParse(Console.ReadLine(), out rec))
                                        Console.Write("Enter the record number you want to change: ");
                                    rec--;
                                }
                                main[rec].addChange();
                            }
                            else // Character
                            {
                                while (rec > chaCounter - 1 || rec < 0)
                                {
                                    Console.Write("The number you entered was out of range, try again");
                                    while (!int.TryParse(Console.ReadLine(), out rec))
                                        Console.Write("Enter the identification number you want to change: ");
                                    rec--;
                                }
                                chars[rec].addChange();
                            }
                            break;
                        case 3: // Print All
                            if (type == 1) //MainCharacter
                            {
                                for (int i = 0; i < mainCounter; i++)
                                    main[i].print();
                            }
                            else // Character
                            {
                                for (int i = 0; i < chaCounter; i++)
                                    chars[i].print();
                            }
                            break;
                        default:
                            Console.WriteLine("You made an invalid selection, please try again");
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
            Console.WriteLine("Please make a selection from the menu");
            Console.WriteLine("1-Add  2-Change  3-Print  4-Quit");
            int selection = 0;
            while (selection < 1 || selection > 4)
                while (!int.TryParse(Console.ReadLine(), out selection))
                    Console.WriteLine("1-Add  2-Change  3-Print  4-Quit");
            return selection;
        }
    }
}