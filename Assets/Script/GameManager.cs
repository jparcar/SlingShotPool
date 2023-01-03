using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    private BallPlayer ballPlayer;
    private PlayerController playerController;
    private HUDPlayer hUDPlayer;
    private GestorBall gestorBall;
    private int playerInPlaying=0;
    private List<Player> players = new List<Player>();

    // Game Instance Singleton
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    public BallPlayer BallPlayer { get => ballPlayer; set => ballPlayer = value; }
    public PlayerController PlayerController { get => playerController; set => playerController = value; }
    public HUDPlayer HUDPlayer { get => hUDPlayer; set => hUDPlayer = value; }
    public GestorBall GestorBall { get => gestorBall; set => gestorBall = value; }

    private void Awake()
    {
        playerInPlaying = Constants.FIRST_PLAYER;
        players.Add(new Player());
        players.Add(new Player());
        // if the singleton hasn't been initialized yet
        gestorBall = FindObjectOfType<GestorBall>();
        print("Readyy");
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

    }
    private void Start()
    {
        
    }
    public static void CreateInstance()
    {
        if (instance == null)
        {
            new GameObject("GameManager", typeof(GameManager));
        }
    }

    public bool putBall(int bola)
    {
        int rivalPlayer = (playerInPlaying+1>=players.Count)?0:1;
        print("Status player: "+ players[0].FocusBalls);
        if(players[0].FocusBalls== BallPlayerFocus.none && bola !=0 && bola != 8)
        {
            if (bola < Constants.FIRST_BALL_STRIPE)
            {
                players[playerInPlaying].FocusBalls = BallPlayerFocus.smooth;
                players[rivalPlayer].FocusBalls = BallPlayerFocus.striped;
            }
            else
            {
                players[playerInPlaying].FocusBalls = BallPlayerFocus.striped;
                players[rivalPlayer].FocusBalls = BallPlayerFocus.smooth;
            }
            players[playerInPlaying].ListBolasObtenidas.Add(bola);
            return true;
        }else if (canPutBall(bola))
        {
            players[playerInPlaying].ListBolasObtenidas.Add(bola);
            checkGo8();
            return true;
        }
        return false;
    }

    private bool canPutBall(int bola)
    {
        bool canBall = false;
        
        if (players[playerInPlaying].FocusBalls == BallPlayerFocus.smooth && bola<8)
            canBall = true;

        if (players[playerInPlaying].FocusBalls == BallPlayerFocus.striped && bola > 8)
            canBall = true;
        
        if(players[playerInPlaying].FocusIn8 && bola == 8)
            canBall = true;
        print("Has metido la bola correcta??? "+canBall);
        return canBall;
    }
    private void checkGo8()
    {
        if (players[playerInPlaying].ListBolasObtenidas.Count >= 7)
        {
            players[playerInPlaying].FocusIn8 = true;
        }
    }

    public void changePlayer(int firstBall)
    {
        playerInPlaying++;
        if (playerInPlaying >= players.Count)
        {
            playerInPlaying = 0; 
        }
    }
}
