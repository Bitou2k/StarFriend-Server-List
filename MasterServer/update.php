<?php
$MySQL_db = "cabrita_starfriend";
$MySQL_host = "localhost";
$MySQL_username = "cabrita_bot";
$MySQL_password = "1237557321";

$version = $_GET['version'];
$delay = $_GET['delay'];
$players = $_GET['players'];
$ip = $_GET['ip'];
$description = $_GET['description'];

if (!isset($ip)) {
	$ip = $_SERVER['REMOTE_ADDR'];
}

if (!isset($description) or strlen($description) <= 0) {
	$description = "No Description";
}

if (!isset($version) or !isset($delay) or !isset($players) or !isset($ip)) {
	die("Error Sending Data (#1)");
}

if (!is_numeric($players)) {
	die("Error Sending Data (#2)");
}

if (!is_numeric($delay)) {
	die("Error Sending Data (#3)");
}

if (strlen($description) > 20) {
	die("Error Sending Data (#6)");
}

if (strlen($players) > 2) {
	die("Error Sending Data (#7)");
}

$SQL = mysql_connect($MySQL_host, $MySQL_username, $MySQL_password);

if (!$SQL) {
	die("Error Sending Data (#4)");
}

mysql_select_db($MySQL_db, $SQL);

$query = sprintf("SELECT id FROM servers WHERE ip='%s'",
	mysql_real_escape_string($ip));
	
$result = mysql_query($query);

if (mysql_num_rows($result) == 0) {
	$query = sprintf("REPLACE INTO servers(version, maxdelay, players, ip, description) 
		VALUES('%s', '%s', '%s', '%s', '%s')",
		mysql_real_escape_string($version),
		$delay,
		$players,
		mysql_real_escape_string($ip),
		mysql_real_escape_string($description));
} else {
	$query = sprintf("UPDATE servers SET version = '%s', maxdelay = '%s',
		players = '%s', ip = '%s', description = '%s' WHERE ip = '%s'",
		mysql_real_escape_string($version),
		$delay,
		$players,
		mysql_real_escape_string($ip),
		mysql_real_escape_string($description),
		mysql_real_escape_string($ip));
}
unset($result);
	
$result = mysql_query($query);

if ($result) {
	echo "Server Data Received!";
} else {
	echo "Error Sending Data (#5)";
}

mysql_close($SQL);
?>