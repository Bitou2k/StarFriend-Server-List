<style type="text/css">
<!--
body {
	background: url("planet.jpg") no-repeat fixed center top #070706;
    color: #2B2C26;
}
.style1 {color: #FFFFFF}
body,td,th {
	color: #FFFFFF;
}
-->
</style><center>
<?php
$MySQL_db = "cabrita_starfriend";
$MySQL_host = "localhost";
$MySQL_username = "cabrita_bot";
$MySQL_password = "1237557321";

$client = $_GET['client'];
?><table width="100%" height="100%" border="0" style="background: rgba(0, 0, 0, 0.5);">
  <tr>
    <td align="center" valign="top"><h1 class="style1">Starfriend Server List</h1>
      <table width="950" border="1" align="center" cellpadding="0" cellspacing="0">
        <tr>
          <th id='version'>Version</th>
          <th id='maxlatency'>Max Latency</th>
          <th id='players'>Players</th>
          <th id='ipaddress'>IP Address</th>
          <th id='description'>Description</th>
          <th id='lastupdate'>Last Update</th>
<?php 
if (isset($client)) {
	echo "<th id='latency'>Latency</th>";
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
      </table></td>
  </tr>
</table>
</center>
