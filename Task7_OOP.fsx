// Task 7: Object-Oriented Programming
// This file demonstrates classes, interfaces, and objects in F# with .NET OOP features

open System

printfn "=== Task 7: Object-Oriented Programming ==="
printfn ""

// ===== CLASSES =====
printfn "--- Classes ---"
printfn ""

// Basic class with primary constructor
type Person(name: string, age: int) =
    // Private field
    let mutable _email = ""
    
    // Public properties
    member this.Name = name
    member this.Age = age
    
    // Property with getter and setter
    member this.Email
        with get() = _email
        and set(value) = _email <- value
    
    // Method
    member this.Introduce() =
        sprintf "Hi, I'm %s and I'm %d years old" name age

let person1 = Person("Alice", 30)
person1.Email <- "alice@example.com"

printfn "Basic class example:"
printfn "  Name: %s" person1.Name
printfn "  Age: %d" person1.Age
printfn "  Email: %s" person1.Email
printfn "  %s" (person1.Introduce())
printfn ""

// Class with additional constructors
type Rectangle(width: float, height: float) =
    // Primary constructor
    
    // Additional constructor for squares
    new(side: float) = Rectangle(side, side)
    
    member this.Width = width
    member this.Height = height
    member this.Area() = width * height
    member this.Perimeter() = 2.0 * (width + height)
    member this.IsSquare() = width = height

let rect1 = Rectangle(5.0, 10.0)
let square1 = Rectangle(5.0)

printfn "Rectangle class with multiple constructors:"
printfn "  Rectangle (5x10): Area=%.2f, Perimeter=%.2f, IsSquare=%b" 
    (rect1.Area()) (rect1.Perimeter()) (rect1.IsSquare())
printfn "  Square (5x5): Area=%.2f, Perimeter=%.2f, IsSquare=%b" 
    (square1.Area()) (square1.Perimeter()) (square1.IsSquare())
printfn ""

// ===== INHERITANCE =====
printfn "--- Inheritance ---"
printfn ""

// Base class
type Animal(name: string) =
    member this.Name = name
    abstract member MakeSound: unit -> string
    default this.MakeSound() = "Some generic sound"
    member this.Describe() = sprintf "%s says: %s" name (this.MakeSound())

// Derived classes
type Dog(name: string, breed: string) =
    inherit Animal(name)
    member this.Breed = breed
    override this.MakeSound() = "Woof!"

type Cat(name: string, color: string) =
    inherit Animal(name)
    member this.Color = color
    override this.MakeSound() = "Meow!"

let dog = Dog("Buddy", "Golden Retriever")
let cat = Cat("Whiskers", "Orange")

printfn "Inheritance example:"
printfn "  %s" (dog.Describe())
printfn "  Breed: %s" dog.Breed
printfn "  %s" (cat.Describe())
printfn "  Color: %s" cat.Color
printfn ""

// ===== INTERFACES =====
printfn "--- Interfaces ---"
printfn ""

// Define an interface
type IShape =
    abstract member Area: unit -> float
    abstract member Perimeter: unit -> float
    abstract member Name: string

// Implement interface in a class
type Circle(radius: float) =
    interface IShape with
        member this.Area() = Math.PI * radius * radius
        member this.Perimeter() = 2.0 * Math.PI * radius
        member this.Name = "Circle"
    
    member this.Radius = radius

type Triangle(base_: float, height: float, side1: float, side2: float) =
    interface IShape with
        member this.Area() = 0.5 * base_ * height
        member this.Perimeter() = base_ + side1 + side2
        member this.Name = "Triangle"

let circle = Circle(5.0)
let triangle = Triangle(4.0, 3.0, 3.0, 5.0)

let describeShape (shape: IShape) =
    sprintf "%s: Area=%.2f, Perimeter=%.2f" shape.Name (shape.Area()) (shape.Perimeter())

printfn "Interface implementation:"
printfn "  %s" (describeShape (circle :> IShape))
printfn "  %s" (describeShape (triangle :> IShape))
printfn ""

// ===== ABSTRACT CLASSES =====
printfn "--- Abstract Classes ---"
printfn ""

[<AbstractClass>]
type Employee(name: string, id: int) =
    member this.Name = name
    member this.Id = id
    abstract member CalculateSalary: unit -> float
    abstract member GetRole: unit -> string

