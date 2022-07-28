using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player w_player, b_player;
    [SerializeField] private ChessGrid grid;
    private int selectedPiece = -1;
    private int secondPiece;

    // Start is called before the first frame update
    void Start()
    {
        w_player.Init(true);
        b_player.Init(false);
        grid.GenerateGrid();
    }

    // Update is called once per frame
    void Update()
    {
        int index = searchPieces(); 
        int x, y;
        
        bool tile = searchTiles(out x, out y);
        if (index != -1 || selectedPiece != -1)
        {
            if (index != -1)
            {
                if (selectedPiece != -1) { grid.getTiles()[grid.getPieces()[selectedPiece].getX(), grid.getPieces()[selectedPiece].getY()].setColor(grid.getTiles()[grid.getPieces()[selectedPiece].getX(), grid.getPieces()[selectedPiece].getY()].getColor()); }
                selectedPiece = index;
                grid.getTiles()[grid.getPieces()[selectedPiece].getX(), grid.getPieces()[selectedPiece].getY()].setColor(Color.green);
            }
            if (tile)
            {
                if (isLegal(x, y, grid.getPieces()[selectedPiece]) && checkTurn(grid.getPieces()[selectedPiece].getColor()))
                {
                    changeTurn(!grid.getPieces()[selectedPiece].getColor());
                    unpieceTile(false);
                    grid.getPieces()[selectedPiece].move(x, y);
                    unpieceTile(true);
                    selectedPiece = -1;
                    unSelectPieces();
                    unSelectTiles();
                    
                }
                else { unSelectTiles(); }
                
            }
        }
        else { unSelectTiles(); }

    }
    public void unSelectTiles()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                grid.getTiles()[i, j].setSelected(false);
                grid.getTiles()[i, j].setColor(grid.getTiles()[i, j].getColor());
            }
        }
    }
    public bool searchTiles(out int x, out int y)
    {
        for (int i = 0; i < 8; i++) 
        {
            for (int j = 0; j < 8; j++)
            {
                if (grid.getTile(i,j).Selected())
                {   
                    x = i;
                    y = j;
                    return true;
                }

            }
        }
        x = 0;
        y = 0;
        return false;
    }

    public int searchPieces()  //Since this is an unsorted, small list of pieces (16) a linear search will do
    {
        for (int i = 0; i < grid.getPieces().Count; i++)
        {
            if (grid.getPieces()[i].Selected())
            {
                if (selectedPiece != -1 && grid.getPieces()[i].getColor() != grid.getPieces()[selectedPiece].getColor()) {
                    if (grid.getPieces()[selectedPiece].isLegal(grid.getPieces()[i].getX(), grid.getPieces()[i].getY(), ref grid))
                    {
                        grid.getTile(grid.getPieces()[i].getX(), grid.getPieces()[i].getY()).setSelected(true);
                        return -1;
                    }
                }
                else if(selectedPiece != -1 && grid.getPieces()[i].getColor() == grid.getPieces()[selectedPiece].getColor()){
                    unSelectPieces();
                    return i;
                }
                grid.getPieces()[i].setSelected(false);
                return i;
                    
            }
        }
        return -1;
    }
    public void unSelectPieces()
    {
        for (int i = 0; i < grid.getPieces().Count; i++)
        {
           grid.getPieces()[i].setSelected(false);
        }
    }

    public bool isLegal(int x, int y, Piece piece)
    {
        return piece.isLegal(x, y, ref grid);
    }

    public void unpieceTile(bool hasPiece)
    {
        int x = grid.getPieces()[selectedPiece].getX();
        int y = grid.getPieces()[selectedPiece].getY();
        grid.getTile(x, y).setPiece(hasPiece);
    }

    public void changeTurn(bool turn)
    {
        if (turn)
        {
            w_player.setTurn(true);
            b_player.setTurn(false);
        }
        else
        {
            w_player.setTurn(false);
            b_player.setTurn(true);
        }
    }

    public bool checkTurn(bool turn)
    {
        if (turn) { return w_player.isTurn(); }
        else { return b_player.isTurn(); }
        
    }
}

