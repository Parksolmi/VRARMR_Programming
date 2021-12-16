using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GnrtDeliveryBox : MonoBehaviour
{
    //상자 오브젝트
    public GameObject present;
    public GameObject woodBox;

    //선물 상자 나오는 확률
    public float rate;

    //while문 조건 변수
    bool onGoing;

    //포털 오브젝트
    GameObject portal;

    //이펙트
    public ParticleSystem successEff;
    public ParticleSystem failEff;

    //폭발 효과음
    public AudioClip explosion;

    AudioSource ads;

    //스테이지 저장 할 게임 오브젝트
    GameObject stage;

    void Start()
    {

        ads = GetComponent<AudioSource>();

        stage = GameObject.FindGameObjectWithTag("Stage3");
        StartCoroutine(GenerateBox());
    }

    void Update()
    {

    }

    IEnumerator GenerateBox()
    {
        yield return new WaitForSeconds(0.5f);

        if (Random.Range(0.0f, 1.0f) < rate)
        {
            woodBox.SetActive(false);
            present.SetActive(true);
        }
        else
        {
            present.SetActive(false);
            woodBox.SetActive(true);
        }
    }

    //충돌 이벤트
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Portal1_In")
        {
            if (present.activeSelf == true)
            {
                //이펙트 생기는 위치
                Vector3 pos = present.transform.position;
                //이펙트 넣기
                PlayEffect(true, pos);

                //포털 오브젝트 저장
                portal = GameObject.FindGameObjectWithTag("Portal1");

                //박스 삭제
                present.SetActive(false);
                //포털 삭제
                Destroy(portal);
                //새로운 박스 생성
                StartCoroutine(GenerateBox());

                //점수 획득
                stage.GetComponent<Mng_Score>().AddScore(1);
            }

            else if(woodBox.activeSelf == true)
            {
                portal = GameObject.FindGameObjectWithTag("Portal1");

                //박스 삭제
                woodBox.SetActive(false);
                //포털 삭제
                Destroy(portal);
                //새로운 박스 생성
                StartCoroutine(GenerateBox());

                //시간 잃음
                stage.GetComponent<Mng_Score>().MinusCountDown(3);
            }
        }

        if (other.tag == "Portal2_In")
        {
            if(present.activeSelf==true)
            {
                portal = GameObject.FindGameObjectWithTag("Portal2");

                //박스 삭제
                present.SetActive(false);
                //포털 삭제
                Destroy(portal);
                //새로운 박스 생성
                StartCoroutine(GenerateBox());

                //점수 잃음
                stage.GetComponent<Mng_Score>().SubScore(1);
            }

            else if(woodBox.activeSelf == true)
            {
                portal = GameObject.FindGameObjectWithTag("Portal2");

                //이펙트 생기는 위치
                Vector3 pos = woodBox.transform.position;
                //이펙트 넣기
                PlayEffect(false, pos);

                //박스 삭제
                woodBox.SetActive(false);
                //포털 삭제
                Destroy(portal);
                //새로운 박스 생성
                StartCoroutine(GenerateBox());

                //폭발 효과음 생성
                ads.PlayOneShot(explosion);

                //시간 획득
                stage.GetComponent<Mng_Score>().PlusCountDown(5);
            }
        }
    }

    public void PlayEffect(bool success, Vector3 pos)
    {
        ParticleSystem ps = success ? Instantiate(successEff)
                                    : Instantiate(failEff);

        ps.transform.position = pos;
    }
}
