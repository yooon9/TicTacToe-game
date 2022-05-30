using TicTacToe.Game;

Console.Write("Plase enter board game size:");
var boardGameSizeInput = Console.ReadLine();


Console.Write("Plase enter player O Name:");
var playerOName = Console.ReadLine();

Console.Write("Plase enter player X Name:");
var playerXName = Console.ReadLine();

int.TryParse(boardGameSizeInput, out int boardGameSize);

var game = new TicTacToeGame(boardGameSize == 0 ? 4 : boardGameSize,
    string.IsNullOrEmpty(playerXName) ? "X" : playerXName,
    string.IsNullOrEmpty(playerOName) ? "O" : playerOName);

game.Play();