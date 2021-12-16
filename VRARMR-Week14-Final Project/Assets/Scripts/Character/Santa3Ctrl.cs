using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//스테이지3의 플레이어 캐릭터 컨트롤 클래스
public class Santa3Ctrl : MonoBehaviour
{
    //스테이지 오브젝트 저장하는 변수
    GameObject stage;

    //플레이어 위치 변수
    public Space mySpace;

    //이전위치를 저장할 변수
    Vector3 prePos;

    
    private void Start()
    {
        //스테이지 변수 설정
        stage = GameObject.FindGameObjectWithTag("Stage3");
    }

    void Update()
    {
        //마우스 왼쪽 버튼을 눌러서 캐릭터 이동 - Santa1Ctrl과 중복
        if (Input.GetMouseButton(0))
        {
            Vector2 deltaPos = Input.mousePosition - prePos;
            deltaPos *= (Time.deltaTime * 0.1f);

            transform.Translate(deltaPos.x, 0, deltaPos.y, mySpace);
        }

        //마우스 위치에 따라 캐릭터 회전 - Santa1Ctrl과 중복
        Vector2 deltaPosForRotate = Input.mousePosition - prePos;
        deltaPosForRotate *= (Time.deltaTime * 10);
        transform.Rotate(0, deltaPosForRotate.x * 2, 0, Space.World);

        prePos = Input.mousePosition;

    }

    //충돌처리
    private void OnTriggerEnter(Collider other)
    {
        //Score관리 클래스에서 게임 종료에 대한 변수 가져오기
        int score = stage.GetComponent<Mng_Score>().GetScore();
        int goal = stage.GetComponent<Mng_Score>().GetGoal();

        //게임이 진행되는 동안(아직 성공, 실패가 결정되지 않은 상황)
        if (score < goal && score >= 0)
        {
            if (other.tag == "Child") //Child와 충돌 한 경우
            {
                stage.GetComponent<Mng_Score>().SetCountDown(0); //게임 종료
            }
        }
    }
}
