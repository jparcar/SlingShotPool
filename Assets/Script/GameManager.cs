using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    private BallPlayer ballPlayer;
    private PlayerController playerController;

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

    private void Awake()
    {
        // if the singleton hasn't been initialized yet
        print("Readyy");
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

}
