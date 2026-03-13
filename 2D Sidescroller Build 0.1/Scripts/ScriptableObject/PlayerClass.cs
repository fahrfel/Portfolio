using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player", menuName = "ScriptableObjects/Character/Player", order = 1)]
public class PlayerClass : ScriptableObject
{
    [Header("Player Data")]
    public Sprite playerIcon;
    public GameObject playerPrefab;

    [Header("Player Info")]
    public string playerName;
    public string playerID;

    [Header("Player Stats")]
    public float playerHealth;

    [Header("Player Settings")]
    public float moveSpeed;
    public float runSpeed;
    public float jumpPower;

    [Header("General Settings")]
    public LayerMask groundLayer;

    public virtual PlayerClass GetPlayer() { return this; }
}
