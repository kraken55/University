module ZH where

sum' :: Num a => [a] -> a
sum' [] = 0
sum' (x:xs) = x + sum' xs

last' :: [a] -> a
last' (x:xs)
    | null xs = x
    | otherwise = last' xs

init' :: [a] -> [a]
init' [] = []
init' [a] = []
init' (x:xs) = x : init' xs

minimum' :: Ord a => [a] -> a
minimum' [x] = x
minimum' (x1:xs) = min x1 (minimum' xs)

concat' :: [[a]] -> [a]
concat' [] = []
concat' (x:xs) = x ++ concat' xs

conc :: [a] -> [a] -> [a]
conc [] a = a
conc a [] = a
conc (x:xs) y = x : conc xs y

zip' :: [a] -> [b] -> [(a,b)]
zip' a [] = []
zip' [] a = []
zip' (x:xs) (y:ys) = (x, y) : zip' xs ys

isPrefixOf :: Eq a => [a] -> [a] -> Bool
isPrefixOf [] a = True
isPrefixOf a [] = False
isPrefixOf (x:xs) (y:ys) = (x == y) && isPrefixOf xs ys

elem' :: Eq a => a -> [a] -> Bool
elem' _ [] = False
elem' a (x:xs)
    | a == x = True
    | otherwise = elem' a xs

nub :: Eq a => [a] -> [a]
nub [] = []
nub (x:xs) = x : nub (filter (/=x) xs)

polinom :: Num a => [a] -> a -> a
polinom [] a = 0
polinom (x:xs) a = x + a * polinom xs a

runs :: Int -> [a] -> [[a]]
runs _ [] = []
runs len x
    | length x < len = [x]
    | otherwise = take len x : runs len (drop len x)

slice :: [Int] -> [a] -> [[a]]
slice [] x = []
slice _ [] = [[]]
slice (l:ls) x
    | length x < l = [take (l - length x) x] ++ [[]]
    | otherwise = take l x : slice ls (drop l x)

every :: Int -> [a] -> [a]
every _ [] = []
every a (x:xs) = x : every a (drop (a - 1) xs)

duplicateElements :: [a] -> [a]
duplicateElements [] = []
duplicateElements (x:xs) = x : x : duplicateElements xs

take' :: Int -> [a] -> [a]
take' 0 _ = []
take' _ [] = []
take' n (x:xs) = x : take' (n - 1) xs

drop' :: Int -> [a] -> [a]
drop' 0 a = a
drop' _ [] = []
drop' n (x:xs) = drop' (n - 1) xs

insert :: Ord a => a -> [a] -> [a]
insert n [] = n : []
insert n (x:xs)
    | n <= x = n : x : xs
    | otherwise = x : insert n xs

merge :: Ord a => [a] -> [a] -> [a]
merge [] a = a
merge a [] = a
merge (x:xs) y = merge xs (insert x y)

sublist :: Int -> Int -> [a] -> [a]
sublist _ _ [] = []
sublist 0 0 x = []
sublist 0 e (x:xs) = x : sublist 0 (e - 1) xs
sublist s e (x:xs) = sublist (s - 1) e xs