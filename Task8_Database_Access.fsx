// Task 8: Database Access
// This file demonstrates connecting to relational (SQL Server) and NoSQL (MongoDB) databases

// NOTE: To run this code, you need to install required packages:
// dotnet add package System.Data.SqlClient
// dotnet add package MongoDB.Driver

open System
open System.Data.SqlClient
open MongoDB.Driver
open MongoDB.Bson

printfn "=== Task 8: Database Access ==="
printfn ""

// ===== SQL SERVER (RELATIONAL DATABASE) =====
printfn "--- SQL Server (Relational Database) ---"
printfn ""

// Connection string (update with your actual server details)
let sqlConnectionString = "Server=localhost;Database=FSharpDemo;Integrated Security=true;TrustServerCertificate=true"

// Function to execute SQL commands
let executeSqlCommand connectionString commandText =
    try
        use connection = new SqlConnection(connectionString)
        connection.Open()
        use command = new SqlCommand(commandText, connection)
        command.ExecuteNonQuery() |> ignore
        printfn "  ✓ SQL command executed successfully"
        Ok ()
    with ex ->
        printfn "  ✗ Error: %s" ex.Message
        Error ex.Message

// Function to create database (if not exists)
let createDatabase() =
    let masterConnectionString = "Server=localhost;Database=master;Integrated Security=true;TrustServerCertificate=true"
    let createDbCommand = """
        IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'FSharpDemo')
        BEGIN
            CREATE DATABASE FSharpDemo
        END
    """
    printfn "Creating database (if not exists)..."
    executeSqlCommand masterConnectionString createDbCommand

// Function to create table
let createUsersTable() =
    let createTableCommand = """
        IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Users' AND xtype='U')
        BEGIN
            CREATE TABLE Users (
                Id INT PRIMARY KEY IDENTITY(1,1),
                Name NVARCHAR(100) NOT NULL,
                Email NVARCHAR(100) NOT NULL UNIQUE,
                Age INT,
                CreatedAt DATETIME DEFAULT GETDATE()
            )
        END
    """
    printfn "Creating Users table..."
    executeSqlCommand sqlConnectionString createTableCommand

// INSERT operation
let insertUser name email age =
    try
        use connection = new SqlConnection(sqlConnectionString)
        connection.Open()
        
        let commandText = "INSERT INTO Users (Name, Email, Age) VALUES (@Name, @Email, @Age)"
        use command = new SqlCommand(commandText, connection)
        
        command.Parameters.AddWithValue("@Name", name) |> ignore
        command.Parameters.AddWithValue("@Email", email) |> ignore
        command.Parameters.AddWithValue("@Age", age) |> ignore
        
        command.ExecuteNonQuery() |> ignore
        printfn "  ✓ Inserted: %s (%s)" name email
        Ok ()
    with ex ->
        printfn "  ✗ Error inserting user: %s" ex.Message
        Error ex.Message

// SELECT operation
let getAllUsers() =
    try
        use connection = new SqlConnection(sqlConnectionString)
        connection.Open()
        
        let commandText = "SELECT Id, Name, Email, Age, CreatedAt FROM Users"
        use command = new SqlCommand(commandText, connection)
        use reader = command.ExecuteReader()
        
        let users = ResizeArray<_>()
        while reader.Read() do
            let user = {|
                Id = reader.GetInt32(0)
                Name = reader.GetString(1)
                Email = reader.GetString(2)
                Age = reader.GetInt32(3)
                CreatedAt = reader.GetDateTime(4)
            |}
            users.Add(user)
        
        Ok (users |> Seq.toList)
    with ex ->
        printfn "  ✗ Error reading users: %s" ex.Message
        Error ex.Message

// UPDATE operation
let updateUserEmail userId newEmail =
    try
        use connection = new SqlConnection(sqlConnectionString)
        connection.Open()
        
        let commandText = "UPDATE Users SET Email = @Email WHERE Id = @Id"
        use command = new SqlCommand(commandText, connection)
        
        command.Parameters.AddWithValue("@Email", newEmail) |> ignore
        command.Parameters.AddWithValue("@Id", userId) |> ignore
        
        let rowsAffected = command.ExecuteNonQuery()
        if rowsAffected > 0 then
            printfn "  ✓ Updated user ID %d with new email: %s" userId newEmail
            Ok ()
        else
            printfn "  ✗ User ID %d not found" userId
            Error "User not found"
    with ex ->
        printfn "  ✗ Error updating user: %s" ex.Message
        Error ex.Message

// DELETE operation
let deleteUser userId =
    try
        use connection = new SqlConnection(sqlConnectionString)
        connection.Open()
        
        let commandText = "DELETE FROM Users WHERE Id = @Id"
        use command = new SqlCommand(commandText, connection)
        
        command.Parameters.AddWithValue("@Id", userId) |> ignore
        
        let rowsAffected = command.ExecuteNonQuery()
        if rowsAffected > 0 then
            printfn "  ✓ Deleted user ID %d" userId
            Ok ()
        else
            printfn "  ✗ User ID %d not found" userId
            Error "User not found"
    with ex ->
        printfn "  ✗ Error deleting user: %s" ex.Message
        Error ex.Message

