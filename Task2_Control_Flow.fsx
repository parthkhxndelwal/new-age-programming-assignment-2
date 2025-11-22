// Task 2: Control Flow
// This file demonstrates decision-making constructs and loops with real-life examples

printfn "=== Task 2: Control Flow ==="
printfn ""

// ===== IF-THEN-ELSE EXPRESSIONS =====
// In F#, if-then-else is an expression (returns a value), not a statement
// This is different from traditional imperative languages

printfn "--- If-Then-Else Expressions ---"
printfn ""

// Example 1: Grade Calculator
let calculateGrade score =
    if score >= 90 then "A"
    elif score >= 80 then "B"
    elif score >= 70 then "C"
    elif score >= 60 then "D"
    else "F"

let studentScore = 85
let grade = calculateGrade studentScore
printfn "Student Score: %d -> Grade: %s" studentScore grade
printfn ""

// Example 2: Ticket Pricing based on Age
let getTicketPrice age =
    if age < 3 then 0.0          // Toddlers free
    elif age < 12 then 10.0      // Children
    elif age < 65 then 25.0      // Adults
    else 15.0                     // Seniors

let ages = [2; 8; 30; 70]
printfn "Movie Ticket Pricing:"
for age in ages do
    let price = getTicketPrice age
    printfn "  Age %d: $%.2f" age price
printfn ""

// Example 3: Weather Advisory System
let getWeatherAdvisory temperature humidity =
    if temperature > 35 && humidity > 70 then
        "Heat Advisory: Stay hydrated and avoid outdoor activities"
    elif temperature < 0 then
        "Freeze Warning: Protect pipes and stay warm"
    elif temperature > 30 then
        "Hot: Drink plenty of water"
    elif temperature < 10 then
        "Cold: Wear warm clothing"
    else
        "Pleasant weather: Enjoy your day!"

let currentTemp = 38
let currentHumidity = 75
printfn "Weather Advisory:"
printfn "  Temperature: %d°C, Humidity: %d%%" currentTemp currentHumidity
printfn "  Advisory: %s" (getWeatherAdvisory currentTemp currentHumidity)
printfn ""

// ===== PATTERN MATCHING WITH MATCH EXPRESSIONS =====
// Pattern matching is much more powerful than switch statements
// It's exhaustive and can match on structure, not just values

printfn "--- Pattern Matching ---"
printfn ""

// Example 4: Day of Week Activity Planner
let planActivity dayOfWeek =
    match dayOfWeek with
    | "Monday" -> "Start the week with a morning jog"
    | "Tuesday" | "Thursday" -> "Gym day - strength training"
    | "Wednesday" -> "Yoga and meditation"
    | "Friday" -> "Team sports - basketball or soccer"
    | "Saturday" -> "Hiking or outdoor adventure"
    | "Sunday" -> "Rest day - light stretching"
    | _ -> "Invalid day"

let today = "Wednesday"
printfn "Activity Planner:"
printfn "  %s: %s" today (planActivity today)
printfn ""

// Example 5: E-commerce Order Status
type OrderStatus =
    | Pending
    | Processing
    | Shipped of trackingNumber: string
    | Delivered of deliveryDate: System.DateTime
    | Cancelled of reason: string

let getOrderMessage status =
    match status with
    | Pending -> "Your order is pending confirmation"
    | Processing -> "Your order is being prepared"
    | Shipped trackingNumber -> 
        sprintf "Your order has been shipped! Tracking: %s" trackingNumber
    | Delivered date -> 
        sprintf "Delivered on %s" (date.ToString("yyyy-MM-dd"))
    | Cancelled reason -> 
        sprintf "Order cancelled: %s" reason

let order1 = Shipped "1Z999AA10123456784"
let order2 = Delivered (System.DateTime(2025, 11, 20))

printfn "Order Status Messages:"
printfn "  Order 1: %s" (getOrderMessage order1)
printfn "  Order 2: %s" (getOrderMessage order2)
printfn ""

// Example 6: ATM Transaction Validator
let validateTransaction balance amount transactionType =
    match transactionType with
    | "withdraw" when amount > balance -> 
        "Transaction declined: Insufficient funds"
    | "withdraw" when amount > 10000.0 -> 
        "Transaction declined: Exceeds daily limit"
    | "withdraw" -> 
        sprintf "Withdrawal approved: $%.2f (New balance: $%.2f)" amount (balance - amount)
    | "deposit" when amount > 50000.0 -> 
        "Large deposit: Additional verification required"
    | "deposit" -> 
        sprintf "Deposit approved: $%.2f (New balance: $%.2f)" amount (balance + amount)
    | _ -> "Invalid transaction type"

let accountBalance = 5000.0
printfn "ATM Transactions:"
printfn "  Account Balance: $%.2f" accountBalance
printfn "  Withdraw $3000: %s" (validateTransaction accountBalance 3000.0 "withdraw")
printfn "  Withdraw $6000: %s" (validateTransaction accountBalance 6000.0 "withdraw")
printfn "  Deposit $2000: %s" (validateTransaction accountBalance 2000.0 "deposit")
printfn ""

