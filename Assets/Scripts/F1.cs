using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class F1 : MonoBehaviour
{

    // Use this for initialization
    public float Vuser = 0.3f;
    public float Auser = 0.3f;
    public GameObject WL, WR, WU, WD, Room;
    public float D2;
    float time0, time1, rmode, V1, D1, D3;
    bool out1;
    Vector2 i;
    Rigidbody2D R1;
    Transform T1;
    private Animator A1;

    

    void Start()
    {
        R1 = gameObject.GetComponent<Rigidbody2D>();
        A1 = gameObject.GetComponent<Animator>();
        T1 = gameObject.transform;

        time0 = 0f;
        time1 = 1.1f;
        rmode = 0;
        out1 = false;
        D1 = 90;//初始角度
        T1.Rotate(Vector3.forward * D1);
        D2 = transform.rotation.z + 90f;
        D1 = Random.Range(-Auser, Auser);
        A1.SetBool("Go", true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        walk();
        D2 = transform.rotation.z + 90f;


    }
    /*
    public void onBun()
    {
        walk();

    }
    */
    void walk()
    {
        if (time0 <= 0.5f * Mathf.PI)//前進0.5PI秒
        {
            time0 += Time.deltaTime;
            V1 = Vuser * (1 + Mathf.Sin(2 * time0 + 0.2f * Mathf.PI));//速度函數
            R1.velocity = new Vector2(Mathf.Cos(D2 * Mathf.Deg2Rad), Mathf.Sin(D2 * Mathf.Deg2Rad)) * V1;//移動方向轉彎

            
            T1.Rotate(Vector3.forward * D1* V1);
            D2 = transform.rotation.z + 90f;
            if (time0>1.2)
                A1.SetBool("Go", false);
        }
        else
        {

            if (time1 <= 1f)//漂流一秒
            {
                time1 += Time.deltaTime;
                R1.velocity = new Vector2(V1 * Mathf.Cos(D2 / 180f * Mathf.PI), V1 * Mathf.Sin(D2 / 180f * Mathf.PI));
            }
            else
            {
                
                out1 = false;
                rmode = Random.Range(-0.4f, 1f);
                
                if (rmode <= 0)
                {
                    time0 = 0f;
                    
                    if (D1 > 0)
                    {
                        D1 = Random.Range(-Auser / 3, Auser);//提高跟上一次旋轉方向一樣的機率
                    }
                    else if (D1 < 0)
                    {
                        D1 = Random.Range(-Auser, Auser / 3);
                    }else
                    {
                        D1 = Random.Range(-Auser, Auser);
                    }
                    A1.SetBool("Go", true);

                }
                else
                {
                    time1 = 0f;
                    
                }
                Debug.Log(Time.time);
                
            }




        }

        //this.transform.position += new Vector3(0, 1.0f, 0);
        /*
        for (float i = 0f; i <= 5; i += Time.deltaTime)
        {
            Debug.Log(i);
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, Mathf.Sin(i+0.3f*Mathf.PI));
        }
        */
        //this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 5);
        //StartCoroutine(Example());

    }

    /*IEnumerator Example()
    {
        print(Time.time);
        yield return new WaitForSeconds(5);
        print(Time.time);
        this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -10));
        yield return new WaitForSeconds(5);
        this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -10));
    }
    */

    void OnTriggerStay2D(Collider2D other)
    {


        if (other == WL.GetComponent<Collider2D>() || other == WR.GetComponent<Collider2D>())
        {
            /*
            out1 = true;
            time0 = 0f;
            time1 = 1.1f;
            rmode = 0;
            if ((D2 % 360f >= 180f && D2 % 360f < 360f) || (D2 % 360f >= -180f && D2 % 360f < 0f))
                D1 = 3f;
            if ((D2 % 360f < 180f && D2 % 360f >= 0f) || (D2 % 360f < -180f && D2 % 360f >= -360f))
                D1 = -3f;
            */
            D2 = 180f - D2;
            T1.Rotate(Vector3.forward * (2f * D2 - 180f));
        }
        /*
        if (other == WR.GetComponent<Collider2D>())
        {
            out1 = true;
            time0 = 0f;
            time1 = 1.1f;
            rmode = 0;

            if ((D2 % 360f >= 180f && D2 % 360f < 360f) || (D2 % 360f >= -180f && D2 % 360f < 0f))
                D1 = -3f;
            if ((D2 % 360f < 180f && D2 % 360f >= 0f) || (D2 % 360f < -180f && D2 % 360f >= -360f))
                D1 = 3f;

        }
        */
        if (other == WU.GetComponent<Collider2D>() || other == WD.GetComponent<Collider2D>())
        {
            D2 = -D2;
            T1.Rotate(Vector3.forward * 2 * D2);
            /*
            out1 = true;
            time0 = 0f;
            time1 = 1.1f;
            rmode = 0;
            if ((D2 % 360f >= 90f && D2 % 360f < 270f) || (D2 % 360f >= -270f && D2 % 360f < -90f))
                D1 = 3f;
            if ((D2 % 360f < 90f && D2 % 360f >= 270f) || (D2 % 360f < -270f && D2 % 360f >= -90f))
                D1 = -3f;
            */
        }
        /*
        if (other == WD.GetComponent<Collider2D>())
        {
            out1 = true;
            time0 = 0f;
            time1 = 1.1f;
            rmode = 0;
            if ((D2 % 360f >= 90f && D2 % 360f < 270f) || (D2 % 360f >= -270f && D2 % 360f < -90f))
                D1 = -3f;
            if ((D2 % 360f < 90f && D2 % 360f >= 270f) || (D2 % 360f < -270f && D2 % 360f >= -90f))
                D1 = 3f;

        }
        */

        if (other == Room.GetComponent<Collider2D>())
        {


            Debug.Log(out1);
        }
    }
    /*
    void OnTriggerExit2D(Collider2D other)
    {
        if (other == WL.GetComponent<Collider2D>())
        {
            out1 = false;
            D1 = 0;
        }
        if (other == WR.GetComponent<Collider2D>())
        {
            out1 = false;
            D1 = 0;
            Debug.Log(out1);
        }
        if (other == WU.GetComponent<Collider2D>())
        {
            out1 = false;
            D1 = 0;
        }
        if (other == WD.GetComponent<Collider2D>())
        {
            out1 = false;
            D1 = 0;
        }
    }
    */
}