<?php
include '../soap_connection.php';

// Obtén el ID de la categoría desde la URL
if (!isset($_GET['id'])) {
    die("ID de categoría no proporcionado.");
}

$categoryID = (int)$_GET['id'];

try {
    // Llama al servicio SOAP para obtener la categoría por ID
    $response = $client->GetCategoriesByID(['CategoryID' => $categoryID]);

    // Valida la respuesta
    if (isset($response->GetCategoriesByIDResult->Categories)) {
        $category = $response->GetCategoriesByIDResult->Categories;

        // Si la respuesta contiene múltiples categorías, selecciona la primera
        if (is_array($category)) {
            $category = $category[0];
        }

        // Si no se encontró la categoría
        if (!$category) {
            die("Categoría no encontrada.");
        }
    } else {
        die("Categoría no encontrada.");
    }
} catch (Exception $e) {
    die("Error al obtener la categoría: " . $e->getMessage());
}

// Lógica para actualizar la categoría
if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    $categoryName = $_POST['CategoryName'];
    $description = $_POST['Description'];

    try {
        // Llama al servicio SOAP para actualizar la categoría
        $updateResponse = $client->UpdateCategories([
            'CategoryID' => $categoryID,
            'CategoryName' => $categoryName,
            'Description' => $description
        ]);

        // Valida si la actualización fue exitosa
        if ($updateResponse->UpdateCategoryResult) {
            // Redirige al listado de categorías
            header("Location: lista.php?message=Categoría actualizada correctamente");
            exit;
        } else {
            die("Error al actualizar la categoría.");
        }
    } catch (Exception $e) {
        die("Error al actualizar la categoría: " . $e->getMessage());
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
    <form method="post">
        <input type="hidden" name="CategoryID" value="<?= htmlspecialchars($category->CategoryID) ?>">

        <div class="mb-3">
            <label for="CategoryName" class="form-label">Nombre de la Categoría</label>
            <input type="text" class="form-control" id="CategoryName" name="CategoryName"
                   value="<?= htmlspecialchars($category->CategoryName) ?>" required>
        </div>

        <div class="mb-3">
            <label for="Description" class="form-label">Descripción</label>
            <textarea class="form-control" id="Description" name="Description" required><?= htmlspecialchars($category->Description) ?></textarea>
        </div>

        <button type="submit" class="btn btn-primary">Actualizar</button>
        <a href="lista.php" class="btn btn-secondary">Cancelar</a>
    </form>
</div>
</body>
</html>
