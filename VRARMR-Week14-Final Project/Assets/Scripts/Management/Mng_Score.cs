using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//���� ���� Ŭ����
public class Mng_Score : MonoBehaviour
{
    public Text scoreText; //���� text
    public Text goalText; //��ǥġ text
    public Text resultText; //��� text

    public int score; //���� ���� ����
    public int goal; //��ǥġ ���� ����

    private bool isSuccess; //�������� ���� �� ����
    private bool isFail; //���� ���� ���� �� ����

    //��ư
    public GameObject nextStage; //���� �������� ��ư�� ���� �� ����
    public GameObject replay; //�ٽ��ϱ� ��ư�� ���� �� ����

    //Ÿ�̸� text
    public Text timerText; //Ÿ�̸� text
    public float time; //�ʱ� �ð� float����
    private float countDown; //ī��Ʈ �ٿ� �ǰ� �ִ� ���� ���� �� float����

    //���� ȿ���� - �����Ŭ��
    public AudioClip getPresent; //���� ����� ��
    public AudioClip getWoodBox; //���� ���� ����� ��

    AudioSource ads; //����� ������Ʈ�� ���� �� ����

    //getter & setter
    public int GetScore()
    {
        return score;
    }
    public int GetGoal()
    {
        return goal;
    }
    public bool GetIsSuccess()
    {
        return isSuccess;
    }
    public bool GetIsFail()
    {
        return isFail;
    }
    public void SetScore(int score)
    {
        this.score = score;
    }
    public void SetGoal(int goal)
    {
        this.goal = goal;
    }
    public void SetIsSuccess(bool isSuccess)
    {
        this.isSuccess = isSuccess;
    }
    public void SetIsFail(bool isFail)
    {
        this.isFail = isFail;
    }
    public void SetCountDown(int countDown)
    {
        this.countDown = countDown;
    }

    //���� ȹ���ϴ� �Լ�
    public void AddScore(int num)
    {
        ads.PlayOneShot(getPresent);

        score += num;
    }
    //���� ���ҽ�Ű�� �Լ�
    public void SubScore(int num)
    {
        ads.PlayOneShot(getWoodBox);

        score -= num;
    }

    private void Start()
    {
        //����� ������Ʈ ��������
        ads = GetComponent<AudioSource>();

        //Ÿ�̸� ����
        countDown = time;

        //goal �ؽ�Ʈ ����
        goalText.text = "Goal " + goal;

        //����/���� ���� ���� false�� ����
        isSuccess = false;
        isFail = false;
    }

    private void Update()
    {
        //score text ������Ʈ
        if (score < 0)
        {
            score = 0;
        }
        scoreText.text = "Present " + score;

        //�ð��ʰ�
        if (Mathf.Floor(countDown)<=0)
        {
            //���� ����
            //������ ���
            if (score >= goal)
            {
                //���� �������� ��ư�� Ȱ��ȭ �Ǿ� ���� �ʴٸ�
                if (nextStage.activeSelf == false)
                {
                    //��� �޼��� ����
                    resultText.text = "Success!";
                    //���� ���� true�� ����
                    isSuccess = true;
                }
            }
            //������ ���
            else if (score < goal)
            {
                //���÷��� ��ư�� Ȱ��ȭ �Ǿ� ���� �ʴٸ�
                if(replay.activeSelf == false)
                {
                    //��� �޼��� ����
                    resultText.text = "Fail!";
                    //���� ���� true ����
                    isFail = true;
                }
            }
        }
        else //���� ���� ��
        {
            //ī��Ʈ�ٿ��ϱ�
            countDown -= Time.deltaTime;
            timerText.text = Mathf.Floor(countDown).ToString(); //���� �ð� text�� �����ֱ�

            //���� ����
            //�ð��� �������� ��ǥġ�� �����Ͽ� ������ ���
            if (score >= goal)
            {
                //���� �������� ��ư�� ��Ȱ��ȭ �Ǿ� �ִٸ�
                if (nextStage.activeSelf == false)
                {
                    //��� �޼��� ����
                    resultText.text = "Success!";
                    //���� ���� ���� true�� ����
                    isSuccess = true;
                }
            }
        }
        
    }

    //Ÿ�̸� set�ϴ� �Լ�
    public void SetTimer()
    {
        countDown = time;
    }
    //ī��Ʈ �ٿ� plus�ϴ� �Լ�
    public void PlusCountDown(int num)
    {
        countDown += num;
    }
    //ī��Ʈ �ٿ� minus�ϴ� �Լ�
    public void MinusCountDown(int num)
    {
        countDown -= num;
    }
}
