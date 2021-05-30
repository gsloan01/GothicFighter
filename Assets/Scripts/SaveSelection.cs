using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SaveSelection : MonoBehaviour
{
    public PlayerData[] players;
    public TMP_Text[] playerNames;
    public TMP_Text[] playTimes;

    private void Start()
    {
        UpdateSaves();
    }

    private void OnEnable()
    {
        UpdateSaves();
    }

    void UpdateSaves()
    {
        for (int i = 0; i < playerNames.Length; i++)
        {
            playerNames[i].text = players[i].name;
            playTimes[i].text = players[i].playtime.ToString("00.00");

        }
    }
}
