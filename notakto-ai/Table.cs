public class Table
{
  public bool[] pos { get; set; } = new bool[9];

  public bool IsTableFinished()
  {
    if(
      pos[0] && pos[1] && pos[2] || // horizontals
      pos[3] && pos[4] && pos[5] ||
      pos[6] && pos[7] && pos[8] || 
      pos[0] && pos[4] && pos[8] || // diagonals
      pos[2] && pos[4] && pos[6] ||
      pos[0] && pos[3] && pos[6] || // verticals
      pos[1] && pos[4] && pos[7] ||
      pos[2] && pos[5] && pos[8] 
    )
      return true;
    
    return false;
  }

  private bool isValidMove(int move) => pos[move] == false;

  public bool MakeMove(int move)
  {
    if(isValidMove(move))
    {
      pos[move] = true;
      return true;
    }

    return false;
  }
}