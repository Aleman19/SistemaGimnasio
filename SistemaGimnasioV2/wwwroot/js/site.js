function generateInvoicePdf(invoiceData) {
    const doc = new jsPDF();
    doc.text("Facturas Generadas", 10, 10);

    let y = 20;
    invoiceData.forEach(invoice => {
        doc.text(`ID: ${invoice.Id}`, 10, y);
        doc.text(`Cliente: ${invoice.Cliente}`, 10, y + 10);
        doc.text(`Fecha: ${invoice.Fecha}`, 10, y + 20);
        doc.text(`Monto: ${invoice.Monto}`, 10, y + 30);
        y += 40;
    });

    doc.save("facturas.pdf");
}
