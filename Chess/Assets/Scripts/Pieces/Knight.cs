using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Knight : Piece
{
    public Knight(Type type, PlayerColor color, Vector2Int pos) : base(type, color, pos)
    {}

    public override List<string> GetPossibleMovements()
    {
        List<string> positions = CheckMovements(new List<Vector2Int>()
        {
            new Vector2Int(-2, 1),
            new Vector2Int(-2, -1),
            new Vector2Int(2, 1),
            new Vector2Int(2, -1),
            new Vector2Int(1, 2),
            new Vector2Int(-1, 2),
            new Vector2Int(1, -2),
            new Vector2Int(-1, -2),
        });
        return positions;
    }
}
