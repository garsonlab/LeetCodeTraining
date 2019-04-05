--
-- @lc app=leetcode id=620 lang=mysql
--
-- [620] Not Boring Movies
--
-- https://leetcode.com/problems/not-boring-movies/description/
--
-- database
-- Easy (61.43%)
-- Total Accepted:    56.3K
-- Total Submissions: 91.3K
-- Testcase Example:  '{"headers":{"cinema":["id", "movie", "description", "rating"]},"rows":{"cinema":[[1, "War", "great 3D", 8.9], [2, "Science", "fiction", 8.5], [3, "irish", "boring", 6.2], [4, "Ice song", "Fantacy", 8.6], [5, "House card", "Interesting", 9.1]]}}'
--
-- X city opened a new cinema, many people would like to go to this cinema. The
-- cinema also gives out a poster indicating the movies’ ratings and
-- descriptions.
-- Please write a SQL query to output movies with an odd numbered ID and a
-- description that is not 'boring'. Order the result by rating.
-- 
-- 
-- 
-- For example, table cinema:
-- 
-- 
-- +---------+-----------+--------------+-----------+
-- |   id    | movie     |  description |  rating   |
-- +---------+-----------+--------------+-----------+
-- |   1     | War       |   great 3D   |   8.9     |
-- |   2     | Science   |   fiction    |   8.5     |
-- |   3     | irish     |   boring     |   6.2     |
-- |   4     | Ice song  |   Fantacy    |   8.6     |
-- |   5     | House card|   Interesting|   9.1     |
-- +---------+-----------+--------------+-----------+
-- 
-- For the example above, the output should be:
-- 
-- 
-- +---------+-----------+--------------+-----------+
-- |   id    | movie     |  description |  rating   |
-- +---------+-----------+--------------+-----------+
-- |   5     | House card|   Interesting|   9.1     |
-- |   1     | War       |   great 3D   |   8.9     |
-- +---------+-----------+--------------+-----------+
-- 
-- 
-- 
-- 
--
# Write your MySQL query statement below

select c.id, c.movie, c.description,c.rating from cinema c 
where c.description!='boring' and mod(c.id,2)=1 order by c.rating desc

-- √ Accepted
--   √ 8/8 cases passed (116 ms)
--   √ Your runtime beats 95.86 % of mysql submissions
-- [WARN] Failed to get memory percentile.

