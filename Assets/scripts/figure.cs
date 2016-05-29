using UnityEngine;
using System.Collections;

public class figure  {

	public class figure_desc
    {
        private  int[,] pos;
        public readonly int[] left_bound;
        public readonly int[] right_bound;
        public readonly int[][,] contact_points;
        //public figure_desc(int[,] pos1, int[] lb, int[] rb, int[][,] cp)  {
        public figure_desc(int[,] pos1)
        {
            pos = pos1;
            //left_bound = lb;
            //right_bound = rb;
            //contact_points = cp;
        }
        int get_down_offset()
        {
            //foreach ( int[] y in pos)
            return 1;
        }
        public void test()
        {
            for ( int i = 0; i < pos.GetLength(0); i++)
            {
                Debug.Log("y " + pos[i,1]);
            }
            
        }
    }
    public static figure_desc get_figure_desc(int num)
    {
        //figure_desc a= new figure_desc();

        if ( true)
        {
            //a = new figure_desc[1];
            int[,] pos2 = new int[,] { { 0, 0 }, { 0, 1 }, { 0, 2 } };
            var a = new figure_desc(pos2);
            return a;
        }
        //return a;
    }
}
