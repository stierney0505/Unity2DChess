using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool turn;
    private byte points;
    private bool check;
    private bool color;

    public void Init(bool Color)
    {
        color = Color;
        turn = Color;
        check = false;
        points = 0;
    }

    public bool isTurn()
    { return turn; }
    public void setTurn(bool Turn)
    { turn = Turn; }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
