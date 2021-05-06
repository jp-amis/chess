using System;
using System.Collections.Generic;
using UnityEngine;

public class Piece
{
    public enum Type
    {  
        Pawn,
        Knight,
        Queen,
        Bishop,
        Rook,
        King
    }

    public enum PlayerColor
    {
        WHITE,
        BLACK
    }

    private PlayerColor _color;

    public PlayerColor Color => _color;

    private Vector2Int _pos;

    public Vector2Int Pos => _pos;

    private Type _type;

    private GameObject _pieceGO;
    private BasePiece _basePiece;

    public Piece(Type type, PlayerColor color, Vector2Int pos)
    {
        _type = type;
        _color = color;
        _pos = pos;

        _pieceGO = Game.GetInstance().InstantiatePiece();
        _basePiece = _pieceGO.GetComponent<BasePiece>();
        _basePiece.SetSprite(color, type);
        
        InstantMove();
    }

    public void InstantMove()
    {
        _pieceGO.transform.localPosition = new Vector3(_pos.x + 0.5f, _pos.y + 0.5f, -4);
    }

    public void SetPosition(string pos)
    {
        _pos = Board.GetPosition(pos);
        InstantMove();
    }

    public virtual List<string> GetPossibleMovements()
    {
        throw new Exception("Not implemented");
    }

    public static Piece Create(Type type, PlayerColor color, Vector2Int pos)
    {
        if (type == Type.Pawn)
        {
            return new Pawn(type, color, pos);
        }

        throw new Exception("Invalid piece type");
    }
}