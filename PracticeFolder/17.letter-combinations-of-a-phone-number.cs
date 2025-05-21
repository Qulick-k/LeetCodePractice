/*
 * @lc app=leetcode id=17 lang=csharp
 *
 * [17] Letter Combinations of a Phone Number
 */

// @lc code=start
public class Solution {
    public IList<string> LetterCombinations(string digits)
    {
        //BackTracking    
        //設置一個IList的Answer字串串列
        IList<string> Answer = new List<string>();
        //設置一個Dictionary放char,string泛型的digitToChar，來裝a~z
        Dictionary<char, string> digitToChar = new Dictionary<char, string>()
        {
            {'2', "abc"},
            {'3', "def"},
            {'4', "ghi"},
            {'5', "jkl"},
            {'6', "mno"},
            {'7', "pqrs"},
            {'8', "tuv"},
            {'9', "wxyz"}
        };
        //如果digits字串長超過0，在執行backtrack。不然就直接回傳還沒放任何字串的Answer空串列
        if( digits.Length > 0)
        {   
            //給backtrack的起始參數為digits開頭索引0，還有空字串
            backtrack(0, "");
        }
        //回傳Answer串列
        return Answer;
        
        //backtrack()的參數設置int放digits的索引值，
        //再設置string放目前字串currentString
        void backtrack(int index, string currentString)
        {   
            //如果目前字串長度，和digits字串相同
            if( currentString.Length == digits.Length )
            {   
                //目前字串即為答案之一，加進Answer串列，並回傳到上一層遞迴
                Answer.Add(currentString);
                return;
            }
            //不相同的話就以digits[index]==作為digitToChar的Key，找相對應的Value值，也就是"abc"..等字串
            //以digit = "23"為例
            //如果index = 0，digits[index] == digits[0] == '2'
            //digitToChar['2'] == "abc"，
            //第一輪的One_char == "a"
            //第二輪的One_char == "b"
            //第三輪的One_char == "c"
            foreach( var One_char in digitToChar[ digits[index] ])
            {   
                //進入遞迴，以第一輪為例，也就是backtrack(0+1, ""+"a")
                backtrack(index+1, currentString + One_char);
            }
        }
    }
}
// @lc code=end

