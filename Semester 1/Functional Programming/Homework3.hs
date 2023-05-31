module Homework3 where


onAxis :: (Int, Int) -> Bool
onAxis (0, _) = True
onAxis (_, 0) = True
onAxis (_, _) = False

shift :: (Int, Int) -> Int -> (Int, Int)
shift (h, m) s = (((h + ((m + s) `div` 60)) `mod` 24), (m + s) `mod` 60)

areAmicableNumbers :: Int -> Int -> Bool
areAmicableNumbers a b = and (sum ([x | x <- [1..a-1], a `mod` x == 0]) == b, sum ([x | x <- [1..b-1], b `mod` x == 0]) == a)