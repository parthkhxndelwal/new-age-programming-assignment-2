# F# Programming Assignment - Setup and Execution Guide

## Quick Start Guide

### Step 1: Verify .NET Installation

Open PowerShell or Command Prompt and run:

```powershell
dotnet --version
```

You should see version 6.0 or later. If not installed, download from:
https://dotnet.microsoft.com/download

### Step 2: Verify F# Interactive

```powershell
dotnet fsi --version
```

This should show the F# compiler version.

### Step 3: Navigate to Project Directory

```powershell
cd "c:\Users\Parth K\OneDrive\Documents\assignments\newage\aastha\new-age-programming-assignment-2"
```

### Step 4: Run Individual Tasks

Run any task file:

```powershell
dotnet fsi Task1_Syntax_Basics.fsx
dotnet fsi Task2_Control_Flow.fsx
dotnet fsi Task3_Functions.fsx
dotnet fsi Task4_Strings_Options_Immutable.fsx
dotnet fsi Task5_Pattern_Matching.fsx
dotnet fsi Task6_Async_Parallel.fsx
dotnet fsi Task7_OOP.fsx
dotnet fsi Task8_Database_Access.fsx
dotnet fsi Task9_Data_Querying.fsx
```

### Step 5: Run All Tasks at Once

```powershell
dotnet fsi RunAll.fsx
```

## Detailed Setup Instructions

### Installing .NET SDK (if not installed)

1. Go to https://dotnet.microsoft.com/download
2. Download the .NET SDK (version 6.0 or later)
3. Run the installer
4. Restart your terminal/PowerShell
5. Verify: `dotnet --version`

### Setting Up Visual Studio Code (Optional but Recommended)

1. **Install VS Code**
   - Download from: https://code.visualstudio.com/

2. **Install Ionide Extension**
   - Open VS Code
   - Go to Extensions (Ctrl+Shift+X)
   - Search for "Ionide-fsharp"
   - Click Install

3. **Open Project**
   - File → Open Folder
   - Select the project directory
   - You can now run .fsx files directly from VS Code

### Running Code in VS Code

1. Open any `.fsx` file
2. Press `Alt+Enter` to send the entire file to F# Interactive
3. Or select specific code and press `Alt+Enter` to run selection
4. View output in the F# Interactive pane

## Database Setup (Optional - for Tasks 8 and 9)

### SQL Server Setup

Tasks 8 and 9 work without databases using simulated data, but if you want to test actual database operations:

1. **Install SQL Server Express**
   - Download from: https://www.microsoft.com/sql-server/sql-server-downloads
   - Choose "Express" edition (free)

2. **Update Connection String**
   - Open `Task8_Database_Access.fsx`
   - Update line: `let sqlConnectionString = "..."`
   - Use your SQL Server instance name

3. **Install Package**
   ```powershell
   dotnet add package System.Data.SqlClient
   ```

### MongoDB Setup

1. **Install MongoDB Community Edition**
   - Download from: https://www.mongodb.com/try/download/community

2. **Start MongoDB Service**
   ```powershell
   net start MongoDB
   ```

3. **Install Package**
   ```powershell
   dotnet add package MongoDB.Driver
   ```

## Running Examples

### Example 1: Run Task 1 (Syntax Basics)

```powershell
PS> dotnet fsi Task1_Syntax_Basics.fsx

=== Task 1: F# Syntax & Basics ===

Integer Types:
  int: 42
  int64: 100
  byte: 255
...
```

### Example 2: Test a Specific Function

Create a test file `test.fsx`:

```fsharp
// Load a task file
#load "Task3_Functions.fsx"

// Test a specific function
let result = square 5
printfn "Square of 5 is %d" result
```

Run it:
```powershell
dotnet fsi test.fsx
```

### Example 3: Interactive Mode

```powershell
PS> dotnet fsi

> let add x y = x + y;;
val add: x:int -> y:int -> int

> add 10 20;;
val it: int = 30

> #quit;;
```

## Common Issues and Solutions

### Issue 1: "dotnet: command not found"

**Solution:**
- Install .NET SDK
- Restart terminal
- Check PATH environment variable includes .NET

### Issue 2: F# Interactive Not Starting

**Solution:**
```powershell
# Try explicit path
"C:\Program Files\dotnet\dotnet.exe" fsi
```

### Issue 3: Script Execution Policy (Windows)

**Error:** "cannot be loaded because running scripts is disabled"

**Solution:**
```powershell
Set-ExecutionPolicy -ExecutionPolicy RemoteSigned -Scope CurrentUser
```

### Issue 4: Package Not Found

**Solution:**
```powershell
# Restore packages
dotnet restore

# Or install specific package
dotnet add package <PackageName>
```

### Issue 5: File Not Found

**Solution:**
- Ensure you're in the correct directory
- Use absolute paths if needed
- Check file names (case-sensitive on some systems)

## Testing Your Setup

Create a simple test file `hello.fsx`:

```fsharp
printfn "Hello, F#!"
printfn "Your setup is working correctly!"
```

Run it:
```powershell
dotnet fsi hello.fsx
```

Expected output:
```
Hello, F#!
Your setup is working correctly!
```

## Performance Tips

1. **Use Compiled Mode for Large Projects**
   ```powershell
   fsharpc Task1_Syntax_Basics.fsx
   ./Task1_Syntax_Basics.exe
   ```

2. **Load Multiple Files**
   ```fsharp
   #load "Task1_Syntax_Basics.fsx"
   #load "Task2_Control_Flow.fsx"
   ```

3. **Timing Execution**
   ```fsharp
   #time "on";;
   // Your code here
   #time "off";;
   ```

## Getting Output

### Save Output to File

```powershell
dotnet fsi Task1_Syntax_Basics.fsx > output.txt
```

### View Output in Browser

```fsharp
// Add to your script
let output = System.IO.File.CreateText("output.html")
fprintf output "<h1>Results</h1>"
output.Close()
```

## Additional Resources

### Documentation
- F# Language Reference: https://docs.microsoft.com/en-us/dotnet/fsharp/
- F# for Fun and Profit: https://fsharpforfunandprofit.com/

### Learning
- F# Tutorial: https://fsharp.org/learn/
- Try F#: https://try.fsharp.org/

### Community
- F# Software Foundation: https://fsharp.org/
- F# Slack: https://fsharp.org/guides/slack/

## Submission Checklist

Before submitting:

- [ ] All 9 task files run without errors
- [ ] README.md is complete and accurate
- [ ] Code is well-commented
- [ ] .gitignore is present
- [ ] Repository is on GitHub
- [ ] Screenshots taken (optional)
- [ ] All output verified

## Next Steps

1. Test all files individually
2. Run RunAll.fsx to verify all tasks work
3. Take screenshots of execution
4. Create GitHub repository
5. Push all files
6. Submit repository URL

## Support

If you encounter issues:
1. Check this SETUP.md file
2. Review error messages carefully
3. Verify .NET installation
4. Check file paths
5. Consult F# documentation

---

**Good luck with your assignment!**
