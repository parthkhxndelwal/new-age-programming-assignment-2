// Task 5: Pattern Matching
// This file demonstrates pattern matching with records, tuples, and discriminated unions

printfn "=== Task 5: Pattern Matching ==="
printfn ""

// Pattern matching is one of F#'s most powerful features
// It's type-safe, exhaustive, and more expressive than switch statements

// ===== BASIC PATTERN MATCHING =====
printfn "--- Basic Pattern Matching ---"
printfn ""

// Simple value matching
let describeNumber n =
    match n with
    | 0 -> "Zero"
    | 1 -> "One"
    | 2 -> "Two"
    | _ -> "Other number"  // _ is wildcard (default case)

printfn "Number description:"
for i in [0; 1; 2; 5] do
    printfn "  %d -> %s" i (describeNumber i)
printfn ""

// Pattern matching with guards (when clause)
let categorizeNumber n =
    match n with
    | x when x < 0 -> "Negative"
    | 0 -> "Zero"
    | x when x > 0 && x <= 10 -> "Small positive"
    | x when x > 10 && x <= 100 -> "Medium positive"
    | _ -> "Large positive"

printfn "Number categorization:"
for i in [-5; 0; 7; 50; 200] do
    printfn "  %d -> %s" i (categorizeNumber i)
printfn ""

// ===== TUPLE PATTERN MATCHING =====
printfn "--- Tuple Pattern Matching ---"
printfn ""

// Matching on tuples
let describePair pair =
    match pair with
    | (0, 0) -> "Origin"
    | (0, y) -> sprintf "On Y-axis at %d" y
    | (x, 0) -> sprintf "On X-axis at %d" x
    | (x, y) when x = y -> sprintf "On diagonal at (%d, %d)" x y
    | (x, y) -> sprintf "Point at (%d, %d)" x y

printfn "Coordinate description:"
let coordinates = [(0, 0); (0, 5); (3, 0); (4, 4); (2, 3)]
for coord in coordinates do
    printfn "  %A -> %s" coord (describePair coord)
printfn ""

// Rock, Paper, Scissors game using tuples
let playGame player1 player2 =
    match (player1, player2) with
    | ("rock", "scissors") | ("scissors", "paper") | ("paper", "rock") -> 
        "Player 1 wins!"
    | ("scissors", "rock") | ("paper", "scissors") | ("rock", "paper") -> 
        "Player 2 wins!"
    | _ -> "It's a tie!"

printfn "Rock, Paper, Scissors:"
printfn "  Rock vs Scissors: %s" (playGame "rock" "scissors")
printfn "  Paper vs Rock: %s" (playGame "paper" "rock")
printfn "  Rock vs Rock: %s" (playGame "rock" "rock")
printfn ""

// ===== RECORD PATTERN MATCHING =====
printfn "--- Record Pattern Matching ---"
printfn ""

type Person = {
    Name: string
    Age: int
    City: string
    Occupation: string
}

// Pattern matching on record fields
let describePerson person =
    match person with
    | { Age = age } when age < 18 -> 
        sprintf "%s is a minor" person.Name
    | { Age = age } when age >= 65 -> 
        sprintf "%s is a senior citizen" person.Name
    | { Occupation = "Student" } -> 
        sprintf "%s is studying" person.Name
    | { City = "New York"; Occupation = occ } -> 
        sprintf "%s works as a %s in New York" person.Name occ
    | { Name = name; Occupation = occ } -> 
        sprintf "%s works as a %s" name occ

let people = [
    { Name = "Alice"; Age = 15; City = "Boston"; Occupation = "Student" }
    { Name = "Bob"; Age = 30; City = "New York"; Occupation = "Engineer" }
    { Name = "Charlie"; Age = 70; City = "Miami"; Occupation = "Retired" }
    { Name = "Diana"; Age = 25; City = "Seattle"; Occupation = "Designer" }
]

printfn "Person descriptions:"
for person in people do
    printfn "  %s" (describePerson person)
printfn ""

// ===== DISCRIMINATED UNION PATTERN MATCHING =====
printfn "--- Discriminated Union Pattern Matching ---"
printfn ""

// Example 1: Shape calculation
type Shape =
    | Circle of radius: float
    | Rectangle of width: float * height: float
    | Triangle of base_: float * height: float
    | Square of side: float

