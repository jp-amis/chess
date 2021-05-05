using System;
using UnityEditorInternal;
using UnityEngine;

public class Game: MonoBehaviour
{
    private static Game _instance;
    
    [SerializeField] private GameObject _piecePrefab;
    
    private Board _board;

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

    void Update()
    {
        
    }
}
