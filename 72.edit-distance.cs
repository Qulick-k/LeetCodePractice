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
        //設置DP陣列，長度各多1個單位放置比較後的值
        int[, ] dp = new int[word1.Length + 1, word2.Length + 1];
        
        //dp陣列的dp[i, 0]從0排到word1的長度
        for (int i = 0; i <= word1.Length; i++)
        {
            dp[i, 0] = i;
        }
        //dp陣列的dp[0, j]從0排到word2的長度
        for (int j = 0; j <= word2.Length; j++)
        {
            dp[0, j] = j;
        }

        //拜訪陣列
        for ( int i = 1; i <= word1.Length; i++)
        {
            
            for (int j = 1; j <= word2.Length; j++)
            {
                //當dp在[i, j]時，查看左上方的[word1[i-1], word2[j-1]]是否相同，相同的話代表不用+1。直接把d[i-1, j-1]的數值傳給dp[i, j]
                if (word1[i-1] == word2[j-1])
                {
                    dp[i, j] = dp[i-1, j-1];
                }
                else
                {
                    //否則的話，查看dp[i, j]的左方、左上方、上方的數值，誰最小，取得三者中最小值後，再+1，表示刪除、新增、取代的步驟
                    dp[i, j] = 1 + Math.Min(Math.Min(dp[i-1, j], dp[i, j-1]), dp[i-1, j-1]);
                }
                
            }
        }
        Console.WriteLine("有跑到這裡");
        //回傳dp陣列右下角的數值
        return dp[word1.Length , word2.Length];
    }
}
// @lc code=end

/*萊文斯坦距離 維基百科
https://zh.wikipedia.org/wiki/%E8%90%8A%E6%96%87%E6%96%AF%E5%9D%A6%E8%B7%9D%E9%9B%A2
https://youtu.be/lCkIPGlP6Mc?si=o4CIYgmNLuZOzsn7
*/