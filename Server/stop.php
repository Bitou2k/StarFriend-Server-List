<?php
$MySQL_db = "cabrita_starfriend";
$MySQL_host = "localhost";
$MySQL_username = "cabrita_bot";
$MySQL_password = "1237557321";

$ip = $_GET['ip'];

if (!isset($ip)) {
	$ip = $_SERVER['REMOTE_ADDR'];
}

$SQL = mysql_connect($MySQL_host, $MySQL_username, $MySQL_password);

if (!$SQL) {
	die("Error Sending Data (#4)");
}

mysql_select_db($MySQL_db, $SQL);


$query = sprintf("DELETE FROM servers WHERE ip='%s'",
	mysql_real_escape_string($ip));
	
$result = mysql_query($query);

if ($result) {
	echo "Server Closed!";
} else {
	echo "Error Sending Data (#5)";
}

mysql_close($SQL);
?>