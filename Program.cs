// Bryson, 03/11/2026, Lab 8: Maze

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