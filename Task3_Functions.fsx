// Task 3: Functions
// This file demonstrates basic, recursive, and higher-order functions, including currying

printfn "=== Task 3: Functions ==="
printfn ""

// ===== BASIC FUNCTIONS =====
printfn "--- Basic Functions ---"
printfn ""

// Simple function with one parameter
let square x = x * x

printfn "Square function:"
printfn "  square(5) = %d" (square 5)
printfn ""

// Function with multiple parameters
let add x y = x + y

printfn "Add function:"
printfn "  add 10 20 = %d" (add 10 20)
printfn ""

// Function with explicit type annotations
let multiply (x: int) (y: int) : int = x * y

printfn "Multiply function:"
printfn "  multiply 7 8 = %d" (multiply 7 8)
printfn ""

// Function with let binding inside
let calculateCircleArea radius =
    let pi = 3.14159
    pi * radius * radius

printfn "Circle area calculator:"
printfn "  Area of circle with radius 5: %.2f" (calculateCircleArea 5.0)
printfn ""

// Function returning tuple
let divideWithRemainder dividend divisor =
    let quotient = dividend / divisor
    let remainder = dividend % divisor
    (quotient, remainder)

let (q, r) = divideWithRemainder 17 5
printfn "Division with remainder:"
printfn "  17 ÷ 5 = %d remainder %d" q r
printfn ""

// ===== RECURSIVE FUNCTIONS =====
// Use 'rec' keyword to allow functions to call themselves
printfn "--- Recursive Functions ---"
printfn ""

// Example 1: Factorial
let rec factorial n =
    if n <= 1 then 
        1
    else 
        n * factorial (n - 1)

printfn "Factorial (recursive):"
printfn "  5! = %d" (factorial 5)
printfn "  10! = %d" (factorial 10)
printfn ""

// Example 2: Fibonacci sequence
let rec fibonacci n =
    match n with
    | 0 -> 0
    | 1 -> 1
    | _ -> fibonacci (n - 1) + fibonacci (n - 2)

printfn "Fibonacci (recursive):"
printfn "  fib(8) = %d" (fibonacci 8)
printfn ""

// Example 3: Sum of list (recursive)
let rec sumList lst =
    match lst with
    | [] -> 0                           // Base case: empty list
    | head :: tail -> head + sumList tail  // Recursive case

let numbers = [1; 2; 3; 4; 5]
printfn "Sum of list (recursive):"
printfn "  sumList %A = %d" numbers (sumList numbers)
printfn ""

// Example 4: Greatest Common Divisor (Euclidean algorithm)
let rec gcd a b =
    if b = 0 then a
    else gcd b (a % b)

printfn "Greatest Common Divisor (recursive):"
printfn "  gcd(48, 18) = %d" (gcd 48 18)
printfn ""

// Example 5: Tail-recursive function (optimized for performance)
// Tail recursion is when the recursive call is the last operation
let factorialTailRec n =
    let rec loop acc n =
        if n <= 1 then acc
        else loop (acc * n) (n - 1)
    loop 1 n

printfn "Factorial (tail-recursive):"
printfn "  5! = %d" (factorialTailRec 5)
printfn ""

// ===== HIGHER-ORDER FUNCTIONS =====
// Functions that take other functions as parameters or return functions
printfn "--- Higher-Order Functions ---"
printfn ""

// Example 1: Function that takes a function as parameter
let applyTwice f x = f (f x)

let increment x = x + 1
printfn "Apply function twice:"
printfn "  applyTwice increment 5 = %d" (applyTwice increment 5)
printfn ""

// Example 2: Function that returns a function
let makeAdder x =
    fun y -> x + y  // Returns a function

let add5 = makeAdder 5
let add10 = makeAdder 10

printfn "Function returning function:"
printfn "  add5(3) = %d" (add5 3)
printfn "  add10(3) = %d" (add10 3)
printfn ""

// Example 3: Map - applies function to each element
let doubleList lst = List.map (fun x -> x * 2) lst

let originalList = [1; 2; 3; 4; 5]
printfn "Map (higher-order function):"
printfn "  Original: %A" originalList
printfn "  Doubled: %A" (doubleList originalList)
printfn ""

// Example 4: Filter - keeps elements matching a predicate
let filterEvens lst = List.filter (fun x -> x % 2 = 0) lst

printfn "Filter (higher-order function):"
printfn "  Original: %A" originalList
printfn "  Evens only: %A" (filterEvens originalList)
printfn ""

// Example 5: Fold - reduces list to single value
let sumWithFold lst = List.fold (+) 0 lst
let productWithFold lst = List.fold (*) 1 lst

printfn "Fold (higher-order function):"
printfn "  Sum: %d" (sumWithFold originalList)
printfn "  Product: %d" (productWithFold originalList)
printfn ""

// Example 6: Compose functions
let add1 x = x + 1
let times2 x = x * 2

let add1ThenTimes2 = add1 >> times2  // Forward composition
let times2ThenAdd1 = times2 >> add1

printfn "Function composition:"
printfn "  (5 |> add1 |> times2) = %d" (add1ThenTimes2 5)
printfn "  (5 |> times2 |> add1) = %d" (times2ThenAdd1 5)
printfn ""

// ===== CURRYING =====
// Currying: transforming a function with multiple arguments into a sequence of functions
// In F#, all functions are curried by default!
printfn "--- Currying ---"
printfn ""

// This function takes two parameters
let addNumbers x y = x + y

// But it's actually a curried function that can be partially applied
let add7 = addNumbers 7  // Partially applied - returns a function

