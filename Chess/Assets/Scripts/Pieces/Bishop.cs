using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Bishop : Piece
{
    public Bishop(Type type, PlayerColor color, Vector2Int pos) : base(type, color, pos)
    {}

    public override List<string> GetPossibleMovements()
    {
        return GetDiagonalPositions();
    }
}
