using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Piece
{
    public bool isLegal(int x2, int y2, ref ChessGrid grid);
    public void move(int x2, int y2);
    public bool Selected();
    public void setSelected(bool Selected);
    public int getX();
    public int getY();

    public bool hasMoved(); 
    public string getType();
    public void destroy();
    public bool getColor();
}
