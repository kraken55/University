module ZHRA where
    data Postfix = Constant Integer | Function (Integer -> Integer -> Integer)

    type PostfixExpression = [Postfix]

    tryApply :: Postfix -> Integer -> Integer -> Maybe Integer
    tryApply (Constant _) _ _ = Nothing
    tryApply (Function f) num1 num2 = Just (f num1 num2)

    evaluatePostfix :: PostfixExpression -> Maybe Integer
    evaluatePostfix xs = eval [] xs where
        eval curr (Constant x:xs) = eval (curr ++ [x]) xs
        eval curr (Function f:xs)
            | length curr < 2 = Nothing
            | otherwise = eval (init (init curr) ++ [f (last (init curr)) (last curr)]) xs
        eval curr [] = Just (head curr)