using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//상자(선물/쓰레기통) 생성하는 함수
public class GnrtBox : MonoBehaviour
{
    public GameObject present;
    public GameObject woodBox;

    float rate = 0.6f;

    void Start()
    {
        InvokeRepeating("GenerateBox", 3, Random.Range(3, 6));
    }

    void Update()
    {
        
    }

    //박스 생성 함수
    void GenerateBox()
    {
        if(Random.Range(0.0f, 1.0f) < rate) //present
        {
            GameObject obj = Instantiate(present);

            Vector3 randPos;
            randPos.x = Random.Range(-0.1f, 0.1f);
            randPos.y = 0.2f;
            randPos.z = -0.1f;

            obj.transform.position = transform.position + randPos;
            
            obj.GetComponent<MoveBox>().SetPosDir(obj.transform.position, 
                                                            Vector3.down);
            
            if(obj.transform.position.y <= 0)
            {
                Destroy(obj);
            }
        }
        else //wood box
        {
            GameObject obj = Instantiate(woodBox);

            Vector3 randPos;
            randPos.x = Random.Range(-0.1f, 0.1f);
            randPos.y = 0.2f;
            randPos.z = -0.1f;

            obj.transform.position = transform.position + randPos;

            obj.GetComponent<MoveBox>().SetPosDir(obj.transform.position,
                                                            Vector3.down);

            if (obj.transform.position.y <= 0)
            {
                Destroy(obj);
            }
        }
        
    }

}
