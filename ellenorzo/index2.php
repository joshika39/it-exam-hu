<?php
$connect = mysqli_connect("localhost", "root", "", "etterem") or die("Ihh");
$id = $_GET['id'];

$query = mysqli_query($connect, "SELECT * FROM pizza WHERE id='$id'");

while ($row = mysqli_fetch_assoc($query)){
    $id = $row['id'];
    $nev = $row['nev'];
    $meret = $row['meret'];
    $leiras = $row['leiras'];
    $alap = $row['alap'];
    $eros = $row['eros'];
    $hagymas = $row['hagymas'];
}

?>

<html>
<body>
<form action="index3.php?id=<?php echo $id?>" method="post">

    <input type="text" name="id" value="<?php echo $id?>" disabled>
    <input type="text" name="nev" value="<?php echo $nev?>">

    <select name="meret">
        <option value="32" <?php if($meret == "32") echo "selected" ?>>32</option>
        <option value="45" <?php if($meret == "45") echo "selected" ?>>45</option>
        <option value="60" <?php if($meret == "60") echo "selected" ?>>60</option>
    </select><br><br>

    <input type="radio" name="alap" value="paradicsom" <?php if($alap == "paradicsom") echo "checked" ?>> Paradicsomos <br>
    <input type="radio" name="alap" value="tejfol" <?php if($alap == "paradicsom") echo "checked" ?>> Tejfolos <br><br>

    <textarea cols="30" rows="5" name="leiras"><?php echo $leiras ?></textarea> <br>
    <input type="checkbox" name="eros" value="eros" <?php if($eros == "igen") echo "checked" ?>> Eros<br>
    <input type="checkbox" name="hagymas" value="hagymas" <?php if($hagymas == "igen") echo "checked" ?>> Hagymas <br><br><br>
    <input type="submit" value="Modosit">
</form>
</body>
</html>
