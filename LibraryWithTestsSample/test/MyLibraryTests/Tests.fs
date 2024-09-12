namespace MyLibraryTests

open System
open Microsoft.VisualStudio.TestTools.UnitTesting
open MyLibrary


[<TestClass>]
type TestClass () =

    [<TestMethod>]
    member this.TestFibonacciSlowZero () =
        let actual = MyLibrary.Fibonacci.countSlow (0)
        let expected = 0
        Assert.AreEqual(expected, actual)

    [<TestMethod>]
    member this.TestFibonacciSlowOne () =
        let actual = MyLibrary.Fibonacci.countSlow (1)
        let expected = 1
        Assert.AreEqual(expected, actual)

    [<TestMethod>]
    member this.TestFibonacciSlowNegativeOne () =
        let actual = MyLibrary.Fibonacci.countSlow (-1)
        let expected = -1
        Assert.AreEqual(expected, actual)

    [<TestMethod>]
    member this.TestFibonacciSlowNine () =
        let actual = MyLibrary.Fibonacci.countSlow (9)
        let expected = 34
        Assert.AreEqual(expected, actual)

    [<TestMethod>]
    member this.TestFibonacciSlowNegativeNine () =
        let actual = MyLibrary.Fibonacci.countSlow (-9)
        let expected = -34
        Assert.AreEqual(expected, actual)

    [<TestMethod>]
    member this.TestFibonacciConsistency () =
        let testValues = [| 0; 1; 2; 3; 4; 5; 6; 7; 8; 9; 10; -9; -10; -11 |]
        
        for value in testValues do
            let actualSlow = MyLibrary.Fibonacci.countSlow (value)
            let actualMedium = MyLibrary.Fibonacci.countMedium (value)
            Assert.AreEqual(actualSlow, actualMedium)
