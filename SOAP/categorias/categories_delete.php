<?php
include '../soap_connection.php';

if (isset($_GET['id'])) {
    try {
        $client->DeleteCategories(['categories' => ['CategoryID' => intval($_GET['id'])]]);
        header("Location: lista.php");
    } catch (Exception $e) {
        die("Error al eliminar categoría: " . $e->getMessage());
    }
}
?>
