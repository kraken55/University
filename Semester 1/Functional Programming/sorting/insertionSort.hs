module InsertionSort where
    
    insert :: Ord a => a -> [a] -> [a]
    insert e [] = [e]
    insert e (x:xs)
        | e <= x    = e : x : xs
        | otherwise = x : insert e xs

    isort :: Ord a => [a] -> [a]
    isort = foldr insert []