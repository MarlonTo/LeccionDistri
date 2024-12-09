<?php
// Incluye la conexión SOAP
$wsdl = "http://localhost:54036/Service1.svc?wsdl";
try {
    $client = new SoapClient($wsdl);
} catch (Exception $e) {
    die("Error al conectarse al servicio SOAP: " . $e->getMessage());
}

// Verifica si se pasó un ID de categoría
if (!isset($_GET['id'])) {
    die("ID de la categoría no especificado.");
}

$CategoryID = intval($_GET['id']);
$category = null;

try {
    $response = $client->GetCategoriaById(['Id' => $CategoryID]); // Usa el método correcto para obtener una categoría
    if (isset($response->GetCategoriaByIdResult)) {
        $category = $response->GetCategoriaByIdResult;
    } else {
        die("Categoría no encontrada en la respuesta del servicio.");
    }
} catch (Exception $e) {
    die("Error al obtener la categoría: " . $e->getMessage());
}

// Si se envía el formulario
if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    // Sanitización y validación de entradas
    $categoryID = $CategoryID;
    $categoryName = trim($_POST['CategoryName']);
    $description = trim($_POST['Description']);

    if (!$categoryName || !$description) {
        $error = "Por favor, ingresa datos válidos en todos los campos.";
    } else {
        try {
            // Actualiza la categoría en el servicio SOAP
            $updateResponse = $client->UpdateCategoria([
                'Categories' => [
                    'CategoryID' => $categoryID,
                    'CategoryName' => $categoryName,
                    'Description' => $description,
                ]
            ]);

            // Redirecciona en caso de éxito
            header("Location: lista_categorias.php?message=Categoría actualizada correctamente");
            exit;
        } catch (Exception $e) {
            $error = "Error al actualizar la categoría: " . $e->getMessage();
        }
    }
}
?>

<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Editar Categoría</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css">
</head>
<body>
<div class="container mt-5">
    <h1>Editar Categoría</h1>
    <?php if (isset($error)): ?>
        <div class="alert alert-danger"><?= htmlspecialchars($error) ?></div>
    <?php endif; ?>
    <form method="POST">
        <div class="mb-3">
            <label for="CategoryName" class="form-label">Nombre de la Categoría</label>
            <input type="text" class="form-control" id="CategoryName" name="CategoryName" 
                   value="<?= htmlspecialchars($category->CategoryName ?? '') ?>" required>
        </div>
        <div class="mb-3">
            <label for="Description" class="form-label">Descripción</label>
            <textarea class="form-control" id="Description" name="Description" rows="3" required><?= htmlspecialchars($category->Description ?? '') ?></textarea>
        </div>
        <button type="submit" class="btn btn-primary">Actualizar Categoría</button>
        <a href="lista_categorias.php" class="btn btn-secondary">Cancelar</a>
    </form>
</div>
</body>
</html>
