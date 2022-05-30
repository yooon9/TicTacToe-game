namespace TicTacToe.Game;

using TicTacToe.Game.Models;

public class TicTacToeGame
{
    private readonly ToeGame Game;
    Player chancePlayer;
    Player? winPlayer;
    public TicTacToeGame(int boardSize, string playerXName, string playerOName)
    {
        Game = new ToeGame(boardSize, playerXName, Models.Enums.PlayerCode.X, playerOName, Models.Enums.PlayerCode.O);
        chancePlayer = Game.PlayerX;
    }

    public void Play()
    {
        do
        {
            Console.Clear();
            Console.WriteLine($"{Game.PlayerX.Name}:X and {Game.PlayerO.Name}:O");
            Console.WriteLine("\n");

            Console.WriteLine($"{chancePlayer.Name} Chance");

            Console.WriteLine("\n");
            Game.Board.PaintBoard();

            var choiceInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(choiceInput) && int.TryParse(choiceInput, out int choice))
            {
                if (Game.Board.SetCodeToItem(choice, chancePlayer.PlayerCode))
                {
                    if (chancePlayer == Game.PlayerX)
                        chancePlayer = Game.PlayerO;
                    else
                        chancePlayer = Game.PlayerX;

                    winPlayer = Game.IsWin();
                }
            }
        }
        while (winPlayer is null);
        Console.Clear();
        Game.Board.PaintBoard();
        Console.WriteLine($"Player {winPlayer.Name} has won");
        Console.ReadLine();
    }
}