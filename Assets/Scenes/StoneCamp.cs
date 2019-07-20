using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneCamp : MonoBehaviour
{
    public GameObject Stone;            // 복제할 미사일 오브젝트
    public Transform StartingPoint;   // 미사일이 발사될 위치
    public float Delay;             // 미사일 발사 속도(미사일이 날라가는 속도x)
    private bool FireState;             // 미사일 발사 속도를 제어할 변수

    public int EnemyMaxPool;          // 메모리 풀에 저장할 미사일 개수
    private MemoryPool MPool;           // 메모리 풀
    private GameObject[] EnemyArray;  // 메모리 풀과 연동하여 사용할 미사일 배열

    private void OnApplicationQuit()
    {
        // 메모리 풀을 비웁니다.
        MPool.Dispose();
    }

    void Start()
    {
        // 처음에 미사일을 발사할 수 있도록 제어변수를 true로 설정
        FireState = true;
        // 메모리 풀을 초기화합니다.
        MPool = new MemoryPool();
        // PlayerMissile을 MissileMaxPool만큼 생성합니다.
        MPool.Create(Stone, EnemyMaxPool);
        // 배열도 초기화 합니다.(이때 모든 값은 null이 됩니다.)
        EnemyArray = new GameObject[EnemyMaxPool];
    }

    void Update()
    {
        // 매 프레임마다 미사일발사 함수를 체크한다.
        stoneCamp();
    }

    // 미사일을 발사하는 함수
    void stoneCamp()
    {
        // 제어변수가 true이고 발사할 Click이 남아 있을 때만 발동
        if (FireState)
        {
            GameObject startingPoint = GameObject.Find("StoneCamp");
            float curX = startingPoint.transform.position.x;
            float curY = startingPoint.transform.position.y;
            startingPoint.transform.position = new Vector3(curX, Random.Range(-4, 4), 0);

            // 코루틴 "FireCycleControl"이 실행되며
            StartCoroutine(FireCycleControl());

            // 미사일 풀에서 발사되지 않은 미사일을 찾아서 발사합니다.
            for (int i = 0; i < EnemyMaxPool; i++)
            {
                // 만약 미사일배열[i]가 비어있다면
                if (EnemyArray[i] == null)
                {
                    // 메모리풀에서 미사일을 가져온다.
                    EnemyArray[i] = MPool.NewItem();
                    // 해당 미사일의 위치를 미사일 발사지점으로 맞춘다.
                    EnemyArray[i].transform.position = StartingPoint.transform.position;
                    // 발사 후에 for문을 바로 빠져나간다.
                    break;
                }
            }

            // Clicks 감소
        }

        // 미사일이 발사될때마다 미사일을 메모리풀로 돌려보내는 것을 체크한다.
        for (int i = 0; i < EnemyMaxPool; i++)
        {
            // 만약 미사일[i]가 활성화 되어있다면
            if (EnemyArray[i])
            {
                // 미사일[i]의 Collider2D가 비활성 되었다면
                if (EnemyArray[i].GetComponent<Collider2D>().enabled == false)
                {
                    // 다시 Collider2D를 활성화 시키고
                    EnemyArray[i].GetComponent<Collider2D>().enabled = true;
                    // 미사일을 메모리로 돌려보내고
                    MPool.RemoveItem(EnemyArray[i]);
                    // 가리키는 배열의 해당 항목도 null(값 없음)로 만든다.
                    EnemyArray[i] = null;
                }
            }
        }
    }

    // 코루틴 함수
    IEnumerator FireCycleControl()
    {
        // 처음에 FireState를 false로 만들고
        FireState = false;
        // FireDelay초 후에
        yield return new WaitForSeconds(Delay);
        // FireState를 true로 만든다.
        FireState = true;
    }

}
