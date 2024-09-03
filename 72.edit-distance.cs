/*
 * @lc app=leetcode id=72 lang=csharp
 *
 * [72] Edit Distance
 */

// @lc code=start
public class Solution {
    public int MinDistance(string word1, string word2)
    {
        //使用多維動態規劃，此題為萊文斯坦距離
        int[, ] dp = new int[word1.Length + 1, word2.Length + 1];
        int cost = 0;

        
        for (int i = 0; i <= word1.Length; i++)
        {
            dp[i, 0] = i;
        }
        for (int j = 0; j <= word2.Length; j++)
        {
            dp[0, j] = j;
        }

        for ( int i = 1; i <= word1.Length; i++)
        {
            
            for (int j = 1; j <= word2.Length; j++)
            {
                
                if (word1[i-1] == word2[j-1])
                {
                    dp[i, j] = dp[i-1, j-1];
                }
                else
                {
                    
                    dp[i, j] = 1 + Math.Min(Math.Min(dp[i-1, j], dp[i, j-1]), dp[i-1, j-1]);
                }
                
            }
        }
        Console.WriteLine("有跑到這裡");
        return dp[word1.Length , word2.Length];
    }
}
// @lc code=end

/*萊文斯坦距離 維基百科
https://zh.wikipedia.org/wiki/%E8%90%8A%E6%96%87%E6%96%AF%E5%9D%A6%E8%B7%9D%E9%9B%A2
*/