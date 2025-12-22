using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float distance;
    public float atkDistince;
    public LayerMask isLayer;
    public float speed;
    public GameObject bullet;
    public Vector3 bulletPos;
    public float coolTime;
    private float currentTime;
    public Vector3 startPos;
    public float maxTime;
    public float curTime;

    private int moveDirection = 1; // 1: 오른쪽, -1: 왼쪽

    private void Start()
    {
        startPos = transform.position;
    }

    private void FixedUpdate()
    {
        // moveDirection에 따라 레이캐스트 방향 설정
        Vector2 rayDir = transform.right * moveDirection;

        // 플레이어 위치를 중심으로 박스 형태로 감지 (공중 포함)
        RaycastHit2D raycast = Physics2D.BoxCast(transform.position, new Vector2(1f, 2f), 0f, rayDir, distance, isLayer);

        if (raycast.collider != null) // 플레이어 감지
        {
            curTime = 0;
            if (Vector2.Distance(transform.position, raycast.collider.transform.position) < atkDistince)
            {
                if (currentTime <= 0)
                {
                    Instantiate(bullet, transform.position + bulletPos, transform.rotation);
                    currentTime = coolTime;
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, raycast.collider.transform.position, Time.deltaTime * speed);
            }

            if (currentTime > 0)
                currentTime -= Time.deltaTime;
        }
        else // 플레이어 미감지
        {
            curTime += Time.deltaTime;
            if (curTime >= maxTime)
            {
                transform.position = Vector3.MoveTowards(transform.position, startPos, Time.deltaTime * speed);
            }
        }

        // 양쪽으로 이동하도록 방향 전환
        if (raycast.collider == null && curTime >= maxTime)
        {
            moveDirection *= -1;
        }

        // Debug
        Debug.DrawRay(transform.position + new Vector3(0, 1f, 0), rayDir * distance, Color.red); // 상단
        Debug.DrawRay(transform.position - new Vector3(0, 1f, 0), rayDir * distance, Color.red); // 하단
    }
}
