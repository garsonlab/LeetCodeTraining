/*
 * @lc app=leetcode id=535 lang=csharp
 *
 * [535] Encode and Decode TinyURL

 TinyURL is a URL shortening service where you enter a URL such as https://leetcode.com/problems/design-tinyurl and it returns a short URL such as http://tinyurl.com/4e9iAk.

Design the encode and decode methods for the TinyURL service. There is no restriction on how your encode/decode algorithm should work. You just need to ensure that a URL can be encoded to a tiny URL and the tiny URL can be decoded to the original URL.
 */
public class Codec {

    // Encodes a URL to a shortened URL
    public string encode(string longUrl)
    {
        if(longUrl.StartsWith("ftp://"))
            return longUrl;

        int s = longUrl.StartsWith("https://") ? 1 : 0;
        if(s == 1)
            longUrl = longUrl.Replace("https://", "");
        else
            longUrl = longUrl.Replace("http://", "");
        int idx = longUrl.IndexOf('/');
        

        if (idx > 0)
        {
            string url = "http://" + longUrl.Substring(0, idx);
            string path = longUrl.Substring(idx+1);
            var bytes = new UTF8Encoding().GetBytes(path);
            var c = Convert.ToBase64String(bytes);
            return url + "/" + s + c;
        }
        else
        {
            return "http://" + longUrl;
        }
    }

    // Decodes a shortened URL to its original URL.
    public string decode(string shortUrl)
    {
        if(shortUrl.StartsWith("ftp://"))
            return shortUrl;

        shortUrl = shortUrl.Replace("http://", "");
        int idx = shortUrl.IndexOf('/');

        if (idx > 0)
        {
            string url = shortUrl.Substring(0, idx);
            if (shortUrl[idx + 1] == '1')
                url = "https://" + url;
            else
                url = "http://" + url;

            string path = shortUrl.Substring(idx+2);
            var bytes = Convert.FromBase64String(path);
            return url + "/" + new UTF8Encoding().GetString(bytes);
        }
        else
        {
            return "https://" + shortUrl;
        }
    }
}

// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.decode(codec.encode(url));

// √ Accepted
//   √ 739/739 cases passed (116 ms)
//   √ Your runtime beats 19.71 % of csharp submissions
//   √ Your memory usage beats 5.88 % of csharp submissions (25.3 MB)

