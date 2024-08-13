/*
 * @lc app=leetcode id=1493 lang=csharp
 *
 * [1493] Longest Subarray of 1's After Deleting One Element
 */

// @lc code=start
public class Solution {
    public int LongestSubarray(int[] nums)
    {
        /*
        給定一個二元陣列 nums，你可以刪除其中一個元素。返回最長僅包含 1 的非空子陣列的大小。如果不存在這樣的子陣列，返回 0。
        */
        //使用Slide Window，並且設置一個k=1，因為題目要我們一定要刪除一個元素
        //設一個左邊界值，還有k值。之後判斷迴圈內nums[i]要是等於0，k--。
        //接著判斷k如果小於0時，且nums[left]左邊界是否為0，是的話k++，left不管是不是都++
        //由於這解法邏輯上是把0翻1，然後繼續算所有1的長度，但其實題目要我們刪除1個元素
        //所以我們在陣列長度減掉左邊界長度時，還要再多刪除1
        //也就是Return nums.Length - left - 1;
        int left = 0;
        int k = 1;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 0)
            {
                k--;
            }
            if (k < 0 && nums[left++] == 0)
            {
                k++;
            }
        }
        return nums.Length - left - 1;
    }
}
// @lc code=end