// ===== FOR LOOPS =====
printfn "--- For Loops ---"
printfn ""

// Example 7: Multiplication Table Generator
printfn "Multiplication Table for 7:"
for i in 1..10 do
    printfn "  7 x %d = %d" i (7 * i)
printfn ""

// Example 8: Temperature Converter (Celsius to Fahrenheit)
printfn "Temperature Conversion (Celsius to Fahrenheit):"
for celsius in [0; 10; 20; 30; 40] do
    let fahrenheit = (celsius * 9 / 5) + 32
    printfn "  %d°C = %d°F" celsius fahrenheit
printfn ""

// Example 9: Countdown Timer
printfn "Countdown Timer:"
for i in 10 .. -1 .. 1 do  // Counting down from 10 to 1
    printfn "  %d..." i
printfn "  Liftoff!"
printfn ""

// Example 10: Shopping Cart Total
let items = [("Laptop", 999.99); ("Mouse", 29.99); ("Keyboard", 79.99); ("Monitor", 299.99)]
let mutable cartTotal = 0.0

printfn "Shopping Cart:"
for (itemName, price) in items do
    printfn "  %s: $%.2f" itemName price
    cartTotal <- cartTotal + price
printfn "  Total: $%.2f" cartTotal
printfn ""

// ===== WHILE LOOPS =====
printfn "--- While Loops ---"
printfn ""

// Example 11: Password Attempt Limiter
let mutable attempts = 0
let maxAttempts = 3
let correctPassword = "secure123"
let mutable userInput = "wrong1"

printfn "Password Authentication System:"
while attempts < maxAttempts && userInput <> correctPassword do
    attempts <- attempts + 1
    printfn "  Attempt %d: Password incorrect" attempts
    // In real scenario, we'd get input from user
    if attempts = 2 then
        userInput <- correctPassword  // Simulate correct password on 3rd attempt
    else
        userInput <- sprintf "wrong%d" (attempts + 1)

if userInput = correctPassword then
    printfn "  Access granted!"
else
    printfn "  Account locked after %d failed attempts" maxAttempts
printfn ""

// Example 12: Bank Account Interest Accumulator
let mutable principal = 1000.0
let targetAmount = 1500.0
let annualRate = 0.05
let mutable years = 0

printfn "Investment Growth (5%% annual interest):"
printfn "  Starting Principal: $%.2f" principal
while principal < targetAmount do
    years <- years + 1
    principal <- principal * (1.0 + annualRate)
    printfn "  Year %d: $%.2f" years principal
printfn "  Goal of $%.2f reached in %d years!" targetAmount years
printfn ""

// Example 13: Stock Price Alert System
let mutable stockPrice = 100.0
let buyThreshold = 95.0
let sellThreshold = 110.0

printfn "Stock Price Monitor:"
printfn "  Buy threshold: $%.2f" buyThreshold
printfn "  Sell threshold: $%.2f" sellThreshold
printfn ""

// Simulate price changes
let priceChanges = [2.5; -3.0; -4.5; 5.0; 8.0; 6.0]
let mutable priceIndex = 0

while priceIndex < priceChanges.Length do
    stockPrice <- stockPrice + priceChanges.[priceIndex]
    printfn "  Price update: $%.2f" stockPrice
    
    if stockPrice <= buyThreshold then
        printfn "    >>> ALERT: Buy signal! Price dropped to $%.2f" stockPrice
    elif stockPrice >= sellThreshold then
        printfn "    >>> ALERT: Sell signal! Price rose to $%.2f" stockPrice
    
    priceIndex <- priceIndex + 1
printfn ""

// ===== RECURSION (Alternative to Loops) =====
// F# prefers recursion over loops for many scenarios
printfn "--- Recursion (Functional Alternative to Loops) ---"
printfn ""

// Example 14: Factorial Calculator
let rec factorial n =
    if n <= 1 then 1
    else n * factorial (n - 1)

printfn "Factorial Calculator:"
for i in [1..7] do
    printfn "  %d! = %d" i (factorial i)
printfn ""

// Example 15: Fibonacci Sequence
let rec fibonacci n =
    match n with
    | 0 -> 0
    | 1 -> 1
    | _ -> fibonacci (n - 1) + fibonacci (n - 2)

printfn "Fibonacci Sequence:"
printf "  "
for i in 0..10 do
    printf "%d " (fibonacci i)
printfn ""
printfn ""

printfn "=== Key Points about F# Control Flow ==="
printfn "1. if-then-else is an expression, not a statement"
printfn "2. Pattern matching is exhaustive and type-safe"
printfn "3. Guards (when clauses) add extra conditions to patterns"
printfn "4. Recursion is preferred over mutable loops"
printfn "5. All branches must return the same type"
