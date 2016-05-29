using UnityEngine;
using System.Collections;

public class figure  {

	public class figure_desc
    {
        private  int[,] pos;
        private readonly int down_offset;
        private readonly int left_offset;
        public readonly int[][,] contact_points;
        //public figure_desc(int[,] pos1, int[] lb, int[] rb, int[][,] cp)  {
        public figure_desc(int[,] pos1)
        {
            pos = pos1;
            down_offset = get_down_offset();
            left_offset = get_left_offset();
            //left_bound = lb;
            //right_bound = rb;
            //contact_points = cp;
        }
        int get_down_offset()
        {
            int result = pos[0, 1];
            for (int i=0; i < pos.GetLength(0); i++)
            {
                var a = pos[i, 1];
                if (a < result) result = a;
            }
            //foreach ( int[] y in pos)
            return result ;
        }
        int get_left_offset()
        {
            int result = pos[0, 0];
            for (int i = 0; i < pos.GetLength(0); i++)
            {
                var a = pos[i, 0];
                if (a < result) result = a;
            }
            //foreach ( int[] y in pos)
            return result;
        }
        public void test()
        {
            for ( int i = 0; i < pos.GetLength(0); i++)
            {
                Debug.Log("y1 " + pos[i,1]);
            }
            
        }
        public int[,] get_pos() { return (int [,]) pos.Clone(); }
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
