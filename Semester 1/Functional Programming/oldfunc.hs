performZombieActions :: GameModel -> Maybe GameModel
    performZombieActions (GameModel suns plants []) = Just (GameModel suns plants []) 
    performZombieActions (GameModel suns plants (((x, y), zombie) : zombies)) = performZombieActions' (GameModel suns plants (((x, y), zombie) : zombies)) [] where
        performZombieActions' :: GameModel -> [(Coordinate, Zombie)] -> Maybe GameModel
        performZombieActions' (GameModel suns plants []) zombiesAcc = Just (GameModel suns plants (reverse zombiesAcc))
        performZombieActions' (GameModel suns plants (((x, y), zombie) : zombies)) zombiesAcc
            | y == 0 = Nothing
            | isJust (lookup (x, y) plants) && isQuickVaulting zombie = performZombieActions' (GameModel suns plants zombies) (((x, y - 1), decreaseSpeed zombie) : zombiesAcc)
            | isJust (lookup (x, y) plants) = performZombieActions' (GameModel suns (damagePlant (x, y) plants) zombies) (((x, y), zombie) : zombiesAcc)
            | otherwise = performZombieActions' (GameModel suns plants zombies) (((x, if isQuickVaulting zombie then y - 2 else y - 1), zombie) : zombiesAcc)
            where
                isQuickVaulting :: Zombie -> Bool
                isQuickVaulting (Vaulting _ 2) = True
                isQuickVaulting _ = False

                decreaseSpeed :: Zombie -> Zombie
                decreaseSpeed (Vaulting hp 2) = Vaulting hp 1
                decreaseSpeed zombie = zombie

                damagePlant :: Coordinate -> [(Coordinate, Plant)] -> [(Coordinate, Plant)]
                damagePlant _ [] = []
                damagePlant (a, b) (((x, y), plant) : xs)
                    | (a, b) == (x, y) = ((x, y), reduceHp plant) : xs
                    | otherwise = damagePlant (a, b) xs
                    where
                        reduceHp :: Plant -> Plant
                        reduceHp (Sunflower hp) = Sunflower (hp - 1)
                        reduceHp (Peashooter hp) = Peashooter (hp - 1)
                        reduceHp (Walnut hp) = Walnut (hp - 1)
                        reduceHp (CherryBomb hp) = CherryBomb (hp - 1)
