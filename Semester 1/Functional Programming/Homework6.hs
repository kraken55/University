module Homework6 where

import Data.Char
import Data.List

listDiff :: Eq a => [a] -> [a] -> [a]
listDiff [] _ = []
listDiff (x:xs) ys
    | not (isElem x ys) = x : listDiff xs ys
    | otherwise = listDiff xs ys
    where
        isElem _ [] = False
        isElem x (y:ys)
            | x == y = True
            | otherwise = isElem x ys

validGame :: String -> Bool
validGame [] = True
validGame x = validGame' (words x) where
    validGame' [a] = True
    validGame' (x:y:xs)
        | last x == head y = validGame' (y:xs)
        | otherwise = False

countSingletons :: [[a]] -> Int
countSingletons [] = 0
countSingletons (x:xs) = evalSingleton x + countSingletons xs where
    evalSingleton [a] = 1
    evalSingleton _ = 0

sameParity :: [Int] -> Bool
sameParity [] = True
sameParity (x:xs) = checkParity (even x) xs where
    checkParity _ [] = True
    checkParity isEven (x:xs)
        | even x == isEven = checkParity isEven xs
        | otherwise = False

longestChain :: String -> Int
longestChain [] = 0
longestChain xs = getMax xs 0 (countSame xs) where
    countSame [] = 0
    countSame [a] = 1
    countSame (x:y:xs)
        | x == y = 1 + countSame (y:xs)
        | otherwise = 1
    getMax _ currMax 0 = currMax
    getMax xs currMax newVal
        | newVal > currMax = getMax new_xs newVal (countSame new_xs)
        | otherwise = getMax new_xs currMax (countSame new_xs)
        where new_xs = drop newVal xs

normalizeText :: String -> String
normalizeText str = map toUpper (filter isAlpha (filter isAscii str))

isTransitive :: Eq a => [(a, a)] -> Bool
isTransitive [] = True
isTransitive xs = isTransitive' xs xs where
    isTransitive' orig_xs (x:xs)
        | checkElems (fst x) (filterBySnd (snd x) orig_xs) orig_xs = isTransitive' orig_xs xs
        | otherwise = False
        where
            filterBySnd _ [] = []
            filterBySnd n (y:ys)
                | fst y == n = snd y : filterBySnd n ys
                | otherwise = filterBySnd n ys
            checkElems _ [] ys = True
            checkElems a (y:ys) lst
                | (a, y) `elem` lst = checkElems a ys lst
                | otherwise = False