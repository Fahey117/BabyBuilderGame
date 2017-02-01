using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawn : MonoBehaviour {

    public GameObject[] objectPool;
    public float timer;
    float maxTime;
    int index;
	// Use this for initialization
	void Start () {
        maxTime = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
        timer += 1 * Time.deltaTime;
        if(timer >= maxTime)
        {
            GameObject objectClone = Instantiate(objectPool[index], transform.position, transform.rotation);
            timer = 0;
            maxTime = Random.Range(1f, 2f);
            index = Random.Range(0, objectPool.Length);
        }
	}
}
