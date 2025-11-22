// Task 1: F# Syntax & Basics
// This file demonstrates F# syntax, data types, variables, and operators
// with explanations of how they differ from traditional imperative languages

printfn "=== Task 1: F# Syntax & Basics ==="
printfn ""

// ===== DATA TYPES =====
// F# has strong type inference - types are inferred automatically
// Unlike traditional languages, you don't need to explicitly declare types most of the time

// Integer types
let intValue = 42                    // int (32-bit)
let longValue = 100L                 // int64
let byteValue = 255uy                // byte (unsigned 8-bit)

printfn "Integer Types:"
printfn "  int: %d" intValue
printfn "  int64: %d" longValue
printfn "  byte: %d" byteValue
printfn ""

// Floating-point types
let floatValue = 3.14                // float (64-bit double)
let float32Value = 2.5f              // float32 (32-bit single)
let decimalValue = 99.99M            // decimal (precise for financial calculations)

printfn "Floating-Point Types:"
printfn "  float: %f" floatValue
printfn "  float32: %f" float32Value
printfn "  decimal: %M" decimalValue
printfn ""

// Boolean and Character types
let boolValue = true                 // bool
let charValue = 'A'                  // char

printfn "Boolean and Character:"
printfn "  bool: %b" boolValue
printfn "  char: %c" charValue
printfn ""

// String type - immutable in F#, unlike mutable strings in some languages
let stringValue = "Hello, F#!"

printfn "String:"
printfn "  string: %s" stringValue
printfn ""

// ===== VARIABLES: IMMUTABLE BY DEFAULT =====
// Key difference from traditional languages: F# values are immutable by default
// This prevents accidental side effects and makes code more predictable

let immutableValue = 100
// immutableValue <- 200  // This would cause a compile error!

printfn "Immutability:"
printfn "  immutableValue: %d (cannot be changed)" immutableValue
printfn ""

// To create mutable variables, use the 'mutable' keyword
let mutable mutableValue = 100
printfn "Mutable variable before: %d" mutableValue
mutableValue <- 200  // Use <- for assignment, not =
printfn "Mutable variable after: %d" mutableValue
printfn ""

// ===== OPERATORS =====

// Arithmetic operators
let a = 10
let b = 3

printfn "Arithmetic Operators (a=%d, b=%d):" a b
printfn "  Addition: %d + %d = %d" a b (a + b)
printfn "  Subtraction: %d - %d = %d" a b (a - b)
printfn "  Multiplication: %d * %d = %d" a b (a * b)
printfn "  Division: %d / %d = %d" a b (a / b)
printfn "  Modulus: %d %% %d = %d" a b (a % b)
printfn "  Exponentiation: %d ** %d = %f" a b (float a ** float b)
printfn ""

// Comparison operators
printfn "Comparison Operators:"
printfn "  %d = %d: %b" a b (a = b)
printfn "  %d <> %d: %b" a b (a <> b)  // <> is 'not equal' in F#
printfn "  %d < %d: %b" a b (a < b)
printfn "  %d > %d: %b" a b (a > b)
printfn "  %d <= %d: %b" a b (a <= b)
printfn "  %d >= %d: %b" a b (a >= b)
printfn ""

// Logical operators
let x = true
let y = false

printfn "Logical Operators (x=%b, y=%b):" x y
printfn "  x && y (AND): %b" (x && y)
printfn "  x || y (OR): %b" (x || y)
printfn "  not x (NOT): %b" (not x)
printfn ""

// Pipe operator (|>) - unique to F# and functional languages
// It passes the result of the left side as an argument to the right side
// This enables fluent, left-to-right code composition
let numbers = [1; 2; 3; 4; 5]

let result = 
    numbers
    |> List.map (fun x -> x * 2)      // Double each number
    |> List.filter (fun x -> x > 5)   // Keep only numbers > 5
    |> List.sum                        // Sum them up

printfn "Pipe Operator Example:"
printfn "  Original list: %A" numbers
printfn "  After map(*2), filter(>5), sum: %d" result
printfn ""

// Composition operator (>>) - combines functions
// Unlike traditional languages, you can compose functions algebraically
let add1 x = x + 1
let times2 x = x * 2
let add1ThenTimes2 = add1 >> times2  // Compose the two functions

printfn "Function Composition:"
printfn "  add1(5) then times2 = %d" (add1ThenTimes2 5)
printfn ""

// ===== TUPLES =====
// Tuples group multiple values together
// Unlike structs in traditional languages, they're lightweight and don't need type definitions

let tuple2 = (1, "hello")            // 2-tuple
let tuple3 = (42, 3.14, true)        // 3-tuple

printfn "Tuples:"
printfn "  2-tuple: %A" tuple2
printfn "  3-tuple: %A" tuple3

// Deconstructing tuples
let (num, text) = tuple2
printfn "  Deconstructed: num=%d, text=%s" num text
printfn ""

// ===== LISTS =====
// Lists are immutable, singly-linked lists
// Unlike arrays in traditional languages, lists are built for functional programming

let list1 = [1; 2; 3; 4; 5]          // Semicolon-separated
let list2 = [1..10]                   // Range syntax
let list3 = 0 :: list1                // :: (cons) prepends an element

printfn "Lists:"
printfn "  list1: %A" list1
printfn "  list2 (range 1..10): %A" list2
printfn "  list3 (0 :: list1): %A" list3
printfn ""

// ===== ARRAYS =====
// Arrays are mutable and fixed-size, similar to traditional languages

let array1 = [|1; 2; 3; 4; 5|]       // Use [| |] for arrays
array1.[0] <- 100                     // Mutable indexing

printfn "Arrays:"
printfn "  array1 after modification: %A" array1
printfn ""

// ===== RECORDS =====
// Records are immutable data structures with named fields
// Similar to structs in C# but immutable by default

type Person = {
    Name: string
    Age: int
    Email: string
}

let person1 = { Name = "Alice"; Age = 30; Email = "alice@example.com" }

printfn "Records:"
printfn "  Person: %A" person1

// Creating a copy with modifications (immutable update)
let person2 = { person1 with Age = 31 }
printfn "  Updated person: %A" person2
printfn ""

// ===== DISCRIMINATED UNIONS =====
// Discriminated unions represent a choice between different types
// Much more powerful than enums in traditional languages

type Shape =
    | Circle of radius: float
    | Rectangle of width: float * height: float
    | Triangle of base_: float * height: float

let shape1 = Circle(radius = 5.0)
let shape2 = Rectangle(width = 4.0, height = 6.0)

printfn "Discriminated Unions:"
printfn "  Circle: %A" shape1
printfn "  Rectangle: %A" shape2
printfn ""

// ===== TYPE ANNOTATIONS =====
// While F# infers types, you can explicitly annotate them

let explicitInt: int = 42
let explicitString: string = "Hello"
let explicitFunction (x: int) (y: int) : int = x + y

printfn "Type Annotations:"
printfn "  Explicit int: %d" explicitInt
printfn "  Explicit function result: %d" (explicitFunction 5 10)
printfn ""

printfn "=== Key Differences from Traditional Languages ==="
printfn "1. Immutability by default - prevents side effects"
printfn "2. Type inference - less verbose than C#/Java"
printfn "3. Expression-based - everything returns a value"
printfn "4. Whitespace-significant - no semicolons or braces needed"
printfn "5. Functional-first - functions are first-class values"
printfn "6. Powerful pattern matching - more than switch statements"
printfn "7. Pipe and composition operators - fluent data transformations"
