CREATE OR REPLACE VIEW vista_detalle_venta AS
SELECT 
    a.VENTA_ID,
    b.Descripcion,
    a.Cantidad,
    b.Costo_Unitario,
    a.Total
FROM 
    DETALLE_VENTA a
JOIN 
    PRODUCTO b ON a.Producto_id = b.Producto_id;