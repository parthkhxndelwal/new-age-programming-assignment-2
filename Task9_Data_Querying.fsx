// Task 9: Data Querying
// This file demonstrates F# query expressions for data retrieval and manipulation

open System
open System.Linq

printfn "=== Task 9: Data Querying ==="
printfn ""

// Sample data models
type Customer = {
    Id: int
    Name: string
    Email: string
    City: string
    Country: string
    Age: int
}

type Order = {
    OrderId: int
    CustomerId: int
    ProductName: string
    Quantity: int
    Price: float
    OrderDate: DateTime
}

type Product = {
    ProductId: int
    Name: string
    Category: string
    Price: float
    Stock: int
}

// Sample data
let customers = [
    { Id = 1; Name = "Alice Johnson"; Email = "alice@email.com"; City = "New York"; Country = "USA"; Age = 30 }
    { Id = 2; Name = "Bob Smith"; Email = "bob@email.com"; City = "London"; Country = "UK"; Age = 25 }
    { Id = 3; Name = "Charlie Brown"; Email = "charlie@email.com"; City = "Paris"; Country = "France"; Age = 35 }
    { Id = 4; Name = "Diana Prince"; Email = "diana@email.com"; City = "New York"; Country = "USA"; Age = 28 }
    { Id = 5; Name = "Eve Wilson"; Email = "eve@email.com"; City = "Tokyo"; Country = "Japan"; Age = 32 }
    { Id = 6; Name = "Frank Miller"; Email = "frank@email.com"; City = "London"; Country = "UK"; Age = 45 }
]

let orders = [
    { OrderId = 101; CustomerId = 1; ProductName = "Laptop"; Quantity = 1; Price = 999.99; OrderDate = DateTime(2025, 11, 1) }
    { OrderId = 102; CustomerId = 2; ProductName = "Mouse"; Quantity = 2; Price = 29.99; OrderDate = DateTime(2025, 11, 5) }
    { OrderId = 103; CustomerId = 1; ProductName = "Keyboard"; Quantity = 1; Price = 79.99; OrderDate = DateTime(2025, 11, 10) }
    { OrderId = 104; CustomerId = 3; ProductName = "Monitor"; Quantity = 2; Price = 299.99; OrderDate = DateTime(2025, 11, 12) }
    { OrderId = 105; CustomerId = 2; ProductName = "Laptop"; Quantity = 1; Price = 999.99; OrderDate = DateTime(2025, 11, 15) }
    { OrderId = 106; CustomerId = 4; ProductName = "Mouse"; Quantity = 3; Price = 29.99; OrderDate = DateTime(2025, 11, 18) }
    { OrderId = 107; CustomerId = 1; ProductName = "Headphones"; Quantity = 1; Price = 149.99; OrderDate = DateTime(2025, 11, 20) }
]

let products = [
    { ProductId = 1; Name = "Laptop"; Category = "Electronics"; Price = 999.99; Stock = 15 }
    { ProductId = 2; Name = "Mouse"; Category = "Electronics"; Price = 29.99; Stock = 50 }
    { ProductId = 3; Name = "Keyboard"; Category = "Electronics"; Price = 79.99; Stock = 30 }
    { ProductId = 4; Name = "Monitor"; Category = "Electronics"; Price = 299.99; Stock = 20 }
    { ProductId = 5; Name = "Desk"; Category = "Furniture"; Price = 399.99; Stock = 10 }
    { ProductId = 6; Name = "Chair"; Category = "Furniture"; Price = 199.99; Stock = 25 }
    { ProductId = 7; Name = "Headphones"; Category = "Electronics"; Price = 149.99; Stock = 40 }
]

// ===== FILTERING =====
printfn "--- Filtering Operations ---"
printfn ""

// Example 1: Filter customers by country
let usCustomers = 
    query {
        for customer in customers do
        where (customer.Country = "USA")
        select customer
    } |> Seq.toList

printfn "Customers from USA:"
for customer in usCustomers do
    printfn "  %s - %s" customer.Name customer.City
printfn ""

// Example 2: Filter with multiple conditions
let youngUKCustomers =
    query {
        for customer in customers do
        where (customer.Country = "UK" && customer.Age < 30)
        select customer
    } |> Seq.toList

printfn "UK customers under 30:"
for customer in youngUKCustomers do
    printfn "  %s (Age: %d)" customer.Name customer.Age
printfn ""

// Example 3: Filter orders above certain amount
let largeOrders =
    query {
        for order in orders do
        where (order.Price * float order.Quantity > 500.0)
        select order
    } |> Seq.toList

printfn "Orders over $500:"
for order in largeOrders do
    let total = order.Price * float order.Quantity
    printfn "  Order #%d: %s (Qty: %d) - Total: $%.2f" 
        order.OrderId order.ProductName order.Quantity total
printfn ""

// ===== SORTING =====
printfn "--- Sorting Operations ---"
printfn ""

