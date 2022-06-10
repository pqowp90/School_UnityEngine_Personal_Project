using UnityEngine;

[System.Serializable]

[CreateAssetMenu(fileName = "PlayerData",
menuName = "Scriptable Object/PlayerData")]
public class PlayerData : ScriptableObject
{
    public float sensivity;
    public float speed;
    public int life;
    public float stamina;
    public float attackPower;
}
