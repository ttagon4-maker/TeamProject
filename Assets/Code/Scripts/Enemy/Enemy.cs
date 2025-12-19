using Unity.Cinemachine;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    PlayerController player;        // 플레이어
    GrapplingHook grappling;        // 그래플링 훅
    IDamageable damageable;         // 데미지 여부 인터페이스

    private void Awake()
    {
        player = GetComponent<PlayerController>();
        grappling = GetComponent<GrapplingHook>();
        damageable = GetComponent<IDamageable>();
    }

    private void Update()
    {

    }

    // 플레이어와 닿았을 경우
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        if (other.TryGetComponent<IDamageable>(out var playerDamageable))
        {
            playerDamageable.TakeDamage(1);
        }
    }

    // 적 데미지
    void IDamageable.TakeDamage(int attack)
    {
        GameManager.Instance.enemyStatsRuntime.currentHP -= attack;

        Debug.Log("[적 데미지] 적 현재 체력: " + GameManager.Instance.enemyStatsRuntime.currentHP);
    }
}
