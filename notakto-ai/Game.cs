public class Game
{
  public string Model { get; set; }
  public bool IsFinished { get; set; }
  public int Winner { get; set; } 
  public List<Table> Tables { get; set; } = new List<Table>();
  public Game(string model, int tables)
  {
    Model = model;
    for(int i = 0; i < tables; i++)
      Tables.Add(new Table());
  }

  public bool Play(string file)
  {
    string filename = Model + ".txt";

    if(file == filename.Replace(".txt", " last.txt"))
    {
      var content = File.ReadAllText(file);
      var data = content
        .Split(' ')
        .Select(int.Parse)
        .ToArray();
      
      

      return true;
    }
    return false;

    
  }
}