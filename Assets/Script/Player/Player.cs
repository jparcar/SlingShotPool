using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player 
{
    private int id;
    private List<int> listBolasObtenidas = new List<int>();
    private BallPlayerFocus focusBalls = BallPlayerFocus.none;
    private bool focusIn8 = false;
    private int triedBall = 1;

    public List<int> ListBolasObtenidas { get => listBolasObtenidas; set => listBolasObtenidas = value; }
    public BallPlayerFocus FocusBalls { get => focusBalls; set => focusBalls = value; }
    public int Id { get => id; set => id = value; }
    public bool FocusIn8 { get => focusIn8; set => focusIn8 = value; }
    public int getTreiedBall()
    {
        return triedBall;
    }
    public void setTriedBall(int trieds)
    {
        //Console.Write("INTENTOS: "+trieds);
        if(trieds >= Constants.MAX_THROWS_PLAYERS)
        {
            triedBall =  Constants.MAX_THROWS_PLAYERS;
        }
        else if(trieds < 0)
        {
            triedBall = 0;
        }else
        {
            triedBall = trieds;
        }
        
       
    }
}
