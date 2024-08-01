/*
 * @lc app=leetcode id=151 lang=csharp
 *
 * [151] Reverse Words in a String
 */

// @lc code=start
public class Solution {
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

