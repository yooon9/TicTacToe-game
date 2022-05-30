namespace TicTacToe.Game.Models;

using TicTacToe.Game.Models.Enums;

public class ToeGame
{
    public ToeGame(int boardSize,
        string playerXName, PlayerCode playerXCode,
        string playerOName, PlayerCode playerOCode)
    {
        Board = new Board(boardSize);
        PlayerX = new Player
        {
            Name = playerXName,
            PlayerCode = playerXCode
        };
        PlayerO = new Player
        {
            Name = playerOName,
            PlayerCode = playerOCode
        };
    }

    public Board Board { get; set; }
    public Player? PlayerX { get; set; }
    public Player? PlayerO { get; set; }

    //Checking that any player has won or not
    public Player? IsWin()
    {
        //int id = 1;
        //for (int y = 0; y < Board.Size; y++)
        //{
        //    var xCode = PlayerCode.X;
        //    for (int x = Board.Size; x > 0; x--)
        //    {
        //        Board.BoardItems.FirstOrDefault(a => a.Id == id);
        //        if (true)
        //        {

        //        }
        //        id++;
        //    }
        //}


        return null;
    }
}
