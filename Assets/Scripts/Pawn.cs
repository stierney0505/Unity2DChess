using System;
using UnityEngine;

public class Pawn : MonoBehaviour, Piece
{

    private byte value = 1;
    private int x, y;
    private string type;
    private bool color; // white if true, black if false
    private bool selected;

    public string getType() { return type; }

    public bool hasMoved() { return true; }
    public bool getColor() { return color; }
    public int getX() { return x; }
    public int getY() { return y; }
    public byte Value { get { return value; } }
    public void setSelected(bool Selected) { selected = Selected; }
    public bool Selected() { return selected; }
    public void Init(int xloc, int yloc, bool color)
    {
        x = xloc;
        y = yloc;
        type = "pawn";
        this.color = color;
        selected = false;
    }
    public void move(int x2, int y2)
    {
        transform.Translate((x2 - x), (y2 - y), 0);
        x = x2;
        y = y2;
    }
    
    public bool isLegal(int x2, int y2, ref ChessGrid grid)
    {
        if (color)
        {
            if ((x2 == x + 1 || x2 == x - 1) && (y2 == y + 1) && grid.getTile(x2,y2).hasPiece())
            {
                if (grid.searchPieceByTile(x2, y2).getColor() != color)
                {
                    grid.searchPieceByTile(x2,y2).destroy();
                    return true;
                }
            }
            else if ((y == 1 && y2 < 4) && x2 == x)
            {
                return true;
            }
            else if (y2 == y + 1 && x2 == x)
            {
                return true;
            }
        }
        else
        {
            if ((x2 == x + 1 || x2 == x - 1) && (y2 == y - 1) && grid.getTile(x2, y2).hasPiece())
            {
                if (grid.searchPieceByTile(x2, y2).getColor() != color)
                {
                    grid.searchPieceByTile(x2, y2).destroy();
                    return true;
                }
            }
            else if ((y == 6 && y2 > 3) && x2 == x)
            {
                return true;
            }
            else if (y2 == y - 1 && x2 == x)
            {
                return true;
            }
        }
            
        return false;
    }

    public void OnMouseDown()
    {
        setSelected(true);
    }

    public void destroy()
    {
        Destroy(gameObject);
    }
}
