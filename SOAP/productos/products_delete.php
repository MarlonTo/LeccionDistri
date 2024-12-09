
<?php
include '../soap_connection.php';
if (isset($_GET['id'])) {
    try {
        $client->DeleteProducts(['products' => ['ProductID' => intval($_GET['id'])]]);
        header("Location: index.php");
    } catch (Exception $e) {
        die("Error al eliminar producto: " . $e->getMessage());
    }
}
?>
