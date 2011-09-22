<?php
$MySQL_db = "cabrita_starfriend";
$MySQL_host = "localhost";
$MySQL_username = "cabrita_bot";
$MySQL_password = "1237557321";

$sure = $_GET['sure'];

if (!isset($sure)) {
	die();
}

$SQL = mysql_connect($MySQL_host, $MySQL_username, $MySQL_password);

if (!$SQL) {
	die("Error (#4)");
}

mysql_select_db($MySQL_db, $SQL);

$query = sprintf("DELETE * FROM servers");

$result = mysql_query($query);

if ($result) {
	echo "Success!";
} else {
	echo "Error (#5)";
}

mysql_close($SQL);
?>