<?php
$id = $_GET['id'];
$nev = $_POST['nev'];
$meret = $_POST['meret'];
$alap = $_POST['alap'];
$leiras = $_POST['leiras'];

// Checkboxok ellnorzese: bele kell tenni, egy isset-be ami ellenorzi, hogy ki van e pipazva
if(isset($_POST['eros'])){
    $eros = "igen";
}
else{
    $eros = "nem";
}

if(isset($_POST['hagymas'])){
    $hagymas = "igen";
}
else{
    $hagymas = "nem";
}

echo "modositott adatok: $nev, $meret, $alap, $leiras, Eros: $eros, Hagymas: $hagymas";

$connect = mysqli_connect("localhost", "root", "", "etterem") or die("Ihh");

mysqli_query($connect, "UPDATE pizza SET nev='$nev', meret='$meret', alap='$alap', leiras='$leiras', eros='$eros', hagymas='$hagymas' WHERE id='$id'");