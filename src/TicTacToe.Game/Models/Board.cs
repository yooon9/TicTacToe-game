namespace TicTacToe.Game.Models
{
    public class Board
    {
        public Board(int boardSize)
        {
            Size = boardSize;
            SetBoardItems(boardSize);
        }
        public int Size { get; set; }
        public List<BoardItem> BoardItems { get; set; }
        private void SetBoardItems(int boardSize)
        {
            BoardItems = new List<BoardItem>();
            int id = 1;
            for (int y = 0; y < boardSize; y++)
            {
                for (int x = boardSize; x > 0; x--)
                {
                    BoardItems.Add(new BoardItem
                    {
                        Id = id,
                        IndexY = y,
                        IndexX = x,
                    });
                    id++;
                }
            }
        }

        public void PaintBoard()
        {
            string lineDash = ExtentionsHelper.GetLineDash(Size);
            Console.WriteLine(lineDash);
            for (int i = 0; i < Size; i++)
            {
                var xBorders = BoardItems.Where(a => a.IndexY == i);
                foreach (var x in xBorders)
                {
                    bool hasCodeValue = x.Code.HasValue;
                    int idStringLength = hasCodeValue ? 1 : x.Id.ToString().Length;
                    Console.Write(idStringLength < 2 ? "|   " : idStringLength < 3 ? "|  " : "| ");

                    var write = hasCodeValue ? x.Code.Value.ToString() : x.Id.ToString();
                    Console.Write($" {write} ");
                }
                Console.Write($"  |");
                Console.WriteLine();
                Console.WriteLine(lineDash);
            }
        }
    }
}
