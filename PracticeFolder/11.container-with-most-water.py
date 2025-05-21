#
# @lc app=leetcode id=11 lang=python3
#
# [11] Container With Most Water
#

# @lc code=start
from typing import List
#使用two pointer

class Solution:
    def maxArea(self, height: List[int]) -> int:
        left = 0
        right = len(height) - 1

        container = 0

        while (left < right):
            #左邊高度比右邊高度低，就取左邊的高度
            if (height[left] < height[right]):
                container = max(container, height[left] * (right - left))
                left += 1
            #右邊高度比左邊高度低，就取右邊的高度
            elif (height[right] < height[left]):
                container = max(container, height[right] * (right - left))
                right -= 1
            #兩邊高度相同，就取左邊高度
            else:
                container = max(container, height[left] * (right - left))
                left +=1
        return container
# @lc code=end

