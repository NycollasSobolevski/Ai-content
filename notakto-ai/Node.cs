using static System.Math;
public class Node
{
  public List<Node> Childs { get; set; } = new List<Node>();
  public int Table { get; set; }
  public int Value { get; set; }
  public Node(int value)
  {
    Value = value;
  }

  public void Add(Node n) => Childs.Add(n);
  public bool IsTerminalNode() => Childs.Count == 0;

  public float MiniMax(Node node, bool maximize, int depth)
  {
    if(depth == 0 || node.IsTerminalNode())
    {
      return 0;
    }

    float value;
    if(maximize)
    {
      value = float.NegativeInfinity;
      foreach(Node child in node.Childs)
      {
        value = Max(value, MiniMax(child, false, depth - 1));
      }
      return value;
    }
    else
    {
      value = float.PositiveInfinity;
      foreach(Node child in node.Childs)
      {
        value = Min(value, MiniMax(child, true, depth - 1));
      }
      return value;
    }
  }
}