using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : MonoBehaviour, Piece
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
        type = "bishop";
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
        if (Mathf.Abs(x2 - x) != Mathf.Abs(y2 - y))
            return false;
        if (x2 > x && y2 > y)
        {
            int i = x + 1;
            int j = y + 1;
            while (i < x2 && j < y2)
            {
                if (grid.getTile(i, j).hasPiece())
                    return false;
                i++;
                j++;
            }
        }
        else if (x2 < x && y2 > y)
        {
            int i = x - 1;
            int j = y + 1;
            while (i < x2 && j > y2)
            {
                if (grid.getTile(i, j).hasPiece())
                    return false;
                i--;
                j++;
            }
        }
        else if (x2 > x && y2 < y)
        {
            int i = x + 1;
            int j = y - 1;
            while (i < x2 && j < y2)
            {
                if (grid.getTile(i, j).hasPiece())
                    return false;
                i++;
                j--;
            }
        }
        else if (x2 < x && y2 < y)
        {
            int i = x - 1;
            int j = y - 1;
            while (i < x2 && j < y2)
            {
                if (grid.getTile(i, j).hasPiece())
                    return false;
                i--;
                j--;
            }
        }

        if (grid.getTile(x2, y2).hasPiece() && grid.searchPieceByTile(x2, y2).getColor() == color)
        {
            return false;
        }
        else if(grid.getTile(x2, y2).hasPiece() && grid.searchPieceByTile(x2, y2).getColor() != color)
        {
            grid.searchPieceByTile(x2, y2).destroy();
            return true;
        }
        return true;
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