type FullTimeEmployee(name: string, id: int, annualSalary: float) =
    inherit Employee(name, id)
    override this.CalculateSalary() = annualSalary / 12.0
    override this.GetRole() = "Full-Time"

type Contractor(name: string, id: int, hourlyRate: float, hoursWorked: float) =
    inherit Employee(name, id)
    override this.CalculateSalary() = hourlyRate * hoursWorked
    override this.GetRole() = "Contractor"

let emp1 = FullTimeEmployee("Alice", 101, 120000.0)
let emp2 = Contractor("Bob", 102, 75.0, 160.0)

printfn "Abstract class example:"
printfn "  %s (ID: %d, %s): Monthly pay = $%.2f" 
    emp1.Name emp1.Id (emp1.GetRole()) (emp1.CalculateSalary())
printfn "  %s (ID: %d, %s): Monthly pay = $%.2f" 
    emp2.Name emp2.Id (emp2.GetRole()) (emp2.CalculateSalary())
printfn ""

// ===== PROPERTIES AND INDEXERS =====
printfn "--- Properties and Indexers ---"
printfn ""

type ShoppingCart() =
    let mutable items = Map.empty<string, int * float>  // (quantity, price)
    
    // Auto-property
    member val Discount = 0.0 with get, set
    
    // Computed property
    member this.ItemCount = items |> Map.fold (fun acc _ (qty, _) -> acc + qty) 0
    
    member this.Subtotal = 
        items |> Map.fold (fun acc _ (qty, price) -> acc + (float qty * price)) 0.0
    
    member this.Total = this.Subtotal * (1.0 - this.Discount)
    
    // Methods
    member this.AddItem(name, quantity, price) =
        items <- items |> Map.add name (quantity, price)
    
    member this.GetItem(name) =
        Map.tryFind name items
    
    // Indexer
    member this.Item
        with get(name) = Map.tryFind name items

let cart = ShoppingCart()
cart.AddItem("Laptop", 1, 999.99)
cart.AddItem("Mouse", 2, 29.99)
cart.AddItem("Keyboard", 1, 79.99)
cart.Discount <- 0.10

printfn "Shopping cart example:"
printfn "  Items: %d" cart.ItemCount
printfn "  Subtotal: $%.2f" cart.Subtotal
printfn "  Discount: %.0f%%" (cart.Discount * 100.0)
printfn "  Total: $%.2f" cart.Total
printfn "  Laptop details: %A" cart.["Laptop"]
printfn ""

// ===== STATIC MEMBERS =====
printfn "--- Static Members ---"
printfn ""

type MathUtils() =
    // Static method
    static member Add(x, y) = x + y
    static member Multiply(x, y) = x * y
    
    // Static property
    static member PI = 3.14159
    
    // Static field
    static let mutable callCount = 0
    
    static member IncrementCallCount() =
        callCount <- callCount + 1
        callCount

printfn "Static members example:"
printfn "  Add(10, 20) = %d" (MathUtils.Add(10, 20))
printfn "  Multiply(5, 6) = %d" (MathUtils.Multiply(5, 6))
printfn "  PI = %.5f" MathUtils.PI
printfn "  Call count: %d" (MathUtils.IncrementCallCount())
printfn "  Call count: %d" (MathUtils.IncrementCallCount())
printfn ""

// ===== OPERATOR OVERLOADING =====
printfn "--- Operator Overloading ---"
printfn ""

type Vector(x: float, y: float) =
    member this.X = x
    member this.Y = y
    
    // Overload + operator
    static member (+) (v1: Vector, v2: Vector) =
        Vector(v1.X + v2.X, v1.Y + v2.Y)
    
    // Overload * operator (scalar multiplication)
    static member (*) (scalar: float, v: Vector) =
        Vector(scalar * v.X, scalar * v.Y)
    
    member this.Magnitude() =
        sqrt (x * x + y * y)
    
    override this.ToString() =
        sprintf "(%.2f, %.2f)" x y

let v1 = Vector(3.0, 4.0)
let v2 = Vector(1.0, 2.0)
let v3 = v1 + v2
let v4 = 2.0 * v1

