namespace HW1LibraryTests

open System
open Microsoft.VisualStudio.TestTools.UnitTesting
open HW1Library

[<TestClass>]
type TestClass () =

    [<TestMethod>]
    member this.FibonacciPositiveTests () =
        let testCases = [ (0, 0I); (1, 1I); (2, 1I); (3, 2I); (9, 34I); (35, 9227465I); ]
        for value, expected in testCases do
            Assert.AreEqual (expected, HW1Library.Fibonacci.count value)
    
    [<TestMethod>]
    member this.FibonacciNegativeTests () =
        let testCases = [ (-0, 0I); (-1, -1I); (-2, 1I); (-3, -2I); (-9, -34I); (-35, -9227465I); (-36, 14930352I); ]
        for value, expected in testCases do
            Assert.AreEqual (expected, HW1Library.Fibonacci.count value)
        
    [<TestMethod>]
    member this.FibonacciBigTests () =
        let testCases = [ (0, 0I); (50, 12586269025I); (-51, -20365011074I); (199, 173402521172797813159685037284371942044301I); (-199, -173402521172797813159685037284371942044301I); ]
        for value, expected in testCases do
            Assert.AreEqual (expected, HW1Library.Fibonacci.count value)
