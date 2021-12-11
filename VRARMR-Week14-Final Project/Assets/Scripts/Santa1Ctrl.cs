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

    //게임 매니저 객체를 저장할 변수
    public GameObject gameMng;

    void Update()
    {
        //마우스 왼쪽 버튼을 눌러서 캐릭터 이동
        if(Input.GetMouseButton(0))
        {
            Vector2 deltaPos = Input.mousePosition - prePos;
            deltaPos *= (Time.deltaTime * 0.1f);

            transform.Translate(deltaPos.x, 0, deltaPos.y, mySpace);
        }

        //마우스 위치에 따라 캐릭터 회전
        Vector2 deltaPosForRotate = Input.mousePosition - prePos;
        deltaPosForRotate *= (Time.deltaTime * 10);
        transform.Rotate(0, deltaPosForRotate.x * 2, 0, Space.World);

        prePos = Input.mousePosition;
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

    //충돌처리
    private void OnTriggerEnter(Collider other)
    {
        int score = gameMng.GetComponent<GameMng>().GetScore();
        int goal = gameMng.GetComponent<GameMng>().GetGaol();

        if(score < goal && score >= 0)
        {
            //선물박스
            if (other.tag == "Present")
            {
                gameMng.GetComponent<GameMng>().SetIsCollisionP(true);
                Destroy(other.gameObject);
            }
            //종이박스
            if (other.tag == "WoodBox")
            {
                gameMng.GetComponent<GameMng>().SetIsCollisionB(true);
                Destroy(other.gameObject);
            }
        }
        
    }

}
