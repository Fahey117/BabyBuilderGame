using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour {

    public float timer;
    float maxTime = 6f;
    Renderer myRend;

	// Use this for initialization
	void Start () {
        myRend = GetComponent<Renderer>();
	}

    // Update is called once per frame
    void Update()
    {
        if (transform.parent == null)
        {
            timer += 1 * Time.deltaTime;
        }
        else
        {
            timer = 0;
        }

        if (timer >= 3f)
        {
            myRend.material.color = Color.red;
        }
        if (timer >= maxTime)
        {
            Destroy(this.gameObject);
        }

        


    }
}
