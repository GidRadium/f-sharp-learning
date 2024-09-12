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
