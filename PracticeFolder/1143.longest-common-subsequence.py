#
# @lc app=leetcode id=1143 lang=python3
#
# [1143] Longest Common Subsequence
#

# @lc code=start
class Solution:
    def longestCommonSubsequence(self, text1: str, text2: str) -> int:
        #使用多維DP
        #使用Bottom Up，由右下回算到左上的動態規劃
        #記得設置比text1、text2多長1個單位的陣列
        dp = [[0 for j in range(len(text2) + 1)] for i in range(len(text1) + 1)]

        for i in range(len(text1) - 1, -1, -1):
            for j in range(len(text2) -1, -1, -1):
                if(text1[i] == text2[j]):
                    dp[i][j] = 1 + dp[i+1][j+1] 
                    #再第一輪比較時，dp[i-1][j-1]
                    #一定會比較到比text1、text2多1單位。也是為何要把dp陣列長度多增加1的緣故
                else:
                    dp[i][j] = max(dp[i][j+1], dp[i+1][j])
        return dp[0][0]
#原理參考https://ics.uci.edu/~eppstein/161/960229.html
# @lc code=end

