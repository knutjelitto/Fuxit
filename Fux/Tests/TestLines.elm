module Test exposing(test)

test = - (fak 1) + fak 2 * fak 3

test =
  skip (chompWhile isNotRelevant) <|
    oneOf
      [ if nestLevel == 1 then
          close
        else
          close
            |> andThen (\_ -> nestableHelp isNotRelevant open close expectingClose (nestLevel - 1))
      , open
          |> andThen (\_ -> nestableHelp isNotRelevant open close expectingClose (nestLevel + 1))
      , chompIf isChar expectingClose
          |> andThen (\_ -> nestableHelp isNotRelevant open close expectingClose nestLevel)
      ]


initialize len fn =
    if len <= 0 then
        empty
    else
        let
            tailLen =
                remainderBy branchFactor len

            tail =
                JsArray.initialize tailLen (len - tailLen) fn

            initialFromIndex =
                len - tailLen - branchFactor
        in
            initializeHelp fn initialFromIndex len [] tail

