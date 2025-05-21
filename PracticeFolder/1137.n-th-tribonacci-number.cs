/*
 * @lc app=leetcode id=1137 lang=csharp
 *
 * [1137] N-th Tribonacci Number
 */

// @lc code=start
public class Solution {
    public int Tribonacci(int n)
    {
        //動態規劃
        //先設置陣列放置0,1,1
        int[] TriArray = [0, 1, 1];

        for (int i = 3; i <= n; i++)
        {
            TriArray[i % 3] = TriArray[0] + TriArray[1] + TriArray[2];
        }
        return TriArray[n % 3];
    }
}
        //以 n = 4為例                                               TriArray[0] + TriArray[1] + TriArray[2]
        //i = 3，TriArray[i % 3] == TriArray[3 % 3] == TriArray[0] = 0 + 1 + 1 = 2
        //i = 4，TriArray[i % 3] == TriArray[4 % 3] == TriArray[1] = 2 + 1 + 1 = 4
        //由於TriArray[1]被賦予新的數值4，所以當n%3餘數為1時，TriArray[1]就等於4
        //return TriArray[n % 3] == TriArray[4 % 3] == TriArray[1] = 4
// @lc code=end
/*      //最快解法
        //先設置陣列放置0,1,1
        int[] TriArray = [0, 1, 1];

        for (int i = 3; i <= n; i++)
        {
            TriArray[i % 3] = TriArray[0] + TriArray[1] + TriArray[2];
        }
        return TriArray[n % 3];
        //以 n = 4為例                                               TriArray[0] + TriArray[1] + TriArray[2]
        //i = 3，TriArray[i % 3] == TriArray[3 % 3] == TriArray[0] = 0 + 1 + 1 = 2
        //i = 4，TriArray[i % 3] == TriArray[4 % 3] == TriArray[1] = 2 + 1 + 1 = 4
        //由於TriArray[1]被賦予新的數值4，所以當n%3餘數為1時，TriArray[1]就等於4
        //return TriArray[n % 3] == TriArray[4 % 3] == TriArray[1] = 4
*/
/*//暴力解爛扣
        //暴力解爛扣
        if (n == 0) return 0;
        if (n < 3) return 1;
        
        int T_first = 0;
        int T_middle = 1;
        int T_back = 1;
        int temp = 0 ;

        for (int i = 3; i <= n; i++)
        {
            temp = T_first + T_middle + T_back;
            T_first = T_middle;
            T_middle = T_back;
            T_back = temp;
        }
        return temp;
*/