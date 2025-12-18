using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStats", menuName = "Custom/Enemy Stats")]
public class EnemyStats : ScriptableObject
{
    [Header("적 기본 스텟")]
    [Header("공격력")]
    public float attack;
    [Header("체력")]
    public float HP;
}

