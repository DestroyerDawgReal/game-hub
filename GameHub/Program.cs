


using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
// allow emojis
Console.OutputEncoding = Encoding.UTF8;
//list of games
List<string> games = ["Minecraft", "Phasmophobia", "Fortnite", "Dead by Daylight"];
 bool inFileMenu = true;
Console.WriteLine("Welcome to the Game Hub!");
 bool hasBeenRenamed = false;
string gameFilePath = @"C:\Users\Public\coding projects\C#\GameHub\GameHub\games.txt";

void RandomGame()
{
     int randomGameIndex = Random.Shared.Next(games.Count);
     string random_game = games[randomGameIndex];
     Console.WriteLine($"Random game is: '{random_game}'");

}



// convert string input to int to avoid casting errors
int choice = 0;
// iterate until user wants to exit (7)
while (choice != 6)
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
        // NEW FILE NAME DECLERATION SO IT GETS RECOGNIZED
      string newName = "";
      void displayGames()
        {
             Console.WriteLine("Here are the games in your collection:\n" );
             Console.WriteLine(string.Join("\n ", games));
        }
         void RemoveAllGames()
        {   int listCount = games.Count();
            foreach (string item in games.ToList())
                {   
                    games.Remove(item);
                    

                }
            Console.WriteLine($"{listCount} games were removed!");
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
               displayGames();
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
                RandomGame();
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
    }           Console.WriteLine($"{deletedGame} was removed!");
        }
          
             
        
        else if (choice2 == "5")
        {
            
              Console.WriteLine("test");

        }

        
           
        
      
        else if (choice2 == "6")
            {
            if (!File.Exists(gameFilePath) && !hasBeenRenamed ) 
                
            {   
                Console.WriteLine("the file does not exist!");
                Console.WriteLine("Creating games file... \n");
                File.AppendAllLines("games.txt", games);
                inFileMenu = true;
                
                
            }  
           
            while (inFileMenu)
            {
            Console.WriteLine("What would you like to do with your games file? 1. append to it 2. rename it \n 3.  open it on your device 4. delete it (CANNOT undo this) 5. exit this menu");
            string fileChoice = Console.ReadLine();

            
             
             
            
            /* 
                  
            */

            
                
            
                
           

              if (fileChoice == "1")
            {
                Console.WriteLine(" what would you like to append?: ");
                string appendFile = Console.ReadLine();

                File.AppendAllText("games.txt", appendFile + Environment.NewLine);
                Console.WriteLine($"{appendFile} was appended!");
            }

                else if(fileChoice == "2")

            {   Console.WriteLine("What would you like to rename this file to?: ");
                newName = Console.ReadLine();
                System.IO.File.Move("games.txt", newName);
                Console.WriteLine($"File was renamed to {newName}!");
                hasBeenRenamed = true;
            }
                else if(fileChoice == "3")

            { 


                if (File.Exists(@"C:\Users\Public\coding projects\C#\GameHub\GameHub\games.txt"))
                    {   string originalFilepath = $"\"{@"C:\Users\Public\coding projects\C#\GameHub\GameHub\games.txt"}\"";
                        Process.Start("notepad.exe", originalFilepath);
                    }
        
                else if (hasBeenRenamed)
                    {   
                         string fullPath = @"C:\Users\Public\coding projects\C#\GameHub\GameHub\";
                         string original = Path.Combine(fullPath, "games.txt");
                         string renamed = Path.Combine(fullPath, newName);
                         string targetFile = File.Exists(renamed) ? renamed : original;
                         string argument = $"\"{targetFile}\"";
                         Process.Start("notepad.exe", argument);
                    }    
               
            } 

                else if(fileChoice == "4")

            {   string fullPath = @"C:\Users\Public\coding projects\C#\GameHub\GameHub\";
                string original = Path.Combine(fullPath, "games.txt");
                string renamed = Path.Combine(fullPath, newName);
                string targetFile = File.Exists(renamed) ? renamed : original;
                string argument = $"\"{targetFile}\"";

                if (File.Exists("games.txt"))
                    {
                        File.Delete("games.txt");
                        
                    }
                else if (File.Exists(targetFile))
                    {
                        File.Delete(targetFile);
                    }
                else if (!File.Exists("games.txt") && !File.Exists(targetFile) )
                    {   
                        Console.WriteLine("No games file exists!");
                          
                    }
                
 
            }
                else if(fileChoice == "5")

                {   
                    inFileMenu = false;
                }
              }
            }                
              
               
            
            
            
                
        else if (choice2 == "7")
        {
            
            Console.WriteLine("Are you sure you want to remove all games? This CANNOT be undone! Y/N");
            string deleteAllGames = Console.ReadLine();
            if (deleteAllGames.ToUpper() == "Y")
            {   
                RemoveAllGames();
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


