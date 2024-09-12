open System
open MyLibrary

for i in -10 .. 10 do
    printfn $"F({i}) = {MyLibrary.Fibonacci.countSlow i} | {MyLibrary.Fibonacci.countMedium i}"
