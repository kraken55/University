module Homework5 where

password :: [Char] -> [Char]
password [] = []
password (char1:str) = '*' : password str

lookup' :: Eq a => a -> [(a, b)] -> b
lookup' key (elem1:lst)
    | key == fst elem1 = snd elem1
    | otherwise = lookup' key lst

toBin :: Integer -> [Int]
toBin 0 = []
toBin num = fromIntegral (num `mod` 2) : (if num `div` 2 > 0 then toBin (num `div` 2) else [])

remdup :: Eq a => [a] -> [a]
remdup [] = []
remdup [x] = [x]
remdup (x1:x2:lst)
    | x1 /= x2 = x1 :  remdup (x2:lst)
    | otherwise = remdup (x2:lst)

mergeToSet :: Ord a => [a] -> [a] -> [a]
mergeToSet [] set2 = remdup set2
mergeToSet set1 [] = remdup set1
mergeToSet a b = remdup (merge a b)

merge :: Ord a => [a] -> [a] -> [a]
merge [] xs = xs
merge xs [] = xs
merge (x:xs) (y:ys)
    | x < y     = x:merge xs (y:ys)
    | otherwise = y:merge (x:xs) ys

