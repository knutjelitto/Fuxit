module Bool exposing
  ( Bool(..)
  , not
  , and
  , or
  , xor
  )

{-| Basic Bool type.

# Booleans
@docs Bool, not, and, or, xor

-}

import Fux.Core.Bool

-- BOOLEANS


{-| A “Boolean” value. It can either be `True` or `False`.

**Note:** Programmers coming from JavaScript, Java, etc. tend to reach for
boolean values way too often in Elm. Using a [union type][ut] is often clearer
and more reliable. You can learn more about this from Jeremy [here][jf] or
from Richard [here][rt].

[ut]: https://guide.elm-lang.org/types/union_types.html
[jf]: https://youtu.be/6TDKHGtAxeg?t=1m25s
[rt]: https://youtu.be/IcgmSRJHu_8?t=1m14s
-}
type Bool
    = False
    | True


{-| Negate a boolean value.

    not True == False
    not False == True
-}
not : Bool -> Bool
not =
    Fux.Core.Bool.not


{-| The logical AND operator. `True` if both inputs are `True`.

    True  && True  == True
    True  && False == False
    False && True  == False
    False && False == False

**Note:** When used in the infix position, like `(left && right)`, the operator
short-circuits. This means if `left` is `False` we do not bother evaluating `right`
and just return `False` overall.
-}
and : Bool -> Bool -> Bool
and =
    Fux.Core.Bool.and


{-| The logical OR operator. `True` if one or both inputs are `True`.

    True  || True  == True
    True  || False == True
    False || True  == True
    False || False == False

**Note:** When used in the infix position, like `(left || right)`, the operator
short-circuits. This means if `left` is `True` we do not bother evaluating `right`
and just return `True` overall.
-}
or : Bool -> Bool -> Bool
or =
    Fux.Core.Bool.or


{-| The exclusive-or operator. `True` if exactly one input is `True`.

    xor True  True  == False
    xor True  False == True
    xor False True  == True
    xor False False == False
-}
xor : Bool -> Bool -> Bool
xor =
    Fux.Core.Bool.xor
