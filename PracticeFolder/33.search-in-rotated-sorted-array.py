#
# @lc app=leetcode id=33 lang=python3
#
# [33] Search in Rotated Sorted Array
#

# @lc code=start
from typing import List


class Solution:
    def search(self, nums: List[int], target: int) -> int:
        #使用二元搜尋法
        left = 0
        right = len(nums) - 1

        while left <= right:
            mid = left + (right - left) // 2

            if (nums[mid] == target):
                return mid
            #判斷該去左邊的升階子陣列找，還是右邊的升階子陣列找
            if (nums[left] <= nums[mid]):
                #如果target就在左邊子陣列，就把right索引，調到mid-1的位置
                if (nums[left] <= target and target < nums[mid]):
                    right = mid - 1
                else:
                    left = mid + 1
            else:
                #如果target就在右邊子陣列，就把left索引，調到mid+1的位置
                if (nums[mid] < target and target <= nums[right]):
                    left = mid + 1
                else:
                    right = mid - 1
        return -1

'''沒使用二元搜尋法 66% 39%
        for i in range(len(nums)):
            if target == nums[i]:
                return i
        return -1
'''
# @lc code=end

