/*
 * @lc app=leetcode id=1431 lang=csharp
 *
 * [1431] Kids With the Greatest Number of Candies
 */

// @lc code=start
public class Solution {
    int Biggest_NUM = 0;
    List<bool> Output = new List<bool>();
    public IList<bool> KidsWithCandies(int[] candies, int extraCandies) {
        for(int i = 0; i < candies.Length; i++)
        {
            if(Biggest_NUM == 0)
            {
                Biggest_NUM = candies[i];
            }
            else
            {
                if(Biggest_NUM < candies[i])
                {
                    Biggest_NUM = candies[i];
                }
            }
        }
        Console.WriteLine(Biggest_NUM);

        for(int j = 0; j < candies.Length; j++)
        {
            if(Biggest_NUM > (candies[j] + extraCandies))
            {
                Output.Add(false);
            }
            else
            {
                Output.Add(true);
            }
        }

        return Output;
    }
}
// @lc code=end

