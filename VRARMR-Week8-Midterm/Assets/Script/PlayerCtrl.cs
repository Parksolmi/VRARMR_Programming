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

    int triggerNum = 0; //�浹 Ƚ��
    int PlayerHP = 10;

    void Start()
    {
        playerState.text = PlayerHP.ToString();
    }

    void Update()
    {
        //���� ������ �ڵ�
        if (Input.GetMouseButtonDown(0))
        {
            prePos = Input.mousePosition;
        }

        //�̵�
        if (Input.GetMouseButton(0)) 
        {
            Vector3 deltaPosForMove = Input.mousePosition - prePos;
            deltaPosForMove *= (Time.deltaTime * 0.1f);

            transform.Translate(deltaPosForMove.x, 0, deltaPosForMove.y, Space.World);
        }

        //ȸ��
        Vector2 deltaPosForRotate = Input.mousePosition - prePos;
        deltaPosForRotate *= (Time.deltaTime * 10);
        transform.Rotate(0, deltaPosForRotate.x * 2, 0, Space.World);
        
        prePos = Input.mousePosition;

        //����
        if(Input.GetMouseButtonDown(1))
        {
            if (triggerNum == 0)
            {
                Shot(transform.forward); //��
            }
            else if (triggerNum == 2)
            {
                Shot(transform.forward); //��
                Shot(-transform.forward); //��
            }
            else if (triggerNum == 4)
            {
                Shot(transform.forward); //��
                Shot(-transform.forward); //��
                Shot(-transform.right); //��
                Shot(transform.right); //��
            }
            else
            {
                Shot(transform.forward); //��
                Shot(-transform.forward); //��
                Shot(-transform.right); //��
                Shot(transform.right); //��
                //����밢��
                Shot((transform.forward + transform.right)/2); //������
                Shot((transform.forward + (-transform.right))/2); //����
                //�Ĺ�밢��
                Shot(((-transform.forward) + transform.right)/2); //������
                Shot(((-transform.forward) + (-transform.right))/2); //����
                
            }
        }

        if (PlayerHP <= 0)
        {
            Destroy(GameObject.FindGameObjectWithTag("Player"));
            gameResult.text = "Game Over";
        }
    }

    //�Ѿ� ���� �� �߻�
    void Shot(Vector3 dir)
    {
        GameObject obj = Instantiate(PlayerBullet);
        Vector3 shotPos = transform.position + transform.up * 0.05f;
        shotPos.y += 0.01f;

        obj.GetComponent<PlayerBulletMove>().SetPosDir(shotPos, dir);
        Destroy(obj, 10);
    }

    //�浹ó��
    private void OnTriggerEnter(Collider other)
    {
        //������
        if (other.tag == "item")
        {
            triggerNum++;
            Destroy(other.gameObject); //�浹 �� ������Ʈ ����
        }
        
        //�Ѿ�
        if(other.tag == "capsuleBullet" 
            || other.tag == "cylinderBullet")
        {
            Destroy(other.gameObject);
            PlayerHP--;
            playerState.text = PlayerHP.ToString();
        }

        //����
        if(other.tag == "cylinder"
            || other.tag == "capsule")
        {
            Destroy(other.gameObject);
            PlayerHP -= 2;
            playerState.text = PlayerHP.ToString();
        }
    }

}
