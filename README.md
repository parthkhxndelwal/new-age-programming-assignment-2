# F# Functional Programming - Complete Assignment

## 👨‍💻 Student Information
- **Assignment**: New Age Programming Languages - Assignment 02
- **Topic**: Mini Project: Exploring F# Syntax, Functional Programming, and Advanced Concepts
- **Course**: New Age Programming Languages

## 📋 Overview

This repository demonstrates a comprehensive exploration of F# programming language, covering functional programming concepts, object-oriented features, asynchronous programming, and database access. The project implements all 10 required tasks with practical, real-world examples.

## 🎯 Learning Objectives Covered

- ✅ F# syntax and functional programming concepts
- ✅ Various F# data types, variables, and operators
- ✅ Control flow (decision-making and loops)
- ✅ Functions (basic, recursive, higher-order, and currying)
- ✅ Strings, Options, and immutable data structures
- ✅ Pattern matching with records, tuples, and discriminated unions
- ✅ Asynchronous and parallel programming
- ✅ Object-oriented programming in F#
- ✅ Relational and NoSQL database access
- ✅ Data querying and transformations

## 📁 Project Structure

```
fsharp-functional-programming/
├── Task1_Syntax_Basics.fsx           # F# syntax, data types, operators
├── Task2_Control_Flow.fsx            # If-else, pattern matching, loops
├── Task3_Functions.fsx               # Basic, recursive, higher-order functions, currying
├── Task4_Strings_Options_Immutable.fsx  # String ops, Option type, immutable collections
├── Task5_Pattern_Matching.fsx        # Advanced pattern matching examples
├── Task6_Async_Parallel.fsx          # Async workflows and parallel programming
├── Task7_OOP.fsx                     # Classes, interfaces, inheritance, generics
├── Task8_Database_Access.fsx         # SQL Server and MongoDB integration
├── Task9_Data_Querying.fsx           # Query expressions, LINQ operations
├── RunAll.fsx                        # Master script to run all tasks
└── README.md                         # This file
```

## 🚀 Installation and Setup

### Prerequisites

1. **.NET SDK** (version 6.0 or later)
   - Download from: https://dotnet.microsoft.com/download
   - Verify installation: `dotnet --version`

2. **F# Interactive** (included with .NET SDK)
   - Verify: `dotnet fsi --version`

3. **Optional: Visual Studio Code with Ionide**
   - VS Code: https://code.visualstudio.com/
   - Ionide F# Extension: Search "Ionide-fsharp" in VS Code extensions

4. **For Database Tasks (Optional):**
   - **SQL Server**: SQL Server Express or LocalDB
   - **MongoDB**: MongoDB Community Edition

### Setup Steps

1. **Clone the repository:**
   ```bash
   git clone https://github.com/aastha-srivastava/fsharp-functional-programming.git
   cd fsharp-functional-programming
   ```

2. **Verify F# installation:**
   ```bash
   dotnet fsi
   ```
   Type `#quit;;` to exit

3. **Install database packages (if testing database tasks):**
   ```bash
   dotnet add package System.Data.SqlClient
   dotnet add package MongoDB.Driver
   ```

## ▶️ Running the Code

### Option 1: Run Individual Tasks

Run any task file using F# Interactive:

```bash
# Windows PowerShell
dotnet fsi Task1_Syntax_Basics.fsx
dotnet fsi Task2_Control_Flow.fsx
dotnet fsi Task3_Functions.fsx
# ... and so on
```

### Option 2: Run All Tasks

Execute the master script:

```bash
dotnet fsi RunAll.fsx
```

### Option 3: Using Visual Studio Code

1. Open the project folder in VS Code
2. Install Ionide-fsharp extension
3. Right-click on any `.fsx` file
4. Select "FSI: Send File"

## 📚 Task Descriptions

### Task 1: F# Syntax & Basics
**File:** `Task1_Syntax_Basics.fsx`

Demonstrates:
- Data types (int, float, string, bool, char)
- Variables (immutable by default)
- Operators (arithmetic, comparison, logical, pipe, composition)
- Tuples, Lists, Arrays
- Records and Discriminated Unions
- Key differences from traditional languages

