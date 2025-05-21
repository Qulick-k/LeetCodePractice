/*
 * @lc app=leetcode id=399 lang=csharp
 *
 * [399] Evaluate Division
 */

// @lc code=start
public class Solution {
    public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
    {
        //使用圖形和DFS，62% 58%
        //graph[equations[i][0]] / graph[equations[i][1]] = k
        // >> A/B = k
        //設置空字典，泛型放string和List
        Dictionary<string, List<(string dvs, double qt)>> graph = new Dictionary<string, List<(string dvs, double qt)>>();

        //掃描equations，作圖
        for (int i = 0; i < equations.Count; i++)
        {
            //假設放A / B = 3.0
            //[["A","B"],["B","C"]]
            //equations[0][0] == "A"
            //          (            key,                               value )
            //          (              A,        List<(string dvs, double qt)>)
            graph.TryAdd(equations[i][0], new List<(string dvs, double qt)>() );
            graph.TryAdd(equations[i][1], new List<(string dvs, double qt)>() );
            
        //  graph[key] = value
        //  graph[key].Add = value.Add
        //  graph[equations[0][0]].Add((equations[0][1], values[0]));
        //  graph["A"].Add(("B", 3.0))
            graph[equations[i][0]].Add((equations[i][1], values[i]));

        //  graph[equations[0][1]].Add((equations[0][0], 1 / values[0]));
        //  graph["B"].Add(("A", 1 / 3.0))
            graph[equations[i][1]].Add((equations[i][0], 1 / values[i]));
        }
        
        //設置要放置的答案串列answer，以及紀錄有無拜訪過的HashSet visited
        List<double> answer = new List<double>();
        HashSet<string> visited = new HashSet<string>();

        //接著進queries看問題
        foreach(IList<string> query in queries)
        {            
//          queries = [["A","C"],["B","A"],["A","E"],["A","A"],["X","X"]]
            //假設現在是第一輪 query = ["A","C"]
            //query[0] == "A"、query[1] == "C"
            //如果query內的陣列有沒定義過的字串，則為-1。並且跳過當前迴圈
            //if(!graph.ContainsKey("A") || !graph.ContainsKey("C")) >>由於"A"、"C"都是graph的Key，所以此if判斷跳過。
            if(!graph.ContainsKey(query[0]) || !graph.ContainsKey(query[1]))
            {
                answer.Add(-1.0);
                continue;
            }

            //              DFS_Divide(graph,      "A",      "C", 1, visited);進遞迴。      ***從第一次DFSDFS_Divide返回CalcEquation，回傳了6.0 給result*** 
            double result = DFS_Divide(graph, query[0], query[1], 1, visited);

            //answer串列新增result == 6.0
            answer.Add(result);
            //把visited清空，重新進行迴圈
            visited.Clear();
        }
        //迴圈結束後，回傳answer串列，記得把串列轉成陣列。
        return answer.ToArray();
    }

