<?php
// Incluye la conexión SOAP
include '../soap_connection.php';

// Maneja el envío del formulario
if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    $productName = $_POST['ProductName'];
    $categoryID = intval($_POST['CategoryID']);
    $unitPrice = floatval($_POST['UnitPrice']);
    $unitsInStock = intval($_POST['UnitsInStock']);

    try {
        // Crea un objeto Products para enviar al servicio SOAP
        $product = new stdClass();
        $product->ProductName = $productName;
        $product->CategoryID = $categoryID;
        $product->UnitPrice = $unitPrice;
        $product->UnitsInStock = $unitsInStock;

        // Envía los datos al servicio SOAP para crear el producto
        $response = $client->CreateProducts($product);

        // Redirige después de crear el producto
        header("Location: products_list.php?message=Producto creado correctamente");
        exit;
    } catch (Exception $e) {
        $error = "Error al crear el producto: " . $e->getMessage();
    }
}
?>

<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Crear Producto</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css">
</head>
<body>
<div class="container mt-5">
    <h1>Crear Producto</h1>
    <?php if (isset($error)): ?>
        <div class="alert alert-danger"><?= htmlspecialchars($error) ?></div>
    <?php endif; ?>
    <form method="POST">
        <div class="mb-3">
            <label for="ProductName" class="form-label">Nombre del Producto</label>
            <input type="text" class="form-control" id="ProductName" name="ProductName" required>
        </div>
        <div class="mb-3">
            <label for="CategoryID" class="form-label">ID de Categoría</label>
            <input type="number" class="form-control" id="CategoryID" name="CategoryID" required>
        </div>
        <div class="mb-3">
            <label for="UnitPrice" class="form-label">Precio Unitario</label>
            <input type="number" step="0.01" class="form-control" id="UnitPrice" name="UnitPrice" required>
        </div>
        <div class="mb-3">
            <label for="UnitsInStock" class="form-label">Unidades en Stock</label>
            <input type="number" class="form-control" id="UnitsInStock" name="UnitsInStock" required>
        </div>
        <button type="submit" class="btn btn-primary">Crear Producto</button>
        <a href="lista.php" class="btn btn-secondary">Cancelar</a>
    </form>
</div>
</body>
</html>
