DROP TABLE Products;

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName NVARCHAR(100),
    Category NVARCHAR(50),
    Price DECIMAL(10, 2)
);

INSERT INTO Products (ProductID, ProductName, Category, Price) VALUES
(1, 'iPhone 14', 'Electronics', 999.99),
(2, 'Samsung Galaxy S23', 'Electronics', 899.99),
(3, 'MacBook Air', 'Electronics', 1249.99),
(4, 'Sony Headphones', 'Electronics', 199.99),
(5, 'Nike Shoes', 'Footwear', 129.99),
(6, 'Adidas Sneakers', 'Footwear', 109.99),
(7, 'Puma Trainers', 'Footwear', 89.99),
(8, 'Redmi Note 12', 'Electronics', 299.99),
(9, 'Bata Slippers', 'Footwear', 29.99),
(10, 'Dell XPS 13', 'Electronics', 999.99);

SELECT 
    ProductID,
    ProductName,
    Category,
    Price,
    ROW_NUMBER() OVER (PARTITION BY Category ORDER BY Price DESC) AS RowNum
FROM 
    Products;

    SELECT 
    ProductID,
    ProductName,
    Category,
    Price,
    ROW_NUMBER() OVER (PARTITION BY Category ORDER BY Price DESC) AS RowNum,
    RANK()       OVER (PARTITION BY Category ORDER BY Price DESC) AS RankNum,
    DENSE_RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS DenseRankNum
FROM 
    Products;

    WITH RankedProducts AS (
    SELECT 
        ProductID,
        ProductName,
        Category,
        Price,
        ROW_NUMBER() OVER (PARTITION BY Category ORDER BY Price DESC) AS RowNum
    FROM 
        Products
)
SELECT 
    ProductID,
    ProductName,
    Category,
    Price,
    RowNum
FROM 
    RankedProducts
WHERE 
    RowNum <= 3;

    WITH RankedProducts AS (
    SELECT 
        ProductID,
        ProductName,
        Category,
        Price,
        RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS RankNum
    FROM 
        Products
)
SELECT 
    ProductID,
    ProductName,
    Category,
    Price,
    RankNum
FROM 
    RankedProducts
WHERE 
    RankNum <= 3;
