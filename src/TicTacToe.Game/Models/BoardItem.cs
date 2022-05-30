namespace TicTacToe.Game.Models
{
    using TicTacToe.Game.Models.Enums;

    public class BoardItem
    {
        public int Id { get; set; }
        public int IndexY { get; set; }
        public int IndexX { get; set; }
        public PlayerCode? Code { get; set; }
    }
}
