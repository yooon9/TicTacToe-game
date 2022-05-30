namespace TicTacToe.Game.Models
{
    using TicTacToe.Game.Models.Enums;

    public class Player
    {
        public string Name { get; set; }
        public PlayerCode PlayerCode { get; set; }
        public bool IsAIPlayer { get; set; } = false;
    }
}
