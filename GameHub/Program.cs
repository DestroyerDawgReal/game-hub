

using System.Runtime.CompilerServices;
using System.Text;
// allow emojis
Console.OutputEncoding = Encoding.UTF8;
//list of games
List<string> games = ["Minecraft", "Phasmophobia", "Fortnite", "Dead by Daylight"];

Console.WriteLine("Welcome to the Game Hub!");



void Del_All_Games()
{
     int randomGameIndex = Random.Shared.Next(games.Count);
     string random_game = games[randomGameIndex];
     Console.WriteLine($"Random game is: '{random_game}'");

}


// convert string input to int to avoid casting errors
int choice = 0;
// iterate until user wants to exit (7)
while (choice != 7)
{   

    
    Console.WriteLine("\n 1. Games \n 2. Challenges \n 3. Video Ideas \n 4. Settings  \n 5. School/Revision \n 6. Exit");
    Console.Write("Enter your choice: ");
     
    // accepts any input that is not an int and returns invalid input
    if (!int.TryParse(Console.ReadLine(), out choice))
    {
        Console.WriteLine("Invalid input.");
    }


    
    if (choice == 1)
    {
        
        
        
        gameMenuLoop:
        Console.WriteLine(" What do you want to do? \n 1. add a game \n 2. view games \n 3. pick a random game \n 4. delete a game \n 5. view game stats \n 6. manage games file \n 7. delete all games (cannot undo this!)  ");
        string choice2 = Console.ReadLine();
        
     void addGameToLibrary ()
        {
            Console.WriteLine("What game would you like to add?: ");
            string whatGame = Console.ReadLine();
            games.Add(whatGame);
            Console.WriteLine($"'{whatGame}' added to your library!");
            
        }
    

    

    


         if (choice2 == "1")
        {
           
            addGameToLibrary();
           
        }
          
        else if (choice2 == "2")
        {
               if (games.Count == 0 || games.All(string.IsNullOrWhiteSpace))
            {
                Console.WriteLine("There are no games in your collection!");
                await Task.Delay(2000);

            }
            else
            {
               Console.WriteLine("Here are the games in your collection:\n" );
               Console.WriteLine(string.Join("\n ", games));
               await Task.Delay(2000);
            }
            
              
        }

        else if (choice2 == "3")
    {   // choose random string (game) from the list
        // string chosen = games[Random.Shared.Next(games.Count)];
        if (games.Count == 0 || games.All(string.IsNullOrWhiteSpace))
            {
                
                Console.WriteLine("You have no games in your collection!");
            }

            else
            {
                
                await Task.Delay(2000);
                continue;
            }
        
    }
        else if (choice2 == "4")
        {
            Console.WriteLine("What game do you want to delete?");
            string deletedGame = Console.ReadLine();
            
             if (!games.Contains(deletedGame))
            {
                Console.WriteLine($"'{deletedGame}' is not in the list, try again!");
                

            }
            
           

            

            
            
            else
            { 
                deleteGame();
            }

        void deleteGame()
    {           // search the list with .find(), uses g => to create a loop by holding a temp variable of each game find() checks
                 // .equals() compares the user's inputted deleted game with the current game
                 //  then .OrdinalIgnoreCase makes this comparison non case- sensitive
                string matchedGame = games.Find(g => g.Equals(deletedGame, StringComparison.OrdinalIgnoreCase));
                games.Remove(matchedGame);
    }    
        }
        
        else if (choice2 == "5")
        {
            
              Console.WriteLine("test");

        }
        else if (choice2 == "6")
            {   
                Console.WriteLine("Creating games file... \n");
                File.AppendAllLines("games.txt", games);
                 
                Console.WriteLine("What would you like to do with your games file? 1. append to it 2. rename it 3. open it on your device 4. delete it (CANNOT undo this) ");
                choice2 = Console.ReadLine();

                if(choice2 == "1")
            {
                Console.WriteLine(" what would you like to append?: ");
                string appendFile = Console.ReadLine();
                File.AppendAllText("games.txt", appendFile + Environment.NewLine);
                Console.WriteLine($"{appendFile} was appended!");
            }

                else if(choice2 == "2")

            {   Console.WriteLine("What would you like to rename this file to?: ");
                string newName = Console.ReadLine();
                System.IO.File.Move("games.txt", newName);
                
            }
            }
        else if (choice2 == "7")
        {
            
            Console.WriteLine("Are you sure you want to remove all games? This CANNOT be undone! Y/N");
            string deleteAllGames = Console.ReadLine();
            if (deleteAllGames.ToUpper() == "Y")
            {
                foreach (string item in games.ToList())
                {
                    games.Remove(item);

                }
            }
            else if (deleteAllGames.ToUpper() == "N")
            {
                return;

            }
        

        }

          
        
       
             
       
      

        else
        {
            Console.WriteLine("Invalid Input. Enter only 'Y' or 'N'");
            goto gameMenuLoop;
        }
    }

    
}


