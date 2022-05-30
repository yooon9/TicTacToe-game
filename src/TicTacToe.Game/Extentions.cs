namespace TicTacToe.Game
{

    public static class ExtentionsHelper
    {
        public static string GetLineDash(int boarSize)
        {
            string lineDash = "------";
            for (int i = 0; i < boarSize; i++)
            {
                lineDash += "-------";
            }
            return lineDash;
        }
    }
}
