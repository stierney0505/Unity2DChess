using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessTile : MonoBehaviour
{
    public int widthLoc;
    public int heightLoc;
    private bool selected;
    private string tileName;
    private bool piece;
    private Color color;
    public bool hasPiece() { return piece; }
    public void setPiece(bool hasPiece) { piece = hasPiece; }
    public bool Selected() { return selected; }
    public void setSelected(bool select) { selected = select;  }    
    public string getName() { return tileName; }
    public void setName(string name) { tileName = name; }
        
    public void setLoc()
    {   
        setName( gameObject.name);
        heightLoc = getName()[7] - '0';
        widthLoc = charToNum(getName()[5]);
        heightLoc--;
        var renderer = gameObject.GetComponent<Renderer>();
        color = renderer.material.GetColor("_Color");
    }

    void Start()
    {
        setLoc();
    }
    void Update()
    {
        
    }

    public int charToNum(char a)
    {
        char[] array1 = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h'};
        for (int i = 0; i < array1.Length; i++)
        {   
            if (a == array1[i]) 
            return i;
        }
        return  0;
    }

    public void OnMouseDown()
    {
        setSelected(true);
        
    }

    public void setColor(Color color)
    {
        var renderer = gameObject.GetComponent<Renderer>();
        renderer.material.SetColor("_Color", color);
    }

    public Color getColor()
    {
        return color;
    }

}
