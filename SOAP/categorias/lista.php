<?php
// Incluye la conexión SOAP
include '../soap_connection.php';

try {
    // Obtiene las categorías desde el servicio SOAP
    $response = $client->GetCategories();

    // Verifica si la respuesta contiene categorías
    if (isset($response->GetCategoriesResult->Categories)) {
        $categories = $response->GetCategoriesResult->Categories;

        // Asegúrate de que sea un array; de lo contrario, conviértelo en un array
        if (!is_array($categories)) {
            $categories = [$categories];
        }
    } else {
        $categories = [];
    }
} catch (Exception $e) {
    die("Error al obtener categorías: " . $e->getMessage());
}
?>

<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Lista de Categorías</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css">
</head>
<body>
<div class="container mt-5">
    <h1 class="mb-4">Lista de Categorías</h1>
    <a href="categories_create.php" class="btn btn-primary mb-3">Agregar Nueva Categoría</a>
    <table class="table table-bordered">
        <thead>
        <tr>
            <th>ID</th>
            <th>Nombre</th>
            <th>Descripción</th>
            <th>Acciones</th>
        </tr>
        </thead>
        <tbody>
        <?php if (!empty($categories)): ?>
            <?php foreach ($categories as $category): ?>
                <tr>
                    <td><?= htmlspecialchars($category->CategoryID) ?></td>
                    <td><?= htmlspecialchars($category->CategoryName) ?></td>
                    <td><?= htmlspecialchars($category->Description) ?></td>
                    <td>
                        <a href="categories_edit.php?id=<?= htmlspecialchars($category->CategoryID) ?>" class="btn btn-warning btn-sm">Editar</a>
                        <a href="categories_delete.php?id=<?= htmlspecialchars($category->CategoryID) ?>" class="btn btn-danger btn-sm">Eliminar</a>
                    </td>
                </tr>
            <?php endforeach; ?>
        <?php else: ?>
            <tr>
                <td colspan="4" class="text-center">No hay categorías disponibles.</td>
            </tr>
        <?php endif; ?>
        </tbody>
    </table>
</div>
</body>
</html>
