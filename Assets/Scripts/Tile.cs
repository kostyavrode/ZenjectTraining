using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public int type;
    public List<Tile> neighbours = new List<Tile>();
    public SpriteRenderer sprite;
    public Sprite[] sprites;
    public bool isCanInteract = true;
    public bool isMerged = false;
    private bool isSelected;
    private TileAnimator tileAnimator;
    private void Awake()
    {
        tileAnimator = GetComponent<TileAnimator>();
        SetSprite();
    }
    private void Start()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y), 0.7f);
        Debug.Log(colliders.Length);
        foreach (Collider2D coll in colliders)
        {
            neighbours.Add(coll.GetComponent<Tile>());
        }
    }
    private void SetSprite()
    {
        sprite.sprite = sprites[type];
    }
    private void LateUpdate()
    {
        if (isCanInteract)
        {
            sprite.color = Color.white;
        }
        else
        {
            sprite.color = Color.grey;
        }
    }
    private void OnMouseDown()
    {
        if (isCanInteract && !isSelected)
        {
            isSelected = true;
            isCanInteract = false;
            tileAnimator.UpScaleTile();
            ChooseTile();

            TileManager.onTileSelected?.Invoke(this);
        }
    }
    public void UnSelectTile()
    {
        tileAnimator.DownScaleTile();
        isSelected = false;
        isCanInteract = true;
    }
    public void ShowNeighbours()
    {
        foreach (Tile neighbor in neighbours)
        {
            neighbor.isCanInteract = true;
        }
    }
    private void ChooseTile()
    {

    }
}
