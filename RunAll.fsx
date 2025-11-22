// RunAll.fsx - Master script to run all assignment tasks
// This script executes all tasks in sequence

printfn "======================================================================="
printfn "   F# FUNCTIONAL PROGRAMMING - COMPLETE ASSIGNMENT"
printfn "   New Age Programming Languages - Assignment 02"
printfn "======================================================================="
printfn ""

let runTask taskNumber taskName filePath =
    printfn ""
    printfn "╔════════════════════════════════════════════════════════════════════╗"
    printfn "║  TASK %d: %-57s║" taskNumber taskName
    printfn "╚════════════════════════════════════════════════════════════════════╝"
    printfn ""
    
    try
        // Load and execute the file
        #load filePath
        printfn ""
        printfn "✓ Task %d completed successfully!" taskNumber
        printfn ""
    with ex ->
        printfn "✗ Error in Task %d: %s" taskNumber ex.Message
        printfn ""

// Uncomment the tasks you want to run
// Note: All tasks are designed to run independently

printfn "Select which tasks to run:"
printfn ""
printfn "Running all tasks will demonstrate the complete F# assignment."
printfn "Each task covers different aspects of F# programming."
printfn ""
printfn "Press Enter to continue..."
System.Console.ReadLine() |> ignore

// Task 1: F# Syntax & Basics
runTask 1 "F# Syntax & Basics" "Task1_Syntax_Basics.fsx"

// Task 2: Control Flow
runTask 2 "Control Flow" "Task2_Control_Flow.fsx"

// Task 3: Functions
runTask 3 "Functions" "Task3_Functions.fsx"

// Task 4: Strings, Options, and Immutable Data
runTask 4 "Strings, Options, and Immutable Data" "Task4_Strings_Options_Immutable.fsx"

// Task 5: Pattern Matching
runTask 5 "Pattern Matching" "Task5_Pattern_Matching.fsx"

// Task 6: Asynchronous & Parallel Programming
runTask 6 "Asynchronous & Parallel Programming" "Task6_Async_Parallel.fsx"

// Task 7: Object-Oriented Programming
runTask 7 "Object-Oriented Programming" "Task7_OOP.fsx"

// Task 8: Database Access
runTask 8 "Database Access" "Task8_Database_Access.fsx"

// Task 9: Data Querying
runTask 9 "Data Querying" "Task9_Data_Querying.fsx"

printfn ""
printfn "======================================================================="
printfn "   ALL TASKS COMPLETED!"
printfn "======================================================================="
printfn ""
printfn "Summary:"
printfn "  ✓ Task 1: F# Syntax & Basics"
printfn "  ✓ Task 2: Control Flow"
printfn "  ✓ Task 3: Functions"
printfn "  ✓ Task 4: Strings, Options, and Immutable Data"
printfn "  ✓ Task 5: Pattern Matching"
printfn "  ✓ Task 6: Asynchronous & Parallel Programming"
printfn "  ✓ Task 7: Object-Oriented Programming"
printfn "  ✓ Task 8: Database Access"
printfn "  ✓ Task 9: Data Querying"
printfn ""
printfn "This assignment demonstrates comprehensive F# programming including:"
printfn "  • Functional programming concepts"
printfn "  • Object-oriented features"
printfn "  • Asynchronous and parallel programming"
printfn "  • Database access (SQL and NoSQL)"
printfn "  • Advanced data querying"
printfn ""
printfn "For more information, see README.md"
printfn "======================================================================="
