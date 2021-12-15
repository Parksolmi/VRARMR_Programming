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

    void Start()
    {
        StartCoroutine(GenerateBox());
    }

    void Update()
    {

    }

    IEnumerator GenerateBox()
    {
        yield return new WaitForSeconds(0.5f);

        if (Random.Range(0.0f, 0.1f) < rate)
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

                portal = GameObject.FindGameObjectWithTag("Portal1");

                //박스 삭제
                present.SetActive(false);
                //포털 삭제
                Destroy(portal);
                //새로운 박스 생성
                StartCoroutine(GenerateBox());
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
