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
        //把字串跟反轉字串加在一起，兩個字串中間加一個#符號來避免重疊
        //找到一個跟最長前綴相同的後綴子字串 。要找到字串的最長前綴和，也就是反轉字串的最長後綴和，就需要使用KMP演算法 partial match table(部分配對表)
        //把那個最長的後綴子字串，從後綴字串中刪掉
        //被刪掉後的後綴字串，加回至字串的左方

        string reverse_string = new string(s.Reverse().ToArray());
        string Leng =  s + "#" + reverse_string; //[aabba#abbaa]

        int[] partial_Table  = new int[Leng.Length]; //[0,0,0,...0,0]

        //建立 KMP 表格
        //i代表後綴邊界
        //j代表前綴邊界
        for (int i = 1; i < Leng.Length; i++)
        {
            //更新前綴邊界
            int j = partial_Table [i-1]; //第一輪 j = 0

            //回到最後一次
            while (j > 0 && (Leng[i] != Leng[j]))  //只要j大於0，並且[i]字元跟[j]字元不相同
            {             
                j = partial_Table [j-1];
            }

            //如果[i]字元跟[j]字元相同
            if (Leng[i] == Leng[j])
            {
                //把目前i位置遇到的前綴和(j+1)，放到table內
                partial_Table [i] = j + 1;
                //Console.WriteLine ("{0},{1},{2}",Palindrome[i], j+1, i);
            }
        }
        //字串的長度，減掉table的最後一個位置的前綴和，就能取得實際需要幾個後綴字元，來加到字串的左方
        return reverse_string.Substring(0, (s.Length - partial_Table [Leng.Length - 1]) ) + s;
    }
}
//KMP參考 https://youtu.be/c4akpqTwE5g?si=H_c6hx0tpYhpLqn1
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

        /*
        //使用KMP演算法
        string reverse_string = new string(s.Reverse().ToArray());
        string Leng =  s + "#" + reverse_string; //[aabba#abbaa]

        int[] Palindrome  = new int[Leng.Length]; //[0,0,0,...0,0]

        for (int i = 1; i < Leng.Length; i++)
        {
            int j = Palindrome [i-1]; //第一輪 j = 0
           
            while (j > 0 && (Leng[i] != Leng[j]))
            {             
                j = Palindrome [j-1];
            }

            if (Leng[i] == Leng[j])
            {
                //Console.WriteLine ("{0},{1}",Leng[i],Leng[j]);
                Palindrome [i] = j + 1;
                //Console.WriteLine ("{0},{1},{2}",Palindrome[i], j+1, i);
            }
        }

        return reverse_string.Substring(0, (s.Length - Palindrome [Leng.Length - 1]) ) + s;
        */