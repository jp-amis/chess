using System;
using UnityEngine;

public class Piece
{
    public enum Type
    {  
        PAWN,
        KNIGHT,
        QUEEN,
        BISHOP,
        ROOK,
        KING
    }

    public enum Color
    {
        WHITE,
        BLACK
    }

    private Color _color;
    private Vector2Int _pos;

    private GameObject _pieceGO;
    private BasePiece _basePiece;

    public Piece(Color color, Vector2Int pos)
    {
        _color = color;
        _pos = pos;

        _pieceGO = Game.GetInstance().InstantiatePiece();
        _basePiece = _pieceGO.GetComponent<BasePiece>();
        
        InstantMove();
    }

    public void InstantMove()
    {
        _pieceGO.transform.localPosition = new Vector3(_pos.x + 0.5f, _pos.y + 0.5f, -2);
    }

    public static Piece Create(Type type, Color color, Vector2Int pos)
    {
        if (type == Type.PAWN)
        {
            return new Pawn(color, pos);
        }

        throw new Exception("Invalid piece type");
    }
}