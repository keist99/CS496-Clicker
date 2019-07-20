using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMove : MonoBehaviour
{
    public int HP, MoveSpeed;

    public static int deadEnemy;

    private Enemy_Data enemyData;

    void Start()
    {
        enemyData = new Enemy_Data(25);
        deadEnemy = 0;
    }

    void Update()
    {
        // 매 프레임마다 미사일이 MoveSpeed 만큼 up방향(Y축 +방향)으로 날라갑니다.
        transform.Translate(Vector3.down * MoveSpeed * Time.deltaTime);
        // 만약에 미사일의 위치가 DestroyYPos를 넘어서면
        if (transform.position.x <= 0)
        {
            // 미사일을 제거
            Destroy(gameObject);
            deadEnemy++;
            Debug.Log("deadEnemy : "+deadEnemy.ToString());
        }

        if (deadEnemy >= 51)
        {
            SceneManager.LoadScene("SpaceshipStage2");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 부딛히는 collision을 가진 객체의 태그가 "Click"이나 "Player"일 경우
        if (collision.CompareTag("Click"))
        {
            Debug.Log("적 기체와 player 충돌");
            enemyData.decreaseHP(25);
            collision.GetComponent<Collider2D>().enabled = false;
            if (enemyData.getHP() <= 0)
            {
                Destroy(gameObject);
                ScoreBar.score += 500;
                deadEnemy++;
                Debug.Log("deadEnemy : " + deadEnemy.ToString());
            }
        }
    }
}
