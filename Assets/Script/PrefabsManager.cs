using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabsManager : MonoBehaviour
{
    private static PrefabsManager instance = null;

    [SerializeField]
    private  GameObject pivot;
    // Game Instance Singleton
    public static PrefabsManager Instance
    {
        get
        {
            return instance;
        }
    }

    public GameObject Pivot { get => pivot; set => pivot = value; }

    private void Awake()
    {
        // if the singleton hasn't been initialized yet
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
}
