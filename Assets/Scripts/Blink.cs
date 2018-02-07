using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour { 
 
    
    Animator A1;
    // Use this for initialization
    void Start () {
        
        A1 = gameObject.GetComponent<Animator>();
        StartCoroutine(WaitthenBlink());
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        
    }

    IEnumerator WaitthenBlink()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(3,10));
            A1.SetTrigger("Blink");
        }
    }
}
