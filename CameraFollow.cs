using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S2cam : MonoBehaviour
{

    public Transform target;


    void LateUpdate()
    {
        Vector3 Pos = target.position;


        Vector3 followPos = new Vector3((Pos.x), (Pos.y), (Pos.z = -10));
        transform.position = followPos;
        //�� ����Ƽ �Ͼ��µ� transform �׳� �ڵ��ϼ� �Ǵ����µ�
        //�� �빮�ڷεż� �Ͻȴ� �Ӵٹ̿�


        //������ ��Ȳ�߻� ���� �̰� z�� ���� �������� �� ��ð������߳� ��������
    }
    
}
