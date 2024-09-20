/*
 * @lc app=leetcode id=214 lang=csharp
 *
 * [214] Shortest Palindrome
 */

// @lc code=start
public class Solution {
    public string ShortestPalindrome(string s)
    {
        //使用KMP演算法
        string reverse_string = new string(s.Reverse().ToArray());
        string Leng =  s + "#" + reverse_string;

        int[] p = new int[Leng.Length];

        for (int i = 1; i < Leng.Length; i++)
        {
            int j = p[i-1];

            while (j > 0 && (Leng[i] != Leng[j]))
            {
                j = p[j-1];
            }

            if (Leng[i] == Leng[j])
            {
                p[i] = j + 1;
            }
        }

        return reverse_string.Substring(0, (s.Length - p[Leng.Length - 1]) ) + s;
    }
}

// @lc code=end
/*初次嘗試 50 / 123 cases passed
        List<char> s_List = s.ToList();

        int List_Length = s_List.Count;
        int cur_index = 0;

        while(cur_index < (s_List.Count / 2) )
        {
            if (s_List[cur_index] != s_List[s_List.Count - 1 - cur_index])
            {
                s_List.Insert(cur_index, s_List[s_List.Count - 1 - cur_index]);
                cur_index = 0;
            }
            cur_index++;
        }
        StringBuilder sb = new StringBuilder();
        foreach(char c in s_List)
        {
            sb.Append(c);
        }
        return sb.ToString();
        //迴文 https://web.ntnu.edu.tw/~algo/Palindrome.html
        //字串反轉 https://rovingwind.synology.me/?p=283
*/