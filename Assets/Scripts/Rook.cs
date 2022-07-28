using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : MonoBehaviour, Piece
{
    private byte value = 5;
    private int x, y;
    private string type;
    private bool color; // white if true, black if false
    private bool selected;
    private bool moved;

    public string getType() { return type; }
    public bool hasMoved() { return moved; }
    public bool getColor() { return color; }
    public int getX() { return x; }
    public int getY() { return y; }
    public byte Value { get { return value; } }

    public void setSelected(bool Selected) { selected = Selected; }

    public bool Selected() { return selected; }
    public void Init(int xloc, int yloc, bool color)
    {
        moved = false;
        x = xloc;
        y = yloc;
        type = "rook";
        this.color = color;
        selected = false;
    }
    public void move(int x2, int y2)
    {
        transform.Translate((x2 - x), (y2 - y), 0);
        x = x2; 
        y = y2;
        moved = true;
    }

    public bool isLegal(int x2, int y2, ref ChessGrid grid)
    {
        bool islegal = false;
        if (x2 == x && y2 > y) //this checks all the pieces before the selected move if the move is selected upwards
        {
            islegal = true;
            for (int i = y + 1; i < y2; i++)
            {
                if (grid.getTile(x,i).hasPiece())
                    return false;
            }
        }
        else if (x2 == x && y2 < y) //this checks all the pieces before the selected move if the move is selected downwards
        {
            islegal = true;
            for (int i = y - 1; i > y2; i--)
            {
                if (grid.getTile(x, i).hasPiece())
                    return false;
            }
        }
        else if (x2 > x && y2 == y)
        {
            islegal = true;
            for (int i = x + 1; i < x2; i++) //this checks all the pieces before the selected move if the move is towards the right
            {
                if (grid.getTile(i, y).hasPiece())
                    return false;
            }
        }
        else if (x2 < x && y2 == y) //this checks all the pieces before the selected move if the move is selected towards the left
        {
            islegal = true;
            for (int i = x - 1; i > x2; i--)
            {
                if (grid.getTile(i, y).hasPiece())
                    return false;
            }
        }

        if (!islegal)
            return false;

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
