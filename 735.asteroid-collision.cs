/*
 * @lc app=leetcode id=735 lang=csharp
 *
 * [735] Asteroid Collision
 */

// @lc code=start
public class Solution {
    public int[] AsteroidCollision(int[] asteroids)
    {
        //26% 50%
        //正數，只會往右走
        //正數由於只會往右走，所以要是左邊遇到負數的話，也沒關係，因為它只會往右看，所以直接push到stack沒關係

        //負數，只會往左走
        //負數往左走遇到正數，只要負數的絕對值比正數大，就把遇到的正數撞碎，取代位置，並且持續往左走，因此如果下一個位置又遇到正數，就會繼續比較絕對值。直到下一個位置的正數比它還大，或者是遇到相同方向的負數
        Stack<int> stack_A = new Stack<int>();
        for (int i = 0; i < asteroids.Length; i++)
        {
            //如果行星陣列[i]是負數，則進行判斷
            if (asteroids[i] < 0)
            {
                //如果sTack是空的，或者Stack.Peek()是負數，就直接push
                if (stack_A.Count ==0 || stack_A.Peek() < 0)
                {
                    stack_A.Push(asteroids[i]);
                }
                else
                {
                    //當Stack大於0，且Stack頂端大於0，且Stack頂端小於行星陣列[i]負數
                    //就一直pop，pop到Stack等於0，或者Stack頂端值小於等於0，或者Stack頂端值>[i]負數的絕對值
                    while (stack_A.Count > 0 && stack_A.Peek() > 0 && stack_A.Peek() < Math.Abs(asteroids[i]))
                    {
                        stack_A.Pop();
                    }
                    //如果行星陣列[i]負數的絕對值壓過左邊的正數，而下一個位置如果遇到同方向的負數，或是壓到Stack變成空的話，就負數[i]push到Stack
                    if(stack_A.Count == 0 || stack_A.Peek() < 0)
                    {
                        stack_A.Push(asteroids[i]);                        
                    }
                    //如果相等的話，就pop掉，基本上這邊會抓while迴圈判斷內的stack_A.Peek() < asteroids[i]，因為[i]負數的絕對值沒大於stack頂端值，就代表兩者相同。所以pop掉
                    else if(Math.Abs(asteroids[i]) == stack_A.Peek())
                    {
                        stack_A.Pop();
                    }                    
                }               
            }
            else //如果行星陣列[i]是正數，就直接push，反正撞不到任何行星
            {
                stack_A.Push(asteroids[i]);
            }
        }
        int[] ans = stack_A.ToArray();
        Array.Reverse(ans);
        return ans;
    }
}
// @lc code=end

