// See https://aka.ms/new-console-template for more information
using TicTacToe.Game;
using TicTacToe.Game.Models;

Console.Write("Plase enter board game size:");
var boardGameSize = Console.ReadLine();

Console.Write("Plase enter player O Name:");
var playerOName = Console.ReadLine();

Console.Write("Plase enter player X Name:");
var playerXName = Console.ReadLine();

var game = new TicTacToeGame(int.Parse(boardGameSize ?? "4"), playerXName ?? "X", playerOName ?? "O");


int player = 1;
int choice;
Player? winPlayer;

do
{
    Console.Clear();
    Console.WriteLine($"{playerXName}:X and {playerOName}:O");
    Console.WriteLine("\n");
    if (player % 2 == 0)//checking the chance of the player
    {
        Console.WriteLine($"{playerOName} Chance");
    }
    else
    {
        Console.WriteLine($"{playerXName} Chance");
    }
    Console.WriteLine("\n");
    game.Play();


    var choiceInput = Console.ReadLine();
    if (!string.IsNullOrEmpty(choiceInput) && int.TryParse(choiceInput,out choice))
    {
        if (player % 2 == 0)
            game.SetCode(choice, TicTacToe.Game.Models.Enums.PlayerCode.O);
        else
            game.SetCode(choice, TicTacToe.Game.Models.Enums.PlayerCode.X);
    }

    player++;
    winPlayer = game.IsWin();
}
while (winPlayer is null);
Console.Clear();
game.Play();
Console.WriteLine($"Player {winPlayer.Name} has won");
Console.ReadLine();