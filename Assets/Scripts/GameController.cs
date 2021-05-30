using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameController : MonoBehaviour
{
    private static GameController instance;
    public static GameController Instance { get { return instance; } }
    public List<MonsterSpawner> spawners = new List<MonsterSpawner>();
    int monstersKilled = 0;
    public SaveData saveData;

    public enum eState
    {
        Playing, Lost, Win
    }

    public GameObject winPanel;
    public GameObject losePanel;

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
                saveData.playerData.playtime += Time.deltaTime;
                //if(monstersKilled == numOfMonsters)
                //{
                //      OnWin();
                //}
                
                break;
            case eState.Lost:
                break;
            case eState.Win:
                break;
            default:
                break;
        }
    }

    public void OnLoss()
    {
        gameState = eState.Lost;
        Time.timeScale = 0.01f;
        losePanel.SetActive(true);
    }

    public void OnWin()
    {
        gameState = eState.Win;
        Time.timeScale = 0.01f;
        winPanel.SetActive(true);

    }
}
