using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GnrtDeliveryBox : MonoBehaviour
{
    //���� ������Ʈ
    public GameObject present;
    public GameObject woodBox;

    //���� ���� ������ Ȯ��
    public float rate;

    //while�� ���� ����
    bool onGoing;

    //���� ������Ʈ
    GameObject portal;

    //����Ʈ
    public ParticleSystem successEff;
    public ParticleSystem failEff;

    void Start()
    {
        StartCoroutine(GenerateBox());
    }

    void Update()
    {

    }

    IEnumerator GenerateBox()
    {
        yield return new WaitForSeconds(0.5f);

        if (Random.Range(0.0f, 0.1f) < rate)
        {
            woodBox.SetActive(false);
            present.SetActive(true);
        }
        else
        {
            present.SetActive(false);
            woodBox.SetActive(true);
        }
    }

    //�浹 �̺�Ʈ
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Portal1_In")
        {
            if (present.activeSelf == true)
            {
                //����Ʈ ����� ��ġ
                Vector3 pos = present.transform.position;
                //����Ʈ �ֱ�
                PlayEffect(true, pos);

                portal = GameObject.FindGameObjectWithTag("Portal1");

                //�ڽ� ����
                present.SetActive(false);
                //���� ����
                Destroy(portal);
                //���ο� �ڽ� ����
                StartCoroutine(GenerateBox());
            }

            else if(woodBox.activeSelf == true)
            {
                portal = GameObject.FindGameObjectWithTag("Portal1");

                //�ڽ� ����
                woodBox.SetActive(false);
                //���� ����
                Destroy(portal);
                //���ο� �ڽ� ����
                StartCoroutine(GenerateBox());
            }
        }

        if (other.tag == "Portal2_In")
        {
            if(present.activeSelf==true)
            {
                portal = GameObject.FindGameObjectWithTag("Portal2");

                //�ڽ� ����
                present.SetActive(false);
                //���� ����
                Destroy(portal);
                //���ο� �ڽ� ����
                StartCoroutine(GenerateBox());
            }

            else if(woodBox.activeSelf == true)
            {
                portal = GameObject.FindGameObjectWithTag("Portal2");

                //����Ʈ ����� ��ġ
                Vector3 pos = woodBox.transform.position;
                //����Ʈ �ֱ�
                PlayEffect(false, pos);

                //�ڽ� ����
                woodBox.SetActive(false);
                //���� ����
                Destroy(portal);
                //���ο� �ڽ� ����
                StartCoroutine(GenerateBox());
            }
        }
    }

    public void PlayEffect(bool success, Vector3 pos)
    {
        ParticleSystem ps = success ? Instantiate(successEff)
                                    : Instantiate(failEff);

        ps.transform.position = pos;
    }
}
