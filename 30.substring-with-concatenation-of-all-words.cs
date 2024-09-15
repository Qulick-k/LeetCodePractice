/*
 * @lc app=leetcode id=30 lang=csharp
 *
 * [30] Substring with Concatenation of All Words
 */

// @lc code=start
public class Solution {
    public IList<int> FindSubstring(string s, string[] words)
    {
        //使用Slide Window、HashTable  
        IList<int> result = new List<int>();
        //如果s長度等於0，或者word[0]的長度等於0，直接回傳null
        /*if (s.Length == 0 || words[0].Length == 0)
        {
            return result;
        }*/
        
        Dictionary<string, int> check_word = new Dictionary<string, int>();
        foreach (string word in words)
        {
            if (check_word.ContainsKey(word))
            {
                check_word[word] = check_word[word] + 1;
            }
            else
            {
                check_word[word] = 1;
            }
        }

        //words的索引數量
        int wordCount = words.Length;
        //words每個索引字串的長度
        int wordLength = words[0].Length;
        //存取子集合的字串長度
        int SubstringLength = wordCount*wordLength;

        for (int i = 0; i < s.Length - SubstringLength + 1; i++)
        {
            Dictionary<string, int> hash_used = new Dictionary<string, int>();
            //不要用j++，有可能造成Time Limit Exceeded，隔天測試一次
            for (int j = 0; j < wordCount; j++)
            {
                int next_index = i + j * wordLength;
                string cur_word = s.Substring(next_index, wordLength);
                /*for (int k = next_index; k < next_index + wordLength; k++)
                {                   
                    cur_word = cur_word + s[k];
                }*/
                if(check_word.ContainsKey(cur_word) == false || check_word[cur_word] < 1)
                {
                    break;
                }
                /*int used_num = 0;
                hash_used.TryGetValue(cur_word, out used_num);
                hash_used[cur_word] = used_num + 1;*/
                if (hash_used.ContainsKey(cur_word))
                {
                    hash_used[cur_word] = hash_used[cur_word] + 1;
                }
                else
                {
                    hash_used[cur_word] = 1;
                }

                /*int check_Num = 0;
                check_word.TryGetValue(cur_word, out int value);
                if (value == null)
                {
                    check_Num = 0;
                }
                else
                {
                    check_Num = value;
                }*/
                
                if (hash_used[cur_word] > check_word[cur_word])
                {
                    break;
                }
                
                if ( j + 1 == wordCount)
                {
                    result.Add(i);
                }
            }
        }
        return result;
    }
}
// @lc code=end

/* C#的Substring
https://learn.microsoft.com/zh-tw/dotnet/api/system.string.substring?view=net-8.0
*/

/*第一次嘗試參考教學
https://youtu.be/ddSzsLUSPrQ?si=Q3OqE1GEtDYALR-3
*/