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
        //하 유니티 믿었는데 transform 그냥 자동완성 탭눌렀는데
        //왜 대문자로돼서 하싫다 밉다미워


        //레전드 상황발생 ㅋㅋ 이거 z값 변동 몰랐으면 또 몇시간쓸번했네 ㅋㅋ개꿀
    }
    
}
