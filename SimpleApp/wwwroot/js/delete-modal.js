function showDeleteModal(productId, productName) {
    document.getElementById("deleteMessage").innerText = `Are you sure you want to delete "${productName}"?`;
    document.getElementById("confirmDeleteBtn").href = `/Product/Delete/${productId}`;

    var deleteModal = new bootstrap.Modal(document.getElementById("deleteModal"));
    deleteModal.show();
}