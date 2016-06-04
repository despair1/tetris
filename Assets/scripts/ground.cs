using UnityEngine;
using System.Collections.Generic;

public class ground : MonoBehaviour {
    private int down_conner = -8;
    public quad q1;
    private int xsize;
    private GameObject[,] rows;
	// Use this for initialization
	void Start () {
        xsize = q1.xsize;
        rows = new GameObject[xsize * 2, (-down_conner) * 2];
	
	}
	public bool check_contack_point(int[] cp)
    {
        /*int[] cp = new int[2];
        cp[0] = contact_point[0];
        cp[1] = contact_point[1]-1;
        */
        if (cp[1] < down_conner) return true;
        return false;
    }

    public void figure2ground(int[,] fig_pos,int xpos, int ypos, List<GameObject> quads)
    {
        for(int i = 0; i < fig_pos.GetLength(0); i++)
        {
            rows[xpos + xsize + fig_pos[i, 0], ypos - down_conner + fig_pos[i, 1]] = quads[i];
        }
        quads.Clear();

    }
	
}
