using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Stage3���� �����ϴ� ��� ���ڸ� �����ϴ� Ŭ����
public class GnrtDeliveryBox : MonoBehaviour
{
    //���� ������Ʈ
    public GameObject present;
    public GameObject woodBox;

    //���� ���� ������ Ȯ��
    public float rate;

    //while�� ���� ����
    bool onGoing;

    //����Ʈ - ���з� �̵��� �� ���̴� ȿ��
    public ParticleSystem successEff;
    public ParticleSystem failEff;

    //���� ȿ����
    public AudioClip explosion; //�����Ŭ��
    AudioSource ads; //����� ������Ʈ ������ ����

    //�������� ���� �� ���� ������Ʈ
    GameObject stage;

    void Start()
    {
        //����� ������Ʈ ��������
        ads = GetComponent<AudioSource>();

        //�������� ���� ����
        stage = GameObject.FindGameObjectWithTag("Stage3");

        //�ڽ� ���� ����
        StartCoroutine(GenerateBox());
    }

    void Update()
    {

    }

    //�ڽ� ���� �Լ�
    IEnumerator GenerateBox()
    {
        //0.5�� ��� �� ����
        yield return new WaitForSeconds(0.5f);

        //���� ���ڰ� ������ ���
        if (Random.Range(0.0f, 1.0f) < rate)
        {
            //������Ʈ ��/Ȱ��ȭ
            woodBox.SetActive(false);
            present.SetActive(true);
        }
        //���� ���ڰ� ������ ���
        else
        {
            //������Ʈ ��/Ȱ��ȭ
            present.SetActive(false);
            woodBox.SetActive(true);
        }
    }

    //�浹 �̺�Ʈ
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Portal1_In") //����1�� �浹 �� ���
        {
            //���� ���ڿ� �浹 ������ ���� 1��ŭ ȹ��
            if (present.activeSelf == true) 
            {
                //����Ʈ ����� ��ġ
                Vector3 pos = present.transform.position;
                //����Ʈ �ֱ�
                PlayEffect(true, pos);

                //�ڽ� ����
                present.SetActive(false);
                //���� ����
                Destroy(GameObject.FindGameObjectWithTag("Portal1"));
                //���ο� �ڽ� ����
                StartCoroutine(GenerateBox());

                //���� ȹ��
                stage.GetComponent<Mng_Score>().AddScore(1);
            }
            //���� ���ڿ� �浹 ������ �־��� �ð� 3�� ����
            else if(woodBox.activeSelf == true)
            {
                //�ڽ� ����
                woodBox.SetActive(false);
                //���� ����
                Destroy(GameObject.FindGameObjectWithTag("Portal1"));
                //���ο� �ڽ� ����
                StartCoroutine(GenerateBox());

                //�ð� ����
                stage.GetComponent<Mng_Score>().MinusCountDown(3);
            }
        }

        //���� 2�� �浹 �� ���
        if (other.tag == "Portal2_In")
        {
            //���� ���ڿ� �浹 ������ ���� 1�� ����
            if(present.activeSelf==true)
            {
                //�ڽ� ����
                present.SetActive(false);
                //���� ����
                Destroy(GameObject.FindGameObjectWithTag("Portal2"));
                //���ο� �ڽ� ����
                StartCoroutine(GenerateBox());

                //���� ����
                stage.GetComponent<Mng_Score>().SubScore(1);
            }
            //���� ���ڿ� �浹 ������ �ð� 5�� ȹ��
            else if(woodBox.activeSelf == true)
            {
                //����Ʈ ����� ��ġ
                Vector3 pos = woodBox.transform.position;
                //����Ʈ �ֱ�
                PlayEffect(false, pos);

                //�ڽ� ����
                woodBox.SetActive(false);
                //���� ����
                Destroy(GameObject.FindGameObjectWithTag("Portal2"));
                //���ο� �ڽ� ����
                StartCoroutine(GenerateBox());

                //���� ȿ���� ����
                ads.PlayOneShot(explosion);

                //�ð� ȹ��
                stage.GetComponent<Mng_Score>().PlusCountDown(5);
            }
        }
    }

    //����Ʈ ����ϴ� �Լ�
    public void PlayEffect(bool success, Vector3 pos)
    {
        //���� ���ο� ���� ���� ����Ʈ, ���� ����Ʈ�� �����ϱ�
        ParticleSystem ps = success ? Instantiate(successEff)
                                    : Instantiate(failEff);

        //���� ��ġ ����
        ps.transform.position = pos;
    }
}
