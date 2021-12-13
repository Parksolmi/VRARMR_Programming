using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Enemy ��Ÿ �����ϴ� ��ũ��Ʈ
public class GnrtEnemy : MonoBehaviour
{
    //Enemy Santa ������ ����
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("GenerateEnemy", 10);
        Invoke("GenerateEnemy", 20);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateEnemy()
    {
        //����
        GameObject obj = Instantiate(enemy);

        //���� ��ġ
        //Enemy�� �����Ǵ� ���� ��ġ ����
        Vector3 randPos;
        randPos.x = Random.Range(-0.2f, 0.2f);
        randPos.y = 0;
        randPos.z = Random.Range(-0.2f, 0.2f);

        //Enemy ��ġ = �÷��̾� ��ġ���� ���� ��ġ�� ���� ��
        obj.transform.position = transform.position + randPos;
    }
}