**Key Concepts:**
- Immutability by default
- Type inference
- Expression-based syntax
- Whitespace significance

### Task 2: Control Flow
**File:** `Task2_Control_Flow.fsx`

Implements:
- If-then-else expressions
- Pattern matching with guards
- For loops with ranges
- While loops
- Recursion as alternative to loops

**Real-World Examples:**
- Grade calculator
- Ticket pricing system
- Weather advisory
- ATM transaction validator
- Stock price monitor

### Task 3: Functions
**File:** `Task3_Functions.fsx`

Covers:
- Basic functions
- Recursive functions (factorial, fibonacci, GCD)
- Higher-order functions (map, filter, fold)
- Currying and partial application
- Function composition
- Lambda expressions
- Memoization

**Key Features:**
- Functions as first-class values
- All functions are curried by default
- Tail recursion optimization

### Task 4: Strings, Options, and Immutable Data
**File:** `Task4_Strings_Options_Immutable.fsx`

Demonstrates:
- String operations (concatenation, slicing, splitting)
- Option type for null-safety
- Immutable lists, maps, sets
- Record types with immutable updates
- Sequences with lazy evaluation

**Benefits:**
- Thread-safe by default
- No defensive copying needed
- Predictable behavior

### Task 5: Pattern Matching
**File:** `Task5_Pattern_Matching.fsx`

Includes:
- Basic value matching
- Tuple pattern matching
- Record pattern matching
- Discriminated union matching
- List pattern matching
- Active patterns
- Nested pattern matching

**Examples:**
- Shape area calculations
- Payment processing
- Order status tracking
- Employee classification

### Task 6: Asynchronous & Parallel Programming
**File:** `Task6_Async_Parallel.fsx`

Implements:
- Async workflows
- Parallel operations (Async.Parallel)
- Task Parallel Library
- Parallel.For and Parallel.ForEach
- PLINQ
- Producer-Consumer pattern
- Cancellation tokens

**Scenarios:**
- File downloads
- Data processing pipelines
- Order processing
- Map-reduce operations

### Task 7: Object-Oriented Programming
**File:** `Task7_OOP.fsx`

Covers:
- Classes with constructors
- Inheritance and polymorphism
- Interfaces
- Abstract classes
- Properties and indexers
- Static members
- Operator overloading
- Events
- Generics
- Extension methods

**Features:**
- Full .NET interoperability
- Mix functional and OOP paradigms

### Task 8: Database Access
**File:** `Task8_Database_Access.fsx`

Demonstrates:
- SQL Server connection and CRUD operations
- MongoDB connection and operations
- Parameterized queries
- Error handling with Result types
- Resource management with `use`

**Operations:**
- CREATE, INSERT, SELECT, UPDATE, DELETE
- Comparison of SQL vs NoSQL

**Note:** Database operations are shown with examples. Actual execution requires database servers to be installed and running.

### Task 9: Data Querying
**File:** `Task9_Data_Querying.fsx`

Implements:
- Query expressions (SQL-like syntax)
- Filtering with `where`
- Sorting with `sortBy`
- Grouping with `groupBy`
- Joins (inner, group, left outer)
- Aggregations (count, sum, average, min, max)
- Projection with `select`
- Distinct values
- Pagination (skip, take)
- Complex nested queries

**Examples:**
- Customer and order analysis
- Product categorization
- Sales reporting

## 🎓 Key Concepts Summary

### Functional Programming Features
1. **Immutability by Default**: Values cannot be changed after creation
2. **First-Class Functions**: Functions as values, parameters, and return types
3. **Type Inference**: Automatic type deduction
4. **Pattern Matching**: Powerful structural matching
5. **Higher-Order Functions**: Functions that operate on functions
6. **Currying**: All functions are automatically curried

### Object-Oriented Features
1. **Classes and Objects**: Full OOP support
2. **Inheritance**: Base and derived classes
3. **Interfaces**: Contract-based programming
4. **Polymorphism**: Virtual and override methods
5. **Generics**: Type-safe reusable components

