/*
 * @lc app=leetcode id=1071 lang=csharp
 *
 * [1071] Greatest Common Divisor of Strings
 */

// @lc code=start
public class Solution {
    //str1 + str2 != str2 + str1 代表兩組有公因數字串，反之則沒有，即""
    //如果有的話，假設str1和str2的長度皆大於0，且str1小於等於str2，而str2長度=n
    //由於str1的長度比str2的長度短，所以知道str1 要加常數C才會等於str2
    //而常數c有幾種情況
    //一，常數C是空值，則str1 = str2
    //二，常數C非空值，則Str2的長度 = str1的長度 + C的長度，並且str1、C的長度皆短於str2
    //則代表str1 + c = c + str1，兩者必定有公因數字串 d
    //也就是說str1 = i * d 而 c = j * d
    //最後str2 = str1 + c = (i + j) * d。
    //結論，d為str1和str2的公因數。
    public int FindGCD(int n1, int n2)
    {
        while(n1 != 0 && n2 != 0) //除到其中一個數為0為止，才能跳出迴圈
        {
            if(n1 > n2)
            {
                n1 %= n2;
            }
            else
            {
                n2 %= n1;
            }
        }
        Console.WriteLine(n1 | n2);        
        //回傳的值，畢竟為0 | NUM，或是NUM | 0，也就是NUM。
        return n1 | n2;
    }
    public string GcdOfStrings(string str1, string str2) 
    {
        //當str1 + str2 == str2 + str1 代表兩組有公因數字串，反之則沒有，即""
        if(str1 + str2 != str2 + str1)
        {
            return "";
        }

        int GCDNum = FindGCD(str1.Length, str2.Length);
        return str1.Substring(0,GCDNum);
    }
}
// @lc code=end

