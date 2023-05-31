module Gyak6 where
    import Data.Char
    
    cipher :: String -> String
    cipher (ch1:ch2:ch3:str)
        | isAlpha ch1 && isAlpha ch2 && isDigit ch3 = [ch1, ch2]
        | otherwise = cipher str
    cipher _ = []

    zip' :: [a] -> [b] -> [(a, b)]
    zip' _ [] = []
    zip' [] _ = []
    zip' (x:xs) (y:ys) = (x, y) : zip' xs ys

    numberedABC :: [(Int, Char)]
    numberedABC = [(x - ord 'a' + 1, chr x) | x <- [ord 'a'..ord 'z']]

    stars :: String
    stars = concat [ concat (replicate n "*") ++ " " | n <- [1..]]

    toUpperFirst :: String -> String
    toUpperFirst str = unwords (upperWord (words str)) where
        upperWord [] = []
        upperWord (x:xs) = (toUpper (head x) : tail x) : upperWord xs
    
    unzip' :: [(a, b)] -> ([a], [b])
    unzip' [] = ([], [])
    unzip' ((x, y):xs) = (x:a, y:b) where
        (a, b) = unzip' xs
    
    unzip3' :: [(a, b, c)] -> ([a], [b], [c])
    unzip3' [] = ([], [], [])
    unzip3' ((x, y, z):xs) = (x:a, y:b, z:c) where
        (a, b, c) = unzip3' xs