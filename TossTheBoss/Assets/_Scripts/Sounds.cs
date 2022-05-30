using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Sounds Scriptable Object Script
/// </summary>

[CreateAssetMenu]
public class Sounds : ScriptableObject
{
    #region References 
    public AudioClip Coin;
    public AudioClip Jump;
    public AudioClip Landing;
    public AudioClip Lose;
    public AudioClip Win;
    public AudioClip WrongTile;
    #endregion
   
}
