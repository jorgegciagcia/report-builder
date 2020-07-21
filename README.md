# report-builder
Esta es la primera versión con los siguientes condicionantes
* Está realizado con bootstrap 4. Es posible que se necesiten modificaciones para adaptarlo a bootstrap 3
* Las librerías utilizadas se encuentran en el archivo .csproj
* dotnet core 3.1

Para probar esta prueba de concepto:
* Abrir el navegador en https://localhost:5001/Report

# Descripción funcional
Este proyecto renderiza objetos html utilizando la librería HtmlDocument de HtmlAgilityPack para dotnet core basándose en una serie de elementos (RenderElement) y la configuración de un archivo json que podréis encontrar en: report-templates/executive-clara-rc.json, a modo de ejemplo práctico

# Características destacables.

* Las propiedades en formato diccionario se promocionan a variables de una manera automática a través de la propiedad Properties. estas propiedades no admiten arrays. Dichas propiedades se utilizan para vincular datos de manera dinámica a través de las clases que heredan de IDataStructure.
* Los datos generados dinámicamente, heredan de IDataStructure y se puede ver una demostración en DataStructure.cs
* No es necesario generar un archivo DataStructure.cs para cada tipo de informe. Si no existen las propiedades no actúa en el renderizado.
* Se pueden crear nuevas clases utilizando herencia o el patrón decorator.
* Si se desea dar de alta una nueva clase, hay que darla de alta en el archivo RenderElement siguiendo el patrón que aparece en la propiedad DerivedClasses. Este es el punto de referencia entre los distintos typeOf definidos en el archivo json del informe y las clases que heredan de RenderElement.
* La clase DecoratedCollapseRenderElement es un ejemplo de patrón de diseño decorador extendiendo el renderizado de CollapseRenderElement.

