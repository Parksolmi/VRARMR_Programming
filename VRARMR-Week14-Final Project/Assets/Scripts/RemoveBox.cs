using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�ڽ� ������Ʈ�� �����ϴ� ��ũ��Ʈ
public class RemoveBox : MonoBehaviour
{
    //�浹ó��
    private void OnCollisionEnter(Collision other)
    {
        //��
        if (other.gameObject.tag.Equals("Ground"))
        {
            //MoveBox��ũ��Ʈ ��Ȱ��ȭ
            this.gameObject.GetComponent<MoveBox>().enabled = false;
            //���� ������ 1�� �� �ڽ� ������Ʈ ���ֱ�
            Destroy(this.gameObject, 1);
        }
    }
}
