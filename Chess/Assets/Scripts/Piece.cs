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

    private bool _isCaptured = false;

    enum Direction
    {
        L,
        R,
        T,
        D,
        TL,
        DL,
        TR,
        DR
    }
    
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

    public void Capture()
    {
        _pieceGO.SetActive(false);
        _isCaptured = true;
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
    
    public List<string> GetCaptureMovements(List<Vector2Int> positions)
    {
        List<string> captureMovements = new List<string>();

        foreach (Vector2Int position in positions)
        {
            string boardPosition = Board.GetPositionStr(Pos + position);
            if (boardPosition != null)
            {
                Piece piece = Game.GetInstance().CurrBoard.GetPieceInPosition(boardPosition);
                if (piece != null && piece.Color != Color)
                {
                    captureMovements.Add(boardPosition);
                }
            }
        }

        return captureMovements;
    }

    public string CheckMovement(Vector2Int position)
    {
        string boardPosition = Board.GetPositionStr(Pos + position);
        if (boardPosition != null)
        {
            Piece piece = Game.GetInstance().CurrBoard.GetPieceInPosition(boardPosition);
            if (piece == null || piece.Color != Color)
            {
                return boardPosition;
            }
        }

        return null;
    }
    
    public List<string> CheckMovements(List<Vector2Int> positions)
    {
        List<string> captureMovements = new List<string>();

        foreach (Vector2Int position in positions)
        {
            if (CheckMovement(position) != null)
            {
                string boardPosition = Board.GetPositionStr(Pos + position);
                captureMovements.Add(boardPosition);
            }
        }

        return captureMovements;
    }

    public List<string> GetDiagonalPositions(int limit = 8)
    {
        List<string> positions = new List<string>();
        List<Direction> blockedDirections = new List<Direction>();
        for (int i = 1; i <= limit; i++)
        {
            if (!blockedDirections.Contains(Direction.TL))
            {
                string tlPos = CheckMovement(new Vector2Int(-i, i));
                if (tlPos != null)
                {
                    positions.Add(tlPos);
                    
                    Piece piece = Game.GetInstance().CurrBoard.GetPieceInPosition(tlPos);
                    if (piece != null && piece.Color != Color)
                    {
                        blockedDirections.Add(Direction.TL);
                    }
                }
                else
                {
                    blockedDirections.Add(Direction.TL);
                }
            }

            if (!blockedDirections.Contains(Direction.TR))
            {
                string trPos = CheckMovement(new Vector2Int(i, i));
                if (trPos != null)
                {
                    positions.Add(trPos);
                    
                    Piece piece = Game.GetInstance().CurrBoard.GetPieceInPosition(trPos);
                    if (piece != null && piece.Color != Color)
                    {
                        blockedDirections.Add(Direction.TR);
                    }
                }
                else
                {
                    blockedDirections.Add(Direction.TR);
                }
            }

            if (!blockedDirections.Contains(Direction.DL))
            {
                string dlPos = CheckMovement(new Vector2Int(-i, -i));
                if (dlPos != null)
                {
                    positions.Add(dlPos);
                    
                    Piece piece = Game.GetInstance().CurrBoard.GetPieceInPosition(dlPos);
                    if (piece != null && piece.Color != Color)
                    {
                        blockedDirections.Add(Direction.DL);
                    }
                }
                else
                {
                    blockedDirections.Add(Direction.DL);
                }
            }

            if (!blockedDirections.Contains(Direction.DR))
            {
                string drPos = CheckMovement(new Vector2Int(i, -i));
                
                if (drPos != null)
                {
                    positions.Add(drPos);
                    
                    Piece piece = Game.GetInstance().CurrBoard.GetPieceInPosition(drPos);
                    if (piece != null && piece.Color != Color)
                    {
                        blockedDirections.Add(Direction.DR);
                    }
                }
                else
                {
                    blockedDirections.Add(Direction.DR);
                }
            }
        }
        return positions;
    }

    public List<string> GetLinearPositions(int limit = 8)
    {
        List<string> positions = new List<string>();
        List<Direction> blockedDirections = new List<Direction>();
        for (int i = 1; i <= limit; i++)
        {
            if (!blockedDirections.Contains(Direction.L))
            {
                string lPos = CheckMovement(new Vector2Int(-i, 0));
                if (lPos != null)
                {
                    positions.Add(lPos);
                    
                    Piece piece = Game.GetInstance().CurrBoard.GetPieceInPosition(lPos);
                    if (piece != null && piece.Color != Color)
                    {
                        blockedDirections.Add(Direction.L);
                    }
                }
                else
                {
                    blockedDirections.Add(Direction.L);
                }
            }

            if (!blockedDirections.Contains(Direction.R))
            {
                string rPos = CheckMovement(new Vector2Int(i, 0));
                if (rPos != null)
                {
                    positions.Add(rPos);
                    
                    Piece piece = Game.GetInstance().CurrBoard.GetPieceInPosition(rPos);
                    if (piece != null && piece.Color != Color)
                    {
                        blockedDirections.Add(Direction.R);
                    }
                }
                else
                {
                    blockedDirections.Add(Direction.R);
                }
            }

            if (!blockedDirections.Contains(Direction.T))
            {
                string tPos = CheckMovement(new Vector2Int(0, i));
                if (tPos != null)
                {
                    positions.Add(tPos);
                    
                    Piece piece = Game.GetInstance().CurrBoard.GetPieceInPosition(tPos);
                    if (piece != null && piece.Color != Color)
                    {
                        blockedDirections.Add(Direction.T);
                    }
                }
                else
                {
                    blockedDirections.Add(Direction.T);
                }
            }

            if (!blockedDirections.Contains(Direction.D))
            {
                string dPos = CheckMovement(new Vector2Int(0, -i));
                
                if (dPos != null)
                {
                    positions.Add(dPos);

                    Piece piece = Game.GetInstance().CurrBoard.GetPieceInPosition(dPos);
                    if (piece != null && piece.Color != Color)
                    {
                        blockedDirections.Add(Direction.D);
                    }
                }
                else
                {
                    blockedDirections.Add(Direction.D);
                }
            }
        }
        return positions;
    }

    public static Piece Create(Type type, PlayerColor color, Vector2Int pos)
    {
        if (type == Type.Pawn)
        {
            return new Pawn(type, color, pos);
        } 
        
        if (type == Type.Knight)
        {
            return new Knight(type, color, pos);
        }
        
        if (type == Type.Rook)
        {
            return new Rook(type, color, pos);
        }
        
        if (type == Type.Bishop)
        {
            return new Bishop(type, color, pos);
        }
        
        if (type == Type.Queen)
        {
            return new Queen(type, color, pos);
        }
        
        if (type == Type.King)
        {
            return new King(type, color, pos);
        }

        throw new Exception("Invalid piece type");
    }
}