namespace TicTacToe.Game;

using TicTacToe.Game.Models;
using TicTacToe.Game.Models.Enums;

public class TicTacToeGame
{
    private readonly ToeGame Game;
    public TicTacToeGame(int boardSize, string playerXName, string playerOName)
    {
        Game = new ToeGame(boardSize, playerXName, Models.Enums.PlayerCode.X, playerOName, Models.Enums.PlayerCode.O);
    }

    public void Play()
    {
        Game.Board.PaintBoard();
    }

    public void SetCode(int id, PlayerCode Code)
    {
        var item = Game.Board.BoardItems.FirstOrDefault(x => x.Id == id);
        if (!item.Code.HasValue)
        {
            item.Code = Code;
        }
        else
        {
            Console.WriteLine("Sorry the row {0} is already marked with {1}", id, item.Code.Value);
            Console.WriteLine("\n");
            Console.WriteLine("Please wait 2 second board is loading again.....");
            Thread.Sleep(2000);
        }
    }
    public Player? IsWin()
    {
        return Game.IsWin();
    }

}