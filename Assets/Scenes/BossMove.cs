using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossMove : MonoBehaviour
{
    public static Enemy_Data enemyData;
    private bool CoroutineTime = true;
    public float Delay;
    GameObject startingPoint;

    void Start()
    {
        startingPoint = GameObject.Find("Boss");
        enemyData = new Enemy_Data(1000);
    }

    void Update()
    {
        if (enemyData.getHP() <= 0)
        {
            SceneManager.LoadScene("Win");
        }

        if (CoroutineTime)
        {
            float curX = startingPoint.transform.position.x;
            float curY = startingPoint.transform.position.y;
            startingPoint.transform.position = new Vector3(curX, Random.Range(-4, 4), 0);

            StartCoroutine(CycleControl());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 부딛히는 collision을 가진 객체의 태그가 "Click"이나 "Player"일 경우
        if (collision.CompareTag("Click"))
        {
            collision.GetComponent<Collider2D>().enabled = false;
        }
    }

    // 코루틴 함수
    IEnumerator CycleControl()
    {
        // 처음에 FireState를 false로 만들고
        CoroutineTime = false;
        // FireDelay초 후에
        yield return new WaitForSeconds(Delay);
        // FireState를 true로 만든다.
        CoroutineTime = true;
    }
}
