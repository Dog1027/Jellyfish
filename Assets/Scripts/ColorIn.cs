using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorIn : MonoBehaviour {

    GameObject Parent;
    Color ParentColor;
    float factor = 0.3f;
	// Use this for initialization
	void Start () {
        Parent = gameObject.transform.parent.gameObject;
        Parent.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0.4f, 0.8f), Random.Range(0.4f, 0.8f), Random.Range(0.4f, 0.8f), 0.75f);
        ParentColor = Parent.GetComponent<SpriteRenderer>().color;
        gameObject.GetComponent<SpriteRenderer>().color = ColorChange(ParentColor);
    }
	
	// Update is called once per frame
	void Update () {
        
    }
    Color ColorChange(Color c)
    {
        Color c_after = c;
        float a = c.r + c.g + c.b;

        c_after.r = c.r + factor * c.r / a;//)>1? 1: (c.r + factor * c.r / a);
        c_after.g = c.g + factor * c.g / a;//)>1? 1: (c.g + factor * c.g / a);
        c_after.b = c.b + factor * c.b / a;//)>1? 1: (c.b + factor * c.b / a);
        return c_after;
    }
    
}
