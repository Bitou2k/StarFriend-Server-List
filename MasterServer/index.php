<?php
$MySQL_db = "cabrita_starfriend";
$MySQL_host = "localhost";
$MySQL_username = "cabrita_bot";
$MySQL_password = "1237557321";

$client = $_GET['client'];
?><center>
<h1>Starfriend Server List</h1>
<table border="1" width="100%" align="center">
<tr>
<th>Version</th>
<th>Max Latency</th>
<th>Players</th>
<th>IP Address</th>
<th>Description</th>
<th>Last Update</th>
<?php 
if (isset($client)) {
	echo "<th>Latency</th>";
}

echo "</tr>";

$SQL = mysql_connect($MySQL_host, $MySQL_username, $MySQL_password);

if (!$SQL) {
	die("<b>Error Connecting to Database</b>");
}

mysql_select_db($MySQL_db, $SQL);

$query = "SELECT * FROM servers ORDER BY started DESC";
	
$result = mysql_query($query);

if (!$result) {
	die("Error Fetching Information.");
}

$num_rows = mysql_num_rows($result);

for ($i = 0; $i < $num_rows; $i++) {
	mysql_data_seek($result, $i);
	$row = mysql_fetch_row($result);
	echo "<tr align='center'>";
	echo "<td>".$row[1]."</td>";
	echo "<td>".$row[2]."</td>";
	echo "<td>".$row[3]."</td>";
	echo "<td id='ip".$i."'>".$row[4]."</td>";
	echo "<td>".$row[5]."</td>";
	echo "<td>".$row[6]."</td>";
	if (isset($client)) {
		echo "<td id='latency".$i."'>0</td>";
	}
	echo "</tr>";
}

mysql_close($SQL);
?>
</table>
</center>