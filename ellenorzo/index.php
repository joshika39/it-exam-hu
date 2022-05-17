<?php

$connect = mysqli_connect("localhost", "root", "", "etterem") or die("Ihh");
$query = mysqli_query($connect, "SELECT * FROM pizza");

while ($row = mysqli_fetch_assoc($query)){
    $id = $row['id'];
    $nev = $row['nev'];
    $meret = $row['meret'];
    $alap = $row['alap'];
    $leiras = $row['leiras'];
    $eros = $row['eros'];
    $hagymas = $row['hagymas'];

    echo "<a href='index2.php?id=$id'>$id, $nev, $meret, $alap, $leiras";
    if($eros == "igen") echo " eros";
    if($hagymas == "igen") echo " hagymas";
    echo "</a>";
}