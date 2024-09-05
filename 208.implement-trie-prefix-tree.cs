/*
 * @lc app=leetcode id=208 lang=csharp
 *
 * [208] Implement Trie (Prefix Tree)
 */

// @lc code=start
public class TrieNode
{
/*使用Trie
先多設置一個TrieNode class，給予一個長度為總英文字母數量的陣列，還有一個判斷是否為單字的布林值，作為指針的引用
*/
    public TrieNode[] Children = new TrieNode[26];
    public bool isWord;

    public TrieNode()
    {
        for (int i = 0; i < Children.Length; i++)
        {
            Children[i] = null;
        }
        isWord = false;
    }
}
public class Trie {
    //新增加一個TrieNode的root節點
    private TrieNode root;
    public Trie()
    {
        root = new TrieNode();
    }

    public void Insert(string word)
    {
        //把root作為目前節點
        TrieNode current = root;
        //拜訪字串內的每一個字元
        foreach (char c in word)
        {
            //'a' - 'a' == 0
            //'b' - 'a' == 1
            //.....
            //'z' - 'a' ==25
            int index = c - 'a';
            //如果Children[index]為null，代表該索引內還沒有c字元，所以在那Children[該索引]內新增一個TrieNode
            if (current.Children[index] == null)
            {
                current.Children[index] = new TrieNode();
            }
            //並且更新目前節點為Children[index]，使能在下一輪迴圈找下一個node的陣列內索引值是否為null
            current = current.Children[index];
        }
        //全插入完後將最後的節點，設定為該節點是一個單字
        current.isWord = true;
    }
    
    public bool Search(string word)
    {
        TrieNode current = root;
        foreach (char c in word)
        {
            int index = c - 'a';
            //如果Children[index]為null，代表沒找到相同的字元，直接回傳false
            if (current.Children[index] == null)
            {
                return false;
            }
            current = current.Children[index];
        }
        return current.isWord;
    }
    
    public bool StartsWith(string prefix)
    {
        TrieNode current = root;
        foreach (char c in prefix)    
        {
            int index = c - 'a';
            //如果Children[index]為null，代表找不到陣列內找不到與前綴相同的字元，回傳false
            if (current.Children[index] == null)
            {
                return false;
            }
            current = current.Children[index];
        }
        return true;
    }
}

/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.Insert(word);
 * bool param_2 = obj.Search(word);
 * bool param_3 = obj.StartsWith(prefix);
 */
// @lc code=end

/*圖文解說影片
https://youtu.be/pkaooVBexeU?si=yAsVF_ZDQ59WHLVa
*/