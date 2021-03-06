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
        string posStr = "";
        // Create Pawns Pieces
        for (int i = 0; i < 8; i++)
        {
            // posStr = _columns[i] + "2";
            // Piece whitePawn = Piece.Create(Piece.Type.Pawn, Piece.PlayerColor.WHITE, Board.GetPosition(posStr)); 
            // _pieces.Add(posStr, whitePawn);
            //
            // posStr = _columns[i] + "7";
            // Piece blackPAwn = Piece.Create(Piece.Type.Pawn, Piece.PlayerColor.BLACK, Board.GetPosition(posStr)); 
            // _pieces.Add(posStr, blackPAwn);
        }
        
        posStr = "b1";
        _pieces.Add(posStr, Piece.Create(Piece.Type.Knight, Piece.PlayerColor.WHITE, Board.GetPosition(posStr)));
        posStr = "g1";
        _pieces.Add(posStr, Piece.Create(Piece.Type.Knight, Piece.PlayerColor.WHITE, Board.GetPosition(posStr)));
        
        posStr = "b8";
        _pieces.Add(posStr, Piece.Create(Piece.Type.Knight, Piece.PlayerColor.BLACK, Board.GetPosition(posStr)));
        posStr = "g8";
        _pieces.Add(posStr, Piece.Create(Piece.Type.Knight, Piece.PlayerColor.BLACK, Board.GetPosition(posStr)));
        
        posStr = "a1";
        _pieces.Add(posStr, Piece.Create(Piece.Type.Rook, Piece.PlayerColor.WHITE, Board.GetPosition(posStr)));
        posStr = "h1";
        _pieces.Add(posStr, Piece.Create(Piece.Type.Rook, Piece.PlayerColor.WHITE, Board.GetPosition(posStr)));
        
        posStr = "a8";
        _pieces.Add(posStr, Piece.Create(Piece.Type.Rook, Piece.PlayerColor.BLACK, Board.GetPosition(posStr)));
        posStr = "h8";
        _pieces.Add(posStr, Piece.Create(Piece.Type.Rook, Piece.PlayerColor.BLACK, Board.GetPosition(posStr)));
        
        posStr = "c1";
        _pieces.Add(posStr, Piece.Create(Piece.Type.Bishop, Piece.PlayerColor.WHITE, Board.GetPosition(posStr)));
        posStr = "f1";
        _pieces.Add(posStr, Piece.Create(Piece.Type.Bishop, Piece.PlayerColor.WHITE, Board.GetPosition(posStr)));
        
        posStr = "c8";
        _pieces.Add(posStr, Piece.Create(Piece.Type.Bishop, Piece.PlayerColor.BLACK, Board.GetPosition(posStr)));
        posStr = "f8";
        _pieces.Add(posStr, Piece.Create(Piece.Type.Bishop, Piece.PlayerColor.BLACK, Board.GetPosition(posStr)));
        
        posStr = "d1";
        _pieces.Add(posStr, Piece.Create(Piece.Type.Queen, Piece.PlayerColor.WHITE, Board.GetPosition(posStr)));
        
        posStr = "d8";
        _pieces.Add(posStr, Piece.Create(Piece.Type.Queen, Piece.PlayerColor.BLACK, Board.GetPosition(posStr)));
        
        posStr = "e1";
        _pieces.Add(posStr, Piece.Create(Piece.Type.King, Piece.PlayerColor.WHITE, Board.GetPosition(posStr)));
        
        posStr = "e8";
        _pieces.Add(posStr, Piece.Create(Piece.Type.King, Piece.PlayerColor.BLACK, Board.GetPosition(posStr)));
    }

    public void Move(string origin, string destination)
    {
        Piece originPiece = _pieces[origin];
        originPiece.SetPosition(destination);
        _pieces.Remove(origin);

        if (_pieces.ContainsKey(destination))
        {
            Piece capturedPiece = _pieces[destination];
            capturedPiece.Capture();
            _pieces.Remove(destination);
        }
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
        if (pos.x < 0 || pos.x > 7)
        {
            return null;
        }

        if (pos.y < 0 || pos.y > 7)
        {
            return null;
        }
        
        string posStr = _columns[pos.x] + "" + (pos.y + 1);

        return posStr;
    }
}
