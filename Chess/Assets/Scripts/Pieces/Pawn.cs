using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Pawn : Piece
{
    
    
    public Pawn(Type type, PlayerColor color, Vector2Int pos) : base(type, color, pos)
    {}

    public override List<string> GetPossibleMovements()
    {
        // Walk
        int tiles = 1;
        if (Color == PlayerColor.WHITE && Board.GetPositionStr(Pos).Contains("2"))
        {
            tiles = 2;
        }
        
        if (Color == PlayerColor.BLACK)
        {
            if (Board.GetPositionStr(Pos).Contains("7"))
            {
                tiles = 2;   
            }
        }

        List<string> positions = new List<string>();
        for (int tile = 1; tile <= tiles; tile++)
        {
            int currTile = tile;
            if (Color == PlayerColor.BLACK)
            {
                currTile *= -1;
            }

            string boardPosition = Board.GetPositionStr(Pos + new Vector2Int(0, currTile));
            if (Game.GetInstance().CurrBoard.GetPieceInPosition(boardPosition) == null)
            {
                positions.Add(boardPosition);    
            }
            else
            {
                break;
            }
        }

        // Capture Movements
        if (Color == PlayerColor.WHITE)
        {
            positions = positions.Concat(GetCaptureMovements(new List<Vector2Int>() {new Vector2Int(-1, 1), new Vector2Int(1, 1)})).ToList();
        }
        else if (Color == PlayerColor.BLACK)
        {
            positions = positions.Concat(GetCaptureMovements(new List<Vector2Int>() {new Vector2Int(-1, -1), new Vector2Int(1, -1)})).ToList();
        }
        
        return positions;
    }
}
