// Actualiza esta URL base con la dirección donde se ejecuta tu servidor proxy
const proxyBaseUrl = 'https://DataVoxAPI.azurewebsites.net';

// Modifica la URL de la solicitud fetch para usar el servidor proxy
fetch('${proxyBaseUrl}/api/report/PersonaFisica?username=${username}&password=${password}&identification=${identification}&idType=${idType}&queryType=${queryType}')
    .then(response => response.json())
    .then(data => {
        reporteContainer.innerHTML = ''; // Limpiar reporte anterior

        const reporte = JSON.parse(data.data.reporte);
        reporte.forEach(persona => {
            const personaDiv = document.createElement('div');

            // Crear estructura HTML para mostrar la información de cada persona en el reporte

            reporteContainer.appendChild(personaDiv);
        });
    })
    .catch(error => console.error(error));