let calculateArea shape =
    match shape with
    | Circle radius -> System.Math.PI * radius * radius
    | Rectangle (width, height) -> width * height
    | Triangle (base_, height) -> 0.5 * base_ * height
    | Square side -> side * side

let shapes = [
    Circle 5.0
    Rectangle (4.0, 6.0)
    Triangle (3.0, 4.0)
    Square 5.0
]

printfn "Shape areas:"
for shape in shapes do
    printfn "  %A -> Area: %.2f" shape (calculateArea shape)
printfn ""

// Example 2: Payment methods
type PaymentMethod =
    | Cash of amount: float
    | CreditCard of cardNumber: string * amount: float * cvv: string
    | DebitCard of cardNumber: string * amount: float * pin: string
    | MobilePayment of provider: string * phoneNumber: string * amount: float

let processPayment payment =
    match payment with
    | Cash amount -> 
        sprintf "Cash payment of $%.2f received" amount
    | CreditCard (cardNum, amount, _) -> 
        sprintf "Credit card ending in %s charged $%.2f" (cardNum.Substring(cardNum.Length - 4)) amount
    | DebitCard (cardNum, amount, _) -> 
        sprintf "Debit card ending in %s charged $%.2f" (cardNum.Substring(cardNum.Length - 4)) amount
    | MobilePayment (provider, phone, amount) -> 
        sprintf "%s payment of $%.2f from %s" provider amount phone

let payments = [
    Cash 50.0
    CreditCard ("1234567812345678", 120.50, "123")
    DebitCard ("8765432187654321", 75.25, "1234")
    MobilePayment ("PayPal", "+1-555-0123", 200.0)
]

printfn "Payment processing:"
for payment in payments do
    printfn "  %s" (processPayment payment)
printfn ""

// Example 3: Order status with nested matching
type OrderStatus =
    | Pending
    | Confirmed of orderDate: System.DateTime
    | Shipped of trackingNumber: string * carrier: string
    | Delivered of deliveryDate: System.DateTime * signature: string
    | Cancelled of reason: string * refundAmount: float

let getOrderDetails status =
    match status with
    | Pending -> 
        "Order is pending confirmation"
    | Confirmed date -> 
        sprintf "Order confirmed on %s" (date.ToString("yyyy-MM-dd"))
    | Shipped (tracking, carrier) -> 
        sprintf "Shipped via %s (Tracking: %s)" carrier tracking
    | Delivered (date, signature) -> 
        sprintf "Delivered on %s, signed by %s" (date.ToString("yyyy-MM-dd")) signature
    | Cancelled (reason, refund) when refund > 0.0 -> 
        sprintf "Cancelled: %s (Refund: $%.2f)" reason refund
    | Cancelled (reason, _) -> 
        sprintf "Cancelled: %s (No refund)" reason

let orders = [
    Pending
    Confirmed (System.DateTime(2025, 11, 20))
    Shipped ("1Z999AA10123456784", "UPS")
    Delivered (System.DateTime(2025, 11, 22), "John Doe")
    Cancelled ("Out of stock", 99.99)
]

printfn "Order status details:"
for order in orders do
    printfn "  %s" (getOrderDetails order)
printfn ""

// ===== LIST PATTERN MATCHING =====
printfn "--- List Pattern Matching ---"
printfn ""

// Matching on list structure
let describeList lst =
    match lst with
    | [] -> "Empty list"
    | [x] -> sprintf "Single element: %d" x
    | [x; y] -> sprintf "Two elements: %d and %d" x y
    | x :: y :: rest -> sprintf "Starts with %d and %d, has %d more elements" x y (List.length rest)

printfn "List descriptions:"
let lists = [
    []
    [1]
    [1; 2]
    [1; 2; 3; 4; 5]
]
for lst in lists do
    printfn "  %A -> %s" lst (describeList lst)
printfn ""

// Recursive function with list pattern matching
let rec sumList lst =
    match lst with
    | [] -> 0
    | head :: tail -> head + sumList tail

printfn "Sum of lists:"
printfn "  [1;2;3;4;5] -> %d" (sumList [1; 2; 3; 4; 5])
printfn ""

// ===== OPTION PATTERN MATCHING =====
printfn "--- Option Pattern Matching ---"
printfn ""

type Customer = {
    Id: int
    Name: string
    Email: string option  // Email is optional
    Phone: string option  // Phone is optional
}

