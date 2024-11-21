#
# @lc app=leetcode id=55 lang=python3
#
# [55] Jump Game
#

# @lc code=start
class Solution:
    def canJump(self, nums: List[int]) -> bool:
        #使用一維DP
        dp = [1]
        for n in nums:
            dp.append(n)
        max_num = 0
        for i in range(len(nums)):
            if i > max_num: return False #[0,2,3] 會永遠卡在index 1，max_num必須永遠停留在1，所以當max_num維持在1的時候，如果i>max_num也就是(1)，那就回傳false
            cur = i + dp[i]
            max_num = max(cur, max_num)
        return max_num >= len(nums)
# @lc code=end

