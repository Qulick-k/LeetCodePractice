/*
 * @lc app=leetcode id=1657 lang=csharp
 *
 * [1657] Determine if Two Strings Are Close
 */

// @lc code=start
public class Solution {
    public bool CloseStrings(string word1, string word2)
    {
        // Base case
        if( word1.Length != word2.Length ){
            return false;
        }

        // To count how many times a letter appears in the word
        // There are 26 letters in the English alphabet (a-z)
        int[] freq1 = new int[26];
        int[] freq2 = new int[26];

        // Count the frequencies for each word
        // Increase the count in the index that represents the letter in the alphabet
        // Character - 'a' = the difference in ascii code for the letters is the position in the array
        // 0 = a, 25 = z
        for( int i = 0; i < word1.Length; i++ ){
            freq1[ word1[i] - 'a' ]++;
            freq2[ word2[i] - 'a' ]++;
        }

        // If any of the sequences is 0, the other must also be 0
        // Otherwise, a letter doesn't exist in one of them
        for( int i = 0; i < 26; i++ ){
            if( freq1[i] == 0 && freq2[i] != 0 ){
                return false;
            }
            if( freq1[i] != 0 && freq2[i] == 0 ){
                return false;
            }
        }

        // Sort the arrays by frequencies
        Array.Sort(freq1);
        Array.Sort(freq2);

        // If the sorted frequencies match true, else false
        // If the frequencies match, even if the characters are not the same, we can change characters to get the same word
        return freq1.SequenceEqual(freq2);
    }
}
// @lc code=end

/*
        //自己寫的超級爛扣 11% / 11%
        Dictionary<char, int> table1 = new(); //先設置兩個陣列的Dictionary
        Dictionary<char, int> table2 = new();

        if(word1.Length != word2.Length)  //兩個陣列長度不同，直接false
        {
            return false;
        }
        for(int i = 0; i < word1.Length; i++) //把每一種char出現的次數，記錄在各個Dictionary內
        {
            if(table1.ContainsKey(word1[i])) 
            {
                table1[word1[i]] = table1[word1[i]] + 1;
            }
            else 
            {
                table1.Add(word1[i], 1);
            }
            if(table2.ContainsKey(word2[i])) 
            {
                table2[word2[i]] = table2[word2[i]] + 1;
            }
            else 
            {
                table2.Add(word2[i], 1);
            }
        }

        if(table1.Count != table2.Count) //如果種類數量不同，回傳false
        {
            return false;
        }

        int[] test_List1 = new int[word1.Length];   //設置兩個陣列，之後比較每一種數值出現的次數，有沒有互相對稱相同
        int[] test_List2 = new int[word2.Length];
        int c = 0;  //用來作為兩個陣列的索引值
        int b = 0;
        int count_1 = 0;    //用來作為非特定字母的出現次數的計數器
        int count_2 = 0;
        int count_key1 = 0; //用來作為相同字母出現種類的
        int count_key2 = 0;
        foreach(var v in table1) //拜訪table1看有哪些非特定字母的出現次數(value)跟table2的出現次數相同，以及看有哪些相同的字母
        {
            if(table2.ContainsValue(v.Value))
            {
                count_1++;
            }
            if (table2.ContainsKey(v.Key))
            {
                count_key1++;
            }
            test_List1[c] = v.Value; //每一種字母出現的次數記錄在陣列內
            c++;    //索引值++
        }
        foreach(var v in table2)    //拜訪table2看有哪些非特定字母的出現次數(value)跟table1的出現次數相同，以及看有哪些相同的字母
        {
            if(table1.ContainsValue(v.Value))
            {
                count_2++;
            }
            if(table1.ContainsKey(v.Key))
            {
                count_key2++;
            }
            test_List2[b] = v.Value;    //每一種字母出現的次數記錄在陣列內
            b++;    //索引值++
        }
        Array.Sort(test_List1); //排序好兩個陣列
        Array.Sort(test_List2);
        

        if (count_1 != table1.Count || count_2 != table2.Count) //互相拜訪對方的table後，非特定字母的出現次數如果不同於自身table，回傳false
        {
            return false;
        }
        if( count_key1 != table1.Count || count_key2 != table2.Count) //互相拜訪對方的table後，相同的字母種類數量如果不同於自身table，回傳false
        {
            return false;
        }
        if(test_List1.Length == test_List2.Length) //如果兩個陣列的i索引中的數值不相同，代表無法滿足題目，回傳false
        {
            for(int i = 0; i < test_List1.Length; i++)
            {
                if(test_List1[i] != test_List2[i])
                {
                    return false;
                }
            }
        }
        
        return true; //跑完都沒問題，回傳True
*/