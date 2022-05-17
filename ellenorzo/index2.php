<?php
$connect = mysqli_connect("localhost", "root", "", "urlapok") or die("Ihh");
$id = $_GET['id'];

$query = mysqli_query($connect, "SELECT * FROM urlapok WHERE id='$id'");

while ($row = mysqli_fetch_assoc($query)){
    $id = $row['id'];
    $nev = $row['nev'];
    $cim = $row['cim'];
}

?>

<html>
<body>
<form action="index3.php?id=<?php echo $id?>" method="post">
    <input type="radio" name="radiocsoport" value="auto"> Auto <br>
    <input type="radio" name="radiocsoport" value="motor"> Motor <br>
    <input type="radio" name="radiocsoport" value="busz"> Busz <br>
    <input type="radio" name="radiocsoport" value="gyalog"> Gyalog <br><br>

    <input type="checkbox" name="feltetel" value="fizet"> Elfogadom a felteteleket <br>
    <input type="checkbox" name="hirlevel" value="nemfizet"> Feliratkozom a hirlevelre <br><br><br>

    <select name="etkezes">
        <option value="reggel">Reggel</option>
        <option value="delben">Delben</option>
        <option value="este">Este</option>
        <option value="minden">Minden etkezes</option>
    </select><br><br>

    <textarea cols="30" rows="5" name="leiras"></textarea>
</form>
</body>
</html>
