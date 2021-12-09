using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���� ���� �� �÷��̾� ĳ���Ϳ� ���� Ŭ����
public class SantaIdle : MonoBehaviour
{
    //�÷��̾ ������ ���� ������Ʈ ����
    public GameObject player;
    //�÷��̾ �νĵǾ����� ���θ� �����ϴ� ����
    public bool isDetected;
    
    //�ش� ���� ������Ʈ�� ��Ȱ��ȭ ��Ű�� �Լ�
    public void setActiveFalse()
    {
        player.SetActive(false);
    }

    //�ش� �÷��̾ �νĵǾ����� Ȯ���ϴ� �Լ�
    public void OnDetect(bool detect)
    {
        //�νĵǾ��ٸ� true��, �νĵ��� �ʾҴٸ� false�� ������ ����
        isDetected = detect;
    }
}
