SELECT 
    Products.Name AS Product, Categories.Name AS Category 
        FROM Products
    LEFT JOIN ProductsCategories ON Products.id = ProductsCategories.product_id
    LEFT JOIN Categories ON ProductsCategories.category_id = Categories.id