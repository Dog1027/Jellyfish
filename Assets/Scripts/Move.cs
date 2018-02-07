using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour 
{

    public static bool MoveAnim, b_Blink;
    public float Auser = 0.6f;
    public float Speed = 0.4f;
    public int floattime = 12;
    Rigidbody2D R1;
    Transform T1;
    Animator A1;
    public float V1, time0, time1, degree1, degree2;
    int RSecond;
    float minSpeedtime = 0.5f * Mathf.PI;
    


    // Use this for initialization
    void Start () {
        
        R1 = gameObject.GetComponent<Rigidbody2D>();
        A1 = gameObject.GetComponent<Animator>();
        T1 = gameObject.transform;
        degree1 = transform.eulerAngles.z + 90f;

        time0 = time1 = 0;
        A1.SetTrigger("Move");
        V1 = Speed * (1 + Mathf.Sin(0.2f * Mathf.PI));//初始速度
        degree2 = Random.Range(-Auser, Auser);//初始隨機角度
        RSecond = Random.Range(1, floattime);
        b_Blink = true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void FixedUpdate()
    {
        

        if ((time0-time1) > RSecond)//重新衝刺
        {
            time0 = 0;
            A1.SetTrigger("Move");
            degree2 = degree(degree2);

            RSecond = Random.Range(1, floattime);
        }
        walk();
        

    }
    float degree(float lastdegree)
    {

        if (lastdegree > 0)
        {
            return Random.Range(-Auser/4, Auser);
        }
        else if (lastdegree < 0)
        {
            return Random.Range(-Auser, Auser/4);
        }
        else
        {
            return Random.Range(-Auser, Auser);
        }


    }

    void walk()
    {
        degree1 = transform.eulerAngles.z + 90f;

        if (time0 <= 0.5f * Mathf.PI)//隨時間改變速度
        {
            time1 = time0;
            degree1 += (degree2 * V1);//改變小角度
            SpeedState(time1);
            
        }
        
        if (time0 > 0.5f * Mathf.PI)//維持速度
        {
            //SpeedState(time1);
        }
        time0 += Time.deltaTime;//計時
    }


    void SpeedState(float time)//更新速度
    {
        V1 = Speed * (1 + Mathf.Sin(2 * time + 0.2f * Mathf.PI));//速度函數
        
        R1.velocity = new Vector2(Mathf.Cos(degree1 * Mathf.Deg2Rad), Mathf.Sin(degree1 * Mathf.Deg2Rad)) * V1;//移動方向轉彎
        T1.eulerAngles = new Vector3(0, 0, degree1-90f);//圖形方向轉彎
        //T1.Rotate(Vector3.forward * degree2 * V1);

    }

    


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Wall1")
        {
            degree1 = transform.eulerAngles.z + 90f;
            degree1 = 180f - degree1;
            SpeedState(time1);

            //degree2 = 2 * degree1 -180f;
        }
        if (other.tag == "Wall2")
        {
            degree1 = transform.eulerAngles.z + 90f;
            degree1 = -degree1;
            SpeedState(time1);
            //degree2 = 2 * degree1;
        }
        
    }


}