// Example 4: Sort customers by age
let customersByAge =
    query {
        for customer in customers do
        sortBy customer.Age
        select customer
    } |> Seq.toList

printfn "Customers sorted by age:"
for customer in customersByAge do
    printfn "  %s - Age: %d" customer.Name customer.Age
printfn ""

// Example 5: Sort in descending order
let customersByAgeDesc =
    query {
        for customer in customers do
        sortByDescending customer.Age
        select customer
    } |> Seq.toList

printfn "Customers sorted by age (descending):"
for customer in customersByAgeDesc do
    printfn "  %s - Age: %d" customer.Name customer.Age
printfn ""

// Example 6: Multiple sorting criteria
let ordersSorted =
    query {
        for order in orders do
        sortBy order.CustomerId
        thenByDescending order.Price
        select order
    } |> Seq.toList

printfn "Orders sorted by customer, then by price (desc):"
for order in ordersSorted do
    printfn "  Customer %d: Order #%d - %s ($%.2f)" 
        order.CustomerId order.OrderId order.ProductName order.Price
printfn ""

// ===== GROUPING =====
printfn "--- Grouping Operations ---"
printfn ""

// Example 7: Group orders by customer
let ordersByCustomer =
    query {
        for order in orders do
        groupBy order.CustomerId into g
        select (g.Key, g)
    } |> Seq.toList

printfn "Orders grouped by customer:"
for (customerId, customerOrders) in ordersByCustomer do
    let customer = customers |> List.find (fun c -> c.Id = customerId)
    printfn "  %s (ID: %d):" customer.Name customerId
    for order in customerOrders do
        printfn "    - Order #%d: %s" order.OrderId order.ProductName
printfn ""

// Example 8: Group products by category
let productsByCategory =
    query {
        for product in products do
        groupBy product.Category into g
        select (g.Key, g)
    } |> Seq.toList

printfn "Products grouped by category:"
for (category, categoryProducts) in productsByCategory do
    printfn "  %s:" category
    for product in categoryProducts do
        printfn "    - %s ($%.2f, Stock: %d)" product.Name product.Price product.Stock
printfn ""

// Example 9: Group and aggregate
let salesByCustomer =
    query {
        for order in orders do
        groupBy order.CustomerId into g
        select (g.Key, query { for o in g do sumBy (o.Price * float o.Quantity) })
    } |> Seq.toList

printfn "Total sales by customer:"
for (customerId, total) in salesByCustomer do
    let customer = customers |> List.find (fun c -> c.Id = customerId)
    printfn "  %s: $%.2f" customer.Name total
printfn ""

// ===== JOINING =====
printfn "--- Joining Operations ---"
printfn ""

// Example 10: Inner join - Orders with customer details
let ordersWithCustomers =
    query {
        for order in orders do
        join customer in customers on (order.CustomerId = customer.Id)
        select (customer.Name, order.ProductName, order.Quantity, order.Price)
    } |> Seq.toList

printfn "Orders with customer details (Inner Join):"
for (name, product, qty, price) in ordersWithCustomers do
    printfn "  %s ordered %d x %s ($%.2f each)" name qty product price
printfn ""

// Example 11: Group join - Customers with their orders
let customersWithOrders =
    query {
        for customer in customers do
        groupJoin order in orders on (customer.Id = order.CustomerId) into customerOrders
        select (customer, customerOrders)
    } |> Seq.toList

printfn "Customers with their order count (Group Join):"
for (customer, customerOrders) in customersWithOrders do
    let orderCount = Seq.length customerOrders
    let totalSpent = customerOrders |> Seq.sumBy (fun o -> o.Price * float o.Quantity)
    printfn "  %s: %d orders, Total: $%.2f" customer.Name orderCount totalSpent
printfn ""

// Example 12: Left join - All customers, with or without orders
let allCustomersWithOrderCount =
    query {
        for customer in customers do
        leftOuterJoin order in orders on (customer.Id = order.CustomerId) into customerOrders
        select (customer.Name, Seq.length customerOrders)
    } |> Seq.toList

printfn "All customers with order count (Left Join):"
for (name, count) in allCustomersWithOrderCount do
    printfn "  %s: %d orders" name count
printfn ""

// ===== AGGREGATION =====
printfn "--- Aggregation Operations ---"
printfn ""

// Example 13: Count
let totalCustomers = query { for c in customers do count }
let totalOrders = query { for o in orders do count }

printfn "Counts:"
printfn "  Total customers: %d" totalCustomers
printfn "  Total orders: %d" totalOrders
printfn ""

// Example 14: Sum
let totalRevenue = 
    query {
        for order in orders do
        sumBy (order.Price * float order.Quantity)
    }

printfn "Total revenue: $%.2f" totalRevenue
printfn ""

// Example 15: Average
let avgCustomerAge =
    query {
        for customer in customers do
        averageBy (float customer.Age)
    }

