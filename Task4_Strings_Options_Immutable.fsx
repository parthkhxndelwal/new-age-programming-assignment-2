// Task 4: Strings, Options, and Immutable Data
// This file demonstrates string operations, Option type usage, and immutable collections

printfn "=== Task 4: Strings, Options, and Immutable Data ==="
printfn ""

// ===== STRING OPERATIONS =====
printfn "--- String Operations ---"
printfn ""

// String basics
let str1 = "Hello, F#!"
let str2 = "Functional Programming"

printfn "Basic strings:"
printfn "  str1: %s" str1
printfn "  str2: %s" str2
printfn ""

// String concatenation
let concatenated = str1 + " " + str2
let formatted = sprintf "%s is awesome with %s" str1 str2

printfn "String concatenation:"
printfn "  Concatenated: %s" concatenated
printfn "  Formatted: %s" formatted
printfn ""

// String length and indexing
printfn "String properties:"
printfn "  Length of '%s': %d" str1 str1.Length
printfn "  First character: %c" str1.[0]
printfn "  Last character: %c" str1.[str1.Length - 1]
printfn ""

// String slicing
let text = "Functional Programming Language"
let substring1 = text.[0..9]        // First 10 characters
let substring2 = text.[11..21]      // Characters 11-21
let substring3 = text.[23..]        // From index 23 to end

printfn "String slicing ('%s'):" text
printfn "  text.[0..9]: %s" substring1
printfn "  text.[11..21]: %s" substring2
printfn "  text.[23..]: %s" substring3
printfn ""

// String methods
let email = "  user@example.com  "
printfn "String methods:"
printfn "  Original: '%s'" email
printfn "  Trimmed: '%s'" (email.Trim())
printfn "  Uppercase: '%s'" (email.ToUpper())
printfn "  Lowercase: '%s'" (email.ToLower())
printfn "  Replace: '%s'" (email.Replace("example", "test"))
printfn ""

// String splitting and joining
let sentence = "F# is a functional-first language"
let words = sentence.Split(' ')
let rejoined = System.String.Join(" | ", words)

printfn "String splitting and joining:"
printfn "  Original: %s" sentence
printfn "  Split: %A" words
printfn "  Rejoined with |: %s" rejoined
printfn ""

// String checking
let url = "https://www.example.com"
printfn "String checking:"
printfn "  URL: %s" url
printfn "  Starts with 'https': %b" (url.StartsWith("https"))
printfn "  Ends with '.com': %b" (url.EndsWith(".com"))
printfn "  Contains 'example': %b" (url.Contains("example"))
printfn ""

// String building (for performance with many concatenations)
let buildLongString n =
    let sb = System.Text.StringBuilder()
    for i in 1..n do
        sb.Append(sprintf "Item %d, " i) |> ignore
    sb.ToString()

printfn "StringBuilder (efficient for many concatenations):"
printfn "  %s" (buildLongString 5)
printfn ""

// Multi-line strings
let multiLine = """This is a
multi-line string
that preserves formatting"""

let verbatim = @"C:\Users\Documents\File.txt"  // Verbatim string (no escaping needed)

printfn "Multi-line and verbatim strings:"
printfn "%s" multiLine
printfn "  Path: %s" verbatim
printfn ""

// ===== OPTION TYPE =====
// Option represents a value that may or may not exist
// This is safer than null references in traditional languages
printfn "--- Option Type ---"
printfn ""

// Basic option values
let someValue: int option = Some 42
let noneValue: int option = None

printfn "Basic Option values:"
printfn "  someValue: %A" someValue
printfn "  noneValue: %A" noneValue
printfn ""

// Pattern matching with options
let describeOption opt =
    match opt with
    | Some value -> sprintf "Has value: %d" value
    | None -> "Has no value"

printfn "Pattern matching with Options:"
printfn "  someValue: %s" (describeOption someValue)
printfn "  noneValue: %s" (describeOption noneValue)
printfn ""

// Real-world example: Safe division
let safeDivide x y =
    if y = 0 then None
    else Some (x / y)

printfn "Safe division (returns Option):"
printfn "  10 / 2 = %A" (safeDivide 10 2)
printfn "  10 / 0 = %A" (safeDivide 10 0)
printfn ""

// Example: User lookup
type User = {
    Id: int
    Name: string
    Email: string
}

let users = [
    { Id = 1; Name = "Alice"; Email = "alice@example.com" }
    { Id = 2; Name = "Bob"; Email = "bob@example.com" }
    { Id = 3; Name = "Charlie"; Email = "charlie@example.com" }
]

let findUserById id =
    users |> List.tryFind (fun u -> u.Id = id)

printfn "User lookup (using Option):"
match findUserById 2 with
| Some user -> printfn "  Found: %s (%s)" user.Name user.Email
| None -> printfn "  User not found"

match findUserById 5 with
| Some user -> printfn "  Found: %s (%s)" user.Name user.Email
| None -> printfn "  User not found"
printfn ""

// Option functions
let optValue = Some 10

printfn "Option helper functions:"
printfn "  Option.isSome: %b" (Option.isSome optValue)
printfn "  Option.isNone: %b" (Option.isNone optValue)
printfn "  Option.defaultValue 0: %d" (Option.defaultValue 0 optValue)
printfn "  Option.defaultValue 0 (None): %d" (Option.defaultValue 0 None)
printfn ""

// Option.map - transform value inside option
let doubleIfPresent opt = Option.map (fun x -> x * 2) opt

