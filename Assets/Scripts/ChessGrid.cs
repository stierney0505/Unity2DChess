using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessGrid : MonoBehaviour
{   
    
    [SerializeField] private int width, height;
    [SerializeField] private ChessTile greyPrefab, blackPrefab;
    [SerializeField] private Pawn w_pawn, b_pawn;
    [SerializeField] private Rook w_rook, b_rook;
    [SerializeField] private Knight w_knight, b_knight;
    [SerializeField] private Bishop w_bishop, b_bishop;
    [SerializeField] private Queen w_queen, b_queen;
    [SerializeField] private King w_king, b_king;
    private List<Piece> pieces = new List<Piece>();

    public List<Piece> getPieces() {  return pieces;  }

    private ChessTile[,] tiles = new ChessTile[8, 8];
    public ChessTile[,] getTiles() { return tiles; }
    public ChessTile getTile(int x, int y) { return tiles[x, y]; }




    void Update()
    {
    }

    

    void Start()
    {
        
    }
    
    public void GenerateGrid()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                var spawnedTile = Instantiate(getTileColor(x, y), new Vector3(x, y), Quaternion.identity);
                spawnedTile.name = getName(x, y);
                tiles[x, y] = spawnedTile;
                if (y <= 1 || y > 5)
                {
                    generatePieces(x, y);
                    
                }
            }

        }
    }
    
    public ChessTile getTileColor(int x, int y)
    {
        if (((x + y) % 2) == 0)

            return blackPrefab;
        else
            return greyPrefab;
    }

    public string getName(int x, int y)
    {

        return ("Tile " + convertNumChar(x) + " " + (y + 1));
    }

    public char convertNumChar(int x)
    {
        char[] array1 = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', };
        return array1[x];
    }

    public void generatePieces(int x, int y)
    {
        if (y == 0 && (x == 0 || x == 7))
        {
            var spawnedPiece = Instantiate(w_rook, new Vector3(x, y, (float)-.2), Quaternion.identity);
            tiles[x, y].setPiece(true);
            spawnedPiece.Init(x, y, true);
            pieces.Add(spawnedPiece);
        }
        else if (y == 0 && (x == 1 || x == 6))
        {
            var spawnedPiece = Instantiate(w_knight, new Vector3(x, y, (float)-.2), Quaternion.identity);
            tiles[x, y].setPiece(true);
            spawnedPiece.Init(x, y, true);
            pieces.Add(spawnedPiece);
        }
        else if (y == 0 && (x == 2 || x == 5))
        {
            var spawnedPiece = Instantiate(w_bishop, new Vector3(x, y, (float)-.2), Quaternion.identity);
            tiles[x, y].setPiece(true);
            spawnedPiece.Init(x, y, true);
            pieces.Add(spawnedPiece);
        }

        else if (y == 0 && x == 3)
        {
            var spawnedPiece = Instantiate(w_queen, new Vector3(x, y, (float)-.2), Quaternion.identity);
            tiles[x, y].setPiece(true);
            spawnedPiece.Init(x, y, true);
            pieces.Add(spawnedPiece);
        }

        else if (y == 0 && x == 4)
        {
            var spawnedPiece = Instantiate(w_king, new Vector3(x, y, (float)-.2), Quaternion.identity);
            tiles[x, y].setPiece(true);
            spawnedPiece.Init(x, y, true);
            pieces.Add(spawnedPiece);
        }

        else if ((y == 1))
        {
            var spawnedPiece = Instantiate(w_pawn, new Vector3(x, y, (float)-.2), Quaternion.identity);
            tiles[x, y].setPiece(true);
            spawnedPiece.Init(x, y, true);
            pieces.Add(spawnedPiece);
        }

        else if (y == 6)
        {
            var spawnedPiece = Instantiate(b_pawn, new Vector3(x, y, (float)-.2), Quaternion.identity);
            tiles[x, y].setPiece(true);
            spawnedPiece.Init(x, y, false);
            pieces.Add(spawnedPiece);
        }

        else if (y == 7 && (x == 0 || x == 7))
        {
            var spawnedPiece = Instantiate(b_rook, new Vector3(x, y, (float)-.2), Quaternion.identity);
            tiles[x, y].setPiece(true);
            spawnedPiece.Init(x, y, false);
            pieces.Add(spawnedPiece);
        }

        else if (y == 7 && (x == 1 || x == 6))
        {
            var spawnedPiece = Instantiate(b_knight, new Vector3(x, y, (float)-.2), Quaternion.identity);
            tiles[x, y].setPiece(true);
            spawnedPiece.Init(x, y, false);
            pieces.Add(spawnedPiece);
        }

        else if (y == 7 && x == 2 || x == 5)
        {
            var spawnedPiece = Instantiate(b_bishop, new Vector3(x, y, (float)-.2), Quaternion.identity);
            tiles[x, y].setPiece(true);
            spawnedPiece.Init(x, y, false);
            pieces.Add(spawnedPiece);
        }

        else if (y == 7 && x == 3)
        {
            var spawnedPiece = Instantiate(b_queen, new Vector3(x, y, (float)-.2), Quaternion.identity);
            tiles[x, y].setPiece(true);
            spawnedPiece.Init(x, y, false);
            pieces.Add(spawnedPiece);
        }

        else if (y == 7 && x == 4)
        {
            var spawnedPiece = Instantiate(b_king, new Vector3(x, y, (float)-.2), Quaternion.identity);
            tiles[x, y].setPiece(true);
            spawnedPiece.Init(x, y, false);
            pieces.Add(spawnedPiece);
        }
    }

    
  
    public Piece searchPieceByTile(int x, int y)
    {
        for(int i = 0; i < pieces.Count; i++)
        {
            if (pieces[i].getX() == x && pieces[i].getY() == y)
                return pieces[i];
        }
        return null;
    }    

    
}
                                    