module Homework11 where
    import Data.Char
    
    type Line = String
    type File = [Line]

    testFile0 :: File
    testFile0 = ["asd  qwe", "-- Foo", "", "\thello world "]

    countWordsInLine :: Line -> Int
    countWordsInLine line = length (words line)

    countWords :: File -> Int
    countWords file = sum (map countWordsInLine file)

    countChars :: File -> Int
    countChars file = sum (map length file)

    capitalizeWordsInLine :: Line -> Line
    capitalizeWordsInLine line = unwords (map capitalizeWord (words line)) where
        capitalizeWord "" = ""
        capitalizeWord (x:xs) = toUpper x : xs
    
    isComment :: Line -> Bool
    isComment "" = False
    isComment [chr] = False
    isComment (chr1:chr2:xs) = chr1 == '-' && chr2 == '-'

    dropComments :: File -> File
    dropComments file = [line | line <- file, not (isComment line)]

    numberLines :: File -> File
    numberLines file = zipWith (++) getLineNumbers file where
        getLineNumbers = [show n ++ ": " | n <- [1..length file]]
    
    dropTrailingWhitespaces :: Line -> Line
    dropTrailingWhitespaces line = reverse (dropWhile isSpace (reverse line))

    replaceTab :: Int -> Char -> [Char]
    replaceTab n '\t' = concat (replicate n " ")
    replaceTab _ chr = [chr]

    replaceTabs :: Int -> File -> File
    replaceTabs n file = [concatMap (replaceTab n) line | line <- file]