// Demonstrate SQL Server operations
printfn "SQL Server CRUD Operations:"
printfn ""

// Note: These operations will only work if SQL Server is installed and running
printfn "NOTE: SQL Server operations require SQL Server to be installed and running."
printfn "If you don't have SQL Server, the operations will show error messages."
printfn ""

// Uncomment the following lines if you have SQL Server running:
(*
createDatabase() |> ignore
createUsersTable() |> ignore

printfn "INSERT operations:"
insertUser "Alice Johnson" "alice@example.com" 30 |> ignore
insertUser "Bob Smith" "bob@example.com" 25 |> ignore
insertUser "Charlie Brown" "charlie@example.com" 35 |> ignore
printfn ""

printfn "SELECT operation:"
match getAllUsers() with
| Ok users ->
    printfn "  Users in database:"
    for user in users do
        printfn "    ID: %d, Name: %s, Email: %s, Age: %d" user.Id user.Name user.Email user.Age
| Error msg -> printfn "  Error: %s" msg
printfn ""

printfn "UPDATE operation:"
updateUserEmail 1 "alice.johnson@newdomain.com" |> ignore
printfn ""

printfn "DELETE operation:"
deleteUser 3 |> ignore
printfn ""

printfn "SELECT after modifications:"
match getAllUsers() with
| Ok users ->
    printfn "  Remaining users:"
    for user in users do
        printfn "    ID: %d, Name: %s, Email: %s, Age: %d" user.Id user.Name user.Email user.Age
| Error msg -> printfn "  Error: %s" msg
printfn ""
*)

printfn "Example SQL operations (simulated):"
printfn "  ✓ Database 'FSharpDemo' created"
printfn "  ✓ Table 'Users' created"
printfn "  ✓ Inserted: Alice Johnson (alice@example.com)"
printfn "  ✓ Inserted: Bob Smith (bob@example.com)"
printfn "  ✓ Inserted: Charlie Brown (charlie@example.com)"
printfn "  ✓ Selected all users (3 records)"
printfn "  ✓ Updated user ID 1 email"
printfn "  ✓ Deleted user ID 3"
printfn ""

// ===== MONGODB (NoSQL DATABASE) =====
printfn "--- MongoDB (NoSQL Database) ---"
printfn ""

// MongoDB connection string (update with your actual MongoDB details)
let mongoConnectionString = "mongodb://localhost:27017"
let databaseName = "FSharpDemo"
let collectionName = "Products"

// Product type for MongoDB
type Product = {
    Id: ObjectId
    Name: string
    Category: string
    Price: float
    InStock: bool
    Tags: string list
}

// Function to get MongoDB collection
let getMongoCollection() =
    try
        let client = MongoClient(mongoConnectionString)
        let database = client.GetDatabase(databaseName)
        let collection = database.GetCollection<BsonDocument>(collectionName)
        Ok collection
    with ex ->
        printfn "  ✗ MongoDB connection error: %s" ex.Message
        Error ex.Message

// INSERT operation (MongoDB)
let insertProduct name category price inStock tags =
    try
        match getMongoCollection() with
        | Ok collection ->
            let document = BsonDocument([
                BsonElement("Name", BsonString(name))
                BsonElement("Category", BsonString(category))
                BsonElement("Price", BsonDouble(price))
                BsonElement("InStock", BsonBoolean(inStock))
                BsonElement("Tags", BsonArray(tags |> List.map BsonString))
            ])
            
            collection.InsertOne(document)
            printfn "  ✓ Inserted product: %s" name
            Ok ()
        | Error msg -> Error msg
    with ex ->
        printfn "  ✗ Error inserting product: %s" ex.Message
        Error ex.Message

// SELECT operation (MongoDB)
let getAllProducts() =
    try
        match getMongoCollection() with
        | Ok collection ->
            let documents = collection.Find(BsonDocument()).ToList()
            let products = ResizeArray<_>()
            
            for doc in documents do
                let product = {|
                    Id = doc.["_id"].AsObjectId.ToString()
                    Name = doc.["Name"].AsString
                    Category = doc.["Category"].AsString
                    Price = doc.["Price"].AsDouble
                    InStock = doc.["InStock"].AsBoolean
                    Tags = [for tag in doc.["Tags"].AsBsonArray -> tag.AsString]
                |}
                products.Add(product)
            
            Ok (products |> Seq.toList)
        | Error msg -> Error msg
    with ex ->
        printfn "  ✗ Error reading products: %s" ex.Message
        Error ex.Message

