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

        sr = GetComponent<SpriteRenderer>(); // ���������� �����پ�
        anim = GetComponent<Animator>(); // �ִϸ����� �����پ�
        rb = GetComponent<Rigidbody2D>(); // ������ �ٵ� �� ����������
    }

    //���������� �ʱ�ȭ �̵����� ����
    void Update()
    {
        if (NextScenePlace && Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene("jumpjump");
        }
        move = Vector2.zero;

        //���� ����� ���ÿ� ������ ���ߴ°� �� ���Ⱑ ���׿� 

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
        //����Ű �Է��¿��ø�
        if (move.x != 0) 
        {
            sr.flipX = move.x < 0;
        }

        Vector2 movenormalized = move.normalized;
        rb.MovePosition(rb.position +  movenormalized*10.0f* Time.fixedDeltaTime);




        #region ����

        //���� ���Ŀ� ���ϱ� ������ ���ϸ� +3-3 �̰Ÿ� �����¿�� �����ϰ���
        //�Ÿ� = �ӷ�*����*�ð�, ���ݳ����Ѱ� ���⸸�߰��Ѱ��� ����3.0f�� �������
        //�� ����Ƽ ���ʹ�xy float�̳� ���� ���� ��������?�ñ��ѵ�
        //3.4028235 �� 10^38 �̰� �÷� �ִ��? 9�غ�
        //rb.MovePosition(rb.position +  movenormalized*3.000000000000000000000000000000000000001f* Time.fixedDeltaTime);
        //�� �׳� ���ʿ� ���־�Ʃ������� �����߰� �Ҽ��� 7�ڸ��ܴ� �� ����Գ�? �ǹ�����

        float nowSpeed = move.magnitude*3f; // ����ũ����� �̰� �׳� ���͸��Ի��ϰ� ���� �װŸ� �Ի�����ֳ�?

        //�̵��Ÿ� = �ð�*�ӵ�
        //���߰Ÿ� - �����Ÿ� = �̵��Ÿ�,
        //�� ������ �� �� �ư��� 
        //�ƴ� �̰� �ӵ� ��¾�ĳ��?�����ɳ����԰ٴ�.
        //Debug.Log("�����̼� : (move.magnitude): " + nowSpeed);

        #endregion
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag( "Npc"))
        {
            NextScenePlace = true;
            Debug.Log("���� ������ ���尡�� �����Դϴ�.");
            openNext();
        }
    }


    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Npc"))
        {
            NextScenePlace = false;
            Debug.Log("������������ ���尡���������� ������ϴ�.");
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
