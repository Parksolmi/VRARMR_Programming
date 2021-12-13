using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GnrtTimeItem : MonoBehaviour
{
    //Ÿ�� ������ ������ ���� �� ���ӿ�����Ʈ
    public GameObject timeItem;

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
        StartCoroutine(GenerateTimeItem());
    }

    public void StopGnrt()
    {
        onGoing = false;
        StopCoroutine(GenerateTimeItem());
    }

    IEnumerator GenerateTimeItem()
    {
        while (onGoing)
        {
            //30~40�� �ڿ� �ٽ� ����
            yield return new WaitForSeconds(Random.Range(30f, 40f));

            //������ ���� ����
            GameObject obj = Instantiate(timeItem);

            //������ ���ڰ� �����Ǵ� ���� ��ġ ����
            Vector3 randPos;
            randPos.x = Random.Range(-0.1f, 0.1f);
            randPos.y = 0.4f; //�ϴÿ��� �����Ǿ�� �ϹǷ� ���� ���� ����
            randPos.z = Random.Range(-0.1f, 0.1f);

            //������ ���� ��ġ = �÷��̾� ��ġ���� ���� ��ġ�� ���� ��
            obj.transform.position = transform.position + randPos;

            //������ ���� �����̱�
            obj.GetComponent<TimeItemMove>().SetPosDir(obj.transform.position,
                                                            Vector3.down);

            //�ƹ����� �浹���� �ʰ� ��� �������� ���
            Destroy(obj, 40);
        }

    }
}
