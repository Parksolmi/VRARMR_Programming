using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�ڽ� ������Ʈ�� �����ϴ� ��ũ��Ʈ
public class RemoveBox : MonoBehaviour
{
    public int deleteTime;

    //�浹ó��
    private void OnCollisionEnter(Collision other)
    {
        //��
        if (other.gameObject.tag.Equals("Ground"))
        {
            //MoveBox��ũ��Ʈ ��Ȱ��ȭ
            this.gameObject.GetComponent<MoveBox>().enabled = false;
            //���� ������ deleteTime�� �� �ڽ� ������Ʈ ���ֱ�
            Destroy(this.gameObject, deleteTime);
        }

        else
        {
            Destroy(this.gameObject, 20);
        }
    }
}
