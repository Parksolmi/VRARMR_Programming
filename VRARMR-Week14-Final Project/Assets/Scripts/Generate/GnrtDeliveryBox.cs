using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Stage3에서 등장하는 배달 상자를 생성하는 클래스
public class GnrtDeliveryBox : MonoBehaviour
{
    //상자 오브젝트
    public GameObject present;
    public GameObject woodBox;

    //선물 상자 나오는 확률
    public float rate;

    //while문 조건 변수
    bool onGoing;

    //이펙트 - 포털로 이동할 때 쓰이는 효과
    public ParticleSystem successEff;
    public ParticleSystem failEff;

    //폭발 효과음
    public AudioClip explosion; //오디오클립
    AudioSource ads; //오디오 컴포넌트 저장할 변수

    //스테이지 저장 할 게임 오브젝트
    GameObject stage;

    void Start()
    {
        //오디오 컴포넌트 가져오기
        ads = GetComponent<AudioSource>();

        //스테이지 변수 설정
        stage = GameObject.FindGameObjectWithTag("Stage3");

        //박스 생성 시작
        StartCoroutine(GenerateBox());
    }

    void Update()
    {

    }

    //박스 생성 함수
    IEnumerator GenerateBox()
    {
        //0.5초 대기 후 생성
        yield return new WaitForSeconds(0.5f);

        //선물 상자가 나오는 경우
        if (Random.Range(0.0f, 1.0f) < rate)
        {
            //오브젝트 비/활성화
            woodBox.SetActive(false);
            present.SetActive(true);
        }
        //나무 상자가 나오는 경우
        else
        {
            //오브젝트 비/활성화
            present.SetActive(false);
            woodBox.SetActive(true);
        }
    }

    //충돌 이벤트
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Portal1_In") //포털1과 충돌 한 경우
        {
            //선물 상자와 충돌 했으면 점수 1만큼 획득
            if (present.activeSelf == true) 
            {
                //이펙트 생기는 위치
                Vector3 pos = present.transform.position;
                //이펙트 넣기
                PlayEffect(true, pos);

                //박스 삭제
                present.SetActive(false);
                //포털 삭제
                Destroy(GameObject.FindGameObjectWithTag("Portal1"));
                //새로운 박스 생성
                StartCoroutine(GenerateBox());

                //점수 획득
                stage.GetComponent<Mng_Score>().AddScore(1);
            }
            //나무 상자와 충돌 했으면 주어진 시간 3초 감소
            else if(woodBox.activeSelf == true)
            {
                //박스 삭제
                woodBox.SetActive(false);
                //포털 삭제
                Destroy(GameObject.FindGameObjectWithTag("Portal1"));
                //새로운 박스 생성
                StartCoroutine(GenerateBox());

                //시간 잃음
                stage.GetComponent<Mng_Score>().MinusCountDown(3);
            }
        }

        //포털 2와 충돌 한 경우
        if (other.tag == "Portal2_In")
        {
            //선물 상자와 충돌 했으면 점수 1점 잃음
            if(present.activeSelf==true)
            {
                //박스 삭제
                present.SetActive(false);
                //포털 삭제
                Destroy(GameObject.FindGameObjectWithTag("Portal2"));
                //새로운 박스 생성
                StartCoroutine(GenerateBox());

                //점수 잃음
                stage.GetComponent<Mng_Score>().SubScore(1);
            }
            //나무 상자와 충돌 했으면 시간 5초 획득
            else if(woodBox.activeSelf == true)
            {
                //이펙트 생기는 위치
                Vector3 pos = woodBox.transform.position;
                //이펙트 넣기
                PlayEffect(false, pos);

                //박스 삭제
                woodBox.SetActive(false);
                //포털 삭제
                Destroy(GameObject.FindGameObjectWithTag("Portal2"));
                //새로운 박스 생성
                StartCoroutine(GenerateBox());

                //폭발 효과음 생성
                ads.PlayOneShot(explosion);

                //시간 획득
                stage.GetComponent<Mng_Score>().PlusCountDown(5);
            }
        }
    }

    //이펙트 재생하는 함수
    public void PlayEffect(bool success, Vector3 pos)
    {
        //성공 여부에 따라 성공 이펙트, 실패 이펙트를 생성하기
        ParticleSystem ps = success ? Instantiate(successEff)
                                    : Instantiate(failEff);

        //생성 위치 설정
        ps.transform.position = pos;
    }
}
