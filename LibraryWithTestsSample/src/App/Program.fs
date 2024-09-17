open System
open MyLibrary

for i in 0 .. 10 do
    printfn $"F({i}) = {MyLibrary.Fibonacci.countSlow i} | {MyLibrary.Fibonacci.countMedium i} | {MyLibrary.Fibonacci.countFast i}"
