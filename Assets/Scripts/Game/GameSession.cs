using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    [SerializeField] private PlayerData _playerData;

    public PlayerData Data => _playerData;
    public static GameSession I { get; private set; }

    public GameSession() 
    { 
        _playerData = new PlayerData();
    }

    private void Awake()
    {
        if (I != null && I != this)
        { 
            DestroyImmediate(I);
        }

        I= this;

        DontDestroyOnLoad(this);
    }
}
