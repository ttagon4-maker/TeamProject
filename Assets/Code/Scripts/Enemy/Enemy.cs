using Unity.Cinemachine;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    PlayerController controller;    // 플레이어
    GrapplingHook grappling;        // 그래플링 훅
    Physics2D physics;

    private void Awake()
    {
        //controller = GetComponent<PlayerController>();
        //grappling = GetComponent<GrapplingHook>();
        //physics = GetComponent<Physics2D>();
    }

    private void Update()
    {
        //if (grappling.isAttach)
        //{
            
        //}
    }

    // 데미지
    public void TakeDamage(int attack)
    {

    }
}
