<?php
// Incluye la conexión SOAP
include '../soap_connection.php';

if (!isset($_GET['id'])) {
    die("ID del producto no especificado.");
}

$productID = intval($_GET['id']);
$product = null;

try {
    // Obtiene el producto por ID desde el servicio SOAP
    $response = $client->GetProductsByID(['productID' => $productID]);
    if (isset($response->GetProductsByIDResult->Products[0])) {
        $product = $response->GetProductsByIDResult->Products[0];
    } else {
        die("Producto no encontrado.");
    }
} catch (Exception $e) {
    die("Error al obtener el producto: " . $e->getMessage());
}

// Si se envía el formulario
if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    $productName = $_POST['ProductName'];
    $categoryID = intval($_POST['CategoryID']);
    $unitPrice = floatval($_POST['UnitPrice']);
    $unitsInStock = intval($_POST['UnitsInStock']);

    try {
        // Actualiza el producto en el servicio SOAP
        $updateResponse = $client->UpdateProducts([
            'product' => [
                'ProductID' => $productID,
                'ProductName' => $productName,
                'CategoryID' => $categoryID,
                'UnitPrice' => $unitPrice,
                'UnitsInStock' => $unitsInStock,
            ]
        ]);

        header("Location: products_list.php?message=Producto actualizado correctamente");
        exit;
    } catch (Exception $e) {
        $error = "Error al actualizar el producto: " . $e->getMessage();
    }
}
?>

<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Editar Producto</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css">
</head>
<body>
<div class="container mt-5">
    <h1>Editar Producto</h1>
    <?php if (isset($error)): ?>
        <div class="alert alert-danger"><?= htmlspecialchars($error) ?></div>
    <?php endif; ?>
    <form method="POST">
        <div class="mb-3">
            <label for="ProductName" class="form-label">Nombre del Producto</label>
            <input type="text" class="form-control" id="ProductName" name="ProductName" value="<?= htmlspecialchars($product->ProductName) ?>" required>
        </div>
        <div class="mb-3">
            <label for="CategoryID" class="form-label">ID de Categoría</label>
            <input type="number" class="form-control" id="CategoryID" name="CategoryID" value="<?= htmlspecialchars($product->CategoryID) ?>" required>
        </div>
        <div class="mb-3">
            <label for="UnitPrice" class="form-label">Precio Unitario</label>
            <input type="number" step="0.01" class="form-control" id="UnitPrice" name="UnitPrice" value="<?= htmlspecialchars($product->UnitPrice) ?>" required>
        </div>
        <div class="mb-3">
            <label for="UnitsInStock" class="form-label">Unidades en Stock</label>
            <input type="number" class="form-control" id="UnitsInStock" name="UnitsInStock" value="<?= htmlspecialchars($product->UnitsInStock) ?>" required>
        </div>
        <button type="submit" class="btn btn-primary">Actualizar Producto</button>
        <a href="products_list.php" class="btn btn-secondary">Cancelar</a>
    </form>
</div>
</body>
</html>
