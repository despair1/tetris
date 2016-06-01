using UnityEngine;
using System.Collections.Generic;
namespace tetris_utils
{
    public class contact_points
    {
        Dictionary<int, int> dick;
        public contact_points(int[,] pos)
        {
            dick = new Dictionary<int, int>();
            for (int i = 0; i < pos.GetLength(0); i++)
            {
                int x = pos[i, 0];
                int y = pos[i, 1];
                if (dick.ContainsKey(pos[i, 0]))
                {
                    if (dick[x] > pos[i, 1])
                    {
                        dick[x] = pos[i, 1];
                    }
                }
                else dick.Add(x, y);
            }
        }
        public List<int[]> get_cp()
        {
            //int[,] result = new int[dick.Count, 2];
            List<int[]> result=new List<int[]>();
            //int i = 0;
            foreach (var pair in dick)
            {
                int[] v = new int[2];
                v[0] = pair.Key;
                v[1] = pair.Value;
                result.Add(v);
            }
            return result;
        }

    }
}