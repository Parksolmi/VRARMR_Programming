using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveTimeItem : MonoBehaviour
{
    //�������� ���� ������Ʈ �����ϴ� ����
    private GameObject stage;

    //������ ȹ�� �� �þ�� �ð�
    public int plusTime;
    //���� ���� �� ������� �ð�
    public float deleteTime;

    private void Start()
    {
        stage = GameObject.FindGameObjectWithTag("Stage2");
    }


    //�浹�˻�
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Santa2")
        {
            Destroy(this.gameObject);
            stage.GetComponent<Mng_Score>().PlusCountDown(plusTime);
        }
        if (other.tag == "Ground")
        {
            //TimeItemMove ��Ȱ��ȭ
            this.gameObject.GetComponent<TimeItemMove>().enabled = false;
            //���� ������ deleteTime�� �� �ڽ� ������Ʈ ���ֱ�
            Destroy(this.gameObject, deleteTime);
        }
    }
}
