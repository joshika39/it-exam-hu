<?php
$connect = mysqli_connect("localhost", "root", "", "urlapok") or die("Ihh");
$query = mysqli_query($connect, "SELECT * FROM urlapok");

while ($row = mysqli_fetch_assoc($query)){
    $id = $row['id'];
    $nev = $row['nev'];
    $cim = $row['cim'];

    echo "<a href='index2.php?id=$id'>$id, $nev, $cim</a><br>";

}
