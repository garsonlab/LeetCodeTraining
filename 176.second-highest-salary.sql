--
-- @lc app=leetcode id=176 lang=mysql
--
-- [176] Second Highest Salary
--
-- https://leetcode.com/problems/second-highest-salary/description/
--
-- database
-- Easy (26.38%)
-- Total Accepted:    118K
-- Total Submissions: 445.8K
-- Testcase Example:  '{"headers": {"Employee": ["Id", "Salary"]}, "rows": {"Employee": [[1, 100], [2, 200], [3, 300]]}}'
--
-- Write a SQL query to get the second highest salary from the Employee
-- table.
-- 
-- 
-- +----+--------+
-- | Id | Salary |
-- +----+--------+
-- | 1  | 100    |
-- | 2  | 200    |
-- | 3  | 300    |
-- +----+--------+
-- 
-- 
-- For example, given the above Employee table, the query should return 200 as
-- the second highest salary. If there is no second highest salary, then the
-- query should return null.
-- 
-- 
-- +---------------------+
-- | SecondHighestSalary |
-- +---------------------+
-- | 200                 |
-- +---------------------+
-- 
-- 
--
# Write your MySQL query statement below

-- SELECT TOP 1 Salary FROM
-- (SELECT TOP 2 Salary FROM Employee ORDER BY Salary DESC)[table]
-- ORDER BY Salary ASC

-- SELECT * FROM
-- (SELECT TOP 2 Salary FROM Employee ORDER BY Salary DESC)
-- WHERE ROWNUM = 2
SELECT IFNULL(
(SELECT DISTINCT Salary FROM Employee ORDER BY Salary DESC LIMIT 1,1), null) AS SecondHighestSalary

-- √ Accepted
--   √ 7/7 cases passed (136 ms)
--   √ Your runtime beats 57.47 % of mysql submissions
-- [WARN] Failed to get memory percentile.

