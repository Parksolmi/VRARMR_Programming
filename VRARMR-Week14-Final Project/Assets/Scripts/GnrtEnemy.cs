using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Enemy ��Ÿ �����ϴ� ��ũ��Ʈ
public class GnrtEnemy : MonoBehaviour
{
    //Enemy Santa ������ ����
    public GameObject enemy;

    bool onGoing;

    // Start is called before the first frame update
    void Start()
    {
        StartGnrt();
    }

    public void StartGnrt()
    {
        onGoing = true;
        //1~3�� �������� ���� �����ϱ�
        StartCoroutine(GenerateEnemy());
    }

    public void StopGnrt()
    {
        onGoing = false;
        StopCoroutine(GenerateEnemy());
    }

    IEnumerator GenerateEnemy()
    {
        while(onGoing)
        {
            //10�� �ڿ� �ٽ� ����
            yield return new WaitForSeconds(10f);

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
}
