/*
 * @lc app=leetcode id=790 lang=csharp
 *
 * [790] Domino and Tromino Tiling
 */

// @lc code=start
public class Solution {
    const long MODULO = 1000000007; //因為迴圈到後期，計算的數值會過於龐大，所以會使用MOD = 1000000007 取餘數，避免計算數值太大，導致溢位。
    public int NumTilings(int n)
    {
        //使用一維動態規劃
        
        //設置long陣列，長度設為n+3，因為先
        long[] dp = new long[n+3];
        dp[0] = 0;
        dp[1] = 1;
        dp[2] = 2;
        dp[3] = 5;
        long prefixSum = 0; //作一個前綴和，把之前上一輪的總和放在裡面

        //從第4個索引開始
        for (int i = 4; i <= n; i++)  //假設n=5
        {
            //當i=4。prefixSum=( 0 + 1) == 1
            //當i=5，prefixSum=( 1 + 2) == 3
            prefixSum = (prefixSum + dp[i-3]) % MODULO;
                        //自己獨有的2種排法
                        ////  |                      
            //當i=4。dp[4]= ( 2 + 2 + 5 + 1*2 ) == 11
            //當i=5。dp[5]= ( 2 + 5 + 11 + 3*2 ) == 24
            dp[i] = (2 + dp[i-2] + dp[i-1] + prefixSum * 2 )  % MODULO;
        }
        //dp[n]先取餘數，再用(int)轉成整數
        return (int)(dp[n] % MODULO);
    }
}
// @lc code=end

/* 推鰻魚燒的解說

利用原本已經計算好n-1、n-2….長度有幾種排法，下去計算長度n時的排法。

一開始會把會有一個陣列dp，紀錄n=1到n=n所有排法數量，之後可以重複利用，前1–3長度的排列數量，會直接先記錄在陣列中，方便計算。

接著用一個for迴圈，去計算n=4到n=n所有排法數量，算法公式如下

1. 當長度大於2之後，本身獨有的排列方式，皆有兩種
2. dp[n] = dp[n-1]*1+dp[n-2]*1+2*(dp[n-3]+dp[n-4]+…+dp[1])+2

https://medium.com/@cindy20303705/790-domino-and-tromino-tiling-%E8%A7%A3%E6%B3%95-43006c33867c
*/

/*效率最高的寫法
public class Solution {
    const long MODULO = 1000000007; //因為迴圈到後期，計算的數值會過於龐大，所以會使用MOD = 1000000007 取餘數，避免計算數值太大，導致溢位。
    public int NumTilings(int n)
    {
        //
        //設置long陣列，長度設為n+3，因為先
        long[] dp = new long[n+3];
        dp[0] = 0;
        dp[1] = 1;
        dp[2] = 2;
        dp[3] = 5;

        //從第4個索引開始
        for (int i = 4; i <= n; i++)  //假設n=5
        {                    
            //當i=4。dp[4]= (2 * 5 + 1) == 11
            //當i=5。dp[5]= (2 * 11 + 2) == 24
            dp[i] = (2 * dp[i-1] + dp[i-3]) % MODULO;
        }
        //dp[n]先取餘數，再用(int)轉成整數
        return (int)(dp[n] % MODULO);
    }
}
*/

/*典型的 DP 問題，基於之前的計算結果取得新的結果
https://kevinchung0921.medium.com/leetcode-%E8%A7%A3%E9%A1%8C%E7%B4%80%E9%8C%84-790-domino-and-tromino-tiling-7c36f7a3ac1b
*/

/*嘗試1
        long[] dpRow = new long[n+1];
        long[] dpUp = new long[n+1];
        long[] dpDown = new long[n+1];
        dpRow[0] = 1;
        dpRow[1] = 1;
        for(int i = 2; i <= n; i++)
        {
            dpUp[i] = (dpDown[i-1] + dpRow[i-2]) % MODULO;
            dpDown[i] = (dpUp[i-1] + dpRow[i-2]) % MODULO;
            dpRow[i] = (dpRow[i-1] + dpRow[i-2] + dpUp[i-1] + dpDown[i-1]) % MODULO;
        }

        return (int)dpRow[n];  
*/

/*嘗試2 10% 45%
        long[] dp = new long[n+3]; //多配置3個讓for迴圈更精簡
        //int MODULO = 1_000_000_007;
        dp[2] = 1; //位置為0

        for(int i = 3; i <= n+2; i++) //從位置1開始
        {
            dp[i] += dp[i-1] % MODULO;
            dp[i] += dp[i-2] % MODULO;
            for(int j = i-3; j >=0; j--) //累加到開始的位置
            {
                dp[i] += (dp[j]) * 2 % MODULO;
            }
        }
        return (int)((dp[n+2]) % MODULO);
*/