let getContactInfo customer =
    match (customer.Email, customer.Phone) with
    | (Some email, Some phone) -> 
        sprintf "%s can be reached at %s or %s" customer.Name email phone
    | (Some email, None) -> 
        sprintf "%s can be reached at %s" customer.Name email
    | (None, Some phone) -> 
        sprintf "%s can be reached at %s" customer.Name phone
    | (None, None) -> 
        sprintf "No contact information for %s" customer.Name

let customers = [
    { Id = 1; Name = "Alice"; Email = Some "alice@example.com"; Phone = Some "+1-555-0101" }
    { Id = 2; Name = "Bob"; Email = Some "bob@example.com"; Phone = None }
    { Id = 3; Name = "Charlie"; Email = None; Phone = Some "+1-555-0102" }
    { Id = 4; Name = "Diana"; Email = None; Phone = None }
]

printfn "Customer contact information:"
for customer in customers do
    printfn "  %s" (getContactInfo customer)
printfn ""

// ===== ACTIVE PATTERNS =====
// Active patterns allow custom pattern matching
printfn "--- Active Patterns ---"
printfn ""

// Single-case active pattern
let (|Even|Odd|) n =
    if n % 2 = 0 then Even else Odd

let describeEvenOdd n =
    match n with
    | Even -> sprintf "%d is even" n
    | Odd -> sprintf "%d is odd" n

printfn "Even/Odd using active pattern:"
for i in [1; 2; 3; 4; 5] do
    printfn "  %s" (describeEvenOdd i)
printfn ""

// Partial active pattern
let (|ParseInt|_|) str =
    match System.Int32.TryParse(str) with
    | (true, value) -> Some value
    | (false, _) -> None

let processInput input =
    match input with
    | ParseInt value -> sprintf "Valid integer: %d" value
    | _ -> sprintf "Invalid input: %s" input

printfn "Parsing with partial active pattern:"
for input in ["42"; "hello"; "123"; "abc"] do
    printfn "  %s" (processInput input)
printfn ""

// Multi-case active pattern
let (|Small|Medium|Large|) n =
    if n < 10 then Small
    elif n < 100 then Medium
    else Large

let categorizeBySize n =
    match n with
    | Small -> sprintf "%d is small" n
    | Medium -> sprintf "%d is medium" n
    | Large -> sprintf "%d is large" n

printfn "Size categorization with active pattern:"
for n in [5; 50; 500] do
    printfn "  %s" (categorizeBySize n)
printfn ""

// ===== NESTED PATTERN MATCHING =====
printfn "--- Nested Pattern Matching ---"
printfn ""

type Address = {
    Street: string
    City: string
    State: string
    ZipCode: string
}

type Employee = {
    Name: string
    Age: int
    Department: string
    Address: Address option
}

let describeEmployee emp =
    match emp with
    | { Age = age; Department = "Engineering"; Address = Some { City = city } } when age > 30 ->
        sprintf "%s is a senior engineer in %s" emp.Name city
    | { Age = age; Department = "Engineering" } when age <= 30 ->
        sprintf "%s is a junior engineer" emp.Name
    | { Department = dept; Address = Some { City = city } } ->
        sprintf "%s works in %s department, lives in %s" emp.Name dept city
    | { Department = dept; Address = None } ->
        sprintf "%s works in %s department" emp.Name dept

let employees = [
    { Name = "Alice"; Age = 35; Department = "Engineering"; 
      Address = Some { Street = "123 Main St"; City = "Seattle"; State = "WA"; ZipCode = "98101" } }
    { Name = "Bob"; Age = 25; Department = "Engineering"; Address = None }
    { Name = "Charlie"; Age = 40; Department = "Sales"; 
      Address = Some { Street = "456 Oak Ave"; City = "Portland"; State = "OR"; ZipCode = "97201" } }
]

printfn "Employee descriptions:"
for emp in employees do
    printfn "  %s" (describeEmployee emp)
printfn ""

printfn "=== Key Concepts ==="
printfn "1. Pattern matching is exhaustive - compiler ensures all cases are covered"
printfn "2. Guards (when clauses) add conditional logic to patterns"
printfn "3. Works with tuples, records, discriminated unions, lists, and options"
printfn "4. Active patterns enable custom matching logic"
printfn "5. Much more powerful than traditional switch statements"
printfn "6. Wildcard (_) matches anything"
printfn "7. Can destructure complex data structures"
