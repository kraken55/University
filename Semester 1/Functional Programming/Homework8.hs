module Homework8 where

    data Base = A | T | G | C
        deriving (Show, Eq)
    
    isComplement :: [Base] -> [Base] -> Bool
    isComplement xs ys = replaceBases xs == ys
        where
            replaceBases [] = []
            replaceBases (x:xs)
                | x == A = T : replaceBases xs
                | x == T = A : replaceBases xs
                | x == C = G : replaceBases xs
                | x == G = C : replaceBases xs
    
    data Transaction = Transfer Int Int | Purchase Int | Receive Int Int String
        deriving (Show)

    netGain :: [Transaction] -> Int
    netGain [] = 0
    netGain ((Transfer amount to):xs) = (-amount) + netGain xs
    netGain ((Purchase price):xs) = (-price) + netGain xs
    netGain ((Receive amount from msg):xs) = amount + netGain xs

    wasNegative :: [Transaction] -> Bool
    wasNegative xs = wasNegative' 1 xs where
        wasNegative' n xs
            | n > length xs = False
            | netGain (take n xs) >= 0 = wasNegative' (n + 1) xs
            | otherwise = True
    
    foo1 :: ([[a]], ([a], String)) -> Int
    foo1 ([_], (a:b, "Hello")) = 0
    foo1 ([_], (a:b, 'H':'e':'l':'l':'o':xs)) = 1
    foo1 ([_,_,_], (a:b, 'H':'e':'l':'l':'o':_:_:[])) = 2

    foo1Solution2 = ([[1, 2], [3, 4], [5, 6]], ([100], "Hellooo"))

    data Gyumolcs = Alma Int Char | Barack | Cseresznye String

    foo2 :: (Gyumolcs, String) -> Int
    foo2 (Alma 12 'a', "Piros") = 0
    foo2 (Barack, 's':'a':xs) = 1
    foo2 (Cseresznye ('p':xs), 'p':[]) = 2

    foo2Solution2 = (Cseresznye "puli", "p")