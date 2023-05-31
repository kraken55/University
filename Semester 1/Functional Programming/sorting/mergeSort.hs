module MergeSort where

    merge :: Ord a => [a] -> [a] -> [a]
    [] `merge` ys = ys
    xs `merge` [] = xs
    firstList@(x:xs) `merge` secondList@(y:ys)
        | x <= y = x : (xs `merge` secondList)
        | otherwise = y : (firstList `merge` ys)

    msort :: Ord a => [a] -> [a]
    msort xs
        | len <= 1 = xs
        | otherwise = msort ys `merge` msort zs
        where
            ys = take half xs
            zs = drop half xs
            half = len `div` 2
            len = length xs