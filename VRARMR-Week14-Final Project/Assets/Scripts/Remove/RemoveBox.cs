using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�ڽ� ������Ʈ�� �����ϴ� ��ũ��Ʈ
public class RemoveBox : MonoBehaviour
{
    public float deleteTime; //���� �� �ð�

    //�浹ó��
    private void OnTriggerEnter(Collider other)
    {
        //���� �浹 �� ���
        if (other.gameObject.tag.Equals("Ground"))
        {
            //MoveBox��ũ��Ʈ ��Ȱ��ȭ
            this.gameObject.GetComponent<MoveBox>().enabled = false;
            //���� ������ deleteTime�� �� �ڽ� ������Ʈ ���ֱ�
            Destroy(this.gameObject, deleteTime);
        }
    }
}
