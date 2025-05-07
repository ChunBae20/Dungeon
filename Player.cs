using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    private Rigidbody2D rb;
    private CapsuleCollider2D cc;  
    private Vector2 move;  //use xy
    private Animator anim;
    private SpriteRenderer sr;

    public uimanager Uimanager;
    public bool NextScenePlace = false;

    public GameObject Panel;
    



    void Start()
    {

        sr = GetComponent<SpriteRenderer>(); // 스프렌더러 가져다씀
        anim = GetComponent<Animator>(); // 애니메이터 가져다씀
        rb = GetComponent<Rigidbody2D>(); // 리지드 바디 좀 가져오겟음
    }

    //매프렘마다 초기화 이동로직 ㅇㅇ
    void Update()
    {
        if (NextScenePlace && Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene("jumpjump");
        }
        move = Vector2.zero;

        //저는 양방향 동시에 누를 멈추는게 더 보기가 좋네요 

        if (Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow))
            move.y = 3;
        else if (Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.UpArrow))
            move.y = -3;
        

        if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
            move.x = 3;
        else if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
            move.x = -3;
    }

    void FixedUpdate()
    {
        //방향키 입력좌우플립
        if (move.x != 0) 
        {
            sr.flipX = move.x < 0;
        }

        Vector2 movenormalized = move.normalized;
        rb.MovePosition(rb.position +  movenormalized*10.0f* Time.fixedDeltaTime);




        #region 더미

        //여기 계산식에 더하기 연산을 안하면 +3-3 이거만 상하좌우로 움직일거임
        //거리 = 속력*방향*시간, 지금내가한거 방향만추가한거임 힘인3.0f를 해줘야함
        //흠 유니티 벡터는xy float이네 따블 쓰면 겜터지나?궁금한데
        //3.4028235 × 10^38 이게 플롯 최대네? 9해봄
        //rb.MovePosition(rb.position +  movenormalized*3.000000000000000000000000000000000000001f* Time.fixedDeltaTime);
        //아 그냥 애초에 비주얼스튜디오에서 오류뜨고 소수점 7자리외는 다 끊어먹네? 

        float nowSpeed = move.magnitude*3f; // 벡터크기계산식 이건 그냥 벡터만게산하고 현재 그거를 계산안해주네?

        //이동거리 = 시간*속도
        //나중거리 - 이전거리 = 이동거리,
        //아 귀찮다 뭐 잘 됐곗지 
        //아니 이거 속도 출력어캐함?아점심나가먹겟다.
        //Debug.Log("현재이속 : (move.magnitude): " + nowSpeed);

        #endregion
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag( "Npc"))
        {
            NextScenePlace = true;
            Debug.Log("다음 씬으로 입장가능 상태입니다.");
            openNext();
        }
    }


    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Npc"))
        {
            NextScenePlace = false;
            Debug.Log("다음스테이지 입장가능지역에서 벗어났습니다.");
            closeNext();
        }
    }

    public void openNext()
    {
        if (NextScenePlace == true)
        {
            Panel.SetActive(true);
        }
    }

    public void closeNext()
    {
        if (NextScenePlace == false)
        {
            Panel.SetActive(false);
        }
    }

}
