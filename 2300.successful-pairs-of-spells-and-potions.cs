/*
 * @lc app=leetcode id=2300 lang=csharp
 *
 * [2300] Successful Pairs of Spells and Potions
 */

// @lc code=start
public class Solution {
    public int[] SuccessfulPairs(int[] spells, int[] potions, long success)
    {
        //potions_sort 由小排到大 [ 5 6 7 8 9 ] ，success = 7
        Array.Sort(potions);
        int n = potions.Length;
        int[] result = new int[spells.Length];

        for (int i = 0; i < spells.Length; i++)
        {
            int spell = spells[i];
            int low = 0;
            int high = n - 1;
            
            //使用二元搜尋法，找到能Success的最低標
            while ( low <= high )
            {
                int mid = low + (high - low) / 2;
                // int mid = (low + high) / 2;
                //如果目前值pair[mid]大於success，代表mid以上的索引值大於success，因此mid更新成新的high，往更低的索引值尋找
                if ( (long)spell * potions[mid] >= success )
                {
                    high = mid - 1;
                }
                else //如果當下值pair[mid]小於success，代表mid以上的索引值大於success，因此mid更新成新的low，往更高的索引值尋找
                {
                    low = mid + 1;
                }            
                //Console.WriteLine(mid);  //跑Console.WriteLone會導致TLE，下次注意
                
            }
            //從'low'到'n-1'的數值，都是Success的。 (n-1)-(low-1)= n - low
            result[i] = n - low;
            
        }
        return result;
    }
}
// @lc code=end

