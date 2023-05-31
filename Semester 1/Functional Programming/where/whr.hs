module WHR where
    
    unzip' :: [(a, b)] -> ([a], [b])
    unzip' [] = ([], [])
    unzip' ((x, y):xs) = (x : a, y : b) where
        (a, b) = unzip' xs
    
    splitAt' :: Int -> [a] -> ([a], [a])
    splitAt' 0 ys = ([], ys)
    splitAt' _ [] = ([], [])
    splitAt' n (y:ys)
        | n < 0 = ([], y:ys)
        | otherwise = (y:a, b) where
            (a, b) = splitAt' (n - 1) ys
    
    split :: [a] -> ([a], [a])
    split xs = splitAt' (length xs `div` 2) xs