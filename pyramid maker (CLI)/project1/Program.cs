using System;

namespace project1
{
    class Program
    {
        public static void Main(string[] args)
        {
            string input;
            int age;
            bool Play = true;

            try
            {
                do
                {
                    Console.WriteLine("\nStart(Y/N)?");
                    string response = Console.ReadLine();

                    if (response.ToUpper() == "Y") //could have put this in a loop but that weould force a user to press y or n, instead kept it simple
                    {
                        Play = true;
                    }
                    else if (response != "Y") // i put if not equal to y coz if the person enters any other key other than n, it still ends...
                    {
                        Play = false;
                        break;
                    }

                    Console.WriteLine("Whats your name?"); // all this part is not really necessary, but just added it coz of aesthetics..
                    input = Console.ReadLine();

                    Type our_type = input.GetType();

                    while (input.Length <= 1 || our_type != typeof(string))      // i know , yeah a really funky program.. xD

                    {
                        Console.WriteLine("Whats your name?");
                        input = Console.ReadLine();
                    }

                    Console.WriteLine("\nWhats your age/");
                    age = Convert.ToInt32(Console.ReadLine());

                    Type our_type2 = age.GetType();

                    while (our_type2 != typeof(int)) // double coz it coverts to double initially..
                    {
                        Console.WriteLine("\nWhats your age/");
                        age = Convert.ToInt32(Console.ReadLine());
                    }

                    Console.WriteLine("\n Hey " + input);  // this part , pretty useless i know. but deal with it... 
                    Checker(Convert.ToInt32(age));


                    int pyramid_height;

                    Console.WriteLine("\n              Want to see a pyramid? \n Enter a random (int type) height, best if you enter above 10..");

                    pyramid_height = Convert.ToInt32(Console.ReadLine());


                    Draw_pyramid(pyramid_height); // calling the pyramid function here to draw the pyramid ........

                    Console.WriteLine("\n              Want to see a rectangle? \n Enter rows");
                    int rows = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("enter columns");
                    int columns = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("enter symbol");
                    char symbol = Convert.ToChar(Console.ReadLine());

                    Draw_rectangle(columns, rows, symbol);
                    Greeting();

                } while (Play == true);

                Console.WriteLine("\nPress any key to close window");
                Console.ReadLine();
            }
            catch   // yeah yeah im too lazy to catch all errors so yeah , ill just put all exceptions here and say something went wrong
            {
                Console.WriteLine("Something went wrong, Try to re run the program...");
            }
        }

        public static void Greeting()
        {
            Console.WriteLine("\n There we go...");
        }

        public static void Checker(int ages)
        {

            if(ages > 100)
            {
                Console.WriteLine("\nyou're way too old");  // this function simply checks if the age is greater than or less than 100. and it displays
            }                                               // too old if so 
            else if(ages < 100)
            {
                Console.WriteLine("\nyou are " + ages + " yrs old..");
            }
        }

        public static void Draw_pyramid(int height)
        {
            int space_before_ast = height + 2;

            for (int j = 1; j <= height + 1; j++)
            {
                space_before_ast -= 1;

                string result = string.Join(" ", new string[space_before_ast] );// joins an initial space before asterisk , that space reduces on 

                result += string.Join("*", new string[j] );        // that space reduces on each iteration.....

                result += string.Join("*", new string[j - 1] );

                Console.WriteLine(result) ;
                   
            }
            
        }
        static void Draw_rectangle(int columns, int rows, char symbol)
        {
            Console.WriteLine("\n");  // to skip a line so that it appears clearly on the next line instead of being all jammed up u kno... 
            for (int i = 1; i <= rows+1; i++)
            {
                string rect = string.Join(symbol, new string[columns]);
                Console.WriteLine($"    {rect}");
            }
        }
    }
}
