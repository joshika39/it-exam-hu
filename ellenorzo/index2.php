<?php
$connect = mysqli_connect("localhost", "root", "", "urlapok") or die("Ihh");
$id = $_GET['id'];

$query = mysqli_query($connect, "SELECT * FROM urlapok WHERE id='$id'");

while ($row = mysqli_fetch_assoc($query)){
    $id = $row['id'];
    $nev = $row['nev'];
    $meret = $row['meret'];
    $alap = $row['alap'];
    $eros = $row['eros'];
    $hagymas = $row['hagymas'];
}

?>

<html>
<body>
<form action="index3.php?id=<?php echo $id?>" method="post">
    <!-- Fontos, hogy a csoport neve minden egy csoportba tartozo radionak ugyan az legyen   -->
    <!-- Ezzel a csoport nevvel kell majd elerni az erteket   -->
    <input type="text" name="nev">

    <select name="meret">
        <option value="32">32</option>
        <option value="45">45</option>
        <option value="60">60</option>
    </select><br><br>

    <input type="radio" name="alap" value="paradicsom" <?php if($alap == "paradicsom") echo "selected" ?>> Paradicsomos <br>
    <input type="radio" name="alap" value="tejfol" <?php if($alap == "paradicsom") echo "selected" ?>> Tejfolos <br><br>

    <textarea cols="30" rows="5" name="leiras"></textarea> <br>
    <input type="checkbox" name="eros" value="eros"> Eros<br>
    <input type="checkbox" name="hagymas" value="hagymas"> Hagymas <br><br><br>
    <input type="submit" value="Modosit">
</form>
</body>
</html>
