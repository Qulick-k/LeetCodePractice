/*
 * @lc app=leetcode id=547 lang=csharp
 *
 * [547] Number of Provinces
 */

// @lc code=start
public class Solution {
    public int FindCircleNum(int[][] isConnected)
    {
        //72% 82%
        //相連的城市，作為一個group
        int group = 0;

        //設置一個有沒有拜訪過的布林陣列
        bool[] visited = new bool[isConnected.Length];

        //開始拜訪每一個城市
        for (int i = 0; i < isConnected.Length; i++)
        {
            //如果當前城市沒拜訪過
            if (!visited[i])
            {
                //開始看這個城市有沒有跟其他城市連接
                DFS_TOOL(isConnected, i, visited);
                group++;  //group增加
            }
        }
        //回傳group數
        return group;
    }

    public void DFS_TOOL(int[][] Matrix, int current, bool[] Visited)
    {
        for (int j = 0; j < Matrix.Length; j++)
        {
            if (Matrix[current][j] == 1 && !Visited[j]) //當前城市有相連到j城市，並且如果i城市沒標記過
            {
                Visited[j] = true;           //那就標記為拜訪過
                DFS_TOOL(Matrix, j, Visited);   //並且繼續看看那個j城市還有沒有連到其他的城市
            }
        }
    }
}
// @lc code=end

/*
        //沒料的code
        int Cir_Length = isConnected.Length;
        
        Dictionary<int, List<int>> dic = new Dictionary<int, List<int>>();
        
        for (int i = 0; i < isConnected.Length; i++)
        {
            for (int j = 0; j < isConnected[i].Length; j++)
            {
                if (isConnected[i][j] == 1 && isConnected[j][i] == 1)
                {
                    if ( i == j )
                    {
                        continue;
                    }
                    if (dic.ContainsKey(i))
                    {
                        dic[i].Add(j);
                    }
                    else
                    {
                        var temp_list = new List<int>(j);
                        dic.Add(i, temp_list);
                    }
                }
            }
        }
        Console.WriteLine(dic.Count);
        return isConnected.Length - (isConnected.Length - dic.Count) ;
*/

//https://youtu.be/YrDYOqH65-E?si=5-fi_O54h_4kJDsP