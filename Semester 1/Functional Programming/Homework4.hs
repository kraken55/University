module Homework4 where

headTail :: [a] -> (a, [a])
headTail a = (head a, tail a)

doubleHead :: [a] -> [b] -> (a, b)
doubleHead a b = (head a, head b)

hasZero :: [Int] -> Bool
hasZero [] = False
hasZero (0:a) = True
hasZero a = hasZero (tail a)

hasEmpty :: [[a]] -> Bool
hasEmpty [] = False
hasEmpty ([]:a) = True
hasEmpty a = hasEmpty (tail a)

doubleAll :: [Int] -> [Int]
doubleAll [] = []
doubleAll a = [2 * head a] ++ doubleAll (tail a)

last' :: [a] -> a
last' [a] = a
last' a = last' (tail a)

init' :: [a] -> [a]
init' [a] = []
init' a = [head a] ++ init' (tail a)
