<#
 # 1. Feladat
 # Adjuk meg azokat az munkahelyeket, ahol egyetlen erőszakos cselekedetet se jelentettek, ha nincs ilyen, írjuk ki, hogy "NINCS"
 #>
$fileReader = [System.IO.File]::OpenText("input.txt")
$noIncidents = [System.Collections.ArrayList]::new()
while ($null -ne ($line = $fileReader.ReadLine())) {
    $splitLine = $line.Split(",")
    if ([Int]$splitLine[2] -eq 0) {
        [Void]$noIncidents.Add($splitLine[0])
    }
}
$fileReader.Close()
Write-Host "A következő cégeknél nem történt erőszakos cselekedet:"
if ($noIncidents.Count -eq 0) {
    Write-Host "NINCS"
} else {
    foreach ($elem in $noIncidents) {
        Write-Host $elem
    }
}
Write-Host

<#
 # 2. Feladat
 # Számoljuk össze, hány biztonsági őr van összesen a megadott adatfájl szerint!
 #>
$fileReader = [System.IO.File]::OpenText("input.txt")
$sumGuards = 0
while ($null -ne ($line = $fileReader.ReadLine())) {
    $splitLine = $line.Split(",")
    $sumGuards += [Int]$splitLine[3]
}
$fileReader.Close()
Write-Host "Összesen $sumGuards biztonsági őr van az adatfájl szerint."
Write-Host

 <#
 # 3. Feladat
 # Hol található a legtöbb erőszakot jelentő munkahely, adjuk meg a nevét/nevüket és címét/címüket!
 #>
 $fileReader = [System.IO.File]::OpenText("input.txt")
 $maxIncidents= 0
 while ($null -ne ($line = $fileReader.ReadLine())) {
    $splitLine = $line.Split(",")
    if ([Int]$splitLine[2] -gt $maxIncidents) {
        $maxIncidents = [Int]$splitLine[2]
    }
 }
 $fileReader.Close()

 $fileReader = [System.IO.File]::OpenText("input.txt")
 while ($null -ne ($line = $fileReader.ReadLine())) {
    $splitLine = $line.Split(",")
    if ([Int]$splitLine[2] -eq $maxIncidents) {
        Write-Host $splitLine[0] "|" $splitLine[1]
    }
 }
 $fileReader.Close()