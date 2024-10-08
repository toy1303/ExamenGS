CREATE OR REPLACE PROCEDURE InsertaVenta(
    p_ClienteId IN NUMBER,
    p_ProductoId IN NUMBER,
    p_Cantidad IN NUMBER
) AS
    v_VentaId NUMBER;
    totalventa NUMBER;
BEGIN
    -- Inserta una nueva venta y captura el VENTA_ID
    INSERT INTO VENTA (VENTA_ID, FECHA, CLIENTE_ID, ESTATUS)
    VALUES (venta_seq.NEXTVAL, SYSDATE, p_ClienteId, 'ACTIVA')
    RETURNING VENTA_ID INTO v_VentaId;
    
    -- Calcula el total de la venta
    SELECT COSTO_UNITARIO * p_Cantidad 
    INTO totalventa
    FROM Producto
    WHERE Producto_id = p_ProductoId;
    
    -- Inserta en la tabla DETALLE_VENTA
    INSERT INTO DETALLE_VENTA (VENTA_ID, PRODUCTO_ID, CANTIDAD, DESCUENTO, TOTAL)
    VALUES (v_VentaId, p_ProductoId, p_Cantidad, 0, totalventa);

END InsertaVenta;

