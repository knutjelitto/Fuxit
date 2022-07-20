module Int exposing
  ( Int
  , add
  , sub
  , mul
  , div
  , modBy, remainderBy, negate
  )

{-| Basic Int type.

# Math
@docs Int, add, sub, mul, div

# Fancier Math
@docs modBy, remainderBy

-}


import Fux.Core.Int


-- MATHEMATICS


{-| An `Int` is a whole number. Valid syntax for integers includes:

    0
    42
    9000
    0xFF   -- 255 in hexadecimal
    0x000A --  10 in hexadecimal

**Note:** `Int` math is well-defined in the range `-2^31` to `2^31 - 1`. Outside
of that range, the behavior is determined by the compilation target. When
generating JavaScript, the safe range expands to `-2^53` to `2^53 - 1` for some
operations, but if we generate WebAssembly some day, we would do the traditional
[integer overflow][io]. This quirk is necessary to get good performance on
quirky compilation targets.

**Historical Note:** The name `Int` comes from the term [integer][]. It appears
that the `int` abbreviation was introduced in [ALGOL 68][68], shortening it
from `integer` in [ALGOL 60][60]. Today, almost all programming languages use
this abbreviation.

[io]: https://en.wikipedia.org/wiki/Integer_overflow
[integer]: https://en.wikipedia.org/wiki/Integer
[60]: https://en.wikipedia.org/wiki/ALGOL_60
[68]: https://en.wikipedia.org/wiki/ALGOL_68
-}
type Int = Int -- NOTE: The compiler provides the real implementation.

add : Int -> Int -> Int
add =
  Fux.Core.Int.add


{-| Subtract numbers like `4 - 3 == 1`.

-}
sub : Int -> Int -> Int
sub =
  Fux.Core.Int.sub


{-| Multiply numbers like `2 * 3 == 6`.

-}
mul : Int -> Int -> Int
mul =
  Fux.Core.Int.mul


{-| Integer division:

    10 / 4 == 2
    11 / 4 == 2
    12 / 4 == 3
    13 / 4 == 3
    14 / 4 == 3

    -1 / 4 == 0
    -5 / 4 == -1

Notice that the remainder is discarded, so `3 / 4` is giving output
similar to `truncate (3 / 4)`.

It may sometimes be useful to pair this with the [`remainderBy`](#remainderBy)
function.
-}
div : Int -> Int -> Int
div =
  Fux.Core.Int.div


{-| Exponentiation

    3^2 == 9
    3^3 == 27
-}
pow : Int -> Int -> Int
pow =
  Fux.Core.Int.pow

-- FANCIER MATH

{-| Perform [modular arithmetic](https://en.wikipedia.org/wiki/Modular_arithmetic).
A common trick is to use (n mod 2) to detect even and odd numbers:

    modBy 2 0 == 0
    modBy 2 1 == 1
    modBy 2 2 == 0
    modBy 2 3 == 1

Our `modBy` function works in the typical mathematical way when you run into
negative numbers:

    List.map (modBy 4) [ -5, -4, -3, -2, -1,  0,  1,  2,  3,  4,  5 ]
    --                 [  3,  0,  1,  2,  3,  0,  1,  2,  3,  0,  1 ]

Use [`remainderBy`](#remainderBy) for a different treatment of negative numbers,
or read Daan Leijen’s [Division and Modulus for Computer Scientists][dm] for more
information.

[dm]: https://www.microsoft.com/en-us/research/wp-content/uploads/2016/02/divmodnote-letter.pdf
-}
modBy : Int -> Int -> Int
modBy =
  Fux.Core.Int.modBy


{-| Get the remainder after division. Here are bunch of examples of dividing by four:

    List.map (remainderBy 4) [ -5, -4, -3, -2, -1,  0,  1,  2,  3,  4,  5 ]
    --                       [ -1,  0, -3, -2, -1,  0,  1,  2,  3,  0,  1 ]

Use [`modBy`](#modBy) for a different treatment of negative numbers,
or read Daan Leijen’s [Division and Modulus for Computer Scientists][dm] for more
information.

[dm]: https://www.microsoft.com/en-us/research/wp-content/uploads/2016/02/divmodnote-letter.pdf
-}
remainderBy : Int -> Int -> Int
remainderBy =
  Fux.Core.Int.remainderBy


{-| Negate a number.

    negate 42 == -42
    negate -42 == 42
    negate 0 == 0
-}
negate : Int -> Int
negate =
  Fux.Core.Int.negate


