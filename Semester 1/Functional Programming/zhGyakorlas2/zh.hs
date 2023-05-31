module ZH where
    import Prelude hiding (Maybe, Nothing, Just)
    
    data Colour = RGB Int Int Int

    red :: Colour
    red = RGB 255 0 0

    green :: Colour
    green = RGB 0 255 0

    blue :: Colour
    blue = RGB 0 0 255

    instance Show Colour where
        show (RGB r g b) = "R = " ++ show r ++ " G = " ++ show g ++ " B = " ++ show b
    
    instance Eq Colour where
        (==) (RGB r1 g1 b1) (RGB r2 g2 b2) = r1 == r2 && g1 == g2 && b1 == b2
    
    isGray :: Colour -> Bool
    isGray (RGB 0 0 0) = False
    isGray (RGB 255 255 255) = False
    isGray (RGB r g b)
        | r == g && g == b = True
        | otherwise = False
    
    data Numbers = Positive Int | Negative Int | Zero
        deriving (Show, Eq)
    
    mkNumbers :: Integer -> Numbers
    mkNumbers n
        | n < 0 = Negative (fromInteger n)
        | n > 0 = Positive (fromInteger n)
        | otherwise = Zero
    
    fromNumbers :: Numbers -> Integer
    fromNumbers Zero = 0
    fromNumbers (Positive n) = fromIntegral n
    fromNumbers (Negative n) = fromIntegral (-n)

    addPositive :: [Numbers] -> Numbers
    addPositive xs = mkNumbers (sum (filter (> 0) (map fromNumbers xs)))

    data Point = Point Double Double
        deriving (Show, Eq)

    getX :: Point -> Double
    getX (Point x y) = x

    getY :: Point -> Double
    getY (Point x y) = y

    displace :: Point -> Point -> Point
    displace (Point x1 y1) (Point x2 y2) = Point (x1 + x2) (y1 + y2)

    data Shape = Circle Point Double | Rect Point Point
        deriving (Eq, Show)

    area :: Shape -> Double
    area (Circle (Point x y) r) = r * r * pi
    area (Rect (Point x1 y1) (Point x2 y2)) = (x2 - x1) * (y1 - y2)

    displaceShape :: Shape -> Point -> Shape
    displaceShape (Circle (Point x y) r) (Point p q) = Circle (displace (Point x y) (Point p q)) r
    displaceShape (Rect (Point x1 y1) (Point x2 y2)) (Point p q) = Rect (displace (Point x1 y1) (Point p q)) (displace (Point x2 y2) (Point p q))

    data Maybe a = Nothing | Just a
        deriving (Show, Eq)

    safeHead :: [a] -> Maybe a
    safeHead [] = Nothing
    safeHead (x:xs) = Just x

    safeDiv :: Double -> Double -> Maybe Double
    safeDiv _ 0 = Nothing
    safeDiv x y = Just (x / y)

    safeIndex :: [a] -> Int -> Maybe a
    safeIndex [] _ = Nothing
    safeIndex (x:xs) i
        | i < 0 = Nothing
        | i == 0 = Just x
        | otherwise = safeIndex xs (i - 1)
    
    countNothings :: Eq a => [Maybe a] -> Int
    countNothings [] = 0
    countNothings (x:xs)
        | x == Nothing = 1 + countNothings xs
        | otherwise = countNothings xs
    
    addBefore :: Maybe a -> [a] -> [a]
    addBefore Nothing xs = xs
    addBefore (Just y) xs = y : xs