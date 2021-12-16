using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//스테이지1의 플레이어 캐릭터 컨트롤 클래스
public class Santa1Ctrl : MonoBehaviour
{
    //스테이지 변수
    GameObject stage;

    //플레이어 변수
    public GameObject player;

    //플레이어 위치 변수
    public Space mySpace;

    //이전위치를 저장할 변수
    Vector3 prePos;

    private void Start()
    {
        //스테이지 변수 설정
        stage = GameObject.FindGameObjectWithTag("Stage1");
    }

    void Update()
    {
        //마우스 왼쪽 버튼을 눌러서 캐릭터 이동
        if(Input.GetMouseButton(0))
        {
            //마우스 위치에서 이전 위치를 뺀 위치를 deltaPos변수에 저장
            Vector2 deltaPos = Input.mousePosition - prePos;
            //일정한 시간으로 움직이게 하기 위해서 deltaTime곱하기
            deltaPos *= (Time.deltaTime * 0.1f);

            //마우스 위치에 따른 상대 위치로 오브젝트 옮기기
            transform.Translate(deltaPos.x, 0, deltaPos.y, mySpace);
        }

        //마우스 위치에 따라 캐릭터 회전
        //마우스 위치에서 이전 위치를 뺀 위치를 deltaPosForRotate변수에 저장
        Vector2 deltaPosForRotate = Input.mousePosition - prePos;
        //일정한 시간으로 움직이게 하기 위해서 deltaTime곱하기
        deltaPosForRotate *= (Time.deltaTime * 10);
        //정해진 각도 만큼 오브젝트 회전하기
        transform.Rotate(0, deltaPosForRotate.x * 2, 0, Space.World);

        //현재 마우스 위치를 이전 위치 변수에 저장
        prePos = Input.mousePosition;
    }

    //충돌처리
    private void OnTriggerEnter(Collider other)
    {
        //Score관리 클래스에서 게임 종료에 대한 변수 가져오기
        bool isSuccess = stage.GetComponent<Mng_Score>().GetIsSuccess();
        bool isFail = stage.GetComponent<Mng_Score>().GetIsFail();

        //게임이 진행되는 동안(아직 성공, 실패가 결정되지 않은 상황)
        if (!isSuccess && !isFail)
        {
            //선물박스와 충돌 한 경우
            if (other.tag == "Present")
            {
                stage.GetComponent<Mng_Score>().AddScore(1); //점수 1점 획득
                Destroy(other.gameObject); //박스 오브젝트 삭제
            }
            //종이박스와 충돌한 경우
            if (other.tag == "WoodBox")
            {
                stage.GetComponent<Mng_Score>().SubScore(3); //점수 3점 감점
                Destroy(other.gameObject); //박스 오브젝트 삭제
            }
        }
        
    }

}
