using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Stage2에서 생성되는 EnemySanta 컨트롤 스크립트
public class EnemySantaCtrl : MonoBehaviour
{
    //EnemySanta 움직이는 속도
    public float speed;
    //EnemySanta 움직이는 방향
    Vector3 moveDir;

    //Present2OnGrnd 오브젝트
    private GameObject present2OnGrnd;

    //Present2 오브젝트
    public GameObject present2;

    //스테이지 오브젝트
    private GameObject stage;

    void Start()
    {
        //스테이지 변수 설정
        stage = GameObject.FindGameObjectWithTag("Stage2");

        //present2OnGrnd 변수 설정
        present2OnGrnd = GameObject.FindWithTag("Present2OnGrnd");

        //present2OnGrnd가 생성되어 있다면(즉, 바닥에 떨어진 선물 상자가 있다면)
        if (present2OnGrnd != null)
        { 
            //선물 쪽으로 방향 전환
            GameObject present2OnGrnd = GameObject.FindGameObjectWithTag("Present2OnGrnd");

            //선물 쪽 방향 구하기
            moveDir = present2OnGrnd.transform.position - transform.position;
            moveDir.y = 0;

            //오브젝트 회전 각도 구하기
            float angle = Vector3.SignedAngle(
                transform.forward, moveDir.normalized, Vector3.up);

            //구해진 각도 만큼 회전하여 EnemySanta가 선물을 향하도록 함
            transform.Rotate(0, angle, 0);
        }
        else //바닥에 떨어져 있는 선물 상자가 없다면 랜덤하게 움직인다
        {
            //플레이어 쪽으로 방향 전환
            GameObject player = GameObject.FindGameObjectWithTag("Santa2");

            //플레이어 쪽 방향 구하기
            moveDir = player.transform.position - transform.position;
            moveDir.y = 0;

            //오브젝트 회전 각도 구하기
            float angle = Vector3.SignedAngle(
                transform.forward, moveDir.normalized, Vector3.up);

            //4초마다 랜덤하게 방향 바꾸기
            StartCoroutine(ChangeDirection());
        }
    }

    void Update()
    {
        //정해진 방향으로 전진하여 움직이기
        Vector3 deltaPos = transform.forward * speed * Time.deltaTime;
        transform.Translate(deltaPos, Space.World);
    }

    //3초마다 방향 바꾸기
    IEnumerator ChangeDirection()
    {
        while(true)
        {
            //랜덤 각도를 angle변수에 저장
            float angle = Random.Range(0, 360);
            //angle각도 만큼 오브젝트 회전 시키기(방향바꾸기)
            transform.Rotate(0, angle, 0);

            //4초 대기 - 대기하는 동안 오브젝트는 정해진 방향으로 직진
            yield return new WaitForSeconds(4.0f);
        }
    }

    //충돌 검사
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")//총알이랑 충돌 했을 시
        {
            Destroy(other.gameObject); //총알 삭제
            Destroy(this.gameObject); //enemy 삭제
        }
        if (other.tag == "Santa2")//플레이어와 충돌 했을 시
        {
            //타이머 줄이기 - 3초
            stage.GetComponent<Mng_Score>().MinusCountDown(3);
        }
        if (other.tag == "Present2OnGrnd") //땅에 떨어진 선물과 충돌 했을 시
        {
            //점수 1점 감점
            stage.GetComponent<Mng_Score>().SubScore(1);
            Destroy(other.gameObject); //선물 제거
            Destroy(this.gameObject); //자기자신(EnemySanta)제거
        }
    }
}
