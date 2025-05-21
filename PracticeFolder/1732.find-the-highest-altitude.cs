/*
 * @lc app=leetcode id=1732 lang=csharp
 *
 * [1732] Find the Highest Altitude
 */

// @lc code=start
public class Solution {
    public int LargestAltitude(int[] gain)
    {
        //網友寫的 99% 71%
        //設目前高度=0，以及最高高度=0
        //使用foreach訪問gain內的每個數值
        //目前高度與i值相加，並且與最高高度比較大小，目前高度比最高高度大的話，更新目前高度的數值給最高高度
        int currentAltitude=0,highestAltitude=0;

        foreach(int i in gain){
            currentAltitude+=i;
            highestAltitude = Math.Max(currentAltitude, highestAltitude);            
        }
        return highestAltitude;
    }
}
// @lc code=end

/*
        // 自己寫的 86% 11%
        //使用前缀和    
        //設一個MAX值，起始為0，接著讓gain[n] + gain[n-1]來算出gain[n]的前綴和
        //然後每一個gain[n]的前綴和都和Max值做比較，最大值丟給Max值
        //為避免前綴和最大值是負數而導致出錯，需要跟0做比較，0如果比前綴和大，就重新賦予0給MAX
        //最後回傳Max
        int Max = int.MinValue;

        Max = Math.Max(Max, gain[0]);

        for (int i = 1; i < gain.Length; i++)
        {
            gain[i] = gain[i] + gain[i-1];
            Max = Math.Max(Max, gain[i]);
            Console.WriteLine(gain[i]);
        }
        Max = Math.Max(Max, 0); //
        return Max;
*/