### Advanced Features
1. **Async Workflows**: Clean asynchronous programming
2. **Parallel Programming**: TPL and PLINQ
3. **Query Expressions**: LINQ-style data queries
4. **Discriminated Unions**: Algebraic data types
5. **Active Patterns**: Custom pattern matching

## 📊 Output Examples

Each task file produces formatted output demonstrating the concepts. Here's a sample:

```
=== Task 1: F# Syntax & Basics ===

Integer Types:
  int: 42
  int64: 100
  byte: 255

Floating-Point Types:
  float: 3.140000
  float32: 2.500000
  decimal: 99.99

...
```

## 🔍 Testing

All code has been tested with:
- **.NET SDK**: Version 8.0
- **F# Interactive**: FSI 12.8
- **OS**: Windows 11

To verify your setup:
```bash
dotnet fsi --version
```

## 🛠️ Troubleshooting

### Common Issues

1. **"dotnet: command not found"**
   - Install .NET SDK from Microsoft website
   - Restart terminal after installation

2. **"The type provider 'FSharp.Data.SqlClient' reported an error"**
   - Install required NuGet package: `dotnet add package System.Data.SqlClient`

3. **Database connection errors**
   - Ensure SQL Server / MongoDB is running
   - Update connection strings with your credentials
   - Database tasks show simulated outputs if databases aren't available

4. **Script execution policy (Windows)**
   ```powershell
   Set-ExecutionPolicy -ExecutionPolicy RemoteSigned -Scope CurrentUser
   ```

## 📖 Learning Resources

- [F# Documentation](https://docs.microsoft.com/en-us/dotnet/fsharp/)
- [F# for Fun and Profit](https://fsharpforfunandprofit.com/)
- [F# Foundation](https://fsharp.org/)
- [Real World F#](https://www.manning.com/books/real-world-functional-programming)

## 🎯 Assignment Completion Checklist

- [x] Task 1: F# Syntax & Basics
- [x] Task 2: Control Flow
- [x] Task 3: Functions
- [x] Task 4: Strings, Options, and Immutable Data
- [x] Task 5: Pattern Matching
- [x] Task 6: Asynchronous & Parallel Programming
- [x] Task 7: Object-Oriented Programming
- [x] Task 8: Database Access
- [x] Task 9: Data Querying
- [x] Task 10: GitHub Repository with Documentation

## 🌟 Highlights

- **Comprehensive Coverage**: All 10 tasks completed with detailed examples
- **Real-World Scenarios**: Practical examples (e-commerce, banking, inventory)
- **Well-Commented Code**: Extensive explanations throughout
- **Functional-First**: Emphasizes functional paradigms while showing OOP integration
- **Production-Ready**: Error handling, resource management, best practices

## 📝 Differences from Traditional Languages

F# differs from languages like C#, Java, or Python in several key ways:

1. **Immutability**: Default immutability prevents bugs and enables safe concurrency
2. **Type Inference**: Less verbose than C# while maintaining type safety
3. **Expression-Based**: Everything returns a value (no void)
4. **Pattern Matching**: More powerful than switch statements
5. **Pipe Operator**: Enables fluent, readable data transformations
6. **Function Composition**: Algebraic function composition
7. **No Null**: Option type eliminates null reference exceptions
8. **Whitespace-Significant**: No braces or semicolons needed

## 🔗 Repository Structure

```
GitHub Repository: fsharp-functional-programming-<yourname>
│
├── Source Code Files (.fsx)
├── README.md (This file)
├── Screenshots/ (Optional: execution screenshots)
└── .gitignore
```

## 🙏 Acknowledgments

This assignment demonstrates F# programming concepts as part of the New Age Programming Languages course. All code is original and created for educational purposes.

## 📧 Contact

For questions or clarifications about this assignment, please contact through the Learning Management System.

---

**Note**: This project is created as an academic assignment and demonstrates various F# programming concepts. Some features (like database operations) require additional setup and are provided with both working examples and simulated outputs for demonstration purposes.
