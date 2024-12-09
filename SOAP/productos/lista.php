<?php
include "../header.php";
// URL del servicio SOAP
$wsdl = "http://localhost:54036/Service1.svc?wsdl";

try {
    // Crear cliente SOAP
    $client = new SoapClient($wsdl);

    // Llamar al método `Get` para obtener productos
    $response = $client->Get();

    // Convertir la respuesta a un formato entendible
    $productos = $response->GetResult->Producto; // Ajusta según el esquema de tu respuesta
} catch (Exception $e) {
    echo "Error: " . $e->getMessage();
    $productos = [];
}
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Listado de Productos</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet">
</head>
<body>
    <div class="container my-5">
        <h1 class="text-center mb-4">Listado de Productos</h1>
        <a href="products_create.php" class="btn btn-primary mb-4">Agregar Producto</a>
        <table class="table table-bordered table-hover">
            <thead class="table-dark">
                <tr>
                    <th>Nombre</th>
                    <th>Categoria Id</th>
                    <th>Precio</th>
                    <th>Stock</th>
                    <th>Acciones</th>
                </tr>
            </thead>
            <tbody>
                <?php if (!empty($productos)): ?>
                    <?php foreach ($productos as $producto): ?>
                        <tr>
                            <td><?= htmlspecialchars($producto->ProductName) ?></td>
                            <td><?= htmlspecialchars($producto->CategoryID) ?></td>
                            <td><?= htmlspecialchars($producto->UnitPrice) ?></td>
                            <td><?= htmlspecialchars($producto->UnitsInStock) ?></td>
                            <td>
                                <a href="products_edit.php?id=<?= $producto->ProductID ?>" class="btn btn-warning btn-sm">Editar</a>
                                <a href="products_delete.php?id=<?= $producto->ProductID ?>" class="btn btn-danger btn-sm">Eliminar</a>

                            </td>
                        </tr>
                    <?php endforeach; ?>
                <?php else: ?>
                    <tr>
                        <td colspan="4" class="text-center">No hay productos disponibles</td>
                    </tr>
                <?php endif; ?>
            </tbody>
        </table>
    </div>
</body>
</html>
