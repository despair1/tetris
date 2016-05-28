using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class quad :MonoBehaviour  {
    public GameObject quad_prefab;
    private List<GameObject> quads = new List<GameObject>();
	// Use this for initialization
	void Start () {
        for (int i = 0; i < 10; i++)
        {
            //Vector3 pos = new Vector3(i * 2 - 4, 2, 0);
            Vector3 pos = new Vector3((int)Random.Range(-4,4.9f), (int) Random.Range(-4,2.9f), 0);
            GameObject q = (GameObject) Instantiate(quad_prefab,pos,Quaternion.identity);
            quads.Add(q);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
