/*
 * @lc app=leetcode id=374 lang=csharp
 *
 * [374] Guess Number Higher or Lower
 */

// @lc code=start
/** 
 * Forward declaration of guess API.
 * @param  num   your guess
 * @return 	     -1 if num is higher than the picked number
 *			      1 if num is lower than the picked number
 *               otherwise return 0
 * int guess(int num);
 */

public class Solution : GuessGame {
    public int GuessNumber(int n)
    {
        //練習二元搜尋法
        int low = 1;
        int high = n;

        while( low <= high )
        {
            // int mid = ( (low + high) / 2 ); 這個公式會OverFlow，因為假如 (1,000,000,000 + 2,000,000,000) / 2 會超過 int.MaxValue 的 2,147,483,647
            int mid = low + ((high - low) / 2);
            int test = guess(mid);
            if ( test == -1) 
            {
                high = mid - 1;
            }
            else if (test == 1)
            {
                low = mid + 1;
            }
            else
            {
                return mid;
            }
        }
        return -1;
    }
}
// @lc code=end

