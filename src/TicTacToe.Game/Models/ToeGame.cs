namespace TicTacToe.Game.Models;

using TicTacToe.Game.Models.Enums;

public class ToeGame
{
    public ToeGame(int boardSize,
        string playerXName, PlayerCode playerXCode,
        string playerOName, PlayerCode playerOCode,
        bool playWithAI)
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
            PlayerCode = playerOCode,
            IsAIPlayer = playWithAI
        };
    }

    public Board Board { get; set; }
    public Player? PlayerX { get; set; }
    public Player? PlayerO { get; set; }

    //Checking that any player has won or not
    public Player? IsWin()
    {
        Player? won = null;
        for (int y = 0; y < Board.Size; y++)
        {
            var yRows = Board.BoardItems
               .Where(a => a.IndexY == y)
               .ToList();
            won = ValidatePlayer(yRows);
            if (won != null)
                return won;

            var xRows = Board.BoardItems
               .Where(a => a.IndexX == y)
               .ToList();
            won = ValidatePlayer(xRows);
            if (won != null)
                return won;
        }

        var xxyRows = new List<BoardItem>();
        for (int y = 1; y <= Board.Size; y++)
        {
            var xxyRow = Board.BoardItems.FirstOrDefault(a => a.IndexY == y - 1 && a.IndexX == Board.Size - y);
            if (xxyRow != null)
            {
                xxyRows.Add(xxyRow);
            }
        }
        won = ValidatePlayer(xxyRows);
        if (won != null)
            return won;

        var xyRows = Board.BoardItems.Where(a => a.IndexX == a.IndexY).ToList();
        won = ValidatePlayer(xyRows);
        return won;
    }

    private Player? ValidatePlayer(List<BoardItem> boardItems)
    {
        if (boardItems.Count == Board.Size)
        {
            if (boardItems.All(a => a.Code == PlayerCode.X))
                return PlayerX;
            if (boardItems.All(a => a.Code == PlayerCode.O))
                return PlayerO;
        }
        return null;
    }
}
