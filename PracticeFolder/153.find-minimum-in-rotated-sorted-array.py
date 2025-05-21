#
# @lc app=leetcode id=153 lang=python3
#
# [153] Find Minimum in Rotated Sorted Array
#

# @lc code=start
from typing import List


class Solution:
    def findMin(self, nums: List[int]) -> int:
        #使用Two pointer或是二元搜尋法
        left = 0
        right = len(nums) - 1
        res = nums[0]

        #在升階陣列中，翻轉時一定會有一個pivot點，會比左邊的數值還有小，只要找到這個pivot點就是解答
        while left <= right:
            if(nums[left] < nums[right]):
                res = min(res, nums[left])
                break

            mid = (left + right) // 2
            res = min(res, nums[mid])
            if nums[mid] >= nums[left]:
                left = mid + 1
            else:
                right = mid - 1
        return res
'''87% 52%
        left = 0
        right = 1
        res = nums[0]

        #在升階陣列中，翻轉時一定會有一個pivot點，會比左邊的數值還有小，只要找到這個pivot點就是解答
        while right < len(nums):
            if(nums[left] > nums[right]):
                res = nums[right]
                break
            left += 1
            right += 1
        return res
'''
# @lc code=end

