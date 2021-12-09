using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Santa1Ctrl : MonoBehaviour
{
    public GameObject player;
    //플레이어 위치 변수
    public Space mySpace;
    
    Vector3 prePos; //이전위치를 저장할 변수

    void Update()
    {
        //마우스 왼쪽 버튼을 눌러서 캐릭터 이동
        if(Input.GetMouseButton(0))
        {
            Vector2 deltaPos = Input.mousePosition - prePos;
            deltaPos *= (Time.deltaTime * 0.1f);

            transform.Translate(deltaPos.x, 0, deltaPos.y, mySpace);
        }

        prePos = Input.mousePosition;

        //마우스 오른쪽 버튼으로 총알 발사
        if(Input.GetMouseButtonDown(1))
        {

        }
        //마우스 위치에 따라 캐릭터 회전

    }

    public void setActiveFalse()
    {
        player.SetActive(false);
    }

    public void setActiveTrue()
    {
        player.SetActive(true);
    }

}
