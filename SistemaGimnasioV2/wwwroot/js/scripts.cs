window.generateInvoicePdf = (invoices) => {
    const { jsPDF } = window.jspdf;
    const doc = new jsPDF();

    doc.setFontSize(18);
    doc.text("Facturas Generadas", 105, 10, { align: "center" });

    doc.setFontSize(12);
    doc.text("ID", 10, 20);
    doc.text("Cliente", 40, 20);
    doc.text("Fecha", 100, 20);
    doc.text("Monto", 150, 20);

    let y = 30;
    invoices.forEach((invoice, index) => {
        doc.text(invoice.Id.toString(), 10, y);
        doc.text(invoice.Cliente, 40, y);
        doc.text(invoice.Fecha, 100, y);
        doc.text(invoice.Monto, 150, y);
        y += 10;
    });

    doc.save("Facturas.pdf");
};
