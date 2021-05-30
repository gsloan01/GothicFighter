using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Player/PlayerData", order = 1)]
public class PlayerData : ScriptableObject
{
    public string playerName = "NEW PLAYER";
    public float playtime = 0.0f;;
    public int health = 5;
    public int attackPower = 1;
}
