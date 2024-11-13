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
'''
定義狀態：用一個數組 dp 來存儲解碼方式的數量，其中 dp[i] 表示字符串前 i 個字符的解碼方式數量。
初始化：dp[0] = 1 表示空字符串有一種解碼方式。dp[1] 取決於字符串的第一個字符，如果它不是 ‘0’，則 dp[1] = 1，否則 dp[1] = 0。
狀態轉移：
如果當前字符 s[i-1] 不是 ‘0’，則 dp[i] += dp[i-1]。
如果前一個字符和當前字符組成的兩位數在 10 到 26 之間，則 dp[i] += dp[i-2]。
返回結果：dp[n] 即為所求。

參考: https://youtu.be/OjEHST4SXfE?si=NUIr_yk489s7HW5B
'''
# @lc code=end

