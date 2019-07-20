using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceshipWithClicks : MonoBehaviour
{
    public GameObject Click;            // 복제할 미사일 오브젝트
    public Transform MissileLocation;   // 미사일이 발사될 위치
    public float FireDelay;             // 미사일 발사 속도(미사일이 날라가는 속도x)
    private bool FireState;             // 미사일 발사 속도를 제어할 변수
    private bool FireShoot;

    public int MissileMaxPool;          // 메모리 풀에 저장할 미사일 개수
    private MemoryPool MPool;           // 메모리 풀
    private GameObject[] MissileArray;  // 메모리 풀과 연동하여 사용할 미사일 배열

    public Text weapons;

    public static int FireCount, FireLimit;

    CameraShaker Camera;                // damage effect

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
        MPool.Create(Click, MissileMaxPool);
        // 배열도 초기화 합니다.(이때 모든 값은 null이 됩니다.)
        MissileArray = new GameObject[MissileMaxPool];

        FireShoot = false;
        FireCount = 0;
        FireLimit = 50;

        Camera = GameObject.FindWithTag("MainCamera").GetComponent<CameraShaker>();
    }

    void Update()
    {
        // 매 프레임마다 미사일발사 함수를 체크한다.
        spaceshipWithClicks();
        weapons.text = (FireLimit - FireCount).ToString();
    }

    // 미사일을 발사하는 함수
    public void spaceshipWithClicks()
    {
        // 제어변수가 true이고 발사할 Click이 남아 있을 때만 발동
        if (FireState)
        {
            if (FireShoot && (FireCount < FireLimit))
            {
                // 사용자가 발사 버튼을 누르면
                FireShoot = false;

                // 코루틴 "FireCycleControl"이 실행되며
                StartCoroutine(FireCycleControl());

                // 미사일 풀에서 발사되지 않은 미사일을 찾아서 발사합니다.
                for (int i = 0; i < MissileMaxPool; i++)
                {
                    // 만약 미사일배열[i]가 비어있다면
                    if (MissileArray[i] == null)
                    {
                        // 메모리풀에서 미사일을 가져온다.
                        MissileArray[i] = MPool.NewItem();
                        // 해당 미사일의 위치를 미사일 발사지점으로 맞춘다.
                        MissileArray[i].transform.position = MissileLocation.transform.position;
                        // 발사 후에 for문을 바로 빠져나간다.
                        break;
                    }
                }
            }
        }

        // 미사일이 발사될때마다 미사일을 메모리풀로 돌려보내는 것을 체크한다.
        for (int i = 0; i < MissileMaxPool; i++)
        {
            // 만약 미사일[i]가 활성화 되어있다면
            if (MissileArray[i])
            {
                // 미사일[i]의 Collider2D가 비활성 되었다면
                if (MissileArray[i].GetComponent<Collider2D>().enabled == false)
                {
                    // 다시 Collider2D를 활성화 시키고
                    MissileArray[i].GetComponent<Collider2D>().enabled = true;
                    // 미사일을 메모리로 돌려보내고
                    MPool.RemoveItem(MissileArray[i]);
                    // 가리키는 배열의 해당 항목도 null(값 없음)로 만든다.
                    MissileArray[i] = null;
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
        yield return new WaitForSeconds(FireDelay);
        // FireState를 true로 만든다.
        FireState = true;
    }

    public void Fire()
    {
        FireShoot = true;
        if (FireCount < FireLimit) FireCount++;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 부딛히는 collision을 가진 객체의 태그가 "Click"이나 "Player"일 경우
        if (collision.CompareTag("Enemy"))
        {
            Camera.VirateForTime(0.05f);                                // damage effect
            collision.GetComponent<Collider2D>().enabled = false;
            HPBar.hp -= 10000;
        }
    }
}
