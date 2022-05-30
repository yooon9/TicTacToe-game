using TicTacToe.Game;

Console.Write("Plase enter board game size:");
var boardGameSizeInput = Console.ReadLine();
int.TryParse(boardGameSizeInput, out int boardGameSize);

Console.Write("Plase enter player X Name:");
var playerXName = Console.ReadLine();

Console.Write("Want play with api player?yes(y)/no(n) default no:");
var playWithAiPlayerInput = Console.ReadLine();
var playWithAiPlayer = false;
if (!string.IsNullOrEmpty(playWithAiPlayerInput) && (playWithAiPlayerInput == "yes" || playWithAiPlayerInput == "y"))
    playWithAiPlayer = true;

var playerOName = "Ai";
if (!playWithAiPlayer)
{
    Console.Write("Plase enter player O Name:");
    playerOName = Console.ReadLine();
}

var playAgain = false;
do
{
    var game = new TicTacToeGame(boardGameSize == 0 ? 4 : boardGameSize,
    string.IsNullOrEmpty(playerXName) ? "X" : playerXName,
    string.IsNullOrEmpty(playerOName) ? "O" : playerOName,
    playWithAiPlayer);

    game.Play();

    Console.Write("Want play again?yes(y)/no(n) default no:");
    var playAgainInput = Console.ReadLine();
    playAgain = !string.IsNullOrEmpty(playAgainInput) && (playAgainInput == "yes" || playAgainInput == "y");
} while (playAgain);
{
}