module QuickSort where
    
    qsort :: Ord a => [a] -> [a]
    qsort [] = []
    qsort (a:xs) = qsort [x | x <- xs, x < a] ++ [a] ++ qsort [x | x <- xs, x >= a]