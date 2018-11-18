using System;
using MarsRover.Domain;
using MarsRover.Repository;

namespace MarsRover.App
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] mars = new string[10, 10];

            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                {
                    var r = new Random().Next(0, 10);
                    mars[i, j] = (r > 8) ? "*" : "+";
                }

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(mars[i, j]);
                }

                Console.WriteLine("");
            }

            string command = "";

            IWorld world = new World(mars);

            MarsService service = new MarsService(world);

            bool run = true;

            while (run)
            {
                try
                {
                    Position position = null;
                    Console.WriteLine("Please insert commands: ");
                    Console.WriteLine("Type 'exit' to leave this application");
                    Console.WriteLine("Type 'land' to land your Mars Rover");
                    Console.WriteLine("Type 'command' to insert a series of commands for your Mars Rover");

                    command = Console.ReadLine();

                    if (command.ToLower() == "land")
                    {
                        Console.WriteLine("Insert your landing X cooridnates, max X = " + world.GetRightEdgeXCoordinates());
                        int x = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Insert your landing Y cooridnates, max Y = " + world.GetTopEdgeYCoordinates());
                        int y = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Insert your landing direction (N,S,E,W))");
                        var direction = Console.ReadLine().ToString();

                        DirectionEnum directionEnum = DirectionEnum.North;

                        if (direction.ToLower() == "n")
                            directionEnum = DirectionEnum.North;
                        if (direction.ToLower() == "s")
                            directionEnum = DirectionEnum.South;
                        if (direction.ToLower() == "e")
                            directionEnum = DirectionEnum.East;
                        if (direction.ToLower() == "w")
                            directionEnum = DirectionEnum.West;

                        position = service.LandRover(x, y, directionEnum);

                    }
                    else if (command.ToLower() == "command")
                    {
                        Console.WriteLine("Insert commands separated by comma ',' and press Enter for example:l,r,f,b");
                        string commands = Console.ReadLine();

                        string[] commandsArray = commands.Split(',', 9000);

                        position = service.MoveRover(commandsArray);

                        Console.WriteLine("New rover position: " + position.ToString());
                    }
                    else if (command.ToLower() == "exit")
                    {
                        run = false;
                    }
                    else
                        Console.WriteLine("Invalid command");

                    PrintMatrix(position, mars);

                }
                catch (RoverException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Last position " + ex.LastPosition.ToString());
                    PrintMatrix(ex.LastPosition, mars);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An errore has occurred: " + ex.Message);
                }
            }

            Console.WriteLine("Bye!!!");

        }

        private static void PrintMatrix(Position position, string[,] mars)
        {
            if (position != null)
            {
                int y = (mars.GetLength(1) - 1) - position.Y;
                int x = position.X;
                string dir = "[n]";

                if (position.Direction == DirectionEnum.East)
                    dir = "e";
                if (position.Direction == DirectionEnum.West)
                    dir = "w";
                if (position.Direction == DirectionEnum.South)
                    dir = "s";
                if (position.Direction == DirectionEnum.North)
                    dir = "n";

                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (j == x && y == i)
                            Console.Write(dir);
                        else
                            Console.Write(mars[i, j]);
                    }

                    Console.WriteLine("");
                }
            }
        }
    }
}
