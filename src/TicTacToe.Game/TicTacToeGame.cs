namespace TicTacToe.Game;

using TicTacToe.Game.Models;

public class TicTacToeGame
{
    private readonly ToeGame Game;
    Player chancePlayer;
    Player? winPlayer;
    public TicTacToeGame(int boardSize, string playerXName, string playerOName, bool playWithAI)
    {
        Game = new ToeGame(boardSize, playerXName, Models.Enums.PlayerCode.X, playerOName, Models.Enums.PlayerCode.O, playWithAI);
        chancePlayer = Game.PlayerX;
    }

    public void Play()
    {
        winPlayer = null;
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
                    if (Game.PlayerO.IsAIPlayer)
                    {
                        Console.Clear();
                        Game.Board.PaintBoard();
                        Console.WriteLine("Please wait the Ai player is playing.....");
                        Thread.Sleep(2000);

                        var notChoicesItems = Game.Board.BoardItems.Where(a => !a.Code.HasValue).ToList();
                        if (notChoicesItems != null && notChoicesItems.Any())
                        {
                            var random = new Random();
                            int index = random.Next(notChoicesItems.Count());
                            var aiRandogChoice = notChoicesItems[index];
                            if (aiRandogChoice != null)
                                Game.Board.SetCodeToItem(aiRandogChoice.Id, Game.PlayerO.PlayerCode);
                        }
                    }
                    else
                    {
                        if (chancePlayer == Game.PlayerX)
                            chancePlayer = Game.PlayerO;
                        else
                            chancePlayer = Game.PlayerX;
                    }

                    winPlayer = Game.IsWin();
                }
            }
        }
        while (winPlayer is null && Game.Board.BoardItems.Any(a => !a.Code.HasValue));
        Console.Clear();
        Game.Board.PaintBoard();

        if (winPlayer is null)
            Console.WriteLine($"No woners");
        else
            Console.WriteLine($"Player {winPlayer.Name} has won");
    }
}