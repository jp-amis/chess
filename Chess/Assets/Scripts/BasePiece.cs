using System;
using UnityEngine;

public class BasePiece : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite[] _whiteSprites;
    [SerializeField] private Sprite[] _blackSprites;

    public void SetSprite(Piece.PlayerColor color, Piece.Type type)
    {
        if (color == Piece.PlayerColor.WHITE)
        {
            SetSprite(_whiteSprites, type.ToString());   
        } 
        else
        {
            SetSprite(_blackSprites, type.ToString());
        }
    }

    private void SetSprite(Sprite[] sprites, string spriteName)
    {
        foreach (Sprite sprite in sprites)
        {
            if (sprite.name == spriteName)
            {
                _spriteRenderer.sprite = sprite;
                break;
            }
        }
    }
}
