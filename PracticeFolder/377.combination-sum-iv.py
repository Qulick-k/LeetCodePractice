#
# @lc app=leetcode id=377 lang=python3
#
# [377] Combination Sum IV
#

# @lc code=start
class Solution:
    def combinationSum4(self, nums: List[int], target: int) -> int:
        #Use Up Button DP, SETUP A DP array [0] with length which is target + 1, then let the dp[1] gave a value 1
        #Creat a target'length 'For loop' range about 1 to target
        #Then, traversal all of nums'array' value(example: num). If i - num >= 0 r, then we can say there have a potential way that could be a sequences 
        #So let the dp[i] have a value which is dp[i] value + dp[i - num]
        # ie: nums = [1,2,3] target = 4 dp = [1,0,0,0,0]
        # Start from 1 ，dive in to second 'For loop' to traversal the nums'array, start for 1
        # if i - num >> if 1 - 1 >= 0, if true, then dp[1] = dp[1] + dp [0] the value will be dp[1] = 0 + 1, with this formula ,we can code dp[i] = dp[i] + dp[i - num] aka dp[i] += dp[i - num]
        #At result ,just return the dp[target]
        dp = [0] * (target + 1)
        dp [0] = 1

        for i in range(1, target + 1):
            for num in nums:
                if (i - num) >= 0:
                    dp[i] = dp[i] + dp[i-num]
        return dp[target]
                
# @lc code=end

