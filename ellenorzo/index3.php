<?php
$id = $_GET['id'];
$valasztottJarmu = $_POST['jarmu'];
$valasztottEtkezes = $_POST['etkezes'];
$leiras = $_POST['leiras'];

// Checkboxok ellnorzese: bele kell tenni, egy isset-be ami ellenorzi, hogy ki van e pipazva
if(isset($_POST['feltetel'])){
    echo "Feltetel pipa";
}

if(isset($_POST['hirlevel'])){
    echo "Hirlevel pipa";
}
