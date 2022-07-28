using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : MonoBehaviour, Piece
{
    private int x, y;
    private string type;
    private bool color; // white if true, black if false
    private bool selected;
    private bool moved;
    public bool hasMoved() { return moved; }
    public string getType() { return type; }
    public bool getColor() { return color; }
    public int getX() { return x; }
    public int getY() { return y; }
   
    public void setSelected(bool Selected) { selected = Selected; }
    public bool Selected() { return selected; }
    public void Init(int xloc, int yloc, bool color)
    {
        moved = false;
        x = xloc;
        y = yloc;
        type = "king";
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

    public bool isLegal(int x2, int y2, ref ChessGrid grid)  // check back for checking if kinbg is in check
    {   
        if(x2 - x == 2 && y2 == y && !moved)
        {
            if (grid.getTile(x + 1, y).hasPiece())
                return false;
            else if (grid.getTile(x + 2, y).hasPiece())
                return false;
            else if (grid.getTile(x + 3, y).hasPiece() && grid.searchPieceByTile(x+3, y).getType().Equals("rook"))
            {
                if (grid.searchPieceByTile(x + 3, y).hasMoved())
                    return false;
                grid.searchPieceByTile(x + 3, y).move(x2 -1, y2);
                return true;
            }
        }
        else if(x2 - x == -2 && y2 == y && !moved)
        {
            if (grid.getTile(x - 1, y).hasPiece())
                return false;
            else if (grid.getTile(x - 2, y).hasPiece())
                return false;
            else if (grid.getTile(x - 3, y).hasPiece())
                return false;
            else if (grid.getTile(x - 4, y).hasPiece() && grid.searchPieceByTile(x - 4, y).getType().Equals("rook"))
            {
                if (grid.searchPieceByTile(x - 4, y).hasMoved())
                    return false;
                grid.searchPieceByTile(x - 4, y).move(x2 + 1, y2);
                return true;
            }
        }


        if (x2 - x > 1 || x2 - x < -1)
            return false;
        else if (y2 - y > 1 || y2 - y < -1)
            return false;
        else if (grid.getTile(x2, y2).hasPiece() && (grid.searchPieceByTile(x2, y2).getColor() == color))
            return false;
        else if(grid.getTile(x2, y2).hasPiece() && (grid.searchPieceByTile(x2, y2).getColor() != color))
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

    }

}
