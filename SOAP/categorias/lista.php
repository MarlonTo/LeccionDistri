<?php
include "../header.php";
// URL del servicio SOAP
$wsdl = "http://localhost:54036/Service1.svc?wsdl";

try {
    // Crear cliente SOAP
    $client = new SoapClient($wsdl);

    // Llamar al método `GetCategoria` para obtener la categoría
    $response = $client->GetCategoria();

    // Asegurarse de que la respuesta esté en el formato correcto
    $categoria = $response->GetCategoriaResult->Categoria ?? []; // Ajusta según el esquema de tu respuesta
} catch (Exception $e) {
    echo "Error: " . $e->getMessage();
    $categoria = [];
}
?>
<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Listado de Categorías</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet">
</head>
<body>
    <div class="container my-5">
        <h1 class="text-center mb-4">Listado de Categorías</h1>
        <a href="categories_create.php" class="btn btn-primary mb-4">Agregar Categoría</a>
        <table class="table table-bordered table-hover">
            <thead class="table-dark">
                <tr>
                    <th>ID</th>
                    <th>Nombre</th>
                    <th>Descripción</th>
                    <th>Acciones</th>
                </tr>
            </thead>
            <tbody>
                <?php if (!empty($categoria)): ?>
                    <?php foreach ($categoria as $cat): ?>
                        <tr>
                            <td><?= htmlspecialchars($cat->CategoryID) ?></td>
                            <td><?= htmlspecialchars($cat->CategoryName) ?></td>
                            <td><?= htmlspecialchars($cat->Description) ?></td>
                            <td>
                                <a href="categories_edit.php?id=<?= $cat->CategoryID ?>" class="btn btn-warning btn-sm">Editar</a>
                                <a href="categories_delete.php?id=<?= $cat->CategoryID ?>" class="btn btn-danger btn-sm">Eliminar</a>
                            </td>
                        </tr>
                    <?php endforeach; ?>
                <?php else: ?>
                    <tr>
                        <td colspan="4" class="text-center">No hay categorías disponibles</td>
                    </tr>
                <?php endif; ?>
            </tbody>
        </table>
    </div>
</body>
</html>
