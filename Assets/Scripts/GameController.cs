using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameController : MonoBehaviour
{
    private static GameController instance;
    public static GameController Instance { get { return instance; } }

    public enum eState
    {
        Playing, Lost, Win
    }

    public IPanel winPanel;
    public IPanel losePanel;

    public eState gameState;

    public PlayerController player;

    void Awake()
    {
        //Game controller should persist throughout the game
        instance = this;
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        switch (gameState)
        {
            case eState.Playing:
                break;
            case eState.Lost:
                break;
            case eState.Win:
                break;
            default:
                break;
        }
    }
}
