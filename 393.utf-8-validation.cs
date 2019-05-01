/*
 * @lc app=leetcode id=393 lang=csharp
 *
 * [393] UTF-8 Validation

 A character in UTF8 can be from 1 to 4 bytes long, subjected to the following rules:

For 1-byte character, the first bit is a 0, followed by its unicode code.
For n-bytes character, the first n-bits are all one's, the n+1 bit is 0, followed by n-1 bytes with most significant 2 bits being 10.
This is how the UTF-8 encoding would work:

   Char. number range  |        UTF-8 octet sequence
      (hexadecimal)    |              (binary)
   --------------------+---------------------------------------------
   0000 0000-0000 007F | 0xxxxxxx
   0000 0080-0000 07FF | 110xxxxx 10xxxxxx
   0000 0800-0000 FFFF | 1110xxxx 10xxxxxx 10xxxxxx
   0001 0000-0010 FFFF | 11110xxx 10xxxxxx 10xxxxxx 10xxxxxx
Given an array of integers representing the data, return whether it is a valid utf-8 encoding.

Note:
The input is an array of integers. Only the least significant 8 bits of each integer is used to store the data. This means each integer represents only 1 byte of data.

Example 1:

data = [197, 130, 1], which represents the octet sequence: 11000101 10000010 00000001.

Return true.
It is a valid utf-8 encoding for a 2-bytes character followed by a 1-byte character.
Example 2:

data = [235, 140, 4], which represented the octet sequence: 11101011 10001100 00000100.

Return false.
The first 3 bits are all one's and the 4th bit is 0 means it is a 3-bytes character.
The next byte is a continuation byte which starts with 10 and that's correct.
But the second continuation byte does not start with 10, so it is invalid.
 */
public class Solution {

    public bool ValidUtf8(int[] data)
    {
        int count = 0;
        foreach (var val in data)
        {
            if (count == 0)
            {
                if ((val >> 5) == 6) count = 1;
                else if ((val >> 4) == 14) count = 2;
                else if ((val >> 3) == 30) count = 3;
                else if ((val >> 7) > 0) return false;
                continue;
            }
            if ((val >> 6) != 2) return false;
            count--;
        }
        return true;
    }

    private int GetLen(int x)
    {
        if ((x & 0xf8) == 0xf0) return 4;
        else if ((x & 0xf0) == 0xe0) return 3;
        else if ((x & 0xe0) == 0xc0) return 2;
        else if ((x & 0x80) == 0x00) return 1;
        else return -1;
    }

    public bool ValidUtf8_a(int[] data) {
        if (data.Length == 0)
            return true;
        // if (data.Length > 4)
        //     return false;
        string fir = Convert.ToString(data[0], 2);
        if (fir.Length < 8)
        {
            return true;
        }
        else
        {
            if (data.Length == 1)
                return false;
        }

        int n = 0;
        for (int i = 0; i < 8; i++)
        {
            if (fir[i] == '1')
                n++;
            else
                break;
        }

        if (n > data.Length)
            return false;

        for (int i = 1; i < n; i++)
        {
            string tem = Convert.ToString(data[i], 2);
            if (tem.Length < 8 || !tem.StartsWith("10"))
                return false;
        }

        return true;
    }
}

