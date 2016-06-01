﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using tetris_utils;

public class quad : MonoBehaviour
{
    /*private class quad_links
    {
        GameObject go;
        int xoffset;
        int yoffset;
    }*/
    public GameObject quad_prefab;
    public ground ground_ref;
    private List<GameObject> quads = new List<GameObject>();
    private float time_between_shots=0.33f;
    private float timestep = 0;
    int xpos = 0;
    int ypos = 4;
    const int xsize = 6;
    const int y_start_pos = 4;
    private  int num_figure = 1;
    private figure.figure_desc fig;
    private float wait_time = 0.5f;
    // Use this for initialization
    void Start()
    {
        num_figure = figure.get_figure_num();
        inst_figure();
    }
    IEnumerator move_down()
    {
        while (true)
        {
            yield return new WaitForSeconds(wait_time);
            ypos--;
            move_quads();
        }
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
        StartCoroutine(move_down());
    }
    void rotate(int dir) // 0 left
    {
        //int[,] b;
        if (dir > 0) fig.right() ;
            else fig.left();
        move_quads();
        
    }
    void move(int dir) // 0 left
    {
        
        if (dir > 0)
        {
            xpos++;
        }
        else xpos--;
        
        move_quads();
    }
    void move_quads()
    {
        int[] bo = fig.bounds();
        var b = fig.get_pos();
        if (xpos + bo[0] < -xsize) xpos = -xsize - bo[0];
        if (xpos + bo[1] > xsize) xpos = xsize - bo[1];
        for (int i = 0; i < quads.Count; i++)
        {
            Vector3 pos = new Vector3(xpos + b[i, 0], ypos + b[i, 1], 0);
            quads[i].transform.position = pos;
        }
    }

    bool check_pos()
    {
        if (ypos <= -6) return false;
        return true;
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
            else if (Input.GetButtonDown("left_move"))
            {
                move(0);
                timestep = Time.time + time_between_shots;
            }
            else if (Input.GetButtonDown("right_move"))
            {
                move(1);
                timestep = Time.time + time_between_shots;
            }
        }

    }
}
