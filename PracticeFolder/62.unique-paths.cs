/*
 * @lc app=leetcode id=62 lang=csharp
 *
 * [62] Unique Paths
 */

// @lc code=start
public class Solution {
    public int UniquePaths(int m, int n)
    {
        //使用多維動態規劃
        
        int[,] dp = new int[m, n];

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i == 0)
                {
                    dp[i, j] = 1;
                }
                if (j == 0)
                {
                    dp[i, j] = 1;
                }

                if ( i > 0 && j > 0 )
                {
                    dp[i, j] = dp[i-1, j] + dp[i, j-1];
                }
            }
        }
        return dp[m-1, n-1];
    }
}
// @lc code=end

