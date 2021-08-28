using System;

namespace project1
{
    class Program
    {
        public static void Main(string[] args)
        {
            string input;
            string age;


            Console.WriteLine("Whats your name?");
            input = Console.ReadLine();

            Console.WriteLine("\nWhats your age/");
            age = Console.ReadLine();



            Console.WriteLine("\n Hey " + input);
            Checker(Convert.ToInt32(age));


            int pyramid_height;

            Console.WriteLine("\n              Want to see a pyramid? \n Enter a random (int type) height, best if you enter above 10..");
            pyramid_height = Convert.ToInt32(Console.ReadLine());


            Draw_pyramid(pyramid_height);

            Greeting();
            Console.ReadKey();
        }

        public static void Greeting()
        {
            Console.WriteLine("\n There we go...");
        }

        public static void Checker(int ages)
        {

            if(ages > 100)
            {
                Console.WriteLine("\nyou're way too old");
            }
            else if(ages < 100)
            {
                Console.WriteLine("\nyou are " + ages + " yrs old..");
            }
        }

        public static void Draw_pyramid(int height)
        {
            int op = height + 2;

            for (int j = 1; j <= height + 1; j++)
            {
                op -= 1;
                string result = string.Join(" ", new string[op] );
                result += string.Join("*", new string[j] );

                result += string.Join("*", new string[j - 1] );
                Console.WriteLine(result) ;
                   
            }
            
        }
    }
}
