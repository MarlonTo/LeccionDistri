<?php
$wsdl = "http://localhost:54036/Service1.svc?wsdl";

try {
    $client = new SoapClient($wsdl);
    echo "Conexión exitosa.";
} catch (Exception $e) {
    die("Error al conectar con el servicio: " . $e->getMessage());
}
?>
