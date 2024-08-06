/*
 * @lc app=leetcode id=334 lang=csharp
 *
 * [334] Increasing Triplet Subsequence
 */

// @lc code=start
/*
給定一個整數陣列 nums，如果存在三個索引 i < j < k(可連續也可非連續)，使得 nums[i] < nums[j] < nums[k]，則返回 true；否則返回 false。

範例 1：
輸入：nums = [1,2,3,4,5]
輸出：true
解釋：任何 i < j < k 的三元組都是有效的。

範例 2：
輸入：nums = [5,4,3,2,1]
輸出：false
解釋：不存在符合條件的三元組。

範例 3：
輸入：nums = [2,1,5,0,4,6]
輸出：true
解釋：三元組 (3, 4, 5) 是有效的，因為 nums[3] == 0 < nums[4] == 4 < nums[5] == 6。
*/
public class Solution {
    public bool IncreasingTriplet(int[] nums)
    {
        /*
        使用Greedy中的兩個整數【最小值】和【第二小值】只是用來尋找遞增情況下比較小的數字，不代表【最小值】和【第二小值】跑完迴圈十，內涵的數值就是True條件內的陣列數值，像是[20,100,10,12,5,13]，True的陣列數值為[10,12,13]，但是【最小值】和【第二小值】在跑完迴圈後的值，會是5和12。
        */
        //從頭開始找最小值和第二小值，如果最小值和第二小值皆有找到的情況下，找到一個值比他們更大，就代表一定有一組三元組符合題目條件，並回傳true。

        int smallest = Int32.MaxValue; //設兩個整數，最小值和最大值
        int smaller = Int32.MaxValue;  //並且都先賦予系統最大值給他們來和陣列中的數字比大小

        for (int i = 0; i < nums.Length; i++)  //拜訪陣列內的數字
        {
            if(nums[i] <= smallest)  //先從最小值開始比較，如果當前數字比最小值小，
            {
                smallest = nums[i];   //就把數字賦予給最小值，進入下一個迴圈
            }
            else if(nums[i] <= smaller)  //如果當前數字比最小值大，就換第二小值比較，當前數字比第二小值小的話
            {
                smaller = nums[i];    //就把數字賦予給第二小值，進入下一個迴圈
            }
            else                     //如果還有其他數字比第一小值和第二小值大，就回傳true
            {
                return true;
            }
        }

        return false;  //如果其他數字都比最小值和第二小值小，或是陣列長度不足迴圈第3次，就回傳false
    }
}
// @lc code=end

/*
67/84
        int n = nums.Length;     
        bool while_check = true;
        int k = 0;
        if(n < 3)  //如果陣列沒到長度3，直接false
        {
            return false;
        }
        while(while_check)
        {            
            if(nums.ElementAtOrDefault(k) < nums.ElementAtOrDefault(k+1) && nums.ElementAtOrDefault(k+1) < nums.ElementAtOrDefault(k+2))
            {
                return true;
            }
            else
            {
                if(k == n)
                {
                    return false;
                }
            }
            Console.WriteLine(k);
            k++;
        }
        return false;
*/
