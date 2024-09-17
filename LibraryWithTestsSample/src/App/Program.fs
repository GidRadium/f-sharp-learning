open System
open MyLibrary

// for i in -10 .. 10 do
//     printfn $"F({i}) = {MyLibrary.Fibonacci.countSlow i} | {MyLibrary.Fibonacci.countMedium i} | {MyLibrary.Fibonacci.countFast i}"

open System.Diagnostics

let measureTime (func: int -> bigint) (n: int) =
    let stopwatch = Stopwatch.StartNew()
    let _ = func n
    stopwatch.Stop()
    stopwatch.ElapsedMilliseconds

let mutable i = 1
let mutable time = 0L

printfn "Slow"
let timer1 = Stopwatch.StartNew()
while timer1.ElapsedMilliseconds < 5000L do
    time <- measureTime MyLibrary.Fibonacci.countSlow i
    printfn $"F({i}) | {time}ms"
    i <- i + 1
timer1.Stop()

i <- 1
printfn "Medium"
let timer2 = Stopwatch.StartNew()
while timer2.ElapsedMilliseconds < 5000L do
    time <- measureTime MyLibrary.Fibonacci.countMedium i
    printfn $"F({i}) | {time}ms"
    i <- i * 2
timer2.Stop()

i <- 1
printfn "Fast"
let timer3 = Stopwatch.StartNew()
while timer3.ElapsedMilliseconds < 5000L do
    time <- measureTime MyLibrary.Fibonacci.countFast i
    printfn $"F({i}) | {time}ms"
    i <- i * 10
timer3.Stop()

