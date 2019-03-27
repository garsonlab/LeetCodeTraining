--
-- @lc app=leetcode id=183 lang=mysql
--
-- [183] Customers Who Never Order
--
-- https://leetcode.com/problems/customers-who-never-order/description/
--
-- database
-- Easy (43.31%)
-- Total Accepted:    93.6K
-- Total Submissions: 215.6K
-- Testcase Example:  '{"headers": {"Customers": ["Id", "Name"], "Orders": ["Id", "CustomerId"]}, "rows": {"Customers": [[1, "Joe"], [2, "Henry"], [3, "Sam"], [4, "Max"]], "Orders": [[1, 3], [2, 1]]}}'
--
-- Suppose that a website contains two tables, the Customers table and the
-- Orders table. Write a SQL query to find all customers who never order
-- anything.
-- 
-- Table: Customers.
-- 
-- 
-- +----+-------+
-- | Id | Name  |
-- +----+-------+
-- | 1  | Joe   |
-- | 2  | Henry |
-- | 3  | Sam   |
-- | 4  | Max   |
-- +----+-------+
-- 
-- 
-- Table: Orders.
-- 
-- 
-- +----+------------+
-- | Id | CustomerId |
-- +----+------------+
-- | 1  | 3          |
-- | 2  | 1          |
-- +----+------------+
-- 
-- 
-- Using the above tables as example, return the following:
-- 
-- 
-- +-----------+
-- | Customers |
-- +-----------+
-- | Henry     |
-- | Max       |
-- +-----------+
-- 
-- 
--
# Write your MySQL query statement below
-- select Name form
-- 	(select * from Customers 
-- 	where (select count(1) as num from Orders where Orders.CustomerId  = Customers.Id) = 0)
SELECT a.Name as Customers FROM
	(SELECT * FROM Customers WHERE Customers.Id NOT IN
	(SELECT CustomerId FROM Orders)) a


-- √ Accepted
--   √ 12/12 cases passed (264 ms)
--   √ Your runtime beats 51.69 % of mysql submissions
-- [WARN] Failed to get memory percentile.



