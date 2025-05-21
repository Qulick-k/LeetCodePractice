/*
 * @lc app=leetcode id=151 lang=csharp
 *
 * [151] Reverse Words in a String
 */

// @lc code=start
public class Solution {
    /*
題目意譯：
給定一個輸入字串 s，反轉其中的字詞之出現順序。

一個字詞定義為一連串非空白字元的序列。s 的字詞之間會至少以一個空白分隔。

回傳一個反轉字詞順序後並統一以單一一個空排分隔的字串。

注意 s 可能包含前導或是末尾空白或是兩字詞可能有多個空白。回傳的字串應只能在兩字詞之間有單一一個空白，不得包含其他額外的空白。

限制：
1 ≦ s.length ≦ 10 ^ 4
s 包含英文字母（大小寫）、數字以及空白 ' '。
s 中至少有一個字詞。

進階：如果字串資料型態在你的語言是可變的（Mutable），你可以在 O(1) 額外空間原地（In-place）解出本題嗎？

範例測資：
範例 1：
輸入： s = "the sky is blue"
輸出： "blue is sky the"

範例 2：
輸入： s = "  hello world  "
輸出： "world hello"
解釋： 你反轉後的字串不應包含前導或是末尾空白。

範例 3：
輸入： s = "a good   example"
輸出： "example good a"
解釋： 你需要將反轉後的字串之兩字詞之間的多個空白縮減到只剩一個。
    */
    public string ReverseWords(string s)
    {
        s = s.Trim(); //如果開頭或是結尾有空格，會一併去除

        string[] str = s.Split(" ", StringSplitOptions.RemoveEmptyEntries);  //RemoveEmptyEntries不會回傳空字串的元素，可以把重複的空字串全部撤除
        

        Array.Reverse(str);  //翻轉

        int num = str.Length; //num裝進當前str的長度
        var Words = new StringBuilder(); //設置一個StringBuilder當空容器
        for (int i = 0; i < num; i++)  //用num的長度，提供給Words空容器的放置字串次數
        {
            //每跑一次，就把str內的字串丟進Words空容器
            Words.Append(str[i]);
            if(i < num-1) //只要當前次數還沒進入最後一次的放置動作，就在Words空容器內的字串後面再加上" "空格
            {
                Words.Append(" ");
            }
            
        }
        
        Console.WriteLine(Words); 
        
        return Words.ToString(); //StringBuilder記得ToString()
    }
}
// @lc code=end

