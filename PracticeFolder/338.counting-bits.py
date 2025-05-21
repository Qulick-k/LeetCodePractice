#
# @lc app=leetcode id=338 lang=python3
#
# [338] Counting Bits
#

# @lc code=start
from typing import List


class Solution:
    def countBits(self, n: int) -> List[int]:
        #練習&位元運算， 只是比191題多加了for迴圈和一個串列而已
        res = []

        for i in range(n + 1):
            count = 0
            while (i != 0):
                i = i & (i - 1)
                count += 1
            res.append(count)
        return res
# @lc code=end

