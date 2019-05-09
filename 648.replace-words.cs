/*
 * @lc app=leetcode id=648 lang=csharp
 *
 * [648] Replace Words

 In English, we have a concept called root, which can be followed by some other words to form another longer word - let's call this word successor. For example, the root an, followed by other, which can form another word another.

Now, given a dictionary consisting of many roots and a sentence. You need to replace all the successor in the sentence with the root forming it. If a successor has many roots can form it, replace it with the root with the shortest length.

You need to output the sentence after the replacement.

Example 1:

Input: dict = ["cat", "bat", "rat"]
sentence = "the cattle was rattled by the battery"
Output: "the cat was rat by the bat"
 

Note:

The input will only have lower-case letters.
1 <= dict words number <= 1000
1 <= sentence words number <= 1000
1 <= root length <= 100
1 <= sentence words length <= 1000
 */
public class Solution {
    public string ReplaceWords(IList<string> dict, string sentence) {
         List<string> list = (List<string>) dict;
        list.Sort();

        StringBuilder builder = new StringBuilder();
        string[] words = sentence.Split(' ');
        foreach (var word in words)
        {
            string tem = word;
            foreach (var dic in list)
            {
                if(dic[0] < tem[0])
                    continue;

                if(dic[0] > tem[0])
                    break;

                if (tem.StartsWith(dic))
                {
                    tem = dic;
                    break;
                }

            }

            if (builder.Length > 0)
                builder.Append(' ');
            builder.Append(tem);
        }

        return builder.ToString();
    }
}

// √ Accepted
//   √ 124/124 cases passed (212 ms)
//   √ Your runtime beats 43.22 % of csharp submissions
//   √ Your memory usage beats 88.89 % of csharp submissions (38.2 MB)