let avgOrderValue =
    query {
        for order in orders do
        averageBy (order.Price * float order.Quantity)
    }

printfn "Averages:"
printfn "  Average customer age: %.1f years" avgCustomerAge
printfn "  Average order value: $%.2f" avgOrderValue
printfn ""

// Example 16: Min and Max
let youngestAge = query { for c in customers do minBy c.Age }
let oldestAge = query { for c in customers do maxBy c.Age }
let cheapestProduct = query { for p in products do minBy p.Price }
let mostExpensiveProduct = query { for p in products do maxBy p.Price }

printfn "Min/Max values:"
printfn "  Youngest customer age: %d" youngestAge
printfn "  Oldest customer age: %d" oldestAge
printfn "  Cheapest product: $%.2f" cheapestProduct
printfn "  Most expensive product: $%.2f" mostExpensiveProduct
printfn ""

// ===== PROJECTION =====
printfn "--- Projection (Select) Operations ---"
printfn ""

// Example 17: Select specific fields
let customerNames =
    query {
        for customer in customers do
        select customer.Name
    } |> Seq.toList

printfn "Customer names only:"
printfn "  %s" (String.concat ", " customerNames)
printfn ""

// Example 18: Project to anonymous type
let customerSummary =
    query {
        for customer in customers do
        select {| Name = customer.Name; Location = sprintf "%s, %s" customer.City customer.Country |}
    } |> Seq.toList

printfn "Customer summary:"
for summary in customerSummary do
    printfn "  %s from %s" summary.Name summary.Location
printfn ""

// ===== DISTINCT =====
printfn "--- Distinct Operations ---"
printfn ""

// Example 19: Get distinct cities
let distinctCities =
    query {
        for customer in customers do
        select customer.City
        distinct
    } |> Seq.toList

printfn "Distinct cities:"
printfn "  %s" (String.concat ", " distinctCities)
printfn ""

// Example 20: Get distinct countries
let distinctCountries =
    query {
        for customer in customers do
        select customer.Country
        distinct
    } |> Seq.toList

printfn "Distinct countries:"
printfn "  %s" (String.concat ", " distinctCountries)
printfn ""

// ===== PAGINATION =====
printfn "--- Pagination Operations ---"
printfn ""

// Example 21: Skip and Take
let page2Customers =
    query {
        for customer in customers do
        sortBy customer.Name
        skip 2
        take 2
        select customer
    } |> Seq.toList

printfn "Customers page 2 (skip 2, take 2):"
for customer in page2Customers do
    printfn "  %s" customer.Name
printfn ""

// ===== COMPLEX QUERIES =====
printfn "--- Complex Queries ---"
printfn ""

// Example 22: Multi-condition filter with aggregation
let highValueUSCustomers =
    query {
        for customer in customers do
        where (customer.Country = "USA")
        join order in orders on (customer.Id = order.CustomerId)
        groupBy customer.Id into g
        where (query { for o in g do sumBy (o.Price * float o.Quantity) } > 500.0)
        select (g.Key, query { for o in g do sumBy (o.Price * float o.Quantity) })
    } |> Seq.toList

printfn "US customers with orders over $500:"
for (customerId, total) in highValueUSCustomers do
    let customer = customers |> List.find (fun c -> c.Id = customerId)
    printfn "  %s: $%.2f" customer.Name total
printfn ""

// Example 23: Nested queries
let customersWithHighOrders =
    query {
        for customer in customers do
        where (query {
            for order in orders do
            where (order.CustomerId = customer.Id && order.Price > 100.0)
            exists
        })
        select customer
    } |> Seq.toList

printfn "Customers who placed orders over $100:"
for customer in customersWithHighOrders do
    printfn "  %s" customer.Name
printfn ""

// ===== USING LINQ METHODS =====
printfn "--- Using LINQ Methods (Alternative Syntax) ---"
printfn ""

// Example 24: Fluent LINQ syntax
let topExpensiveProducts =
    products
        .Where(fun p -> p.Category = "Electronics")
        .OrderByDescending(fun p -> p.Price)
        .Take(3)
        .Select(fun p -> p.Name)
        .ToList()

printfn "Top 3 most expensive electronics:"
for product in topExpensiveProducts do
    printfn "  %s" product
printfn ""

printfn "=== Key Concepts ==="
printfn "1. F# query expressions provide SQL-like syntax"
printfn "2. Filtering with 'where' clause"
printfn "3. Sorting with 'sortBy' and 'sortByDescending'"
printfn "4. Grouping with 'groupBy' for aggregations"
printfn "5. Joining with 'join', 'groupJoin', and 'leftOuterJoin'"
printfn "6. Aggregations: count, sum, average, min, max"
printfn "7. Projection with 'select' to transform data"
printfn "8. 'distinct' removes duplicates"
printfn "9. Pagination with 'skip' and 'take'"
printfn "10. Compatible with LINQ for .NET interoperability"
