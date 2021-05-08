using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Rook : Piece
{
    public Rook(Type type, PlayerColor color, Vector2Int pos) : base(type, color, pos)
    {}

    public override List<string> GetPossibleMovements()
    {
        return GetLinearPositions();
    }
}