    //找到A / C的結果
    public double DFS_Divide(Dictionary<string, List<(string dvs, double qt)>> graphs, string A, string B, double prd,  HashSet<string> visited )
    {
        //假設現在是第一輪 query = ["A","C"]。
        //string A == "A"，string B = "C"，prd = 1
        //visited.Add("A")
        visited.Add(A);

        //if(A == B)
        //if("A" == "C")，不符合，跳過
        if(A == B)
        {
            return prd;
        }

        //graphs[A] == graphs["A"] == List<string dvs, double qt> == [["B", 3.0]]
        foreach(var nd in graphs[A])
        {            
            ///假設目前是第一輪，nd == ["B", 3.0]
            ///visited.Contains("B")，不符合，跳過此判斷
            if(visited.Contains(nd.dvs))
            {
                continue;
            }

            ///             DFS_Divide(graphs,    "B","C",     1*3.0, visited);進遞迴。      ***從第二次DFSDFS_Divide返回第一次DFSDFS_Divide，回傳了6.0 給result***
            double result = DFS_Divide(graphs, nd.dvs,  B, prd*nd.qt, visited);

            //result == 6.0 > 0，因此回傳result == 6.0        ***返回CalcEquation()的foreach(IList<string> query in queries)迴圈***
            if(result > 0)
            {
                return result;
            }
        }

        return -1.0;
    }
    /*///第二次進入DFS_Divide                                                  (graphs,      "B",      "C",      1*3.0,                  visited )的遞迴
    public double DFS_Divide(Dictionary<string, List<(string dvs, double qt)>> graphs, string A, string B, double prd,  HashSet<string> visited )
    {
        //string A == "B"，string B = "C"，prd = 3.0
        //visited.Add("B")，加完後，visited現在有["A", "B"]
        visited.Add(A);

        //if(A == B)
        //if("B" == "C")，不符合，跳過
        if(A == B)
        {
            return prd;
        }

        //graphs[A] == graphs["B"] == List<string dvs, double qt> == [["A", 1 / 3.0], ["C", 2.0]]
        foreach(var nd in graphs[A])
        {            
            ///假設目前是第一輪，nd == ["A", 1 / 3.0]
            ///visited.Contains("A")，符合，跳過本輪迴圈
            ///假設目前是第二輪，nd == ["C", 2.0]
            ///visited.Contains("C")，不符合，跳過此判斷
            if(visited.Contains(nd.dvs))
            {
                continue;
            }

            ///             DFS_Divide(graphs,    "C","C",   3.0*2.0, visited);進遞迴。      ***從第三次DFSDFS_Divide返回第二次DFSDFS_Divide，回傳了prd == 6.0 給result***
            double result = DFS_Divide(graphs, nd.dvs,  B, prd*nd.qt, visited);
            
            //result == 6.0 > 0，回傳result == 6.0。  ***返回第一次DFSDFS_Divide***
            if(result > 0)
            {
                return result;
            }
        }

        return -1.0;
    }
    */
    /*///第三次進入DFS_Divide                                                  (graphs,      "C",      "C",        6.0,                  visited )的遞迴
    public double DFS_Divide(Dictionary<string, List<(string dvs, double qt)>> graphs, string A, string B, double prd,  HashSet<string> visited )
    {
        //string A == "C"，string B = "C"，prd = 6.0
        //visited.Add("C")，加完後，visited現在有["A", "B", "C"]
        visited.Add(A);

        //if(A == B)
        //if("C" == "C")，符合，回傳prd == 6.0。  ***返回第二次DFSDFS_Divide****
        if(A == B)
        {
            return prd;
        }

        //graphs[A] == graphs["B"] == List<string dvs, double qt> == [["A", 1 / 3.0], ["C", 2.0]]
        foreach(var nd in graphs[A])
        {            
            ///假設目前是第一輪，nd == ["A", 1 / 3.0]
            ///visited.Contains("A")，符合，跳過本輪迴圈
            ///假設目前是第二輪，nd == ["C", 2.0]
            ///visited.Contains("C")，不符合，跳過此判斷
            if(visited.Contains(nd.dvs))
            {
                continue;
            }

            ///             DFS_Divide(graphs,    "C","C",   3.0*2.0, visited);進遞迴
            double result = DFS_Divide(graphs, nd.dvs,  B, prd*nd.qt, visited);

            if(result > 0)
            {
                return result;
            }
        }

        return -1.0;
    }
    */
}
// @lc code=end

/*
Dictionary.TryAdd
https://learn.microsoft.com/zh-tw/dotnet/api/system.collections.generic.dictionary-2.tryadd?view=net-8.0#system-collections-generic-dictionary-2-tryadd(-0-1)
題目解析
https://www.youtube.com/watch?v=UwpvInpgFmo
*/

/*
    private Dictionary<string, Dictionary<string, double>> dic = new Dictionary<string, Dictionary<string, double>>();
    private double[] ans;
    private HashSet<string> set = new HashSet<string>();

    public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
    {
        ans = new double[queries.Count];
        for (int i = 0; i < equations.Count; i++)
        {
            var equation = equations[i];
            double value = values[i];
            string dividend = equation[0];
            string divisor = equation[1];

            if (!dic.ContainsKey(dividend)) dic[dividend] = new Dictionary<string, double>();
            if (!dic.ContainsKey(divisor)) dic[divisor] = new Dictionary<string, double>();
            dic[dividend][divisor] = value;
            dic[divisor][dividend] = 1 / value;
        }

        for (int i = 0; i < queries.Count; i++)
        {
            var query = queries[i];

            var dividend = query[0];
            var divisor = query[1];
            if (!dic.ContainsKey(dividend) || !dic.ContainsKey(divisor)) ans[i] = -1;
            else if (dividend == divisor) ans[i] = 1;
            else
            {
                set.Clear();
                double num = DFS(dividend, divisor, 1);
                ans[i] = num;

            }
        }

        return ans;

    }

    private double DFS(string dividend, string divisor, double ans)
    {

        if (dic[dividend].ContainsKey(divisor)) return ans * dic[dividend][divisor];

        if (set.Contains(dividend)) return -1;

        set.Add(dividend);

        foreach (string key in dic[dividend].Keys)
        {
            double tmp = DFS(key, divisor, ans * dic[dividend][key]);
            if (tmp != -1)
            {
                return tmp;
            }
        }

        set.Remove(dividend);
        return -1;

    }
*/