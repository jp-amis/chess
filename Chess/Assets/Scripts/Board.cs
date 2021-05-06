using System;
using System.Collections.Generic;
using UnityEngine;

public class Board
{
    private static List<string> _columns = new List<string>() { "a", "b", "c", "d", "e", "f", "g", "h" };


    private Dictionary<string, Piece> _pieces = new Dictionary<string, Piece>();
    
    private List<Piece> _whitePieces = new List<Piece>();
    private List<Piece> _blackPieces = new List<Piece>();
    
    public Board()
    {
        // Create Pawns Pieces
        for (int i = 0; i < 8; i++)
        {
            string posStr = _columns[i] + "2";
            Piece whitePawn = Piece.Create(Piece.Type.Pawn, Piece.PlayerColor.WHITE, Board.GetPosition(posStr)); 
            _pieces.Add(posStr, whitePawn);

            posStr = _columns[i] + "7";
            Piece blackPAwn = Piece.Create(Piece.Type.Pawn, Piece.PlayerColor.BLACK, Board.GetPosition(posStr)); 
            _pieces.Add(posStr, blackPAwn);
        }
    }

    public void Move(string origin, string destination)
    {
        Piece originPiece = _pieces[origin];
        originPiece.SetPosition(destination);
        _pieces.Remove(origin);
        _pieces.Add(destination, originPiece);
    }

    public Piece GetPieceInPosition(string posStr)
    {
        if (!_pieces.ContainsKey(posStr))
        {
            return null;
        }

        return _pieces[posStr];
    }

    public static Vector2Int GetPosition(string posStr)
    {
        Vector2Int pos = Vector2Int.zero;
        pos.x = _columns.IndexOf(posStr.Substring(0, 1));
        pos.y = (Convert.ToInt32(posStr.Substring(1, 1))) - 1;

        return pos;
    }

    public static string GetPositionStr(Vector2Int pos)
    {
        string posStr = _columns[pos.x] + "" + (pos.y + 1);

        return posStr;
    }
}
