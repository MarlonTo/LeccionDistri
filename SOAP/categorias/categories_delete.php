<?php
$wsdl = "http://localhost:54036/Service1.svc?wsdl";
$client = new SoapClient($wsdl);

if (isset($_GET['id'])) {
    try {
        // Llamada al servicio SOAP para eliminar la categoría, usando el parámetro 'Id'
        $response = $client->DeleteCategoria(['Id' => $_GET['id']]);

        // Redirige a listado.php después de la eliminación exitosa
        header("Location: lista.php");
        exit(); // Asegura que el script se detenga aquí
    } catch (SoapFault $e) {
        // Maneja cualquier error de la llamada SOAP
        echo "Error en la conexión con el servicio web: " . $e->getMessage();
    }
}
?>
