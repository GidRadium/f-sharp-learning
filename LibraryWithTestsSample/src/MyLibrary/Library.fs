namespace MyLibrary

module Say =
    let hello name =
        printfn "Hello %s" name

module Fibonacci =
    let rec countSlow (number: int): bigint =
        if number >= -1 && number <= 1 then bigint(number)
        elif number > 1 then countSlow (number - 1) + countSlow (number - 2)
        else countSlow (number + 2) - countSlow (number + 1) // F(n+2) - F(n+1) = F(n)

    let countMedium (number: int): bigint = 
        if number >= -1 && number <= 1 then bigint number
        else
            let mutable a = 0I
            let mutable b = if number < 0 then -1I else 1I
            let mutable temp = 0I
            for i in 2 .. abs number do
                temp <- a + b * if number < 0 then -1I else 1I
                a <- b
                b <- temp
            b

    let countFast (number: int): bigint =
        let matrixMul (a: bigint[,]) (b: bigint[,]) =
            let c = Array2D.zeroCreate<bigint> 2 2
            c.[0, 0] <- a.[0, 0] * b.[0, 0] + a.[0, 1] * b.[1, 0]
            c.[0, 1] <- a.[0, 0] * b.[0, 1] + a.[0, 1] * b.[1, 1]
            c.[1, 0] <- a.[1, 0] * b.[0, 0] + a.[1, 1] * b.[1, 0]
            c.[1, 1] <- a.[1, 0] * b.[0, 1] + a.[1, 1] * b.[1, 1]
            c

        let absNumber = abs number

        let mutable size = 1
        while 1 <<< size <= absNumber do size <- size + 1
        let mutable matricsPow2s : bigint[,][] = Array.init size (fun _ -> Array2D.zeroCreate<bigint> 2 2)
        matricsPow2s.[0] <- array2D [[1I; 1I]; [1I; 0I]]

        let mutable i = 1
        while 1 <<< i <= absNumber do
            matricsPow2s.[i] <- matrixMul matricsPow2s.[i - 1] matricsPow2s.[i - 1]
            i <- i + 1

        let mutable resultMatrix = array2D [[1I; 0I]; [0I; 1I]]
        let mutable i = 0
        let mutable n = absNumber
        while n > 0 do
            resultMatrix <- if n % 2 = 1 then matrixMul resultMatrix matricsPow2s.[i] else resultMatrix
            i <- i + 1
            n <- n >>> 1

        resultMatrix.[0, 1] * if number < 0 && absNumber % 2 = 1 then -1I else 1I

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
