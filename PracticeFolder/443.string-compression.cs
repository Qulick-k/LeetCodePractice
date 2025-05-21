/*
 * @lc app=leetcode id=443 lang=csharp
 *
 * [443] String Compression
 */

// @lc code=start
public class Solution {
    public int Compress(char[] chars)
    {
        //使用雙指針解題(two pointer)
        
        var i = 0;   //i用來訪問chars整格陣列
        var j = 0;   //j提供index給字元插入，並且順便算Output字元陣列的長度

        while (i < chars.Length)   //假設i沒超過chars陣列
        {
            var current = chars[i];  //當前chars[i]值，暫存在current
            var counter = 0;         //設一個計數器，算同個字元出現幾次

            while (i < chars.Length && chars[i] == current)  //要是i沒超過chars陣列，而且暫存值與當前chars[i]值相同
            {
                i++;         //i++，表示成功拜訪一個字元
                counter++;  //計數器++
            }

            //chars[j] = current;把當前的暫存值放回去chars[j]，之後再把j++
            chars[j++] = current;               
            
            if (counter > 1) //如果計數器大於1
            {
                //就把計數器的數值插入在chars[j]上，之後再把j++
                //如果有數字超過2位數的話(10、11、12)，必須拆解成，["1","0"]、["1","1"]、["1"、"2"]，因此使用foreach拜訪(轉成字串的計數器陣列)
                foreach (var counterChar in counter.ToString())  
                {                    
                    chars[j++] = counterChar;                           
                }
            }
            
        }
        Console.WriteLine($"Index is:  {Array.IndexOf(chars, 'a')}");
        Console.WriteLine(j);
        return j;  //完成後，回傳整數，內含chars[]陣列中的前j個字元。

            
        
        
    }
}
// @lc code=end

/*
廢案
int n = chars.Length;
        char[] temp_char_array = new char[0];
        char temp_c;
        int char_num = 0;
        if(n == 1)  //如果chars只有一個字串，就直接原封不動回傳
        {
            return chars.Length;
        }
        for (int i = 0; i < n; i++)
        {   
            if(temp_c == chars[i])   //此判斷用在第一次迴圈，把第一個字串傳給temp_c
            {
                if (char_num == 0)
                {
                    temp_c = chars[i];
                    temp_char_array[i] = temp_c;
                }
                
                char_num++;
                continue;
            }
            else
            {
                temp_char_array[i] = char_num.ToChar();
                temp_char_array[i] = chars[i];
                char_num = 0;
            }
        }

        return temp_char_array.Length;
*/