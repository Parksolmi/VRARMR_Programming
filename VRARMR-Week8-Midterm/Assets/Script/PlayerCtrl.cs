using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCtrl : MonoBehaviour
{
    Vector3 prePos;
    public GameObject PlayerBullet;
    public Text playerState;
    public Text gameResult;

    int triggerNum = 0; //충돌 횟수
    int PlayerHP = 10;

    void Start()
    {
        playerState.text = PlayerHP.ToString();
    }

    void Update()
    {
        //버그 수정용 코드
        if (Input.GetMouseButtonDown(0))
        {
            prePos = Input.mousePosition;
        }

        //이동
        if (Input.GetMouseButton(0)) 
        {
            Vector3 deltaPosForMove = Input.mousePosition - prePos;
            deltaPosForMove *= (Time.deltaTime * 0.1f);

            transform.Translate(deltaPosForMove.x, 0, deltaPosForMove.y, Space.World);
        }

        //회전
        Vector2 deltaPosForRotate = Input.mousePosition - prePos;
        deltaPosForRotate *= (Time.deltaTime * 10);
        transform.Rotate(0, deltaPosForRotate.x * 2, 0, Space.World);
        
        prePos = Input.mousePosition;

        //공격
        if(Input.GetMouseButtonDown(1))
        {
            if (triggerNum == 0)
            {
                Shot(transform.forward); //앞
            }
            else if (triggerNum == 2)
            {
                Shot(transform.forward); //앞
                Shot(-transform.forward); //뒤
            }
            else if (triggerNum == 4)
            {
                Shot(transform.forward); //앞
                Shot(-transform.forward); //뒤
                Shot(-transform.right); //좌
                Shot(transform.right); //우
            }
            else
            {
                Shot(transform.forward); //앞
                Shot(-transform.forward); //뒤
                Shot(-transform.right); //좌
                Shot(transform.right); //우
                //전방대각선
                Shot((transform.forward + transform.right)/2); //오른쪽
                Shot((transform.forward + (-transform.right))/2); //왼쪽
                //후방대각선
                Shot(((-transform.forward) + transform.right)/2); //오른쪽
                Shot(((-transform.forward) + (-transform.right))/2); //왼쪽
                
            }
        }

        if (PlayerHP <= 0)
        {
            Destroy(GameObject.FindGameObjectWithTag("Player"));
            gameResult.text = "Game Over";
        }
    }

    //총알 생성 및 발사
    void Shot(Vector3 dir)
    {
        GameObject obj = Instantiate(PlayerBullet);
        Vector3 shotPos = transform.position + transform.up * 0.05f;
        shotPos.y += 0.01f;

        obj.GetComponent<PlayerBulletMove>().SetPosDir(shotPos, dir);
        Destroy(obj, 10);
    }

    //충돌처리
    private void OnTriggerEnter(Collider other)
    {
        //아이템
        if (other.tag == "item")
        {
            triggerNum++;
            Destroy(other.gameObject); //충돌 시 오브젝트 삭제
        }
        
        //총알
        if(other.tag == "capsuleBullet" 
            || other.tag == "cylinderBullet")
        {
            Destroy(other.gameObject);
            PlayerHP--;
            playerState.text = PlayerHP.ToString();
        }

        //몬스터
        if(other.tag == "cylinder"
            || other.tag == "capsule")
        {
            Destroy(other.gameObject);
            PlayerHP -= 2;
            playerState.text = PlayerHP.ToString();
        }
    }

}
