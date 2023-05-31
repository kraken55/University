module ZH where
    
    zipIf :: (a -> a -> Bool) -> [a] -> [a] -> [(a, a)]
    zipIf _ [] [] = []
    zipIf _ [] _ = []
    zipIf _ _ [] = []
    zipIf p (x:xs) (y:ys)
        | p x y = (x, y) : zipIf p xs ys
        | otherwise = zipIf p xs ys

    countEmptyLists :: [[a]] -> Int
    countEmptyLists xs = length (filter (==True) (map null xs))

    matrixAdd :: Num a => [[a]] -> [[a]] -> [[a]]
    matrixAdd [] [] = []
    matrixAdd (x:xs) (y:ys) = (zipWith (+) x y) : matrixAdd xs ys