printfn "Operator overloading:"
printfn "  v1 = %O" v1
printfn "  v2 = %O" v2
printfn "  v1 + v2 = %O" v3
printfn "  2 * v1 = %O" v4
printfn "  |v1| = %.2f" (v1.Magnitude())
printfn ""

// ===== EVENTS =====
printfn "--- Events ---"
printfn ""

type Button() =
    let clickEvent = new Event<_>()
    
    // Expose event
    [<CLIEvent>]
    member this.Click = clickEvent.Publish
    
    // Trigger event
    member this.PerformClick(message: string) =
        clickEvent.Trigger(message)

type TextBox() =
    let textChangedEvent = new Event<_>()
    let mutable text = ""
    
    [<CLIEvent>]
    member this.TextChanged = textChangedEvent.Publish
    
    member this.Text
        with get() = text
        and set(value) =
            text <- value
            textChangedEvent.Trigger(value)

let button = Button()
let textbox = TextBox()

// Subscribe to events
button.Click.Add(fun msg -> printfn "  Button clicked: %s" msg)
textbox.TextChanged.Add(fun txt -> printfn "  Text changed to: %s" txt)

printfn "Events example:"
button.PerformClick("First click")
button.PerformClick("Second click")
textbox.Text <- "Hello"
textbox.Text <- "Hello, World!"
printfn ""

// ===== GENERICS =====
printfn "--- Generics ---"
printfn ""

type Stack<'T>() =
    let mutable items: 'T list = []
    
    member this.Push(item: 'T) =
        items <- item :: items
    
    member this.Pop() =
        match items with
        | [] -> None
        | head :: tail ->
            items <- tail
            Some head
    
    member this.Peek() =
        match items with
        | [] -> None
        | head :: _ -> Some head
    
    member this.Count = List.length items
    member this.IsEmpty = List.isEmpty items

let intStack = Stack<int>()
intStack.Push(1)
intStack.Push(2)
intStack.Push(3)

let stringStack = Stack<string>()
stringStack.Push("Hello")
stringStack.Push("World")

printfn "Generic stack example:"
printfn "  Int stack count: %d" intStack.Count
printfn "  Pop from int stack: %A" (intStack.Pop())
printfn "  String stack count: %d" stringStack.Count
printfn "  Peek string stack: %A" (stringStack.Peek())
printfn ""

// ===== INTEROPERABILITY WITH .NET =====
printfn "--- .NET Interoperability ---"
printfn ""

// Using .NET collection classes
let arrayList = System.Collections.ArrayList()
arrayList.Add("F#") |> ignore
arrayList.Add("C#") |> ignore
arrayList.Add("VB.NET") |> ignore

printfn ".NET Collections:"
printfn "  ArrayList contents:"
for item in arrayList do
    printfn "    - %O" item

// Using .NET LINQ
let numbers = [| 1..10 |]
let evenSquares = 
    numbers
    |> Seq.filter (fun x -> x % 2 = 0)
    |> Seq.map (fun x -> x * x)
    |> Seq.toArray

printfn "  LINQ-style operations: %A" evenSquares
printfn ""

// ===== EXTENSION METHODS =====
printfn "--- Extension Methods ---"
printfn ""

type System.String with
    member this.WordCount() =
        this.Split([| ' '; '\t'; '\n' |], StringSplitOptions.RemoveEmptyEntries).Length
    
    member this.IsEmail() =
        this.Contains("@") && this.Contains(".")

let sentence = "F# is a powerful functional-first language"
let email = "user@example.com"

printfn "Extension methods:"
printfn "  '%s'" sentence
printfn "  Word count: %d" (sentence.WordCount())
printfn "  Is '%s' an email? %b" email (email.IsEmail())
printfn ""

printfn "=== Key Concepts ==="
printfn "1. F# supports full OOP with classes, interfaces, and inheritance"
printfn "2. Classes can have primary and additional constructors"
printfn "3. Abstract classes and interfaces define contracts"
printfn "4. Properties provide controlled access to data"
printfn "5. Static members belong to the type, not instances"
printfn "6. Operator overloading enables custom operators"
printfn "7. Events enable pub-sub pattern"
printfn "8. Generics provide type-safe reusable components"
printfn "9. Full interoperability with .NET framework"
printfn "10. Extension methods add functionality to existing types"
