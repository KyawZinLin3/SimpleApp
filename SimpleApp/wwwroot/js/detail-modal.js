function showDetailModal(productId, name, description, created) {
    document.getElementById("detailName").innerText = name;
    document.getElementById("detailDescription").innerText = description;
    document.getElementById("detailCreated").innerText = created;

    document.getElementById("editProductBtn").href = `/Product/Edit/${productId}`;

    var detailModal = new bootstrap.Modal(document.getElementById("detailModal"));
    detailModal.show();
}
