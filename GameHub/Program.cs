
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics.Tracing;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
// allow emojis
Console.OutputEncoding = Encoding.UTF8;
//list of games
List<string> games = ["Minecraft", "Phasmophobia", "Fortnite", "Dead by Daylight"];

Console.WriteLine("Welcome to the Game Hub");




// convert string input to int to avoid casting errors
int choice = 0;
// iterate until user wants to exit (7)
while (choice != 7)
{   

    
    Console.WriteLine("╔══════════════════════════════════╗\r\n║          GAME HUB                ║\r\n╠══════════════════════════════════╣\r\n║                                  ║\r\n║  🎮 My Games(1)                  ║\r\n║  🎲 Random Game   (2)            ║\r\n║  👾 Random Challenge   (3)       ║\r\n║  💡 Video Ideas  (4)             ║\r\n║  📊 Gaming Stats       (5)       ║\r\n║  ⚙ Settings       (6)            ║\r\n║    Exit 🚪 (7)                   ║\r\n╚══════════════════════════════════╝");
    Console.Write("Enter your choice: ");
     
    // accepts any input that is not an int and returns invalid input
    if (!int.TryParse(Console.ReadLine(), out choice))
    {
        Console.WriteLine("Invalid input.");
    }


    
    if (choice == 1)
    {
        
        Console.WriteLine("Here are the games in your collection:\n" );
        Console.WriteLine(string.Join("\n ", games));
    outerLoop:
        Console.WriteLine("Would you like to add a game? Y/N: ");
        string AddGame = Console.ReadLine();
        Console.WriteLine("Do you want to delete a game? Y/N");
        string choice2 = Console.ReadLine();
        if (choice2.ToUpper()  == "Y")
        {
            Console.WriteLine("What game do you want to delete?");
            string deletedGame = Console.ReadLine();
            string matchedGame = games.Find(g => g.Equals(deletedGame, StringComparison.OrdinalIgnoreCase));

            // string deletedGame_lower = deletedGame.ToLower();
            games.Remove(matchedGame);

        }
        else if (choice2.ToUpper() == "N")
        {
            continue;
        }
        else if (AddGame.ToUpper() == "Y")
        {
            Console.WriteLine("What game would you like to add?: ");
            string whatGame = Console.ReadLine();
            games.Add(whatGame);
            Console.WriteLine($"{whatGame} added to your library!");
           
        }
        else if (AddGame.ToUpper() == "N")
        {
            
            continue;
            
        }

        else
        {
            Console.WriteLine("Invalid Input. Enter only 'Y' or 'N'");
            goto outerLoop;
        }
    }

    else if (choice == 2)
    {   // choose random string (game) from the list
        // string chosen = games[Random.Shared.Next(games.Count)];
        int randomGameIndex = Random.Shared.Next(games.Count);
        string random_game = games[randomGameIndex];
        Console.WriteLine("Random game is: " + random_game);
        continue;
    }
}


