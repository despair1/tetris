using UnityEngine;
using System.Collections;

public class ground : MonoBehaviour {
    private int down_conner = -6;
	// Use this for initialization
	void Start () {
	
	}
	public bool check_contack_point(int[] cp)
    {
        if (cp[1] < down_conner) return false;
        return false;
    }
	
}
