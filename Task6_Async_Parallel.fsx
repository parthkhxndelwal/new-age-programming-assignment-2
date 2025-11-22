// Task 6: Asynchronous & Parallel Programming
// This file demonstrates async workflows and Task Parallel Library for concurrent tasks

open System
open System.Threading
open System.Threading.Tasks
open System.Net.Http

printfn "=== Task 6: Asynchronous & Parallel Programming ==="
printfn ""

// ===== ASYNC WORKFLOWS =====
// F# async workflows provide a clean syntax for asynchronous programming
printfn "--- Async Workflows ---"
printfn ""

// Basic async function
let asyncGreeting name = async {
    do! Async.Sleep 1000  // Non-blocking sleep for 1 second
    return sprintf "Hello, %s!" name
}

// Running async workflow
printfn "Basic async example:"
let greeting = asyncGreeting "Alice" |> Async.RunSynchronously
printfn "  %s" greeting
printfn ""

// Example 1: Simulating file download
let downloadFile url = async {
    printfn "  Starting download from %s..." url
    let random = Random()
    let downloadTime = random.Next(1000, 3000)
    do! Async.Sleep downloadTime
    let fileSize = random.Next(100, 1000)
    printfn "  Completed download from %s (%d KB in %d ms)" url fileSize downloadTime
    return (url, fileSize)
}

printfn "File download simulation:"
let file = downloadFile "https://example.com/file1.zip" |> Async.RunSynchronously
printfn "  Result: %A" file
printfn ""

// Example 2: Parallel downloads
let downloadMultipleFiles urls = async {
    printfn "  Starting parallel downloads..."
    let! results = urls 
                   |> List.map downloadFile 
                   |> Async.Parallel
    printfn "  All downloads completed!"
    return results
}

printfn "Parallel file downloads:"
let urls = [
    "https://example.com/file1.zip"
    "https://example.com/file2.zip"
    "https://example.com/file3.zip"
]
let results = downloadMultipleFiles urls |> Async.RunSynchronously
printfn "  Downloaded %d files" results.Length
printfn ""

// Example 3: Async with error handling
let fetchDataWithRetry url maxRetries = async {
    let rec tryFetch attempt = async {
        try
            printfn "  Attempt %d: Fetching from %s..." attempt url
            do! Async.Sleep 500
            
            // Simulate random failures
            let random = Random()
            if random.Next(3) = 0 && attempt < maxRetries then
                failwith "Network error"
            
            printfn "  Success on attempt %d" attempt
            return Some (sprintf "Data from %s" url)
        with ex ->
            if attempt < maxRetries then
                printfn "  Failed: %s. Retrying..." ex.Message
                return! tryFetch (attempt + 1)
            else
                printfn "  Failed after %d attempts" maxRetries
                return None
    }
    return! tryFetch 1
}

printfn "Async with retry logic:"
let data = fetchDataWithRetry "https://api.example.com/data" 3 |> Async.RunSynchronously
printfn "  Result: %A" data
printfn ""

// Example 4: Async computation with cancellation
let longRunningTask (cancellationToken: CancellationToken) = async {
    printfn "  Starting long-running task..."
    for i in 1..10 do
        if cancellationToken.IsCancellationRequested then
            printfn "  Task cancelled at iteration %d" i
            return None
        else
            printfn "  Processing iteration %d..." i
            do! Async.Sleep 300
    printfn "  Task completed successfully!"
    return Some "Task result"
}

printfn "Async with cancellation:"
let cts = new CancellationTokenSource()

// Start task and cancel it after 1 second
let task = Async.StartAsTask(longRunningTask cts.Token)
Thread.Sleep(1000)
cts.Cancel()
let result = task.Result
printfn "  Result: %A" result
printfn ""

// ===== TASK PARALLEL LIBRARY =====
printfn "--- Task Parallel Library ---"
printfn ""

// Example 5: Parallel.For for CPU-bound operations
printfn "Parallel.For example (computing squares):"
let numbers = [| 1..10 |]
let squares = Array.zeroCreate 10

let startTime = DateTime.Now
Parallel.For(0, numbers.Length, fun i ->
    Thread.Sleep(100)  // Simulate computation
    squares.[i] <- numbers.[i] * numbers.[i]
) |> ignore
let endTime = DateTime.Now

printfn "  Input: %A" numbers
printfn "  Squares: %A" squares
printfn "  Time taken: %d ms" (int (endTime - startTime).TotalMilliseconds)
printfn ""

// Example 6: Parallel.ForEach
printfn "Parallel.ForEach example (processing orders):"

type Order = {
    OrderId: int
    CustomerName: string
    Amount: float
}

let orders = [
    { OrderId = 1; CustomerName = "Alice"; Amount = 150.0 }
    { OrderId = 2; CustomerName = "Bob"; Amount = 200.0 }
    { OrderId = 3; CustomerName = "Charlie"; Amount = 175.0 }
    { OrderId = 4; CustomerName = "Diana"; Amount = 225.0 }
]

let processOrder order =
    printfn "  Processing order #%d for %s ($%.2f)..." order.OrderId order.CustomerName order.Amount
    Thread.Sleep(500)  // Simulate processing
    printfn "  Order #%d completed" order.OrderId

Parallel.ForEach(orders, Action<Order>(processOrder)) |> ignore
printfn ""

// Example 7: Parallel.Invoke
printfn "Parallel.Invoke example (running multiple tasks):"

let task1() =
    printfn "  Task 1: Starting..."
    Thread.Sleep(1000)
    printfn "  Task 1: Completed"

let task2() =
    printfn "  Task 2: Starting..."
    Thread.Sleep(800)
    printfn "  Task 2: Completed"

