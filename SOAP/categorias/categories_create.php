<?php
// Incluye la conexión SOAP
include '../soap_connection.php';

// Maneja el envío del formulario
if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    $categoryName = $_POST['CategoryName'];
    $description = $_POST['Description'];

    try {
        // Crea la categoría como un array asociativo para el SOAP
        $params = [
            'Categories' => [
                'CategoryName' => $categoryName,
                'Description' => $description
            ]
        ];

        // Llama al servicio SOAP
        $response = $client->__soapCall('InsertCategoria', [$params]);

        // Verifica la respuesta
        if ($response) {
            header("Location: lista.php?message=Categoría creada correctamente");
            exit;
        } else {
            $error = "Error: No se pudo crear la categoría.";
        }
    } catch (SoapFault $e) {
        $error = "Error al crear la categoría: " . $e->getMessage();
    }
}
?>

<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Crear Categoría</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css">
</head>
<body>
<div class="container mt-5">
    <h1>Crear Categoría</h1>
    <?php if (isset($error)): ?>
        <div class="alert alert-danger"><?= htmlspecialchars($error) ?></div>
    <?php endif; ?>
    <form method="POST">
        <div class="mb-3">
            <label for="CategoryName" class="form-label">Nombre de la Categoría</label>
            <input type="text" class="form-control" id="CategoryName" name="CategoryName" required>
        </div>
        <div class="mb-3">
            <label for="Description" class="form-label">Descripción</label>
            <input type="text" class="form-control" id="Description" name="Description" required>
        </div>
        <button type="submit" class="btn btn-primary">Crear Categoría</button>
        <a href="lista_categorias.php" class="btn btn-secondary">Cancelar</a>
    </form>
</div>
</body>
</html>
