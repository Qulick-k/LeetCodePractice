#
# @lc app=leetcode id=91 lang=python3
#
# [91] Decode Ways
#

# @lc code=start
class Solution:
    def numDecodings(self, s: str) -> int:
        #Use DP
        n = len(s)
        dp = [0] * (n + 1)
        dp[0] = 1
        #dp[1] 取決於字符串的第一個字符，如果它不是 ‘0’，則 dp[1] = 1，否則 dp[1] = 0。
        dp[1] = 1 if s[0] != '0' else 0
        
        for i in range(2, n + 1):
            #如果當前字符非'0'
            if s[i-1] != '0':
                dp[i] += dp[i - 1]
            #如果前一個字符和當前字符組成的兩位數在10~26之間
            if 10 <= int(s[i-2 : i]) <= 26:
                dp[i] += dp[i - 2]
        
        return dp[n]

# @lc code=end

