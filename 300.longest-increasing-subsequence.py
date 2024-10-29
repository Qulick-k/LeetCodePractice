#
# @lc app=leetcode id=300 lang=python3
#
# [300] Longest Increasing Subsequence
#

# @lc code=start
from typing import List


class Solution:
    def lengthOfLIS(self, nums: List[int]) -> int:
        #練習DP N^2，爛方法
        cur_list = [1] * len(nums)

        for i in range(len(nums) -1, -1, -1):
            for j in range(i + 1, len(nums)):
                if nums[j] > nums[i]:
                    cur_list[i] = max(cur_list[i], 1 + cur_list[j])
        return max(cur_list)
#https://youtu.be/cjWnW0hdF1Y?si=-Atebvg-23lT3lTy
# @lc code=end

