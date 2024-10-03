/*
 * @lc app=leetcode id=1331 lang=csharp
 *
 * [1331] Rank Transform of an Array
 */

// @lc code=start
public class Solution {
    public int[] ArrayRankTransform(int[] arr)
    {
        //使用HASH TABLE和SORTED
        Dictionary<int, int> Table = new Dictionary<int, int>();
        
        //int[] copy = arr.OrderBy(x=>x).ToArray();
        //Array.Sort(copy);
        int[] sortedArray = new int[arr.Length];
        arr.CopyTo(sortedArray, 0);
        Array.Sort(sortedArray);

        //int rank = 1;
        foreach(int i in sortedArray)    
        {
            if(!Table.ContainsKey(i))
            {
                //Table[i] = rank;
                //rank++;
                Table[i] = Table.Count + 1;
            }
        }
        int[] res = new int[arr.Length];

        for(int i = 0; i < arr.Length; i++)
        {
            res[i] = Table[arr[i]];
        }

        return res;
    }
}
// @lc code=end

