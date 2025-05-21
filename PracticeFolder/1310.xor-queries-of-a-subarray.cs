/*
 * @lc app=leetcode id=1310 lang=csharp
 *
 * [1310] XOR Queries of a Subarray
 */

// @lc code=start
public class Solution {
    public int[] XorQueries(int[] arr, int[][] queries)
    {
        //使用位元運算，還有prefix Sum    
        //範例arr=[1,3,4,8]
        //prefixsum後的prefix_sum=[0,1,2,6,14]
        int[] prefix_sum = new int[arr.Length+1];
        prefix_sum[0] = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            prefix_sum[i+1] = prefix_sum[i] ^ arr[i];
        }

        int[] result = new int[queries.Length];
        int step = 0;
        foreach (int[] query in queries)
        {
            result[step] = prefix_sum[query[1]+1] ^ prefix_sum[query[0]];
            step++;
        }
        return result;
    }
}
// @lc code=end

/*暴力解法 9% / 100% 3分鐘內解決
        //使用位元運算
        int[] result = new int[queries.Length];
        int index = 0;
        foreach(int[] values in queries)
        {
            int start = values[0];
            int end = values[1];
            int temp = 0;
            for(int i = start; i <= end; i++)
            {
                temp = temp ^ arr[i];
            }
            result[index] = temp;
            index++;
        }
        return result;
*/