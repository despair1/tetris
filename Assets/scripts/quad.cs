using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class quad : MonoBehaviour
{
    public GameObject quad_prefab;
    private List<GameObject> quads = new List<GameObject>();
    private float time_between_shots=0.33f;
    private float timestep = 0;
    int xpos = -8;
    int ypos = 4;
    const int xsize = 8;
    const int y_start_pos = 4;
    private  int num_figure = 1;
    private figure.figure_desc fig;
    // Use this for initialization
    void Start()
    {
        /*for (int i = 0; i < 10; i++)
        {
            //Vector3 pos = new Vector3(i * 2 - 4, 2, 0);
            Vector3 pos = new Vector3((int)Random.Range(-4,4.9f), (int) Random.Range(-4,2.9f), 0);
            GameObject q = (GameObject) Instantiate(quad_prefab,pos,Quaternion.identity);
            quads.Add(q);
            
            
        }*/
        num_figure = figure.get_figure_num();
        inst_figure();
        //fig = figure.get_figure_desc(0);
        /*var b = a.get_pos();
        for (int rot = 0; rot < 6; rot++)
        {


            for (int i = 0; i < b.GetLength(0); i++)
            {
                Vector3 pos = new Vector3(xpos + b[i, 0] + rot * 5, ypos + b[i, 1], 0);
                GameObject q = (GameObject)Instantiate(quad_prefab, pos, Quaternion.identity);
                //quads.Add(q);
            }
            b = a.left();
            //b = a.rotate_left();

        }
        //b[0, 1] = -4;
        //a.test();
        */
    }

    void inst_figure()
    {
        fig = figure.get_figure_desc(0);
        var b = fig.get_pos();
        for (int i = 0; i < b.GetLength(0); i++)
        {
            Vector3 pos = new Vector3(xpos + b[i, 0], ypos + b[i, 1], 0);
            GameObject q = (GameObject)Instantiate(quad_prefab, pos, Quaternion.identity);
            quads.Add(q);
        }
    }
    void rotate(int dir) // 0 left
    {
        int[,] b;
        if (dir > 0) b=fig.right() ;
            else b=fig.left();

        for ( int i = 0; i < quads.Count; i++)
        {
            Vector3 pos = new Vector3(xpos + b[i, 0], ypos + b[i, 1], 0);
            quads[i].transform.position = pos;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ( Time.time>timestep)
        {
            if ( Input.GetButtonDown("rotate_left"))
            {
                rotate(0);
                timestep = Time.time + time_between_shots;
            }
            else if ( Input.GetButtonDown("rotate_right"))
            {
                rotate(1);
                timestep = Time.time + time_between_shots;
            }
        }

    }
}
