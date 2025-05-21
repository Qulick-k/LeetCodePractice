#
# @lc app=leetcode id=62 lang=python3
#
# [62] Unique Paths
#

# @lc code=start
class Solution:
    def uniquePaths(self, m: int, n: int) -> int:
        #使用二維DP，記得把題目的圖，往菱形方向看
        '''
        i = 0 或是 j = 0代表dp[i][j]維持1
        i > 0 且 j > 0，代表dp[i][j]要加上左方和上方的dp數值
        '''
        dp = [[0 for j in range(n + 1)] for i in range(m + 1)]

        for i in range(m):
            for j in range(n):
                if i == 0:
                    dp[i][j] = 1
                elif j == 0:
                    dp[i][j] = 1
                elif i > 0 and j > 0:
                    dp[i][j] = dp[i-1][j] + dp[i][j-1]
        return dp[m -1][n - 1]
# @lc code=end

