using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Santa2Ctrl : MonoBehaviour
{
    //플레이어를 저장할 게임 오브젝트 변수
    public GameObject player;

    //총 저장할 게임 오브젝트 변수
    public GameObject gun;

    //총알 저장할 게임 오브젝트 변수
    public GameObject bullet;

    //플레이어 위치 변수
    public Space mySpace;

    //이전위치를 저장할 변수
    Vector3 prePos;

    void Update()
    {
        //마우스 왼쪽 버튼을 눌러서 캐릭터 이동
        if (Input.GetMouseButton(0))
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

        //마우스 오른쪽 버튼 눌러서 총알 발사
        if(Input.GetMouseButtonDown(1))
        {
            Shot(transform.forward);
        }
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
        int score = Mng_Score.instance.GetScore();
        int goal = Mng_Score.instance.GetGoal();

        if (score < goal && score >= 0)
        {
            //선물박스
            if (other.tag == "Present2")
            {
                Mng_Score.instance.AddScore(1);
                Destroy(other.gameObject);
            }
            //종이박스
            if (other.tag == "WoodBox")
            {
                Mng_Score.instance.SubScore(4);
                Destroy(other.gameObject);
            }
        }
    }

    //총알 생성 및 발사하는 함수
    void Shot(Vector3 dir)
    {
        GameObject obj = Instantiate(bullet);
        Vector3 shotPos = gun.transform.position;

        obj.GetComponent<MoveBullet>().SetPosDir(shotPos, dir);
        Destroy(obj, 10);
    }
}
