/*
 * @lc app=leetcode id=643 lang=csharp
 *
 * [643] Maximum Average Subarray I
 */

// @lc code=start
public class Solution {
    public double FindMaxAverage(int[] nums, int k)
    {
        /*主題為Slide Windows
        此題解法為差異法，先算出從0開始算起k個數值的總和作為基準值，來和後面的K-Subarray總和比較
        1st K-Subarray == 0,1,2,3,...,k-1,k
        2st K-Subarray ==   1,2,3,...,k-1,k,k+1
        在for迴圈怎麼刪掉nums[0]?，i設為k，第一輪的nums[i]
        以nums = [1,12,-5,-6,50,3]，k = 4為例
        先用一個迴圈算好1st K-Subarray = 2 。把1st K-Subarray的2賦予給Max_Average
        再用第二個迴圈開始比較，設i為k作為起始，也就是i = 4
                  開始算Temp = Temp + nums[i] - nums[i-k];               
        首先算2st K-Subarray =  2   +   50    -  1。 1st K-Subarray的2和2st K-Subarray的51比較取最大值，並重新賦予最大值給Max_Average，也就是51
        接著算3st K-Subarray =  51   +   3    -  12。 2st K-Subarray的51和3st K-Subarray的42比較取最大值，並重新賦予最大值給Max_Average，仍然還是51比較大
        最後迴圈只跑2次，i就從到達6了，因此跳出迴圈。並回傳Max_Average / k作為解答。

        在C#的寫法，Max_Average和Temp_Average記得宣告為浮點數值型別
        */
        double Max_Average = 0;
        double Temp_Average = 0;

        for (int i = 0; i < k; i++)
        {
            Temp_Average = Temp_Average + nums[i];
        }
        Max_Average = Temp_Average;

        for (int i = k; i < nums.Length; i++)
        {
            Temp_Average = Temp_Average + nums[i] - nums[i-k];
            Max_Average = Math.Max(Max_Average, Temp_Average);
        }
        
        return Max_Average / k;
    }
}
// @lc code=end

