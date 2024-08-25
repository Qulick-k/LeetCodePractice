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
        //graph[A][B] = k >> A/B = k
        //設置空字典，泛型放string和List
        Dictionary<string, List<(string dvs, double qt)>> graph = new Dictionary<string, List<(string dvs, double qt)>>();

        //建圖
        for (int i = 0; i < equations.Count; i++)
        {
            graph.TryAdd(equations[i][0], new List<(string dvs, double qt)>() );
            graph.TryAdd(equations[i][1], new List<(string dvs, double qt)>() );
            graph[equations[i][0]].Add((equations[i][1], values[i]));
            graph[equations[i][1]].Add((equations[i][0], 1 / values[i]));
        }
        
        //設置要放置的答案串列，以及紀錄有無拜訪過的HashSet
        List<double> answer = new List<double>();
        HashSet<string> visited = new HashSet<string>();

        foreach(IList<string> query in queries)
        {
            //如果query內的陣列有沒定義過的字串，則為-1。並且跳過當前迴圈
            if(!graph.ContainsKey(query[0]) || !graph.ContainsKey(query[1]))
            {
                answer.Add(-1.0);
                continue;
            }

            double result = DFS_Divide(graph, query[0], query[1], 1, visited);
            answer.Add(result);
            visited.Clear();
        }
        
        return answer.ToArray();
    }

    //找到A / B的結果
    public double DFS_Divide(Dictionary<string, List<(string dvs, double qt)>> graphs, string A, string B, double prd,  HashSet<string> visited )
    {
        visited.Add(A);

        if(A == B)
        {
            return prd;
        }

        foreach(var nd in graphs[A])
        {
            if(visited.Contains(nd.dvs))
            {
                continue;
            }

            double result = DFS_Divide(graphs, nd.dvs, B, prd*nd.qt, visited);

            if(result > 0)
            {
                return result;
            }
        }

        return -1.0;
    }
}
// @lc code=end

/*
Dictionary.TryAdd
https://learn.microsoft.com/zh-tw/dotnet/api/system.collections.generic.dictionary-2.tryadd?view=net-8.0#system-collections-generic-dictionary-2-tryadd(-0-1)
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