// UPDATE operation (MongoDB)
let updateProductPrice name newPrice =
    try
        match getMongoCollection() with
        | Ok collection ->
            let filter = Builders<BsonDocument>.Filter.Eq("Name", BsonString(name))
            let update = Builders<BsonDocument>.Update.Set("Price", BsonDouble(newPrice))
            
            let result = collection.UpdateOne(filter, update)
            if result.ModifiedCount > 0L then
                printfn "  ✓ Updated price for %s to $%.2f" name newPrice
                Ok ()
            else
                printfn "  ✗ Product %s not found" name
                Error "Product not found"
        | Error msg -> Error msg
    with ex ->
        printfn "  ✗ Error updating product: %s" ex.Message
        Error ex.Message

// DELETE operation (MongoDB)
let deleteProduct name =
    try
        match getMongoCollection() with
        | Ok collection ->
            let filter = Builders<BsonDocument>.Filter.Eq("Name", BsonString(name))
            let result = collection.DeleteOne(filter)
            
            if result.DeletedCount > 0L then
                printfn "  ✓ Deleted product: %s" name
                Ok ()
            else
                printfn "  ✗ Product %s not found" name
                Error "Product not found"
        | Error msg -> Error msg
    with ex ->
        printfn "  ✗ Error deleting product: %s" ex.Message
        Error ex.Message

// Query with filters (MongoDB)
let findProductsByCategory category =
    try
        match getMongoCollection() with
        | Ok collection ->
            let filter = Builders<BsonDocument>.Filter.Eq("Category", BsonString(category))
            let documents = collection.Find(filter).ToList()
            
            let products = [
                for doc in documents ->
                    doc.["Name"].AsString
            ]
            Ok products
        | Error msg -> Error msg
    with ex ->
        printfn "  ✗ Error querying products: %s" ex.Message
        Error ex.Message

// Demonstrate MongoDB operations
printfn "MongoDB CRUD Operations:"
printfn ""

printfn "NOTE: MongoDB operations require MongoDB to be installed and running."
printfn "If you don't have MongoDB, the operations will show error messages."
printfn ""

// Uncomment the following lines if you have MongoDB running:
(*
printfn "INSERT operations:"
insertProduct "Laptop" "Electronics" 999.99 true ["computer"; "portable"; "work"] |> ignore
insertProduct "Mouse" "Electronics" 29.99 true ["computer"; "accessory"] |> ignore
insertProduct "Desk" "Furniture" 299.99 true ["office"; "workspace"] |> ignore
insertProduct "Chair" "Furniture" 199.99 false ["office"; "seating"] |> ignore
printfn ""

printfn "SELECT operation:"
match getAllProducts() with
| Ok products ->
    printfn "  Products in database:"
    for product in products do
        printfn "    %s ($%.2f) - %s [%s]" 
            product.Name product.Price product.Category 
            (String.concat ", " product.Tags)
| Error msg -> printfn "  Error: %s" msg
printfn ""

printfn "UPDATE operation:"
updateProductPrice "Laptop" 899.99 |> ignore
printfn ""

printfn "QUERY with filter:"
match findProductsByCategory "Electronics" with
| Ok products ->
    printfn "  Electronics products:"
    for product in products do
        printfn "    - %s" product
| Error msg -> printfn "  Error: %s" msg
printfn ""

printfn "DELETE operation:"
deleteProduct "Mouse" |> ignore
printfn ""
*)

printfn "Example MongoDB operations (simulated):"
printfn "  ✓ Connected to MongoDB"
printfn "  ✓ Inserted: Laptop (Electronics, $999.99)"
printfn "  ✓ Inserted: Mouse (Electronics, $29.99)"
printfn "  ✓ Inserted: Desk (Furniture, $299.99)"
printfn "  ✓ Inserted: Chair (Furniture, $199.99)"
printfn "  ✓ Selected all products (4 records)"
printfn "  ✓ Updated Laptop price to $899.99"
printfn "  ✓ Queried Electronics category (2 products)"
printfn "  ✓ Deleted Mouse product"
printfn ""

// ===== COMPARISON: SQL vs NoSQL =====
printfn "--- SQL vs NoSQL Comparison ---"
printfn ""
printfn "SQL Server (Relational):"
printfn "  + Strong ACID guarantees"
printfn "  + Complex queries with JOINs"
printfn "  + Schema enforcement"
printfn "  + Better for structured data"
printfn "  - Less flexible schema"
printfn "  - Vertical scaling primarily"
printfn ""
printfn "MongoDB (NoSQL):"
printfn "  + Flexible schema"
printfn "  + Easy horizontal scaling"
printfn "  + Better for unstructured data"
printfn "  + Fast for simple queries"
printfn "  - Eventual consistency (by default)"
printfn "  - More complex for relational data"
printfn ""

printfn "=== Key Concepts ==="
printfn "1. SQL Server uses structured tables with fixed schemas"
printfn "2. MongoDB uses flexible JSON-like documents"
printfn "3. F# provides strong typing for database operations"
printfn "4. Use parameterized queries to prevent SQL injection"
printfn "5. Both databases support full CRUD operations"
printfn "6. Connection handling with 'use' ensures proper disposal"
printfn "7. Error handling with Result types provides safety"
printfn "8. Choose database based on data structure and requirements"
