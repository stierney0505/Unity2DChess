using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour, Piece
{

    private byte value = 3;
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
        type = "knight";
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
        if(y2 == y + 2 && (x2 == x + 1 || x2 == x - 1))
        {
            if (!grid.getTile(x2, y2).hasPiece())
                return true;
            else if (grid.searchPieceByTile(x2, y2).getColor() != color)
            {
                grid.searchPieceByTile(x2, y2).destroy();
                return true;
            }
            return false;
        }
        else if (y2 == y - 2 && (x2 == x + 1 || x2 == x - 1))
        {
            if (!grid.getTile(x2, y2).hasPiece())
                return true;
            else if (grid.searchPieceByTile(x2, y2).getColor() != color)
            {
                grid.searchPieceByTile(x2, y2).destroy();
                return true;
            }
            return false;
        }
        else if (x2 == x + 2 && (y2 == y + 1 || y2 == y - 1))
        {
            if (!grid.getTile(x2, y2).hasPiece())
                return true;
            else if (grid.searchPieceByTile(x2, y2).getColor() != color)
            {
                grid.searchPieceByTile(x2, y2).destroy();
                return true;
            }
            return false;
        }
        else if (x2 == x - 2 && (y2 == y + 1 || y2 == y - 1))
        {
            if (!grid.getTile(x2, y2).hasPiece())
                return true;
            else if (grid.searchPieceByTile(x2, y2).getColor() != color)
            {
                grid.searchPieceByTile(x2, y2).destroy();
                return true;
            }
               
            return false;
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
