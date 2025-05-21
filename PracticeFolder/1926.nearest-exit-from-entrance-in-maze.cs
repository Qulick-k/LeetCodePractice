/*
 * @lc app=leetcode id=1926 lang=csharp
 *
 * [1926] Nearest Exit from Entrance in Maze
 */

// @lc code=start
public class Solution {
    public int NearestExit(char[][] maze, int[] entrance)
    {
        //graph / BFS
        ///以entrance = [1,2]為例
        //設置queue
        Queue<int[]> BFS_queue = new Queue<int[]>();

        //entrance起始點加進queue
        BFS_queue.Enqueue(entrance);

        //設置步數
        int step = 0;

        //設置已被標記的座標，也就是起始點
        maze[entrance[0]][entrance[1]] = '*';

        //設置上下左右的方向
        int[][] offsets = new int[][]
        {
            new int[] { -1, 0 }, new int[] { 1, 0 }, //上，下
            new int[] { 0, -1 }, new int[] { 0, 1 }  //左，右
        };

        //當Queue.Count不為0時，進入while
        while(BFS_queue.Count > 0)
        {
            //每一輪，步數+1
            step++;
            //紀錄queue的長度
            int queue_Count = BFS_queue.Count;
            
            //進for迴圈，把Queue的數值Dequeue出來給thisPoint
            for(int num = 0; num < queue_Count; num++)
            {
                //thisPoint就是目前站的點
                int[] thisPoint = BFS_queue.Dequeue();
                int row = thisPoint[0]; //row拿1
                int col = thisPoint[1]; //col拿2

                //在thisPoint，利用for迴圈掃描4個方向
                for(int i = 0; i < offsets.Length; i++)
                {
                    //當前的點加上offsets，就等於新的row和col點
                    int newRow = row + offsets[i][0];
                    int newCol = col + offsets[i][1];

                    //如果新的row點和col點，還待在maze邊界內，並且是可以走的話'.'
                    if( newRow >= 0 && newRow < maze.Length && 
                        newCol >= 0 && newCol < maze[newRow].Length && maze[newRow][newCol] == '.')
                    {
                        //如果新的row點或col點就處在邊界，也就是說，新的row點或col點是出口，就回傳步數
                        if( newRow == 0 || newRow == maze.Length-1 ||
                            newCol == 0 || newCol == maze[newRow].Length-1)
                        {
                            return step;
                        }

                        //如果新的row點和col點待在邊界內，但不是出口，就標記為'*'
                        maze[newRow][newCol] = '*';
                        //把新的row點和col點座標，放進Queue，之後作下一輪的起始點
                        BFS_queue.Enqueue(new int[] {newRow, newCol});
                    }
                }
            }
        }

        //跑完判斷不出來，代表沒出口，回傳-1
        return -1;
    }
}
// @lc code=end

/*蓋牌重打
        //蓋牌重打
        Queue<int[]> BFS_Queue = new Queue<int[]>();
        int step = 0;
        int[][] offsets = new int[][]
        { 
            new int[] { -1, 0 }, new int[] { 1, 0 },
            new int[] { 0, -1 }, new int[] { 0, 1 } 
        };

        BFS_Queue.Enqueue(entrance);
        maze[entrance[0]][entrance[1]] = '*';

        while(BFS_Queue.Count > 0)
        {
            step++;
            int Queue_Count = BFS_Queue.Count;
            //進for迴圈，把Queue的數值Dequeue出來給thisPoint
            for(int num = 0; num < Queue_Count; num++)
            {
                int[] thisPoint = BFS_Queue.Dequeue();
                int row = thisPoint[0];
                int col = thisPoint[1];

                for(int i = 0; i < offsets.Length; i++)
                {
                    int newRow = row + offsets[i][0];
                    int newCol = col + offsets[i][1];

                    if( newRow >= 0 && newRow < maze.Length &&
                        newCol >= 0 && newCol < maze[newRow].Length &&
                        maze[newRow][newCol] == '.' )
                    {
                        if( newRow == 0 || newRow == maze.Length-1 ||
                            newCol == 0 || newCol == maze[newRow].Length-1)
                        {
                            return step;
                        }

                        maze[newRow][newCol] = '*';
                        BFS_Queue.Enqueue( new int[] { newRow, newCol});
                    }
                }
            }
        }
        return -1;
*/