printfn "Option.map (transforms value inside Option):"
printfn "  doubleIfPresent (Some 5): %A" (doubleIfPresent (Some 5))
printfn "  doubleIfPresent None: %A" (doubleIfPresent None)
printfn ""

// Option.bind - for chaining operations that return options
let parseAndDivide str divisor =
    match System.Int32.TryParse(str) with
    | (true, num) -> safeDivide num divisor
    | (false, _) -> None

printfn "Option.bind (chaining Optional operations):"
printfn "  parseAndDivide '20' 4: %A" (parseAndDivide "20" 4)
printfn "  parseAndDivide 'abc' 4: %A" (parseAndDivide "abc" 4)
printfn "  parseAndDivide '20' 0: %A" (parseAndDivide "20" 0)
printfn ""

// ===== IMMUTABLE DATA STRUCTURES =====
printfn "--- Immutable Data Structures ---"
printfn ""

// Immutable Lists
printfn "Immutable Lists:"
let list1 = [1; 2; 3; 4; 5]
printfn "  Original list: %A" list1

// Operations return NEW lists without modifying original
let list2 = 0 :: list1              // Prepend (cons)
let list3 = list1 @ [6; 7]          // Append
let list4 = List.map ((*) 2) list1  // Map

printfn "  After prepend 0: %A (original unchanged: %A)" list2 list1
printfn "  After append [6;7]: %A" list3
printfn "  After map (*2): %A" list4
printfn ""

// List comprehensions
let squares = [ for x in 1..10 -> x * x ]
let evenSquares = [ for x in 1..10 do if x % 2 = 0 then yield x * x ]

printfn "List comprehensions:"
printfn "  Squares of 1..10: %A" squares
printfn "  Even squares: %A" evenSquares
printfn ""

// Immutable Records
printfn "Immutable Records:"

type Person = {
    Name: string
    Age: int
    City: string
}

let person1 = { Name = "Alice"; Age = 30; City = "New York" }
printfn "  Original: %A" person1

// Creating modified copy (original is unchanged)
let person2 = { person1 with Age = 31 }
let person3 = { person1 with City = "San Francisco" }

printfn "  After age update: %A" person2
printfn "  After city update: %A" person3
printfn "  Original unchanged: %A" person1
printfn ""

// Immutable Maps (Dictionary-like)
printfn "Immutable Maps:"
let map1 = Map.empty
             |> Map.add "Alice" 30
             |> Map.add "Bob" 25
             |> Map.add "Charlie" 35

printfn "  Map contents:"
for kvp in map1 do
    printfn "    %s: %d" kvp.Key kvp.Value

let map2 = map1 |> Map.add "Diana" 28
printfn "  After adding Diana: %A" (map2 |> Map.toList)

// Looking up values
match Map.tryFind "Bob" map1 with
| Some age -> printfn "  Bob's age: %d" age
| None -> printfn "  Bob not found"
printfn ""

// Immutable Sets
printfn "Immutable Sets:"
let set1 = Set.ofList [1; 2; 3; 4; 5]
let set2 = Set.ofList [4; 5; 6; 7; 8]

printfn "  set1: %A" set1
printfn "  set2: %A" set2
printfn "  Union: %A" (Set.union set1 set2)
printfn "  Intersection: %A" (Set.intersect set1 set2)
printfn "  Difference: %A" (Set.difference set1 set2)
printfn ""

// Immutable Arrays (still immutable content, but fixed size)
printfn "Arrays (fixed-size, but elements can be mutable):"
let arr1 = [| 1; 2; 3; 4; 5 |]
printfn "  Original array: %A" arr1

// Array operations return new arrays
let arr2 = Array.map ((*) 2) arr1
printfn "  After map (*2): %A (original: %A)" arr2 arr1
printfn ""

// Sequences (lazy evaluation)
printfn "Sequences (lazy evaluation):"
let infiniteSeq = Seq.initInfinite (fun i -> i * i)
let first10Squares = infiniteSeq |> Seq.take 10 |> Seq.toList

printfn "  First 10 squares from infinite sequence: %A" first10Squares
printfn ""

// Sequence comprehension with filtering
let evenSquaresSeq = 
    seq { 
        for i in 1..20 do
            if i % 2 = 0 then
                yield i * i
    }

printfn "  Even squares (1-20): %A" (evenSquaresSeq |> Seq.toList)
printfn ""

// ===== BENEFITS OF IMMUTABILITY =====
printfn "--- Benefits of Immutability ---"
printfn ""

// Example: Safe sharing of data
let sharedList = [1; 2; 3]
let processedList1 = sharedList |> List.map ((*) 2)
let processedList2 = sharedList |> List.filter (fun x -> x % 2 = 0)

printfn "Safe sharing without defensive copying:"
printfn "  Original: %A" sharedList
printfn "  Processed 1 (doubled): %A" processedList1
printfn "  Processed 2 (evens): %A" processedList2
printfn "  Original still: %A" sharedList
printfn ""

// Example: Thread-safe by default
printfn "Thread-safety:"
printfn "  Immutable data can be safely shared across threads"
printfn "  No locks or synchronization needed"
printfn "  No risk of race conditions"
printfn ""

printfn "=== Key Takeaways ==="
printfn "1. Strings are immutable in F#"
printfn "2. Option type provides null-safety"
printfn "3. Immutable collections prevent accidental modifications"
printfn "4. Operations return new collections, preserving originals"
printfn "5. Immutability enables safe concurrent programming"
printfn "6. Use records with 'with' syntax for updates"
printfn "7. Maps and Sets provide efficient immutable lookups"
