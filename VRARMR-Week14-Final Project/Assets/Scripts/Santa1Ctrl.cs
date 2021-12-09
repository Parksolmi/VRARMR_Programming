using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//스테이지1의 플레이어 캐릭터에 대한 클래스
public class Santa1Ctrl : MonoBehaviour
{
    //플레이어를 저장할 게임 오브젝트 변수
    public GameObject player;

    //플레이어 위치 변수
    public Space mySpace;

    //이전위치를 저장할 변수
    Vector3 prePos; 

    void Update()
    {
        //마우스 왼쪽 버튼을 눌러서 캐릭터 이동
        if(Input.GetMouseButton(0))
        {
            Vector2 deltaPos = Input.mousePosition - prePos;
            deltaPos *= (Time.deltaTime * 0.1f);

            transform.Translate(deltaPos.x, 0, deltaPos.y, mySpace);
        }

        //prePos에 마우스 위치를 넣는다
        prePos = Input.mousePosition;

        //마우스 위치에 따라 캐릭터 회전

    }

    //해당 게임 오브젝트를 비활성화 시키는 함수
    public void setActiveFalse()
    {
        player.SetActive(false);
    }
    //해당 게임 오브젝트를 활성화 시키는 함수
    public void setActiveTrue()
    {
        player.SetActive(true);
    }

}
