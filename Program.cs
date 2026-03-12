// Bryson, 03/11/2026, Lab 8: Maze

//gives the function needed for the stopwatch
using System.Diagnostics;


// nice greeting
Console.WriteLine("Welcome to the Maze Game!");
Console.WriteLine("Reach the * to win. Press ESC to quit.");
Console.WriteLine("Press any key to start...");
Console.ReadKey(true);

// load the map file and give error if can't find
string fileName = "map.txt";
if (!File.Exists(fileName))
{
    Console.WriteLine("Error: map.txt not found!");
    return;
}

string[] mazeData = File.ReadAllLines(fileName);

// display the maze
Console.Clear();
foreach (string line in mazeData)
{
    Console.WriteLine(line);
}

//a the starting position
Console.SetCursorPosition(0,0);
bool isPlaying = true;
//needed to add so you can win while still having the timer.
bool hasWon = false;

//the game moving loop/function
void TryMove(int newTop, int newLeft, string[] maze)
{
    if (newTop < 0 || newTop >= maze.Length) return;
    if (newLeft < 0 || newLeft >= maze[newTop].Length) return;
    if (maze[newTop][newLeft] == '#') return;

    Console.SetCursorPosition(newLeft, newTop);
}

//extra start the timer
Stopwatch missionTimer = new Stopwatch();
missionTimer.Start();


do
{
    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
    int currentTop = Console.CursorTop;
    int currentLeft = Console.CursorLeft;

    if (keyInfo.Key == ConsoleKey.Escape)
    {
        isPlaying = false;
    }
    else if (keyInfo.Key == ConsoleKey.UpArrow)
    {
        TryMove(currentTop - 1, currentLeft, mazeData);
    }
    else if ( keyInfo.Key == ConsoleKey.DownArrow)
    {
        TryMove(currentTop + 1, currentLeft,mazeData);
    }
    else if ( keyInfo.Key == ConsoleKey.LeftArrow)
    {
        TryMove(currentTop,currentLeft -1, mazeData);
    }
    else if ( keyInfo.Key == ConsoleKey.RightArrow)
    {
        TryMove(currentTop, currentLeft + 1, mazeData);
    }

    //lets you win/ and end to the game.
    //had to make new win condition
    if (mazeData[Console.CursorTop][Console.CursorLeft] == '*')
    {
        hasWon = true;
        isPlaying = false;
    }

} while(isPlaying);

// stops timer
missionTimer.Stop(); 
Console.Clear();

//displays if won or lost/just left.
if (hasWon)
{
    Console.WriteLine("*********************************");
    Console.WriteLine("   CONGRATULATIONS! YOU WON!     ");
    Console.WriteLine($"   Time: {missionTimer.Elapsed.TotalSeconds:F2} seconds");
    Console.WriteLine("*********************************");
}
else
{
    Console.WriteLine("Game Exited. Better luck next time!");
}