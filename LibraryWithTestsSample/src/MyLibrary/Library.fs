namespace MyLibrary

module Say =
    let hello name =
        printfn "Hello %s" name

module Fibonacci =
    let rec countSlow number =
        if number >= -1 && number <= 1 then number
        elif number > 1 then countSlow (number - 1) + countSlow (number - 2)
        else countSlow (number + 2) - countSlow (number + 1) // F(n+2) - F(n+1) = F(n)

    let countMedium number = 
        if number >= -1 && number <= 1 then number
        else
            let mutable a = 0
            let mutable b = sign(number)
            let mutable temp = 0
            for i in 2 .. number * sign(number) do
                temp <- a + b * sign(number)
                a <- b
                b <- temp
            b

    let countFast number =
        let matrixMul (a: bigint[,]) (b: bigint[,]) =
            let c = Array2D.zeroCreate<bigint> 2 2
            c.[0, 0] <- a.[0, 0] * b.[0, 0] + a.[0, 1] * b.[1, 0]
            c.[0, 1] <- a.[0, 0] * b.[0, 1] + a.[0, 1] * b.[1, 1]
            c.[1, 0] <- a.[1, 0] * b.[0, 0] + a.[1, 1] * b.[1, 0]
            c.[1, 1] <- a.[1, 0] * b.[0, 1] + a.[1, 1] * b.[1, 1]
            c

        let mutable n = number
        let mutable matricsPow2s : bigint[,][] = Array.init 300 (fun _ -> Array2D.zeroCreate<bigint> 2 2)
        matricsPow2s.[0] <- array2D [[1I; 1I]; [1I; 0I]]
        let mutable pow2 = 1
        let mutable i = 0
        let mutable pow2Matrix = array2D [[1I; 1I]; [1I; 0I]]
        while pow2 * 2 <= n do
            pow2 <- pow2 * 2
            i <- i + 1
            pow2Matrix <- matrixMul pow2Matrix pow2Matrix
            matricsPow2s.[i] <- pow2Matrix
        
        let mutable resultMatrix = array2D [[1I; 0I]; [0I; 1I]]
        let mutable i = 0
        while n > 0 do
            resultMatrix <- if n % 2 = 1 then matrixMul resultMatrix matricsPow2s.[i] else resultMatrix
            i <- i + 1
            n <- n / 2

        resultMatrix.[0, 1]


module Factorial =
    let countMedium number =
        let mutable result = 1
        for i in 1 .. number do
            result <- result * i
        result

module Sort =
    let bubble (array: int[]) =
        let mutable sorted = false
        while not sorted do
            sorted <- true
            for i in 0 .. (array.Length - 2) do
                if array.[i] > array.[i + 1] then
                    let temp = array.[i]
                    array.[i] <- array.[i + 1]
                    array.[i + 1] <- temp
                    sorted <- false
        array
