<?php
include '../soap_connection.php';

if ($_SERVER['REQUEST_METHOD'] == 'POST') {
    $newCategory = [
        'CategoryName' => $_POST['CategoryName'],
        'Description' => $_POST['Description']
    ];

    try {
        $result = $client->CreateCategories(['categories' => $newCategory]);
        header("Location: lista.php");
        exit(); // Asegura que el script termine después de la redirección.
    } catch (Exception $e) {
        die("Error al crear categoría: " . $e->getMessage());
    }
}
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Agregar Categoría</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.1/dist/css/bootstrap.min.css" rel="stylesheet">
</head>
<body>
    <div class="container mt-5">
        <h1 class="text-center mb-4">Agregar Categoría</h1>
        <form method="post" class="shadow p-4 rounded">
            <div class="mb-3">
                <label for="CategoryName" class="form-label">Nombre</label>
                <input type="text" id="CategoryName" name="CategoryName" class="form-control" required>
            </div>
            <div class="mb-3">
                <label for="Description" class="form-label">Descripción</label>
                <textarea id="Description" name="Description" class="form-control" rows="3" required></textarea>
            </div>
            <div class="d-flex justify-content-between">
                <a href="lista.php" class="btn btn-secondary">Volver</a>
                <button type="submit" class="btn btn-primary">Guardar</button>
            </div>
        </form>
    </div>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.1/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
