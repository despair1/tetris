using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class quad :MonoBehaviour  {
    public GameObject quad_prefab;
    private List<GameObject> quads = new List<GameObject>();
    int xpos=-8;
    int ypos=4;
	// Use this for initialization
	void Start () {
        /*for (int i = 0; i < 10; i++)
        {
            //Vector3 pos = new Vector3(i * 2 - 4, 2, 0);
            Vector3 pos = new Vector3((int)Random.Range(-4,4.9f), (int) Random.Range(-4,2.9f), 0);
            GameObject q = (GameObject) Instantiate(quad_prefab,pos,Quaternion.identity);
            quads.Add(q);
            
            
        }*/
        var a = figure.get_figure_desc(1);
        var b = a.get_pos();
        for (int rot = 0; rot < 6; rot++)
        {
            

            for (int i = 0; i < b.GetLength(0); i++)
            {
                Vector3 pos = new Vector3(xpos + b[i, 0]+rot*5, ypos + b[i, 1], 0);
                GameObject q = (GameObject)Instantiate(quad_prefab, pos, Quaternion.identity);
                //quads.Add(q);
            }
            b = a.left();
            //b = a.rotate_left();
            
        }
        //b[0, 1] = -4;
        //a.test();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
