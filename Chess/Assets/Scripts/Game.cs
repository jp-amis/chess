using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Game: MonoBehaviour
{
    private static Game _instance;
    
    [SerializeField] private GameObject _piecePrefab;
    [SerializeField] private GameObject _selected;
    [SerializeField] private Camera _camera;
    
    private Board _board;

    public Board CurrBoard => _board;

    private Piece.PlayerColor playerTurn = Piece.PlayerColor.WHITE;
    private Piece _selectedPiece;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    public static Game GetInstance()
    {
        return _instance;
    }

    public GameObject InstantiatePiece()
    {
        return Instantiate(_piecePrefab, transform);
    }

    void Start()
    {
        _board = new Board();
    }

    void NextTurn()
    {
        if (playerTurn == Piece.PlayerColor.WHITE)
        {
            playerTurn = Piece.PlayerColor.BLACK;
            return;
        }

        playerTurn = Piece.PlayerColor.WHITE;
    }
    
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Vector3 worldPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            worldPosition.z = 0.0f;
        
            Vector2Int cursorPosition = new Vector2Int(Mathf.FloorToInt(worldPosition.x), Mathf.FloorToInt(worldPosition.y));
            string positionStr = Board.GetPositionStr(cursorPosition);
            Piece selectedPiece = _board.GetPieceInPosition(positionStr);
            if (selectedPiece != null && selectedPiece.Color == playerTurn)
            {
                _selected.transform.localPosition = new Vector3(
                    selectedPiece.Pos.x + 0.5f,
                    selectedPiece.Pos.y + 0.5f,
                    _selected.transform.localPosition.z
                );
                _selectedPiece = selectedPiece;
                return;
            }

            if (_selectedPiece != null)
            {
                List<string> possibleMovements = _selectedPiece.GetPossibleMovements();
                if (possibleMovements.Contains(positionStr))
                {
                    _board.Move(Board.GetPositionStr(_selectedPiece.Pos), positionStr);
                    NextTurn();
                }
            }
        }
    }
}
