CREATE OR REPLACE VIEW vw_VentasPorCliente AS
SELECT 
    a.CLAVE AS CLAVE,
    a.NOMBRE AS Nombre,
    a.MAIL AS Mail,
    b.FECHA AS Fechaventa,
    SUM(c.TOTAL) AS TotalVenta,
    c.VENTA_ID 
FROM 
    CLIENTE a
JOIN 
    VENTA b ON a.CLIENTE_ID = b.CLIENTE_ID
LEFT JOIN 
    DETALLE_VENTA c ON b.VENTA_ID = c.VENTA_ID
GROUP BY  
    a.CLAVE, a.NOMBRE, a.MAIL, b.FECHA, c.VENTA_ID;