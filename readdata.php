<?php

$hostname = "localhost";
$username = "root";
$password = "";
$database = "teste_esp";

$conn = mysqli_connect($hostname, $username, $password, $database);
if (!$conn) {
    die("Connection failed: " . mysqli_connect_error);
}

// Fetch data from the database
$query = "SELECT TAG FROM teste1";
$result = mysqli_query($conn, $query);

if ($result) {
    // Build an array to store the TAG values
    $tags = array();

    while ($row = mysqli_fetch_assoc($result)) {
        $tags[] = $row["TAG"];
    }

    // Convert the array to a JSON string
    $tags_json = json_encode($tags);

    // Set the appropriate header
    header('Content-Type: application/json');

    // Return the JSON response
    echo $tags_json;
} else {
    echo "Error in database query";
}

mysqli_close($conn);
?>
