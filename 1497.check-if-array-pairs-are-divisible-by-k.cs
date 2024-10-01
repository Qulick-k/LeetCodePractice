/*
 * @lc app=leetcode id=1497 lang=csharp
 *
 * [1497] Check If Array Pairs Are Divisible by k
 */

// @lc code=start
public class Solution {
    public bool CanArrange(int[] arr, int k)
    {
        //練習hash table的概念，雖然這題是使用陣列來實現hash table的概念

        //設置餘數空陣列
        int[] remainCount = new int[k];

        foreach (int num in arr)
        {
            //找出num的餘數
            int remain = num % k;
            //如果餘數小於0，加上k。EX: K = 7、remain = -1  >> -1 + 7 = 6，6再跟1加起來就可以被7整除 
            if (remain < 0) remain +=  k;
            //在該餘數陣列增加次數
            remainCount[remain] ++;
        }

        //如果餘數為0的索引值，數量不是2的倍數，代表不是成對的，必定回傳false
        if (remainCount[0] % 2 != 0) return false;

        //拜訪餘數1~K的索引值內的數值，如果K = 7，且餘數[1]的數量等同於餘數[6]的數量，拜屌通過檢測，如果餘數[2]的數量不同於餘數[5]的數量，則回傳false;
        for (int r = 1; r < k; r++)
        {
            if (remainCount[r] != remainCount[k - r]) return false;
        }
        
        return true;
    }
}
// @lc code=end

