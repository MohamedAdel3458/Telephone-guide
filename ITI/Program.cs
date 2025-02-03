Numbers[] numbers = new Numbers[1000];

void add(ref int n, Numbers[] addedArray)
{
    Console.Write("Enter the Numbers of Number Phones that You Want to Add: ");
    byte addNum = byte.Parse(Console.ReadLine());
    for (byte i = 0; i < addNum; i++)
    {
        Console.Write($"Enter the Name of Person {i + 1}: ");
        string name = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(name) == true)
        {
            Console.Write("Please Enter the Name: ");
            name = Console.ReadLine();
        }

        Console.Write("Add the Phone Number: ");
        string number = Console.ReadLine();

        while (number.Length != 11)
        {
            Console.Write("Please Enter the Correct Number: ");
            number = Console.ReadLine();
        }

        for (int j = 0; j < number.Length; j++)
        {
            while (char.IsDigit(number[j]) == false)
            {
                Console.Write("Please Enter the Correct Number: ");
                number = Console.ReadLine();
            }
        }
        while (number.StartsWith("010") == false &&
               number.StartsWith("011") == false &&
               number.StartsWith("012") == false &&
               number.StartsWith("015") == false)
        {
            Console.Write("Please Enter the Correct Number: ");
            number = Console.ReadLine();
        }

        bool isFoundName = false;
        bool isFoundNumber = false;

        for (int j = 0; j < addNum; j++)
        {
            if (addedArray[j].name == name)
            {
                isFoundName = true;
            }
            if (addedArray[j].Number == number)
            {
                isFoundNumber = true;
            }
        }

        if (isFoundName)
        {
            Console.Write($"This Name of Person {i + 1} is Already Exists Before Please Add Another Name: ");
            name = Console.ReadLine();
        }

        if (isFoundNumber)
        {
            Console.Write($"This Number of Person {i + 1} is Already Exists Before Please Add Another Number: ");
            number = Console.ReadLine();
        }

        addedArray[n].name = name;
        addedArray[n].Number = number;

        n++;
    }
}

void Delete(ref int n, Numbers[] DeletedArray)
{
    Console.Write("Enter the Name that You Want to Delete it: ");
    string name = Console.ReadLine();

    while (string.IsNullOrWhiteSpace(name) == true)
    {
        Console.Write("Please Enter the Name: ");
        name = Console.ReadLine();
    }

    bool isFound = false;
    int index = -1;

    for (int i = 0; i < n; i++)
    {
        if (DeletedArray[i].name == name)
        {
            isFound = true;
            index = i;
            break;
        }
    }

    if (!isFound)
    {
        Console.WriteLine("The Name Does Not Exist");
    }
    else
    {

        for (int i = index; i < n - 1; i++)
        {
            DeletedArray[i] = DeletedArray[i + 1];
        }
        n--;
        Console.WriteLine("Done");
    }

}

void Display(int n, Numbers[] displayedArray)
{
    Console.WriteLine("===============================================================");
    Console.WriteLine("Name:\t\tPhone Nmaber: ");
    Console.WriteLine();
    for (int i = 0; i < n; i++)
    {
        Console.WriteLine(displayedArray[i].name + "\t\t" + displayedArray[i].Number);
    }
    Console.WriteLine("===============================================================");
}

int n = 0;

Console.Write("If You Want to Add Number Enter 1 and if You Want to End the Program Enter 2: ");
byte choice = byte.Parse(Console.ReadLine());

while (choice != 1 && choice != 2)
{
    Console.WriteLine("Invalid Number");
    Console.Write("Please Enter Another Number: ");
    choice = byte.Parse(Console.ReadLine());
}

if (choice == 2)
{
    choice++;
}

while (choice == 1 || choice == 2 || choice == 3)
{

    if (choice == 1)
    {
        add(ref n, numbers);
        Display(n, numbers);
    }
    else if (choice == 2)
    {
        Delete(ref n, numbers);
        Display(n, numbers);
    }
    else if (choice == 3)
    {
        Console.WriteLine("Done");
        break;
    }
    Console.Write("If You Want to Add Number Enter 1 and if You Want to Delete Enter 2 and if You Want to End the Program Enter 3: ");
    choice = byte.Parse(Console.ReadLine());

}

if (choice != 1 && choice != 2 && choice != 3)
{
    Console.WriteLine("Invalid Number");
}
struct Numbers
{
    public string name;
    public string Number;
};
