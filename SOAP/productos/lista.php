<?php
// Incluye la conexión SOAP
include '../soap_connection.php';

try {
    // Obtiene los productos desde el servicio SOAP
    $response = $client->Get();

    // Verifica si la respuesta contiene productos
    if (isset($response->GetProductsResult->Products)) {
        $products = $response->GetProductsResult->Products;

        // Asegúrate de que sea un array; de lo contrario, conviértelo en un array
        if (!is_array($products)) {
            $products = [$products];
        }
    } else {
        $products = [];
    }
} catch (Exception $e) {
    die("Error al obtener productos: " . $e->getMessage());
}
?>

<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Lista de Productos</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css">
</head>
<body>
<div class="container mt-5">
    <h1 class="mb-4">Lista de Productos</h1>
    <a href="products_create.php" class="btn btn-primary mb-3">Agregar Nuevo Producto</a>
    <table class="table table-bordered">
        <thead>
        <tr>
            <th>ID</th>
            <th>Nombre</th>
            <th>Categoría</th>
            <th>Precio Unitario</th>
            <th>Unidades en Stock</th>
            <th>Acciones</th>
        </tr>
        </thead>
        <tbody>
        <?php if (!empty($products)): ?>
            <?php foreach ($products as $product): ?>
                <tr>
                    <td><?= htmlspecialchars($product->ProductID) ?></td>
                    <td><?= htmlspecialchars($product->ProductName) ?></td>
                    <td><?= htmlspecialchars($product->CategoryID) ?></td>
                    <td><?= htmlspecialchars($product->UnitPrice) ?></td>
                    <td><?= htmlspecialchars($product->UnitsInStock) ?></td>
                    <td>
                        <a href="products_edit.php?id=<?= htmlspecialchars($product->ProductID) ?>" class="btn btn-warning btn-sm">Editar</a>
                        <a href="products_delete.php?id=<?= htmlspecialchars($product->ProductID) ?>" class="btn btn-danger btn-sm">Eliminar</a>
                    </td>
                </tr>
            <?php endforeach; ?>
        <?php else: ?>
            <tr>
                <td colspan="6" class="text-center">No hay productos disponibles.</td>
            </tr>
        <?php endif; ?>
        </tbody>
    </table>
</div>
</body>
</html>
