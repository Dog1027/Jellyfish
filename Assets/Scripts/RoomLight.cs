using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLight : MonoBehaviour {

    SpriteRenderer x;
    bool open;

	// Use this for initialization
	void Start () {
        x = gameObject.GetComponent<SpriteRenderer>();
        open = true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PressKey()
    {
        if (open)
        {
            StartCoroutine(TurnBlack());
            open = false;
        }
        else if (!open)
        {
            StartCoroutine(TurnWhite());
            open = true;
        }
    }

    IEnumerator TurnBlack()
    {
        for(float i = 1; i>=0f; i-=0.05f)
        {
            x.color = new Color(i, i, i);
            Debug.Log(x.color);
            yield return new WaitForSeconds(0.05f);
        }
        

    }

    IEnumerator TurnWhite()
    {
        for (float i = 0; i <= 1f; i += 0.05f)
        {
            x.color = new Color(i, i, i);
            Debug.Log(x.color);
            yield return new WaitForSeconds(0.05f);
        }


    }

}
