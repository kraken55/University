module PVZ where

    import Data.List
    import Data.Maybe (isJust)
    
    type Coordinate = (Int, Int)
    type Sun = Int

    data Plant = Peashooter Int | Sunflower Int | Walnut Int | CherryBomb Int
        deriving (Eq, Show)
    data Zombie = Basic Int Int | Conehead Int Int | Buckethead Int Int | Vaulting Int Int
        deriving (Eq, Show)
    data GameModel = GameModel Sun [(Coordinate, Plant)] [(Coordinate, Zombie)]
        deriving (Eq, Show)

    defaultPeashooter :: Plant
    defaultPeashooter = Peashooter 3
    
    defaultSunflower :: Plant
    defaultSunflower = Sunflower 2

    defaultWalnut :: Plant
    defaultWalnut = Walnut 15

    defaultCherryBomb :: Plant
    defaultCherryBomb = CherryBomb 2
    
    basic :: Zombie
    basic = Basic 5 1
    
    coneHead :: Zombie
    coneHead = Conehead 10 1

    bucketHead :: Zombie
    bucketHead = Buckethead 20 1

    vaulting :: Zombie
    vaulting = Vaulting 7 2

    tryPurchase :: GameModel -> Coordinate -> Plant -> Maybe GameModel
    tryPurchase (GameModel sunAmount plants zombies) (x, y) plant
        | x < 0 || x > 4 = Nothing
        | y < 0 || y > 11 = Nothing
        | isJust (lookup (x, y) plants) = Nothing
        | getPrice plant > sunAmount = Nothing
        | otherwise = Just (GameModel (sunAmount - getPrice plant) (((x, y), plant) : plants) zombies)
        where
            getPrice :: Plant -> Sun
            getPrice (Peashooter _) = 100
            getPrice (Sunflower _) = 50
            getPrice (Walnut _) = 50
            getPrice (CherryBomb _) = 150

    placeZombieInLane :: GameModel -> Zombie -> Int -> Maybe GameModel
    placeZombieInLane (GameModel suns plants zombies) zombie lane
        | lane < 0 || lane > 4 = Nothing
        | isJust (lookup (lane, 11) zombies) = Nothing
        | otherwise = Just (GameModel suns plants (((lane, 11), zombie) : zombies))

    performZombieActions :: GameModel -> Maybe GameModel
    performZombieActions (GameModel suns plants zombies) = performZombieActions' (GameModel suns plants zombies) [] where
        performZombieActions' (GameModel suns plants []) zombiesAcc = Just (GameModel suns plants (reverse zombiesAcc))
        performZombieActions' (GameModel suns plants (currZombie@((x, y), zombie) : zombies)) zombiesAcc
            | isQuickVaulting zombie && isJust (lookup (x, y - 1) plants) = performZombieActions' (GameModel suns plants zombies) (((x, y - 2), decreaseSpeed zombie) : zombiesAcc)
            | isQuickVaulting zombie && isJust (lookup (x, y) plants) = performZombieActions' (GameModel suns plants zombies) (((x, y - 1), decreaseSpeed zombie) : zombiesAcc)
            | isJust (lookup (x, y) plants) = performZombieActions' (GameModel suns (damagePlants (x, y) plants) zombies) (currZombie : zombiesAcc)
            | y - getSpeed zombie < 0 = Nothing
            | otherwise = performZombieActions' (GameModel suns plants zombies) (((x, y - getSpeed zombie), zombie) : zombiesAcc)
            where
                isQuickVaulting :: Zombie -> Bool
                isQuickVaulting (Vaulting _ 2) = True
                isQuickVaulting _ = False

                decreaseSpeed :: Zombie -> Zombie
                decreaseSpeed (Vaulting hp 2) = Vaulting hp 1
                decreaseSpeed zombie = zombie

                getSpeed :: Zombie -> Int
                getSpeed (Basic _ speed) = speed
                getSpeed (Conehead _ speed) = speed
                getSpeed (Buckethead _ speed) = speed
                getSpeed (Vaulting _ speed) = speed

                damagePlants :: Coordinate -> [(Coordinate, Plant)] -> [(Coordinate, Plant)]
                damagePlants (_, _) [] = []
                damagePlants (p, q) (((x, y), plant) : plants)
                    | (p, q) == (x, y) = ((x, y), reduceHp plant) : damagePlants (p, q) plants
                    | otherwise = ((x, y), plant) : damagePlants (p, q) plants
                    where
                        reduceHp :: Plant -> Plant
                        reduceHp (Peashooter hp) = Peashooter (hp - 1)
                        reduceHp (Sunflower hp) = Sunflower (hp - 1)
                        reduceHp (Walnut hp) = Walnut (hp - 1)
                        reduceHp (CherryBomb hp) = CherryBomb (hp - 1)
    
    cleanBoard :: GameModel -> GameModel
    cleanBoard (GameModel suns plants zombies) = GameModel suns (clearPlants plants) (clearZombies zombies) where
        clearPlants :: [(Coordinate, Plant)] -> [(Coordinate, Plant)]
        clearPlants [] = []
        clearPlants (((x, y), plant) : xs)
            | isDeadPlant plant = clearPlants xs
            | otherwise = ((x, y), plant) : clearPlants xs
            where
                isDeadPlant :: Plant -> Bool
                isDeadPlant (Sunflower hp)
                    | hp <= 0 = True
                    | otherwise = False
                isDeadPlant (Peashooter hp)
                    | hp <= 0 = True
                    | otherwise = False
                isDeadPlant (Walnut hp)
                    | hp <= 0 = True
                    | otherwise = False
                isDeadPlant (CherryBomb hp)
                    | hp <= 0 = True
                    | otherwise = False
        clearZombies :: [(Coordinate, Zombie)] -> [(Coordinate, Zombie)]
        clearZombies [] = []
        clearZombies (((x, y), zombie) : xs)
            | isDeadZombie zombie = clearZombies xs
            | otherwise = ((x, y), zombie) : clearZombies xs
            where
                isDeadZombie :: Zombie -> Bool
                isDeadZombie (Basic hp _)
                    | hp <= 0 = True
                    | otherwise = False
                isDeadZombie (Conehead hp _)
                    | hp <= 0 = True
                    | otherwise = False
                isDeadZombie (Buckethead hp _)
                    | hp <= 0 = True
                    | otherwise = False
                isDeadZombie (Vaulting hp _)
                    | hp <= 0 = True
                    | otherwise = False
            
        performPlantActions :: GameModel -> GameModel
        performPlantActions (GameModel suns plants zombies) = performPlantActions' (GameModel suns plants zombies) plants where
            performPlantActions' (GameModel suns origPlants zombies) [] = (GameModel suns origPlants zombies)
            performPlantActions' (GameModel suns origPlants zombies) (((x, y), plant) : plants)
                | getType plant == 0 = performPlantActions' (GameModel (suns + 25) origPlants zombies) plants
                | getType plant == 1 = performPlantActions' (GameModel suns origPlants (damageZombie (getFirstZombieInLane x zombies) zombies)) plants
                where
                    getType :: Plant -> Int
                    getType (Sunflower _) = 0
                    getType (Peashooter _) = 1
                    getType (CherryBomb _) = 2

                    getFirstZombieInLane :: Int -> [(Coordinate, Zombie)] -> Coordinate
                    getFirstZombieInLane lane zombies = (lane, minimum (map snd (fst (unzip zombies))))

                    damageZombie :: Coordinate -> [(Coordinate, Zombie)] -> [(Coordinate, Zombie)]
                    damageZombie coord (((x, y), zombie) : zombies)
                        | coord == (x, y) = ((x, y), reduceHp zombie) : damageZombie coord zombies
                        | otherwise = damageZombie coord zombies
                        where
                            reduceHp :: Zombie -> Zombie
                            reduceHp (Basic hp speed) = Basic (hp - 1) speed
                            reduceHp (Conehead hp speed) = Conehead (hp - 1) speed
                            reduceHp (Buckethead hp speed) = Buckethead (hp - 1) speed
                            reduceHp (Vaulting hp speed) = Vaulting (hp - 1) speed