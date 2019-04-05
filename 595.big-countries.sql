--
-- @lc app=leetcode id=595 lang=mysql
--
-- [595] Big Countries
--
-- https://leetcode.com/problems/big-countries/description/
--
-- database
-- Easy (73.22%)
-- Total Accepted:    98.8K
-- Total Submissions: 134.8K
-- Testcase Example:  '{"headers": {"World": ["name", "continent",\t"area",\t"population", "gdp"]}, "rows": {"World": [["Afghanistan", "Asia", 652230, 25500100, 20343000000], ["Albania", "Europe", 28748, 2831741, 12960000000], ["Algeria", "Africa", 2381741, 37100000, 188681000000], ["Andorra", "Europe", 468, 78115,\t3712000000], ["Angola", "Africa", 1246700, 20609294, 100990000000]]}}'
--
-- There is a table World
-- 
-- 
-- +-----------------+------------+------------+--------------+---------------+
-- | name            | continent  | area       | population   | gdp           |
-- +-----------------+------------+------------+--------------+---------------+
-- | Afghanistan     | Asia       | 652230     | 25500100     | 20343000      |
-- | Albania         | Europe     | 28748      | 2831741      | 12960000      |
-- | Algeria         | Africa     | 2381741    | 37100000     | 188681000     |
-- | Andorra         | Europe     | 468        | 78115        | 3712000       |
-- | Angola          | Africa     | 1246700    | 20609294     | 100990000     |
-- 
-- +-----------------+------------+------------+--------------+---------------+
-- 
-- 
-- A country is big if it has an area of bigger than 3 million square km or a
-- population of more than 25 million.
-- 
-- Write a SQL solution to output big countries' name, population and area.
-- 
-- For example, according to the above table, we should output:
-- 
-- 
-- +--------------+-------------+--------------+
-- | name         | population  | area         |
-- +--------------+-------------+--------------+
-- | Afghanistan  | 25500100    | 652230       |
-- | Algeria      | 37100000    | 2381741      |
-- +--------------+-------------+--------------+
-- 
-- 
-- 
-- 
--
# Write your MySQL query statement below

SELECT name, population, area FROM World WHERE population > 25000000 OR area > 3000000

-- √ Accepted
--   √ 4/4 cases passed (209 ms)
--   √ Your runtime beats 64.38 % of mysql submissions
-- [WARN] Failed to get memory percentile.


