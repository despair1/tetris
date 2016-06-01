using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace tetris_utils
{
    public class figure
    {

        public class figure_desc
        {
            private int[,] pos;
            private int[,] bounds_offset;
            private int[,,] positions; // quad num/xy/rotation num
            private List<int[]>[] collision_points;
            private int rotation_num = 0;

            public figure_desc(int[,] pos1)
            {
                pos = pos1;
                positions = new int[pos1.GetLength(0), 2, 4];
                collision_points = new List<int[]>[4];
                set_rotation();
                set_offset_nd_upper();
                set_collision_points();
            }
            public List<int[]> get_contact_points()
            {
                return collision_points[rotation_num];
            }
            private void set_offset_nd_upper()
            {
                bounds_offset = new int[pos.GetLength(0), 2];
                for (int rot = 0; rot < 4; rot++)
                {
                    int down = 0;
                    int left = 0;
                    int right = 0;

                    for (int i = 0; i < pos.GetLength(0); i++)
                    {
                        if (down > positions[i, 1, rot]) down = positions[i, 1, rot];
                        if (left > positions[i, 0, rot]) left = positions[i, 0, rot];
                        if (right < positions[i, 0, rot]) right = positions[i, 0, rot];
                    }
                    bounds_offset[rot, 0] = left;
                    bounds_offset[rot, 1] = right;

                    for (int i = 0; i < pos.GetLength(0); i++)
                    {
                        positions[i, 1, rot] = positions[i, 1, rot] - down;
                    }
                }
            }
            private void set_collision_points()
            {
                for (int i = 0; i < 4; i++)
                {
                    contact_points c = new contact_points(get_pos());
                    collision_points[rotation_num] = c.get_cp() ;
                    rotation_num++;




                }
                rotation_num = 0;
            }
            public List<int[]> get_collisions()
            {
                return collision_points[rotation_num];
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
            public void left()
            {
                rotation_num++;
                if (rotation_num >= 4) rotation_num = 0;
                //turn get_pos();
            }
            public void right()
            {
                rotation_num--;
                if (rotation_num < 0) rotation_num = 3;
                //return get_pos();
            }
            public int[] bounds()
            {
                var b = new int[2];
                b[0] = bounds_offset[rotation_num, 0];
                b[1] = bounds_offset[rotation_num, 1];
                return b;
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
}