printfn "Currying - Partial Application:"
printfn "  add7(3) = %d" (add7 3)
printfn "  add7(10) = %d" (add7 10)
printfn ""

// Example: Volume calculator
let calculateVolume length width height = length * width * height

// Partially apply to create specific calculators
let calculateVolumeOfBox = calculateVolume 10  // Fix length = 10
let calculateVolumeOfSquareBox = calculateVolumeOfBox 10  // Fix width = 10

printfn "Currying - Volume calculator:"
printfn "  Full: calculateVolume 5 4 3 = %d" (calculateVolume 5 4 3)
printfn "  Partial (length=10): calculateVolumeOfBox 5 8 = %d" (calculateVolumeOfBox 5 8)
printfn "  Partial (length=10, width=10): calculateVolumeOfSquareBox 6 = %d" (calculateVolumeOfSquareBox 6)
printfn ""

// Example: Discount calculator with currying
let applyDiscount discountRate price = 
    price * (1.0 - discountRate)

let apply10PercentDiscount = applyDiscount 0.10
let apply25PercentDiscount = applyDiscount 0.25

printfn "Currying - Discount calculator:"
printfn "  Original price: $100"
printfn "  With 10%% discount: $%.2f" (apply10PercentDiscount 100.0)
printfn "  With 25%% discount: $%.2f" (apply25PercentDiscount 100.0)
printfn ""

// Example: Custom formatting function
let formatMessage prefix level message =
    sprintf "[%s] %s: %s" prefix level message

let logWithTimestamp = formatMessage "2025-11-23 10:30:00"
let errorLog = logWithTimestamp "ERROR"
let infoLog = logWithTimestamp "INFO"

printfn "Currying - Custom logger:"
printfn "  %s" (errorLog "Database connection failed")
printfn "  %s" (infoLog "Application started successfully")
printfn ""

// ===== LAMBDA EXPRESSIONS (ANONYMOUS FUNCTIONS) =====
printfn "--- Lambda Expressions ---"
printfn ""

// Lambda syntax: fun parameter -> expression
let numbers2 = [1; 2; 3; 4; 5; 6; 7; 8; 9; 10]

printfn "Lambda expressions in higher-order functions:"
printfn "  Original: %A" numbers2

let squared = numbers2 |> List.map (fun x -> x * x)
printfn "  Squared: %A" squared

let evenSquares = squared |> List.filter (fun x -> x % 2 = 0)
printfn "  Even squares: %A" evenSquares
printfn ""

// ===== FUNCTION PIPELINE =====
printfn "--- Function Pipeline ---"
printfn ""

// Pipeline operator |> passes value to next function
let result =
    [1..20]
    |> List.filter (fun x -> x % 2 = 0)    // Keep evens
    |> List.map (fun x -> x * x)            // Square them
    |> List.filter (fun x -> x > 50)        // Keep > 50
    |> List.sum                              // Sum them up

printfn "Pipeline example (1..20 |> filterEvens |> square |> filter>50 |> sum):"
printfn "  Result: %d" result
printfn ""

// Real-world example: Data processing pipeline
type Employee = {
    Name: string
    Department: string
    Salary: float
    YearsOfService: int
}

let employees = [
    { Name = "Alice"; Department = "Engineering"; Salary = 80000.0; YearsOfService = 5 }
    { Name = "Bob"; Department = "Marketing"; Salary = 60000.0; YearsOfService = 3 }
    { Name = "Charlie"; Department = "Engineering"; Salary = 95000.0; YearsOfService = 7 }
    { Name = "Diana"; Department = "Sales"; Salary = 70000.0; YearsOfService = 4 }
    { Name = "Eve"; Department = "Engineering"; Salary = 85000.0; YearsOfService = 6 }
]

// Calculate average salary for engineering employees with 5+ years experience
let avgSeniorEngSalary =
    employees
    |> List.filter (fun e -> e.Department = "Engineering")
    |> List.filter (fun e -> e.YearsOfService >= 5)
    |> List.map (fun e -> e.Salary)
    |> List.average

printfn "Data processing pipeline:"
printfn "  Average salary of senior Engineering employees: $%.2f" avgSeniorEngSalary
printfn ""

// ===== MEMOIZATION (Caching Function Results) =====
printfn "--- Memoization ---"
printfn ""

// Memoization improves performance by caching function results
let memoize f =
    let cache = System.Collections.Generic.Dictionary<_, _>()
    fun x ->
        if cache.ContainsKey(x) then
            cache.[x]
        else
            let result = f x
            cache.[x] <- result
            result

// Memoized fibonacci is much faster
let rec fibSlow n =
    match n with
    | 0 -> 0
    | 1 -> 1
    | _ -> fibSlow (n - 1) + fibSlow (n - 2)

let fibFast = memoize (fun n ->
    let rec fib n =
        match n with
        | 0 -> 0
        | 1 -> 1
        | _ -> fibFast (n - 1) + fibFast (n - 2)
    fib n
)

printfn "Memoization example:"
printfn "  Fibonacci(35) with memoization: %d" (fibFast 35)
printfn ""

printfn "=== Key Concepts ==="
printfn "1. Functions are first-class values in F#"
printfn "2. All functions are curried by default"
printfn "3. Higher-order functions enable powerful abstractions"
printfn "4. Recursion is preferred over imperative loops"
printfn "5. Tail recursion optimizes recursive calls"
printfn "6. Pipeline operator |> enables fluent code"
printfn "7. Lambda expressions create anonymous functions"
