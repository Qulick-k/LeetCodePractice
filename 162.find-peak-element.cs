/*
 * @lc app=leetcode id=162 lang=csharp
 *
 * [162] Find Peak Element
 */

// @lc code=start
public class Solution {
    public int FindPeakElement(int[] nums)
    {
        //使用Binary Search

        int left = 0;
        int right = nums.Length - 1;

        //找到一個mid使得，去做與mid相鄰的判斷
        //如果[mid]比[mid+1]大，就繼續往左找，right = mid
        //如果[mid+1]比[mid]大，就繼續往右找，left = mid
        while (left+1 < right)
        {
            int mid = left + (right - left) / 2;

            if ( nums[mid] > nums[mid+1])
            {
                right = mid;
            }
            else
            {
                left = mid;
            }
        }
        //能跳出迴圈，代表left跟right符合相鄰
        //如果[left]比[right]大，代表[left]是peek，回傳left
        //如果[right]比[left]大，代表[right]是peel，回傳right
        if (nums[left] > nums[right])
        {
            return left;
        }
        else
        {
            return right;
        }
  
    }
}
// @lc code=end

