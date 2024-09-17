namespace NumbersGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int triesLeft = 5;
            //int guessNum;
            // Creates a bool to hande the loop for playing
            bool playing = true;
            // While bool is true keep playing
            while (playing)
            {
                // Call method StartGame and save return value
                playing = StartGame();
            }
            Console.ReadKey();
        }
        // static bool method
        static bool StartGame()
        {
            // instanciate the Random class
            Random rnd = new Random();
            // create variables
            int randomNum;
            int choice;
            int topNum;
            /*-------------- OLD CODE --------------*/
            // Console.WriteLine("Välkommen! Jag tänker på ett nummer. Kan du gissa vilket? Du får fem försök.");
            Console.WriteLine("__     ___   _ _ _                                        " +
                "\r\n\\ \\   / (_)_(_) | | _____  _ __ ___  _ __ ___   ___ _ __  " +
                "\r\n \\ \\ / / / _` | | |/ / _ \\| '_ ` _ \\| '_ ` _ \\ / _ \\ '_ \\ " +
                "\r\n  \\ V / | (_| | |   < (_) | | | | | | | | | | |  __/ | | |\r\n   " +
                "\\_/   \\__,_|_|_|\\_\\___/|_| |_| |_|_| |_| |_|\\___|_| |_|");
            Console.WriteLine("\tDu ska gissa på ett tal och får 5 försök.");
            Console.WriteLine("\tFörst ska du välja en svårighetsgrad mellan 1-5");
            Console.Write("\t");
            // try to parse the input from user to int32
            Int32.TryParse(Console.ReadLine(), out choice);
            switch (choice)
            {
                // Depending of users choice choose what to generate
                case 1:
                    randomNum = rnd.Next(1, 10 + 1);
                    topNum = 10;
                    break;
                case 2:
                    randomNum = rnd.Next(1, 20 + 1);
                    topNum = 20;
                    break;
                case 3:
                    randomNum = rnd.Next(1, 50 + 1);
                    topNum = 50;
                    break;
                case 4:
                    randomNum = rnd.Next(1, 100 + 1);
                    topNum = 100;
                    break;
                case 5:
                    randomNum = rnd.Next(1, 1000 + 1);
                    topNum = 1000;
                    break;
                default:
                    Console.WriteLine("Ogiltligt val!");
                    return true;
            }
            // Call method Game and pass along values
            // and return the value
            return Game(randomNum, topNum);
        }

        /*-------------- OLD CODE --------------*/
        //while (triesLeft > 0)
        //{
        //    if (Int32.TryParse(Console.ReadLine(), out guessNum))
        //    {
        //        bool rightGuess = CheckGuess(guessNum, randomNum);

        //        if (rightGuess)
        //        {
        //            break;
        //        }
        //        else
        //        {
        //            triesLeft--;
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("Du måste gissa på ett nummer");
        //    }
        //    if (triesLeft == 0)
        //    {
        //        Console.WriteLine("Tyvärr du lyckades inte gissa talet på fem försök!");
        //    }
        //}

        // Game method
        static bool Game(int randomNum, int topNum)
        {
            // Create variables needed
            int guessNum;
            // Sets how many tries the user have before the loop
            int triesLeft = 5;
            // Do while triesLeft is not 0
            while (triesLeft > 0)
            {
                // Writes out in what range the user have to guess
                Console.WriteLine($"\tGissa på ett nummer mellan 1 och {topNum}");
                Console.Write("\t");
                // Check input of user and try to parse this to int
                if (Int32.TryParse(Console.ReadLine(), out guessNum))
                {
                    // Check for bool value if guess is right or wrong
                    // by calling the method CheckGuess
                    bool rightGuess = CheckGuess(guessNum, randomNum, topNum);
                    // If answer is right, break out.
                    if (rightGuess)
                    {
                        break;
                    }
                    // Else sutract triesLeft with 1
                    else
                    {
                        triesLeft--;
                    }
                }
                // If user did not write a number
                else
                {
                    Console.WriteLine("\tDu måste gissa på ett nummer");
                }
                // If user doesn't have any tries left.
                if (triesLeft == 0)
                {
                    Console.WriteLine("\tTyvärr du lyckades inte gissa talet på fem försök!");
                }
            }
            // Ask if the user wants to play again
            Console.WriteLine("\tVill du spela igen? Y/N");
            Console.Write("\t");
            // Save user choice
            string playAgain = Console.ReadLine().ToUpper();
            // If user inputed y/Y return true, which will be
            // carried over by the methods to the Main Method
            return playAgain == "Y";
        }
        // static method to check guesses
        static bool CheckGuess(int guess, int rnd, int topNum)
        {
            // create variable
            int reply;
            // call method and save return value to string
            string close = HowClose(guess, rnd, topNum);
            // Creates an instance of random class
            Random replyNum = new Random();
            // if the guess is higher than random number
            if (guess > rnd)
            {
                // Creates a random number with each new guess
                reply = replyNum.Next(1, 5);
                // a switch to handle what text to write out depending on the random number
                switch (reply)
                {
                    case 1:
                        Console.WriteLine("\tTyvärr du gissade för högt!");
                        break;
                    case 2:
                        Console.WriteLine("\tHaha! Det var för högt!");
                        break;
                    case 3:
                        Console.WriteLine("\tTänk lägre!");
                        break;
                    case 4:
                        Console.WriteLine("\tFörsök gissa lägre!");
                        break;
                }
                // also write out the value from HowClose method at the end
                Console.WriteLine($"{close}");
                return false;
            }
            // if the guess is lower than random number
            else if (guess < rnd)
            {
                reply = replyNum.Next(1, 5);
                switch (reply)
                {
                    case 1:
                        Console.WriteLine("\tTyvärr du gissade för lågt!");
                        break;
                    case 2:
                        Console.WriteLine("\tHaha! Det var för lågt!");
                        break;
                    case 3:
                        Console.WriteLine("\tTänk högre!");
                        break;
                    case 4:
                        Console.WriteLine("\tFörsök gissa högre!");
                        break;
                }
                Console.WriteLine($"{close}");
                return false;
            }
            // Else the player guessed right
            else
            {
                // Else the player succeeded and we write out that he is victorious!
                Console.WriteLine("\tWohoo! Du gjorde det!");
                return true;
            }
        }
        // a static method that returns a string on how close
        // to the random number the user is.
        static string HowClose(int guess, int rnd, int maxValue)
        {
            // Calling the Math.abs to give an positive answer
            // else it could be 50-100 witch result to -50.
            // But the Abs gives the absolute value.
            // So it will instead give the value 50.
            double compared = Math.Abs(rnd - guess);
            // Here we divide the above value with the maximum range.
            // Meaning we will get a 0.** value that corresponds to
            // the % value which gives us an idea how close the user is.
            double result = compared / maxValue;

            /*-------------- OLD CODE --------------*/
            // if less or up to 10% close
            //if (result <= 0.1)
            //{
            //    return "\tNu bränns det!";
            //}
            //// if between 10,1% to 20%
            //else if (result >= 0.101 && result <= 0.2)
            //{
            //    return "\tNu är du nära!";
            //}
            //// if between 20,1% up to 50%
            //else if (result > 0.201 && result <= 0.5)
            //{
            //    return "\tDu går åt rätt håll!";
            //}
            //// If above 50% tell the user to go the other way
            //else
            //{
            //    return "\tGå åt andra hållet...";
            //}


            // switched out the if statements to a switch
            // As we learned this in class i wanted to implement it.
            // And as a result it was more neat to have it like this.
            switch (result)
            {
                case <= 0.1:
                    return "\tNu bränns det!";
                case >= 0.101 and <= 0.2:
                    return "\tNu är du nära!";
                case > 0.201 and <= 0.5:
                    return "\tDu går åt rätt håll!";
                default:
                    return "\tGå åt andra hållet...";
                // As a note, could implement better
                // margin for the cases for better hints
            }
        }
    }
}
