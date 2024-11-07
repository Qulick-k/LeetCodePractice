#
# @lc app=leetcode id=139 lang=python3
#
# [139] Word Break
#

# @lc code=start
from typing import List


class Solution:
    def wordBreak(self, s: str, wordDict: List[str]) -> bool:
        #Use Button Up DP
        dp = [False] * (len(s) + 1)
        dp[len(s)] = True

        for i in range(len(s) -1, -1, -1):
            for w in wordDict:
                if (i + len(w)) <= len(s) and s[i : i + len(w)] == w:
                    dp[i] = dp[i + len(w)]
                if dp[i] == True:
                    break
        return dp[0]
'''
分切後的字串必須要WordDict內有出現，才可以回傳True
i+長度w 沒超過長度s字串，並且字串s的從第i到i第+(i+長度w)的字串跟w相同
那就把底層dp[i+len(w)]的布林值，交付給上層的dp[i]
如果dp[i]已經是True了，跳出wordDict的for迴圈
'''
#參考https://youtu.be/Sx9NNgInc3A?si=UtSDsFW-q7GTwRZr
# @lc code=end

