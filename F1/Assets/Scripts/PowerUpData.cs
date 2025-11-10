using UnityEngine;

[CreateAssetMenu(fileName = "NewPowerUp", menuName = "PowerUps/New PowerUp")]
public class PowerUpData : ScriptableObject
{
    public string powerUpName;
    public Sprite icon;
    public float value; 
}

