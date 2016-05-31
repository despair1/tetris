using UnityEngine;
using System.Collections;

public class figure
{

    public class figure_desc
    {
        private int[,] pos;
        private int[,,] positions; // quad num/xy/rotation num
        private int rotation_num = 0;
        private readonly int down_offset;
        private readonly int left_offset;
        public readonly int[][,] contact_points;
        //public figure_desc(int[,] pos1, int[] lb, int[] rb, int[][,] cp)  {
        public figure_desc(int[,] pos1)
        {
            pos = pos1;
            positions = new int[pos1.GetLength(0), 2, 4];
            set_rotation();
            for (int rot = 0; rot < 4; rot++)
            {

            }
            down_offset = get_down_offset();
            left_offset = get_left_offset();
            //left_bound = lb;
            //right_bound = rb;
            //contact_points = cp;
        }
        int get_down_offset()
        {
            int result = pos[0, 1];
            for (int i = 0; i < pos.GetLength(0); i++)
            {
                var a = pos[i, 1];
                if (a < result) result = a;
            }
            //foreach ( int[] y in pos)
            return result;
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
            for (int i = 0; i < pos.GetLength(0); i++)
            {
                Debug.Log("y1 " + pos[i, 1]);
            }

        }
        public int[,] get_pos()
        {
            var result = new int[pos.GetLength(0), 2];
            for (int i = 0; i < pos.GetLength(0); i++)
            {
                result[i, 0] = positions[i, 0, rotation_num];
                result[i, 1] = positions[i, 1, rotation_num];

            }
            return result;
        }
        public int[,] left()
        {
            rotation_num++;
            if (rotation_num >= 4) rotation_num = 0;
            return get_pos();
        }
        private void set_rotation()
        {

            for (int rot = 0; rot < 4; rot++)
            {
                var result = new int[pos.GetLength(0), 2];
                for (int i = 0; i < pos.GetLength(0); i++)
                {
                    result[i, 0] = -pos[i, 1];
                    result[i, 1] = pos[i, 0];
                }

                for (int i = 0; i < pos.GetLength(0); i++)
                {
                    positions[i, 0, rot] = pos[i, 0];
                    positions[i, 1, rot] = pos[i, 1];
                }
                pos = result;
            }
            //return result;
        }
    }
    public static figure_desc get_figure_desc(int num)
    {
        //figure_desc a= new figure_desc();

        if (true)
        {
            //a = new figure_desc[1];
            int[,] pos2 = new int[,] { { 0, 0 }, { 0, 1 }, { 0, 2 }, { 1, 0 } };
            var a = new figure_desc(pos2);
            return a;
        }
        //return a;
    }
    public static int get_figure_num()
    {
        return 1;
    }
}
