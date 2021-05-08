using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Queen : Piece
{
    public Queen(Type type, PlayerColor color, Vector2Int pos) : base(type, color, pos)
    {}

    public override List<string> GetPossibleMovements()
    {
        List<string> positions = new List<string>();
        positions = positions.Concat(GetDiagonalPositions()).ToList();
        positions = positions.Concat(GetLinearPositions()).ToList();
        return positions;
    }
}
