using System;
using System.Collections.Generic;
using UnityEngine;

public class Board
{
    private static List<string> _columns = new List<string>() { "a", "b", "c", "d", "e", "f", "g", "h" };
    
    
    private List<Piece> _whitePieces = new List<Piece>();
    private List<Piece> _blackPieces = new List<Piece>();
    
    public Board()
    {
        // Create Pawns Pieces
        for (int i = 0; i < 8; i++)
        {
            _whitePieces.Add(Piece.Create(Piece.Type.PAWN, Piece.Color.WHITE, Board.GetPosition(_columns[i]+"2")));
            _blackPieces.Add(Piece.Create(Piece.Type.PAWN, Piece.Color.BLACK, Board.GetPosition(_columns[i]+"7")));
        }
    }

    public static Vector2Int GetPosition(string posStr)
    {
        Vector2Int pos = Vector2Int.zero;
        pos.x = _columns.IndexOf(posStr.Substring(0, 1));
        pos.y = (Convert.ToInt32(posStr.Substring(1, 1))) - 1;

        return pos;
    }
}
