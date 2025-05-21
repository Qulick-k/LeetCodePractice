/*
 * @lc app=leetcode id=994 lang=csharp
 *
 * [994] Rotting Oranges
 */

// @lc code=start
public class Solution {
    public int OrangesRotting(int[][] grid)
    {
        //Graph / BFS 78% 78%
        ///設置Queue、新鮮橘子數、花了幾分鐘、和上下左右的方向
        Queue<int[]> BFS_Queue = new Queue<int[]>();
        int freshOrange = 0;
        int Minute = 0;
        int[][] offsets = new int[][]
            { new int[] { -1, 0 }, new int[] { 1, 0 },
              new int[] { 0, -1 }, new int[] { 0, 1 }
            };
        
        ///找出所有新鮮橘子的數量，還有找出腐爛的橘子在哪個位置，把腐爛橘子放進Queue裡面
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j] == 1)
                {
                    freshOrange++;
                }
                else if (grid[i][j] == 2)
                {
                    BFS_Queue.Enqueue(new int[] { i, j });
                }
            }
        }

        ///當Queue不為空，並且新鮮橘子大於0
        while (BFS_Queue.Count > 0 && freshOrange > 0)
        {
            ///紀錄Queue的長度
            int Queue_count = BFS_Queue.Count;
            
            //把Queue存起來的座標，提出來分成為"列row"和"行col"
            for (int num = 0; num < Queue_count; num++)
            {
                int[] CurrentPoint = BFS_Queue.Dequeue();
                int row = CurrentPoint[0];
                int col = CurrentPoint[1];

                //把座標新增上下左右，變成"新座標"
                for (int i = 0; i < offsets.Length; i++)
                {
                    int newRow = row + offsets[i][0];
                    int newCol = col + offsets[i][1];

                    //當新座標超出邊界，或是座標不是新鮮橘子的位置，叫跳過本輪迴圈
                    if ( newRow < 0 || newRow >= grid.Length ||
                         newCol < 0 || newCol >= grid[newRow].Length || grid[newRow][newCol] != 1)
                    {
                        continue;        
                    }

                    //找到新鮮橘子的話，就把它變腐爛，接著把變腐爛的橘子座標放進Queue內，最後把新鮮橘子的數量-1
                    grid[newRow][newCol] = 2;
                    BFS_Queue.Enqueue(new int[] { newRow, newCol });
                    freshOrange--;
                }
            }
            //跑完一整輪Queue迴圈，就把分鐘+1
            Minute ++;
        }
        
        //BFS跑完後，如果還有其他新鮮橘子，回傳-1。
        //否則回傳"花了幾分鐘"腐爛新鮮橘子
        if (freshOrange > 0)
        {
            return -1;
        }
        else
        {
            return Minute;
        }
    }
}
// @lc code=end

