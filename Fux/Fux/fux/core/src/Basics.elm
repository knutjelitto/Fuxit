module Basics exposing
  ( (+), (-), (*), (/), (^)
  , (||), (^^), (&&)
  , (==), (!=)
  , (<), (>), (<=), (>=)
  , (++)
  , negate, abs, clamp
  , identity, always, (<|), (|>), (<<), (>>), Never, never
  )

{-| Tons of useful functions that get imported by default.

# Math
@docs (+), (-), (*), (/), (^)

# Equality
@docs (==), (!=)

# Comparison

These functions only work on `comparable` types. This includes numbers,
characters, strings, lists of comparable things, and tuples of comparable
things.

@docs (<), (>), (<=), (>=)

# Append Strings and Lists
@docs (++)

# Fancier Math
@docs negate, abs, clamp
# Function Helpers
@docs identity, always, (<|), (|>), (<<), (>>), Never, never

-}


import Fux.Core.Basics
import Fux.Core.Utils

import Compare exposing(..)
import Int exposing(..)
import Bool exposing(..)
import String exposing(..)


-- INFIX OPERATORS

infix right 0 (<|) = apL
infix left  0 (|>) = apR
infix right 2 (||) = Bool.or
infix right 2 (^^) = Bool.xor
infix right 3 (&&) = Bool.and
infix non   4 (==) = Compare.eq
infix non   4 (!=) = Compare.neq
infix non   4 (<)  = Compare.lt
infix non   4 (>)  = Compare.gt
infix non   4 (<=) = Compare.le
infix non   4 (>=) = Compare.ge
infix right 5 (++) = append
infix left  6 (+)  = Int.add
infix left  6 (-)  = Int.sub
infix left  7 (*)  = Int.mul
infix left  7 (/)  = Int.div
infix right 8 (^)  = Int.pow
infix left  9 (<<) = composeL
infix right 9 (>>) = composeR


-- TYPE CLASSES

class Eq a where
    (==) : a -> a -> Bool
    (!=) : a -> a -> Bool

class Ord a : Eq a where
    (<=) : a -> a -> Bool
    (<) : a -> a -> Bool
    (>=) : a -> a -> Bool
    (>) : a -> a -> Bool


-- APPEND

{-| Put two appendable things together. This includes strings and lists.

    "hello" ++ "world" == "helloworld"
    [1,1,2] ++ [3,5,8] == [1,1,2,3,5,8]
-}
append : appendable -> appendable -> appendable
append =
    Fux.Core.Utils.append



-- FANCIER MATH


{-| Negate a number.

    negate 42 == -42
    negate -42 == 42
    negate 0 == 0
-}
negate : number -> number
negate =
    Fux.Core.Basics.negate


{-| Get the [absolute value][abs] of a number.

    abs 16   == 16
    abs -4   == 4
    abs -8.5 == 8.5
    abs 3.14 == 3.14

[abs]: https://en.wikipedia.org/wiki/Absolute_value
-}
abs : number -> number
abs n =
    if lt n 0 then -n else n


{-| Clamps a number within a given range. With the expression
`clamp 100 200 x` the results are as follows:

    100     if x < 100
     x      if 100 <= x < 200
    200     if 200 <= x
-}
clamp : number -> number -> number -> number
clamp low high number =
    if lt number low then
        low
    else if gt number high then
        high
    else
        number


-- FUNCTION HELPERS


{-| Function composition, passing results along in the suggested direction. For
example, the following code checks if the square root of a number is odd:

    not << isEven << sqrt

You can think of this operator as equivalent to the following:

    (g << f)  ==  (\x -> g (f x))

So our example expands out to something like this:

    \n -> not (isEven (sqrt n))
-}
composeL : (b -> c) -> (a -> b) -> (a -> c)
composeL g f x =
    g (f x)


{-| Function composition, passing results along in the suggested direction. For
example, the following code checks if the square root of a number is odd:

    sqrt >> isEven >> not

-}
composeR : (a -> b) -> (b -> c) -> (a -> c)
composeR f g x =
    g (f x)


{-| Saying `x |> f` is exactly the same as `f x`.

It is called the “pipe” operator because it lets you write “pipelined” code.
For example, say we have a `sanitize` function for turning user input into
integers:

    -- BEFORE
    sanitize : String -> Maybe Int
    sanitize input =
      String.toInt (String.trim input)

We can rewrite it like this:

    -- AFTER
    sanitize : String -> Maybe Int
    sanitize input =
      input
        |> String.trim
        |> String.toInt

Totally equivalent! I recommend trying to rewrite code that uses `x |> f`
into code like `f x` until there are no pipes left. That can help you build
your intuition.

**Note:** This can be overused! I think folks find it quite neat, but when you
have three or four steps, the code often gets clearer if you break out a
top-level helper function. Now the transformation has a name. The arguments are
named. It has a type annotation. It is much more self-documenting that way!
Testing the logic gets easier too. Nice side benefit!
-}
apR : a -> (a -> b) -> b
apR x f =
    f x


{-| Saying `f <| x` is exactly the same as `f x`.

It can help you avoid parentheses, which can be nice sometimes. Maybe you want
to apply a function to a `case` expression? That sort of thing.
-}
apL : (a -> b) -> a -> b
apL f x =
    f x


{-| Given a value, returns exactly the same value. This is called
[the identity function](https://en.wikipedia.org/wiki/Identity_function).
-}
identity : a -> a
identity x =
    x


{-| Create a function that *always* returns the same value. Useful with
functions like `map`:

    List.map (always 0) [1,2,3,4,5] == [0,0,0,0,0]

    -- List.map (\_ -> 0) [1,2,3,4,5] == [0,0,0,0,0]
    -- always = (\x _ -> x)
-}
always : a -> b -> a
always a _ =
    a


{-| A value that can never happen! For context:

  - The boolean type `Bool` has two values: `True` and `False`
  - The unit type `()` has one value: `()`
  - The never type `Never` has no values!

You may see it in the wild in `Html Never` which means this HTML will never
produce any messages. You would need to write an event handler like
`onClick ??? : Attribute Never` but how can we fill in the question marks?!
So there cannot be any event handlers on that HTML.

You may also see this used with tasks that never fail, like `Task Never ()`.

The `Never` type is useful for restricting *arguments* to a function. Maybe my
API can only accept HTML without event handlers, so I require `Html Never` and
users can give `Html msg` and everything will go fine. Generally speaking, you
do not want `Never` in your return types though.
-}
type Never = JustOneMore Never


{-| A function that can never be called. Seems extremely pointless, but it
*can* come in handy. Imagine you have some HTML that should never produce any
messages. And say you want to use it in some other HTML that *does* produce
messages. You could say:

    import Html exposing (..)

    embedHtml : Html Never -> Html msg
    embedHtml staticStuff =
      div []
        [ text "hello"
        , Html.map never staticStuff
        ]

So the `never` function is basically telling the type system, make sure no one
ever calls me!
-}
never : Never -> a
never (JustOneMore nvr) =
    never nvr