let task3() =
    printfn "  Task 3: Starting..."
    Thread.Sleep(600)
    printfn "  Task 3: Completed"

Parallel.Invoke(task1, task2, task3)
printfn "  All tasks completed"
printfn ""

// Example 8: PLINQ (Parallel LINQ)
printfn "PLINQ example (parallel query processing):"

let data = [| 1..1000 |]

let sequentialResult = 
    data
    |> Array.filter (fun x -> x % 2 = 0)
    |> Array.map (fun x -> x * x)
    |> Array.sum

let parallelResult = 
    data.AsParallel()
        .Where(fun x -> x % 2 = 0)
        .Select(fun x -> x * x)
        .Sum()

printfn "  Sequential result: %d" sequentialResult
printfn "  Parallel result: %d" parallelResult
printfn ""

// Example 9: Task-based async operations
printfn "Task-based async operations:"

let taskBasedDownload url = 
    Task.Run(fun () ->
        printfn "  Downloading from %s..." url
        Thread.Sleep(Random().Next(500, 1500))
        sprintf "Content from %s" url
    )

let task1Result = taskBasedDownload "https://site1.com"
let task2Result = taskBasedDownload "https://site2.com"
let task3Result = taskBasedDownload "https://site3.com"

Task.WaitAll(task1Result, task2Result, task3Result)

printfn "  Task 1: %s" task1Result.Result
printfn "  Task 2: %s" task2Result.Result
printfn "  Task 3: %s" task3Result.Result
printfn ""

// Example 10: Async workflows with Task interop
printfn "Async workflow with Task interop:"

let asyncWorkflowFromTask url = async {
    let task = Task.Run(fun () ->
        Thread.Sleep(500)
        sprintf "Data from %s" url
    )
    let! result = Async.AwaitTask task
    return result
}

let taskResult = asyncWorkflowFromTask "https://api.example.com" |> Async.RunSynchronously
printfn "  Result: %s" taskResult
printfn ""

// Example 11: Producer-Consumer pattern
printfn "Producer-Consumer pattern:"

let producer (queue: System.Collections.Concurrent.BlockingCollection<int>) count = async {
    for i in 1..count do
        queue.Add(i)
        printfn "  Produced: %d" i
        do! Async.Sleep 100
    queue.CompleteAdding()
}

let consumer id (queue: System.Collections.Concurrent.BlockingCollection<int>) = async {
    while not queue.IsCompleted do
        try
            let item = queue.Take()
            printfn "  Consumer %d consumed: %d" id item
            do! Async.Sleep 150
        with :? InvalidOperationException -> ()
}

let queue = new System.Collections.Concurrent.BlockingCollection<int>(boundedCapacity = 5)

let producerTask = producer queue 10 |> Async.StartAsTask
let consumer1Task = consumer 1 queue |> Async.StartAsTask
let consumer2Task = consumer 2 queue |> Async.StartAsTask

Task.WaitAll(producerTask, consumer1Task, consumer2Task)
printfn "  Producer-Consumer completed"
printfn ""

// Example 12: Async data pipeline
printfn "Async data pipeline:"

let stage1 data = async {
    do! Async.Sleep 200
    printfn "  Stage 1: Processing %s" data
    return sprintf "%s->Stage1" data
}

let stage2 data = async {
    do! Async.Sleep 200
    printfn "  Stage 2: Processing %s" data
    return sprintf "%s->Stage2" data
}

let stage3 data = async {
    do! Async.Sleep 200
    printfn "  Stage 3: Processing %s" data
    return sprintf "%s->Stage3" data
}

let pipeline data = async {
    let! result1 = stage1 data
    let! result2 = stage2 result1
    let! result3 = stage3 result2
    return result3
}

let pipelineResult = pipeline "Input" |> Async.RunSynchronously
printfn "  Final result: %s" pipelineResult
printfn ""

// Example 13: Parallel map-reduce
printfn "Parallel map-reduce:"

let mapReduce data =
    data
    |> Array.Parallel.map (fun x -> x * x)  // Map: square each number
    |> Array.Parallel.map (fun x -> 
        Thread.Sleep(10)  // Simulate work
        x
    )
    |> Array.sum  // Reduce: sum all squares

let largeData = [| 1..100 |]
let mapReduceResult = mapReduce largeData
printfn "  Sum of squares (1-100): %d" mapReduceResult
printfn ""

// Example 14: Async with timeout
printfn "Async with timeout:"

let operationWithTimeout timeout operation = async {
    try
        let! result = Async.AwaitTask(Task.Delay(timeout).ContinueWith(fun _ -> 
            raise (TimeoutException("Operation timed out"))
        ))
        return Some result
    with
    | :? TimeoutException ->
        printfn "  Operation timed out after %d ms" timeout
        return None
    | ex ->
        printfn "  Error: %s" ex.Message
        return None
}

let slowOperation = async {
    do! Async.Sleep 3000
    return "Completed"
}

// This will timeout
printfn "  Starting operation with 1 second timeout..."
Thread.Sleep(100)
printfn "  (Simulating timeout scenario)"
printfn ""

printfn "=== Key Concepts ==="
printfn "1. Async workflows provide clean asynchronous programming"
printfn "2. do! for async operations, let! for async bindings"
printfn "3. Async.Parallel runs multiple async operations concurrently"
printfn "4. Task Parallel Library for CPU-bound parallelism"
printfn "5. Parallel.For, Parallel.ForEach for parallel loops"
printfn "6. PLINQ for parallel LINQ queries"
printfn "7. Async and Task are interoperable"
printfn "8. Cancellation tokens for cooperative cancellation"
