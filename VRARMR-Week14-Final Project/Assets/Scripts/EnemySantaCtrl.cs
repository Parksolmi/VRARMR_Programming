using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySantaCtrl : MonoBehaviour
{
    public float speed;
    Vector3 moveDir;

    //Present2OnGrnd 오브젝트를 저장하는 변수
    private GameObject present2OnGrnd;

    //Present2 오브젝트를 저장하는 변수
    public GameObject present2;

    //스테이지 오브젝트
    private GameObject stage;

    void Start()
    {
        present2OnGrnd = GameObject.FindWithTag("Present2OnGrnd");

        //스테이지 설정
        stage = GameObject.FindGameObjectWithTag("Stage2");

        if (present2OnGrnd != null)
        { 
            //선물 쪽으로 방향 전환
            GameObject present2OnGrnd = GameObject.FindGameObjectWithTag("Present2OnGrnd");

            moveDir = present2OnGrnd.transform.position - transform.position;
            moveDir.y = 0;

            float angle = Vector3.SignedAngle(
                transform.forward, moveDir.normalized, Vector3.up);

            transform.Rotate(0, angle, 0);
        }
        else
        {
            //랜덤 방향으로 움직이기
            GameObject player = GameObject.FindGameObjectWithTag("Santa2");

            moveDir = player.transform.position - transform.position;
            moveDir.y = 0;

            float angle = Vector3.SignedAngle(
                transform.forward, moveDir.normalized, Vector3.up);

            //3초마다 방향 바꾸기
            StartCoroutine(ChangeDirection());
        }
    }

    void Update()
    {
        //움직이기
        Vector3 deltaPos = transform.forward * speed * Time.deltaTime;
        transform.Translate(deltaPos, Space.World);
    }

    //3초마다 방향 바꾸기
    IEnumerator ChangeDirection()
    {
        while(true)
        {
            float angle = Random.Range(0, 360);
            transform.Rotate(0, angle, 0);

            yield return new WaitForSeconds(4.0f);
        }
    }

    //충돌 검사
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            Destroy(other.gameObject); //총알 삭제
            Destroy(this.gameObject); //enemy 삭제
        }
        if (other.tag == "Santa2")
        {
            //타이머 줄이기 - 3초
            stage.GetComponent<Mng_Score>().MinusCountDown(3);
        }
        if (other.tag == "Present2OnGrnd")
        {
            stage.GetComponent<Mng_Score>().SubScore(1);
            //선물 제거
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
