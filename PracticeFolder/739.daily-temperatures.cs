/*
 * @lc app=leetcode id=739 lang=csharp
 *
 * [739] Daily Temperatures
 */

// @lc code=start
public class Solution {
    public int[] DailyTemperatures(int[] temperatures)
    {
        //使用Monotonic Stack
        Stack<int> index_temperatures = new Stack<int>();
        int[] result = new int[temperatures.Length];

        //Stack放置的是索引，而不是溫度
        index_temperatures.Push(0);
        
        for (int i = 1; i < temperatures.Length; i++)
        {
            while( index_temperatures.Count > 0 && temperatures[index_temperatures.Peek()] < temperatures[i] )
            {
                int getIndex = index_temperatures.Pop();
                result[getIndex] = i - getIndex;
            }
            index_temperatures.Push(i);
        }
        return result;
    }
}
// @lc code=end

