using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class King : Piece
{
    public King(Type type, PlayerColor color, Vector2Int pos) : base(type, color, pos)
    {}
    
    public override List<string> GetPossibleMovements()
    {
        List<string> positions = new List<string>();
        positions = positions.Concat(GetDiagonalPositions(1)).ToList();
        positions = positions.Concat(GetLinearPositions(1)).ToList();
        return positions;
    }
}
