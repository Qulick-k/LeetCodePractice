/*
 * @lc app=leetcode id=392 lang=csharp
 *
 * [392] Is Subsequence
 */

// @lc code=start
public class Solution {
    public bool IsSubsequence(string s, string t)
    {
        /*
        輸入兩個字串s 與 t，確認是否s是t的子序列。也就是s所有的元素，都出現在t，且出現的前後順序保持不變。比如範例輸入的 s = "abc", t = "ahbgdc"，abc都在t出現，且a與b與c的出現順序與在s一樣。
        */

        //一樣使用雙點針，但時間複雜度更精簡，空間複雜度則落後
        int i = 0, j = 0;
        while (i < s.Length && j < t.Length) {
            if (s[i] == t[j]) {
                i++;
            }
            j++;
        }
        return i == s.Length;

    }
}
// @lc code=end

/*
        // 20/20，自己想的爛扣，使用雙點針，贏40%跟67%
        int counter = 0;    //設置一個計數器，計算s序列內有幾個值，也出現在t序列內
        int j = 0;          //計數器給t序列，判斷掃描到第幾個index了

        for (int i = 0; i < s.Length; i++)      //先抓s序列的值，一個個看
        {
            while (j < t.Length )   //接著掃描t序列
            {
                if (s[i] == t[j])   //如果s序列的i值跟t序列的j值相同
                {
                    counter++;      //計數器+1
                    j++;            //t序列的index++
                    if (counter == s.Length)        //如果已知t序列內有s序列的所有值了 
                    {
                        return true;    //直接回傳true
                    }
                    break; //跳出while迴圈，繼續跑下一個s序列的值
                }
                else
                {
                    j++;        //如果s序列的i值跟t序列的j值不同，就增加t序列的index
                }
            }
        }
        Console.WriteLine(counter);
        if( counter == s.Length )   //當計數器相同於s序列，回傳true，反之回傳false
        {
            return true;
        }
        else
        {
            return false;
        }
*/
