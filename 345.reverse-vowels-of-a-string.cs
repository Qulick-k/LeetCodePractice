/*
 * @lc app=leetcode id=345 lang=csharp
 *
 * [345] Reverse Vowels of a String
 */

// @lc code=start
public class Solution {
    //訪問s字串所有的字元有沒有母音(包含大小寫)
    //先把指定母音放進HashSet<Char>內，用來檢查
    //如果有母音，就把母音字元放進Stack裡面，同時把母音字元在s字串的指標放進Index內。以便之後取回位置
    //Index使用HashSet<Int>來存放
    //然後用for迴圈一個數字一個數字詢問Index有哪些位置(數字)是母音，如果是，就pop掉Stack上的母音字元
    //到要輸出的字串上。
    //這次會用到的類別有
    //Stack<T>
    //HashSet<T>
    //StringBuilder
    public string ReverseVowels(string s) 
    {
       HashSet<char> vowels_set = new HashSet<char>()
       {
        'a', 'e','i', 'o', 'u', 'A','E','I','O','U'
       };
       HashSet<int> index_of_the_vowels = new HashSet<int>();
       Stack<char> Foundvowels = new Stack<char>(); //用來放母音的堆疊
       StringBuilder output = new StringBuilder(s);

       for (int i = 0; i < s.Length; i++)
       {    
            if(vowels_set.Contains(s[i]))
            {
                Foundvowels.Push(s[i]);
                index_of_the_vowels.Add(i);
            }
       }
       
       for (int i = 0; i < s.Length; i++)
       {
            if(index_of_the_vowels.Contains(i))
            {
                output[i] = Foundvowels.Pop();
            }
       }

       return output.ToString();
    }
}
// @lc code=end

