using UnityEngine;

public class Click2Move : MonoBehaviour
{
    public float MoveSpeed;     // 미사일이 날라가는 속도

    void Update()
    {
        // 매 프레임마다 미사일이 MoveSpeed 만큼 up방향(Y축 +방향)으로 날라갑니다.
        transform.Translate(Vector3.up * MoveSpeed * Time.deltaTime);
        // 만약에 미사일의 위치가 DestroyYPos를 넘어서면
        if (transform.position.x >= 1900)
        {
            // 미사일을 제거
            gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 부딛히는 collision을 가진 객체의 태그가 "Enemy"일 경우
        if (collision.CompareTag("Enemy"))
        {
            Handheld.Vibrate();
            Enemy2Move.enemyData.decreaseHP(25);
            if (Enemy2Move.enemyData.getHP() <= 0)
            {
                collision.GetComponent<Collider2D>().enabled = false;
                ScoreBar.score += 500;
                Enemy2Move.deadEnemy++;
                Debug.Log("deadEnemy : " + Enemy2Move.deadEnemy.ToString());
            }
        }
    }


}


