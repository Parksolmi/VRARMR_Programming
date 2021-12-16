using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//스테이지2의 플레이어 캐릭터 컨트롤 클래스
public class Santa2Ctrl : MonoBehaviour
{
    //스테이지 변수
    GameObject stage;

    //총 오브젝트 변수
    public GameObject gun;

    //총알 오브젝트 변수
    public GameObject bullet;

    //플레이어 위치 변수
    public Space mySpace;

    //이전위치를 저장할 변수
    Vector3 prePos;

    //효과음
    public AudioClip shot; //오디오 클립
    AudioSource ads; //오디오 컴포넌트를 저장할 변수

    private void Start()
    {
        ads = GetComponent<AudioSource>(); //오디오 컴포넌트 가져오기

        stage = GameObject.FindGameObjectWithTag("Stage2"); //스테이지 변수 설정
    }

    void Update()
    {
        //마우스 왼쪽 버튼을 눌러서 캐릭터 이동 - Sanata1Ctrl 클래스와 중복
        if (Input.GetMouseButton(0))
        {
            Vector2 deltaPos = Input.mousePosition - prePos;
            deltaPos *= (Time.deltaTime * 0.1f);

            transform.Translate(deltaPos.x, 0, deltaPos.y, mySpace);
        }

        //마우스 위치에 따라 캐릭터 회전 - Sanata1Ctrl 클래스와 중복
        Vector2 deltaPosForRotate = Input.mousePosition - prePos;
        deltaPosForRotate *= (Time.deltaTime * 10);
        transform.Rotate(0, deltaPosForRotate.x * 2, 0, Space.World);

        prePos = Input.mousePosition;

        //마우스 오른쪽 버튼 눌러서 총알 발사
        if(Input.GetMouseButtonDown(1))
        {
            Shot(transform.forward); //발사 함수 호출
        }
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
            //선물박스와 충돌 한 경우
            if (other.tag == "Present2")
            {
                stage.GetComponent<Mng_Score>().AddScore(1);//점수 1점 획득
                Destroy(other.gameObject); //박스 오브젝트 삭제
            }
            //종이박스
            if (other.tag == "WoodBox")
            {
                stage.GetComponent<Mng_Score>().SubScore(3); //점수 3점 감점
                Destroy(other.gameObject); //박스 오브젝트 삭제
            }
        }
    }

    //총알 생성 및 발사하는 함수
    void Shot(Vector3 dir)
    {
        GameObject obj = Instantiate(bullet); //총알 생성
        Vector3 shotPos = gun.transform.position; //총구 위치를 발사 위치로 설정

        //총알 쏘는 효과음 발생
        ads.PlayOneShot(shot);

        //총알 움직이기
        obj.GetComponent<MoveBullet>().SetPosDir(shotPos, dir);

        //10초 뒤에 총알 없애기
        Destroy(obj, 10);
    }
}
