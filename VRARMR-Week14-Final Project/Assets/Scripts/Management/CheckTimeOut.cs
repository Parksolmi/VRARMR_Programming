using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTimeOut : MonoBehaviour
{
    //�������� ���� �� ���� ������Ʈ
    GameObject stage;

    bool isTimeOut;

    public bool GetIsTimeOut()
    {
        return isTimeOut;
    }

    // Start is called before the first frame update
    void Start()
    {
        stage = GameObject.FindGameObjectWithTag("Stage2");

        isTimeOut = true;

        StartCoroutine(PlusScore());
    }

    //�浹 �˻�
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemySanta")
        {
            isTimeOut = false;
        }
    }

    IEnumerator PlusScore()
    {
        yield return new WaitForSeconds(15f);

        if (isTimeOut)
        {
            stage.GetComponent<Mng_Score>().AddScore(1);
        }

        //������Ʈ ����
        Destroy(this.gameObject);
    }
}
