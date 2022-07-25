module Test

import List exposing (List, (::))

type AB
    = A
    | B

test5 x =
    let
        f = \a -> a
    in
        f A

test4 : (AB, AB) -> AB
test4 (x, y) =
    y

test3 : AB
test3 = 
    let
        x = A
        y = B
    in
        x

test2 = 
    let
        (x, y) = (A, B)
    in
        y

test1 = 
    let
        (_, y) = (A, B)
    in
        y


